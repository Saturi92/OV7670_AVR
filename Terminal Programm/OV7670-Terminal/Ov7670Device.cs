using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace OV7670_Terminal
{
    //TODO: einfügen eines abfangens, wenn zu wenig Bytes per Linie gesendet werden.

    public enum EnumResolutionFormat { VGA, CIF, QVGA, QCIF, NotSelected, manually };
    public enum EnumColorFormat { YUV, BayerRaw, ProcessedBayerRaw, NotSelected, RGB444, RGB565, RGB555}
    public enum EnumTestPatter { NoTestOutput, Shifting1,EightBarColorBar, FadeToGray}
    public enum EnumDspColorBar { enabled, disabled}

    /// <summary>
    /// Eventargs which contain the address and the value of an Register
    /// </summary>
    public class RegisterEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address">the address of a Register</param>
        /// <param name="value">the value of a Register</param>
        public RegisterEventArgs(RegisterValue address, RegisterValue value)
        {
            Address = address;
            Value = value;
        }

        /// <summary>
        /// Address of the Register
        /// </summary>
        public RegisterValue Address { get; set; }
        /// <summary>
        /// Value of the Register
        /// </summary>
        public RegisterValue Value { get; set; }
    }

    public class ComTransmissionEventArgs : EventArgs
    {
       public Queue<byte> TransmittedData { get; set; }
    }

    public class PictureFormatEventArgs:EventArgs
    {
        public int xRes { get; set; }
        public int yRes { get; set; }
        public int BytesPerPixel { get; set; }

        public PictureFormatEventArgs(int nxRes, int nyRes, int nBytesPerPixel)
        {
            xRes = nxRes;
            yRes = nyRes;
            BytesPerPixel = nBytesPerPixel;
        }
    }

    public class ErrorEventArgs : EventArgs
    {
        public ErrorEventArgs()
        {
            
        }

        public ErrorEventArgs(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

    }

    class Ov7670Device
    {
        //Events & Eventhandler
        public event EventHandler DataIsProceeded;
        protected virtual void OnDataIsProceeded()
        {
            if(DataIsProceeded != null)
            {
                DataIsProceeded(this, EventArgs.Empty);
            }
        }
        
        public event EventHandler PictureRowReceived;
        public virtual void OnPictureRowReceived()
        {
            if (PictureRowReceived != null)
            {
                PictureRowReceived(this, EventArgs.Empty);
            }
        }

        public event EventHandler SccbRegisterWasChanged;
        public virtual void OnSccbRegisterWasChanged()
        {
            if (SccbRegisterWasChanged != null)
            {
                SccbRegisterWasChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler ProgrammStatusChanged;
        public virtual void OnProgrammStatusChanged()
        {
            if (ProgrammStatusChanged != null)
            {
                ProgrammStatusChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler<PictureFormatEventArgs> PictureFormatChanged;
        public virtual void OnPictureFormatChanged(PictureFormatEventArgs e)
        {
            if (PictureFormatChanged != null)
            {
               PictureFormatChanged(this,e);
            }
        }

        public event EventHandler<RegisterEventArgs> RegisterWriteComplete; 
        public virtual void OnRegisterWrite(RegisterEventArgs e)
        {
            EventHandler<RegisterEventArgs> handler = RegisterWriteComplete;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<ComTransmissionEventArgs> RxDataSnifferComplete;
        public virtual void OnRecDataSnifferComplete(ComTransmissionEventArgs e)
        {
            EventHandler<ComTransmissionEventArgs> handler = RxDataSnifferComplete;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<ComTransmissionEventArgs> txDataSnifferComplete;
        public virtual void OnTxDataSnifferComplete(ComTransmissionEventArgs e)
        {
            EventHandler<ComTransmissionEventArgs> handler = txDataSnifferComplete;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<ErrorEventArgs> ErrorOccured;
        public virtual void OnErrorOccured(ErrorEventArgs e)
        {
           EventHandler<ErrorEventArgs> handler = ErrorOccured;
            if (handler != null)
            {
                handler(this, e);
            }
        }



        public event EventHandler PictureComplete;
        protected virtual void OnPictureComplete()
        {
            PictureComplete?.Invoke(this, EventArgs.Empty);
        }
        

        //Variables
        private EnumResolutionFormat _outPutResolutionFormat = EnumResolutionFormat.NotSelected;
        private EnumColorFormat _outPutColorFormat = EnumColorFormat.NotSelected;
        private EnumTestPatter _appliedTestPattern = EnumTestPatter.NoTestOutput;
        private EnumDspColorBar _dspColorBar = EnumDspColorBar.disabled;
        private Queue<byte> _receivedData = new Queue<byte>();
        private readonly SerialPort _comPort;
        private Stream _myStream = new MemoryStream();
        public ImageFile _picture;
        static readonly int numberOfRegister = 0xCA;
        public SccbRegister[] SccbRegisterList = new SccbRegister[numberOfRegister];    //Register list of all Register of the OV7670
        public byte[] StatusRegisterList= new byte[13];   //List of Register Addresses which are important for the mode of the OV7670

        private int _rowCount;  //Variable that counts the received rows until a complete Image is received
        private Queue<SccbRegister> _RegisterToWrite = new Queue<SccbRegister>();

        public RegisterEventArgs WrittenRegister = new RegisterEventArgs(null,null);

        //Constructor
        public Ov7670Device()
        {
            //Programstatus
            Programstatus = -1;
            ErrorCode = 0;
            //initiate the Register
            RegisterValue defaultValue = new RegisterValue();
            defaultValue.setByte(0x00); //initiate value 0 for each register
            for (int i = 0; i < SccbRegisterList.Length; i++) //Create Setting Register with the Addresses from 0 to the Amount of the Registers
            {
                SccbRegisterList[i] = new SccbRegister((byte)i,defaultValue);
            }

            //initialize the COMPort
            _comPort = new SerialPort();
            _comPort.DataReceived += ComPortDataReceived;

            //initiate Variables
            _rowCount = 0;

            _picture = new ImageFile();
            rowRepeatCounter = 0;

            //Statusregister. This register are relevant for the general adjustment of the sensor. These register addresses will bre read when Camera Status is requested
            StatusRegisterList[0] = 0x0C;   
            StatusRegisterList[1] = 0x12;
            StatusRegisterList[2] = 0x1C;
            StatusRegisterList[3] = 0x1D;
            StatusRegisterList[4] = 0x3A;
            StatusRegisterList[5] = 0x3D;
            StatusRegisterList[6] = 0x3E;
            StatusRegisterList[7] = 0x40;   //COM15 - RGB444 Mode
            StatusRegisterList[8] = 0x42;
            StatusRegisterList[9] = 0x70;
            StatusRegisterList[10] = 0x71;
            StatusRegisterList[11] = 0x0A;
            StatusRegisterList[12] = 0x0B;
        }

        //Variables for Datacollection (just stats)
        public int rowRepeatCounter;

        //Properties
        private int _programmstatus;
        public int Programstatus
        {
            get { return _programmstatus;}
            set
            {
                _programmstatus = value;
                OnProgrammStatusChanged();
            }
        }

        public int ReadCounter { get; set; }
        public byte ErrorCode { get; set; }
        public EnumResolutionFormat OutputResolution { get { return _outPutResolutionFormat; } }
        public EnumColorFormat OutputColorFormat { get { return this._outPutColorFormat; } }
        public int AmountRegister
        {
            get { return numberOfRegister; }
        }
        

        //Methods
        void ComPortDataReceived(object s, SerialDataReceivedEventArgs e)
        {
            var data = new byte[_comPort.BytesToRead];
            _comPort.Read(data, 0, data.Length);
            Queue<byte> receivedProtocoll = new Queue<byte>();
            foreach (var b in data.ToList())
            {
                _receivedData.Enqueue(b);
                receivedProtocoll.Enqueue(b);
            }
            //data.ToList().ForEach(b => _receivedData.Enqueue(b));
            ComTransmissionEventArgs sniffedArgs = new ComTransmissionEventArgs();
            sniffedArgs.TransmittedData = receivedProtocoll;
            OnRecDataSnifferComplete(sniffedArgs);
            ProcessData();
        }

        private void ProcessData()
        {
            switch (Programstatus)
            {
                case 1: //Read Register: Expected value: 1 Byte
                    ReceiveReadRegister();
                    Programstatus = -1;
                    break;
                case 2:
                    BuildPicture();
                    break;
                case 3:
                    BuildPictureRbyR();
                    break;
                case 4: //send yRes to Camera (followed after xRes is send to camera)
                    var statusCode = ReceiveStatusCode();
                    if (statusCode == 4)
                    {
                        byte[] HeightSplit = getHighAndLowByte(_picture.ResolutionY);
                        Programstatus = 5;

                        var myBuffer = new byte[5];
                        myBuffer[0] = 0x05;
                        myBuffer[1] = HeightSplit[0];
                        myBuffer[2] = HeightSplit[1];
                        myBuffer[3] = 13;
                        myBuffer[4] = 10;
                        this.SendCommand(myBuffer);
                    }
                    else
                    {
                        OnErrorOccured(new ErrorEventArgs(99, "Statuscode Expected: 4, received: " + statusCode));
                        Programstatus = -1;
                    }
                    break;
                case 5: //send Bytes per Pixel to Camera (followed after send yRes to Camera)
                    var statusCode2 = ReceiveStatusCode();
                    if (statusCode2 == 5)
                    {
                        Programstatus = 6;

                        var myBuffer = new byte[4];
                        myBuffer[0] = 0x06;
                        myBuffer[1] = (byte) _picture.BytesPerPixel;
                        myBuffer[2] = 13;
                        myBuffer[3] = 10;
                        this.SendCommand(myBuffer);
                        OnDataIsProceeded();
                    }
                    else
                    {
                        OnErrorOccured(new ErrorEventArgs(99, "Statuscode Expected: 5, received: " + statusCode2));
                        Programstatus = -1;
                    }
                    break;
                case 6: //Complete sync was done
                    var statusCode3 = ReceiveStatusCode();
                    if (ReceiveStatusCode() == 6)
                    {
                        Programstatus = -1;
                    }
                    else
                    {
                        OnErrorOccured(new ErrorEventArgs(99, "Statuscode Expected: 6, received: " + statusCode3));
                        Programstatus = -1;
                    }

                    break;
                case 8: //initialize camera
                    ReceiveErrorCode();
                    //set resolution to QVGA
                    //Programstatus = 53;
                    resetReceivedData();
                    writeRegister(0x12, 0x16);
                    ReceiveErrorCode();
                    OnRegisterWrite(WrittenRegister);
                    writeRegister(0x40, 0x10);
                    ReceiveErrorCode();
                    OnRegisterWrite(WrittenRegister);
                    Programstatus = -1;
                    break;
                case 10:
                    ReceiveReadRegister();
                    break;
                case 11:
                    ReceiveErrorCode();
                    break;
                case 51: //read one register
                    ReceiveReadRegister();
                    break;
                case 52: //read for change register
                    ReceiveReadRegister();
                    break;
                case 53: //write one register
                    ReceiveErrorCode();
                    OnRegisterWrite(WrittenRegister);
                    break;
                case 60:
                    ReceiveReadRegister();
                    break;
                    //functions for Testpurpose
                case 90:
                    BuildPicture();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// This function read two Bytes from the buffer. 1: Register Address 2:Register value
        /// Because this funciton is used in more than one Programstatus it is outsourced of the switch case statement
        /// </summary>
        private void ReceiveReadRegister ()
        {
            RegisterValue tempValue = new RegisterValue();
            if (_receivedData.Count >= 2)
            {
                var Address = new byte();
                Address=_receivedData.Dequeue();
                var readValue = new byte();
                readValue= _receivedData.Dequeue();

                tempValue.setByte(readValue);
                if (Address <= SccbRegisterList.Length - 1)
                {
                    SccbRegisterList[Address].Value=tempValue;
                    OnDataIsProceeded();
                }
                else
                {
                    OnErrorOccured(new ErrorEventArgs(99,"Die empfangene Addresse des Registers existiert nicht"));
                }
            }
        }
        private void ReceiveErrorCode ()
        {
            var newErrorCode = new byte();
            if (_receivedData.Count >= 1)
            {
                newErrorCode = _receivedData.Dequeue();
                if (newErrorCode != 0)
                {
                    OnErrorOccured(new ErrorEventArgs(newErrorCode, "Fehler auf uC"));
                }
                ErrorCode = newErrorCode;
                OnDataIsProceeded();
            }
        }

        private int ReceiveStatusCode()
        {
            var statusCode = new byte();
            if (_receivedData.Count >= 1)
            {
                statusCode = _receivedData.Dequeue();
                OnDataIsProceeded();
            }

            return statusCode;
        }
        private PictureRow BuildRow()
        {

            PictureRow _newPictureRow = new PictureRow(_picture.ResolutionX, OutputColorFormat);

            //Read one Line from stream
            for (int i = 0; i < _picture.ResolutionX; i++)
            {
                //At this Point we need to different between the Colorformats
                switch (OutputColorFormat)
                {
                    case EnumColorFormat.YUV: //TODO: Complete yuv build (for the moment just luminance is written)
                        var pixelByte = new byte[2];
                        pixelByte[0] = _receivedData.Dequeue();
                        pixelByte[1] = _receivedData.Dequeue();
                        var pixelForYuv = Color.FromArgb((int)pixelByte[0], (int)pixelByte[0], (int)pixelByte[0]); //Add in each Colorchannel the same Y Value to get a grey Color
                        _newPictureRow.AddPixel(pixelForYuv);

                        break;
                    case EnumColorFormat.BayerRaw:
                        break;
                    case EnumColorFormat.ProcessedBayerRaw:
                        var pixelBytes = new byte[3];
                        pixelBytes[0] = _receivedData.Dequeue();
                        pixelBytes[1] = _receivedData.Dequeue();
                        pixelBytes[2] = _receivedData.Dequeue();
                        //TODO: make a differntiation between the different color formats of the image and check if Color Format is known otherwise throw exception
                        var pixel = Color.FromArgb((int)pixelBytes[0], (int)pixelBytes[1], (int)pixelBytes[2]);
                        _newPictureRow.AddPixel(pixel);
                        break;
                    case EnumColorFormat.RGB444:   //RGB444:8G8R 8G8B
                                                //TODO: include colorformat: RGB444 4:2:2
                        break;
                    case EnumColorFormat.RGB565:
                        var pixelBytesRGB565 = new byte[2];
                        pixelBytesRGB565[0] = _receivedData.Dequeue();
                        pixelBytesRGB565[1] = _receivedData.Dequeue();
                        var _newColorRGB565 = new ColorFormat();
                        _newColorRGB565.ColorRgb565Value = pixelBytesRGB565;
                        _newPictureRow.AddPixel(_newColorRGB565.ColorRgb888);
                        break;
                    case EnumColorFormat.RGB555:
                        //TODO: Add ColorFormat (COM15)
                        break;
                    case EnumColorFormat.NotSelected:
                        break;

                }

            }

            return _newPictureRow;
        }

        private void BuildPicture()
        {
            if (_receivedData.Count >= ((_picture.BytesPerPixel * _picture.ResolutionX) + 2))
            {
                var _newPictureRow = BuildRow();
                _picture.AddLineToImage(_newPictureRow, _rowCount);
                OnPictureRowReceived();
                _rowCount++;
                //check if last Line is read
                if (_rowCount == (_picture.ResolutionY-1))
                {
                    Programstatus = -1;
                    OnPictureComplete();
                }
            }
        }

        private void BuildPictureRbyR()
        {
            //TODO: Add other COlorformats and add a decision which one is to choose
            //wait until the whole Line is completed
            if (_receivedData.Count >= ((_picture.BytesPerPixel * _picture.ResolutionX) + 2))
            {
                var _newPictureRow = BuildRow();
                //check if the next two Bytes are CR+LF (13,10)
                var crCheck = _receivedData.Dequeue();
                var lfCheck = _receivedData.Dequeue();
                //if row is complete, add Line to Image
                if ((crCheck == 13) && (lfCheck == 10))
                {
                    _picture.AddLineToImage(_newPictureRow, _rowCount);
                    OnPictureRowReceived();
                    _rowCount++;
                    //check if last Line is read
                    if (_rowCount >= _picture.ResolutionY)
                    {
                        Programstatus = -1;
                    }
                    //send Acknoledge
                    sendLineAccept();
                }
                else
                {
                    rowRepeatCounter++;
                    _receivedData.Clear();
                    sendLineRepeat();
                }
            }
        }

        private void SendCommand (byte[] commandBytes)
        {
            _comPort.Write(commandBytes, 0, commandBytes.Length);
            Queue<byte> sentBytes = new Queue<byte>();
            foreach (var c in commandBytes)
            {
                sentBytes.Enqueue(c);
            }
            ComTransmissionEventArgs args = new ComTransmissionEventArgs();
            args.TransmittedData = sentBytes;
            OnTxDataSnifferComplete(args);
        }

        public int getRowCount()
        {
            return _rowCount;
        }

        //Sync methods
        /// <summary>
        /// the relevant Register of the Registerlist 0x12 will be masked and the _ouPutResolutionFormat is set.
        /// Note that this function do not get refreshed data from the hardware camera. It is just an internal object update class.
        /// To be sure to get the latest status of the camera you need to read the 0x12 register from the camera
        /// </summary>
        public void UpdateOutputFormat()
        {
            Byte ColorFormat = this.getRegisterValue(0x12).getByte();
            ColorFormat = (Byte)(ColorFormat & (Byte)0x38);
            switch (ColorFormat)
            {
                case 0:
                    _outPutResolutionFormat = EnumResolutionFormat.VGA;
                    _picture.ResolutionX = 640;
                    _picture.ResolutionY = 480;
                    break;
                    //TODO: add other resolutions
                case 8:
                    _outPutResolutionFormat = EnumResolutionFormat.QCIF;
                    _picture.ResolutionX = 176;
                    _picture.ResolutionY = 144;
                    break;
                case 16:
                    _outPutResolutionFormat = EnumResolutionFormat.QVGA;
                    _picture.ResolutionX = 313;
                    _picture.ResolutionY = 240;
                    break;
                case 32:
                    _outPutResolutionFormat = EnumResolutionFormat.CIF;
                    _picture.ResolutionX = 352;
                    _picture.ResolutionY = 288;
                    break;
                default:
                    _outPutResolutionFormat = EnumResolutionFormat.NotSelected;
                    break;
            }
            PictureFormatEventArgs eArgs = new PictureFormatEventArgs(_picture.ResolutionX,_picture.ResolutionY,_picture.BytesPerPixel);
            OnPictureFormatChanged(eArgs);
        }
        /// <summary>
        /// the relevant Register 0x12 for the color format will be masked and the _outPutColorFormat is set.
        /// Note that this function do not get refreshed data from the hardware camera. It is just an internal object update class.
        /// To be sure to get the latest status of the camera you need to read the 0x12 register from the camera
        /// </summary>
        public void updateColorFormat()
        {
            Byte ColorFormat = this.getRegisterValue(0x12).getByte();
            ColorFormat = (Byte)(ColorFormat & (Byte)0x05);
            switch (ColorFormat)
            {
                //TODO: add other color formats
                case 0:
                    _outPutColorFormat = EnumColorFormat.YUV;
                    _picture.BytesPerPixel = 2; //TODO: That is wrong, but it is set to 2 to get the Y channel of each Pixel for test Purpose
                    break;
                case 1:
                    _outPutColorFormat = EnumColorFormat.BayerRaw;
                    _picture.BytesPerPixel = 1;
                    break;
                case 4:
                    //Since there are different Formats for RGB444, we need to distinguish here more:
                    var RgbFormat=this.getRegisterValue(0x40).getByte() & 0x30;  //COM15
                    switch (RgbFormat)
                    {
                        case 16:
                            _outPutColorFormat = EnumColorFormat.RGB565;
                            _picture.BytesPerPixel = 2;
                            break;
                        case 48:
                            _outPutColorFormat = EnumColorFormat.RGB555;
                            _picture.BytesPerPixel = 2;
                            break;
                        default:
                            _outPutColorFormat = EnumColorFormat.RGB444;
                            _picture.BytesPerPixel = 2; //TODO: implement the correct function: 1st Pixel has G and R information, 2nd G in B information GRB4:2:2
                            break;
                    }
                    break;
                case 5:
                    _outPutColorFormat = EnumColorFormat.ProcessedBayerRaw;
                    _picture.BytesPerPixel = 3;
                    break;
                default:
                    _outPutColorFormat = EnumColorFormat.NotSelected;
                    break;
            }
            PictureFormatEventArgs eArgs = new PictureFormatEventArgs(_picture.ResolutionX, _picture.ResolutionY, _picture.BytesPerPixel);
            OnPictureFormatChanged(eArgs);
        }

        /// <summary>
        /// With this function, the colorformat can be set manually without reading the registers.
        /// Caution! This operations should be performed after the registers are read, because the
        /// register read will overwrite it.
        /// </summary>
        /// <param name="_setColorformat"></param>
        public void SetColorFormatManualy(EnumColorFormat _setColorformat)
        {
            _outPutColorFormat = _setColorformat;
        }

        /// <summary>
        /// With this function, the resolutionformat can be set manually without reading the registers.
        /// Caution! This operations should be performed after the registers are read, because the
        /// register read will overwrite it.
        /// </summary>
        /// <param name="_setResolutionFormat"></param>
        public void SetResolutionFormatManually(EnumResolutionFormat _setResolutionFormat)
        {
            _outPutResolutionFormat = _setResolutionFormat;
        }

        /// <summary>
        /// This function checks, which Testpattern is applied to the camera. The Register 0x70 and 0x71 needs to be evaluated for this:
        /// 0x70[7],0x71[7]: (0,0) no test output, (0,1) Shifting1 , (1,0) 8-Bar Colorbar, (1,1) Fade to gray color bar
        /// </summary>
        private void updateTestPattern()
        {
            //get latest register value
            byte TestPatter = 0;
            byte TestPattern1 = this.getRegisterValue(0x70).getByte();
            byte TestPattern2 = this.getRegisterValue(0x71).getByte();
            //build testpattern: 0x70[7],0x71[7]: (0,0) no test output, (0,1) Shifting1 , (1,0) 8-Bar Colorbar, (1,1) Fade to gray color bar

            TestPatter = (byte) ((TestPattern1 >> 6) & 0x02);
            TestPatter = (byte) (TestPatter | (byte) ((TestPattern2 >> 7) & 0x01));
            switch (TestPatter)
            {
                case 0: _appliedTestPattern = EnumTestPatter.NoTestOutput;
                    break;
                case 1: _appliedTestPattern = EnumTestPatter.Shifting1;
                    break;
                case 2: _appliedTestPattern = EnumTestPatter.EightBarColorBar;
                    break;
                case 3: _appliedTestPattern = EnumTestPatter.FadeToGray;
                    break;
                default: _appliedTestPattern = EnumTestPatter.NoTestOutput;
                    break;
            }
        }

        /// <summary>
        /// This function checks the necessary bit of the register 0x42 and determines if the ColorBar of the DSP is enabled or disabled
        /// </summary>
        private void updateDspColorBar()
        {
            byte dspColorBar = this.getRegisterValue(0x42).getByte();
            dspColorBar = (byte) ((dspColorBar >> 3) & 0x01);
            if (dspColorBar == 0x01)
                _dspColorBar = EnumDspColorBar.enabled;
            else
                _dspColorBar = EnumDspColorBar.disabled;
        }

        /// <summary>
        /// This function sends a command to the camera, which will perform the initialisation of the camera again.
        /// </summary>
        public void initializeCamera()
        {
            Byte[] myBuffer = new Byte[3];
            myBuffer[0] = 0x08;
            myBuffer[1] = 13;
            myBuffer[2] = 10;
            SendCommand(myBuffer);
        }

        /// <summary>
        /// This function starts a sequence of a communication between the Terminal and the Camera to
        /// synch the width, the height and the Bytes per Pixels for the read out of an Image.
        /// All in all the programmstati 4, 5 and 6 will be exectued.
        /// 
        /// </summary>
        public void startSendResColFormatToCamera()
        {
            byte[] widthSplit = getHighAndLowByte(_picture.ResolutionX);
            Programstatus = 4;

            var myBuffer = new byte[5];
            myBuffer[0] = 0x04;
            myBuffer[1] = widthSplit[0];
            myBuffer[2] = widthSplit[1];
            myBuffer[3] = 13;
            myBuffer[4] = 10;
            this.SendCommand(myBuffer);
        }
        /// <summary>
        /// this function performs all for syncronisation necessary communication between Camera and Terminal
        /// </summary>
        public void syncBetweenCameraAndTerminal()
        {
            UpdateOutputFormat();
            updateColorFormat();
            startSendResColFormatToCamera();
        }

        /// <summary>
        /// This function does the following:
        /// -reset the RowCount of the OV7670 device
        /// - resets the RowCount of the image
        /// - sets the resoltion of the _picture which is afterwards filled
        /// </summary>
        public void UpdatePicture()
        {
            _rowCount = 0;
            _picture.ResetRowCounter();
            if (OutputResolution != EnumResolutionFormat.NotSelected)
                _picture.Image = new Bitmap(_picture.ResolutionX,_picture.ResolutionY);
            else
            {
                MessageBox.Show("Bild Format konnte nicht gesetzt werden");
            }
        }


        public bool readRegister (byte registerAddress)
        {
            Byte[] myBuffer = new Byte[4];
            myBuffer[0] = 0x01;
            myBuffer[1] = registerAddress;
            myBuffer[2] = 13;
            myBuffer[3] = 10;
            SendCommand(myBuffer);
            return true;
        }
        public bool writeRegister (byte registerAddress, byte data)
            {
            Byte[] myBuffer = new byte[5];
            myBuffer[0] = 0x02;
            myBuffer[1] = registerAddress;
            myBuffer[2] = data;
            myBuffer[3] = 13;
            myBuffer[4] = 10;
            SendCommand(myBuffer);
            WrittenRegister.Value = new RegisterValue();
            WrittenRegister.Address= new RegisterValue();
            WrittenRegister.Value.setByte(data);
            WrittenRegister.Address.setByte(registerAddress);
            return true;
            }


        public bool saveSccbSettings()
        {
            SaveFileDialog SettingSaveDialog = new SaveFileDialog();
            SettingSaveDialog.DefaultExt = "csv";
            SettingSaveDialog.Filter = "CSV|.csv";
            if ((SettingSaveDialog.ShowDialog() == DialogResult.OK) && (SettingSaveDialog.FileName != ""))
            {
                String[] Lines = new String[numberOfRegister];
                for (int i = 0; i < Lines.Length; i++)
                {
                    Lines[i] = SccbRegisterList[i].ToStringHexCSV();
                }
                File.WriteAllLines(SettingSaveDialog.FileName, Lines);
                return true;
            }
            MessageBox.Show("False!");
            return false;
        }

        public bool saveSettingsToStruct()
        {
            SaveFileDialog SettingSaveDialog = new SaveFileDialog();
            if ((SettingSaveDialog.ShowDialog() == DialogResult.OK) && (SettingSaveDialog.FileName != ""))
            {
                String[] Lines = new String[numberOfRegister];
                for (int i = 0; i < Lines.Length; i++)
                {
                    Lines[i] = SccbRegisterList[i].ToStructHex();
                }
                File.WriteAllLines(SettingSaveDialog.FileName, Lines);
                return true;
            }
            MessageBox.Show("False!");
            return false;
        }

        public bool loadSccbSettings()
        {
            OpenFileDialog SettingOpenDialog = new OpenFileDialog();
            String[] Elements = new String[2];
            RegisterValue tempRegistervalue = new RegisterValue();

            if ((SettingOpenDialog.ShowDialog() == DialogResult.OK) && (SettingOpenDialog.FileName != ""))
            {
                String[] Lines = File.ReadAllLines(SettingOpenDialog.FileName);
                for (int i = 0; i < Lines.Length; i++)
                {
                    Elements = Lines[i].Split(';');
                    tempRegistervalue = new RegisterValue();
                    tempRegistervalue.setDez(Elements[1]);
                    SccbRegisterList[i].Value = tempRegistervalue;
                }
                return true;
            }
            MessageBox.Show("False!");
            return false;
        }

        public void resetReceivedData()
        {
            _receivedData = new Queue<byte>();
        }
        //COM Port 
        public bool configSerialPort(string sComPort, int sBaudrate, Parity sParityBit, StopBits sStopbits, Handshake shandshake, int sDatabits)
        {
            try
            {
                _comPort.BaudRate = sBaudrate;
                _comPort.PortName = sComPort;
                _comPort.Parity = sParityBit;
                _comPort.StopBits = sStopbits;
                _comPort.Handshake = shandshake;
                _comPort.DataBits = sDatabits;
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool connect()
        {
            try
            {
                //try to open a connection to the port
                _comPort.Open();
                //send CL+LF to uController to close the connect command bytes (4x255)
                byte[] closeConnectCommand = new byte[2];
                closeConnectCommand[0] = 13;
                closeConnectCommand[1] = 10;
                this.SendCommand(closeConnectCommand);
                return true;
            }
            catch (Exception Ex) //Timeout when open the port
            {
                MessageBox.Show(Ex.Message, "connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool isConnected()
        {
            if (_comPort.IsOpen)
                return true;
            else
                return false;
        }
        public bool disconnect()
        {
            try
            {
                //try to open a connection to the port
                _comPort.Close();
                return true;
            }
            catch (Exception Ex) //Timeout when open the port
            {
                MessageBox.Show(Ex.Message, "disconnection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //Register
        public RegisterValue getRegisterValue(int RegisterAddress)
        {
            return SccbRegisterList[RegisterAddress].Value;
        }
        public void SetRegisterValue(int RegisterAddress, RegisterValue newRegisterValue)
        {
            SccbRegisterList[RegisterAddress].Value = newRegisterValue;
        }
        
        //Take _picture
        public void TakePicture ()
        {
            _rowCount = 0;
            _picture.ResetRowCounter();
            var myBuffer = new byte[3];
            myBuffer[0] = 0x03;
            myBuffer[1] = 13;
            myBuffer[2] = 10;
            this.SendCommand(myBuffer);
            _rowCount = 0;
        }

        public void TakePictureComplete()
        {
            _rowCount = 0;
            _picture.ResetRowCounter();
            var myBuffer = new byte[3];
            myBuffer[0] = 0x0C;
            myBuffer[1] = 13;
            myBuffer[2] = 10;
            this.SendCommand(myBuffer);            
        }

        public void sendLineAccept()
        {
            var myBuffer = new byte[3];
            myBuffer[0] = 10;
            myBuffer[1] = 13;
            myBuffer[2] = 10;
            this.SendCommand(myBuffer);
        }
        public void sendLineRepeat()
        {
            var myBuffer = new byte[3];
            myBuffer[0] = 11;
            myBuffer[1] = 13;
            myBuffer[2] = 10;
            this.SendCommand(myBuffer);
        }

        public void addRegisterToWrite(SccbRegister RegisterToAdd)
        {
            _RegisterToWrite.Enqueue(RegisterToAdd);
        }

        public void writeAllRegister()
        {
            if (_RegisterToWrite.Count > 0)
            {
                ErrorCode = 0;
                SccbRegister nextRegister = _RegisterToWrite.Dequeue();
                writeRegister(nextRegister.MyAddress.getByte(), nextRegister.Value.getByte());
            }
            else
            {
                Programstatus = -1;
            }
        }

        //help functions
        /// <summary>
        /// This function splits an 2Byte integer into the MsB and LsB.
        /// </summary>
        /// <param name="numberToSplit">
        ///The integer to split
        /// </param>
        /// <returns>
        /// returns a Bytearray with 0: LsB and 1: MsB</returns>
        private byte[] getHighAndLowByte(int numberToSplit)
        {
            var ReturnArray = new byte[2];
            ReturnArray[0] = (byte)(numberToSplit & 255);
            ReturnArray[1] = (byte)((numberToSplit >> 8) & 255);

            return ReturnArray;
        }


    }

    
}
