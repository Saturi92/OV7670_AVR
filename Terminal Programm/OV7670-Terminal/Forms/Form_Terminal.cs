using OV7670_Terminal.Forms;
using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OV7670_Terminal
{
    public partial class Form_Terminal : Form
    {
        //TODO: check if it is not possible to introduce an imagefile for output or colorformats and use it for all the applications
        //Register Eventhandler
        public delegate void AddDataDelegate(String myString);
        public AddDataDelegate myDelegate;

        public MemoryStream MyStream = new MemoryStream();

        //Form actions
        public Form_Terminal()
        {
            InitializeComponent();
        }

        //Objects
        private SCCB_Interface MySCCB = new SCCB_Interface();
        private Ov7670Device Camera1 = new Ov7670Device();
        private Ov7670Device SavedCamera = new Ov7670Device();

        //Eventhandler used for Form actions, when Data is Proceeded from the Port
        delegate void Camera1DataProceedCallback(object sender, EventArgs e);
        private void Camera1_DataProceeded(object sender, EventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                Camera1DataProceedCallback callback = new Camera1DataProceedCallback(Camera1_DataProceeded);
                this.Invoke(callback, new object[] { sender, e });
            }
            else
            {
                RegisterValue Address = new RegisterValue();
                RegisterValue Value = new RegisterValue();
                //Handle Form actions
                switch (Camera1.Programstatus)
                {
                    case 1:
                        break;
                    case 4:
                        setStatus("Breite des Bildes wurde an Controller gesendet: " + Camera1._picture.ResolutionX + "px");
                        break;
                    case 5:
                        setStatus("Höhes des Bildes wurde an Controller gesendet: " + Camera1._picture.ResolutionY + "px");

                        break;
                    case 6:
                        setStatus("Bytes pro Pixel wurden an den Controller gesendet: " + Camera1._picture.BytesPerPixel);
                        Camera1.Programstatus = -1;
                        break;
                    case 8:
                        if (Camera1.ErrorCode == 0)
                        {
                            setStatus("initialisierung erfolgreich");
                        }
                        else
                        {
                            setStatus("initialisierung fehlgeschlagen, Error Code:" + Camera1.ErrorCode);
                        }

                        Camera1.Programstatus = -1;
                        break;
                    case 10:
                        controllerReadAllRegister();

                        break;
                    case 11:    //write all register

                        RegisterValue addressValue = new RegisterValue();
                        try
                        {
                            addressValue.setHex(
                                LiVi_LoadedSettings.Items[Camera1.ReadCounter].Text.Remove(0, 2));
                            if (Camera1.ErrorCode != 0)
                            {

                                setStatus("0x" + addressValue.toStringHex() +
                                          " Register schreiben - fehlgeschlagen, Errorcode:" +
                                          Camera1.ErrorCode.ToString());
                            }
                            else
                            {
                                setStatus("0x" + addressValue.toStringHex() + " Register schreiben - erfolgreich");
                                cmd_ReadAllRegister.ForeColor = Color.Red;
                            }
                            toolStripProgressBar1.Value++;
                        }
                        catch (Exception ex)
                        {
                            setStatus(ex.Message, Color.Red);
                            toolStripProgressBar1.Value = 0;
                            setStatus("Achtung! Es wurden mehr Register geschrieben als erwartet.");
                        }
                        Camera1.ReadCounter++;
                        Camera1.writeAllRegister();

                        break;
                    case 51:
                        Address = readTextBox_ManualSettingsAdjustment(TeBo_ReadRegister);
                        Value = Camera1.getRegisterValue(Address.getByte());
                        MySCCB.ReceivedValue = Value;
                        TeBo_SettingResult.Text = writeTextBox_ManualSettingsAdjustment(Value);
                        Camera1.Programstatus = -1;
                        cmd_ReadRegister.Enabled = true;
                        setStatus("Register 0x" + Address.toStringHex() + " Read successfull, Value: " + Value.toStringHex());
                        Camera1.OnSccbRegisterWasChanged();

                        break;
                    case 52:
                        Address = readTextBox_ManualSettingsAdjustment(TeBo_ReadRegister);
                        Value = Camera1.getRegisterValue(Address.getByte());
                        MySCCB.ReceivedValue = Value;
                        MySCCB.ReadRegister = Address;
                        MySCCB.WriteRegister = Address;
                        MySCCB.WriteValue = Value;
                        TeBo_SettingResult.Text = writeTextBox_ManualSettingsAdjustment(Value);
                        TeBo_WriteData.Text = TeBo_SettingResult.Text;
                        TeBo_WriteRegister.Text = TeBo_ReadRegister.Text;
                        setStatus("Register 0x" + Address.toStringHex() + " Read successfull, Value: " + Value.toStringHex());
                        Camera1.OnSccbRegisterWasChanged();

                        break;

                    case 60:
                        controllerGetCameraStatus();
                        Camera1.OnSccbRegisterWasChanged();
                        break;
                    case 90:

                    default:
                        break;
                }

            }
        }

        //Eventhandler for status changed
        delegate void Camera1ProgrammStatusChangedCallback(object sender, EventArgs e);
        private void Camera1_ProgrammStatusChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                Camera1ProgrammStatusChangedCallback callback = new Camera1ProgrammStatusChangedCallback(Camera1_ProgrammStatusChanged);
                this.Invoke(callback, new object[] { sender, e });
            }
            else
            {
                ToStStLbl_Programmstatus.Text = "Programm Modus: " + Camera1.Programstatus.ToString();
            }
        }

        //Eventhandler for Register Write
        delegate void Camera1RegisterWrittenCallback(object sender, RegisterEventArgs e);
        private void Camera1_RegisterWritten(object sender, RegisterEventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                Camera1RegisterWrittenCallback callback = new Camera1RegisterWrittenCallback(Camera1_RegisterWritten);
                this.Invoke(callback, new object[] {sender, e});
            }
            else
            {
                if (Camera1.ErrorCode == 0)
                {
                    setStatus("Register 0x" + e.Address.toStringHex() + " written with value 0x" + e.Value.toStringHex() + " complete", Color.Black);
                    Camera1.OnSccbRegisterWasChanged();
                }
                else
                {
                    setStatus("Register 0x" + e.Address.toStringHex() + " written with value 0x" + e.Value.toStringHex() + " failed, Errorcode: " + Camera1.ErrorCode.ToString(), Color.Red);
                }
            }
        }

        /// <summary>
        /// Eventhandler which protocolls the data received on the Comport
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        delegate void Camera1RxDataSniffedCallback(object sender, ComTransmissionEventArgs e);
        private void Camera1RxDataSniffed(object sender, ComTransmissionEventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                Camera1RxDataSniffedCallback callback = new Camera1RxDataSniffedCallback(Camera1RxDataSniffed);
                this.Invoke(callback, new object[] {sender, e});
            }
            else
            {
                RiTeBo_receive.Text += "\n rx:";
                foreach (var s in e.TransmittedData)
                {
                    RegisterValue tempValue = new RegisterValue();
                    tempValue.setByte(s);
                    RiTeBo_receive.Text += " 0x" + tempValue.toStringHex();
                }
            }
        }

        delegate void Camera1_TxDataSniffedCallback(object sender, ComTransmissionEventArgs e);
        /// <summary>
        /// Eventhandler which protocolls the data sent on the Comport
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Camera1_TxDataSniffed(object sender, ComTransmissionEventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                Camera1_TxDataSniffedCallback callback = new Camera1_TxDataSniffedCallback(Camera1_TxDataSniffed);
                this.Invoke(callback, new object[] {sender, e});
            }
            else
            {
                RiTeBo_receive.Text += "\n tx:";
                foreach (var s in e.TransmittedData)
                {
                    RegisterValue tempValue = new RegisterValue();
                    tempValue.setByte(s);
                    RiTeBo_receive.Text += " 0x" + tempValue.toStringHex();
                }
            }
        }

        /// <summary>
        /// Eventhandler, when the SccbRegister of the Camera were updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        delegate void Ov7670_SccbRegisterWasChangedCallback(object sender, EventArgs e);
        private void Camera1_SccbRegisterWasChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                Ov7670_SccbRegisterWasChangedCallback callback =
                    new Ov7670_SccbRegisterWasChangedCallback(Camera1_SccbRegisterWasChanged);
                this.Invoke(callback, new object[] { sender, e });
            }
            else
            {
                RefreshSCCBOverview(Camera1, LiVi_DeviceSettings);
                compareLists(LiVi_LoadedSettings, Camera1);
                refreshFormStatus(Camera1);
            }
        }


        delegate void Camera1_ErrorOccuredCallback(object sender, ErrorEventArgs e);
        /// <summary>
        /// Eventfollower to display ErrorMessages on the Terminal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        /// Class which includes the Errorcode and the ErrorMessage
        /// </param>
        private void Camera1_ErrorOccured(object sender, ErrorEventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                Camera1_ErrorOccuredCallback callback = new Camera1_ErrorOccuredCallback(Camera1_ErrorOccured);
                this.Invoke(callback, new object[] {sender, e});
            }
            else
            {
                setStatus(e.ErrorMessage +", ErrorCode:"+e.ErrorCode,Color.Red);
            }
        }

        delegate void Camera1_PictureFormatChangedCallback(object sender, PictureFormatEventArgs e);
        private void Camera1_PictureFormatChanged(object sender, PictureFormatEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Camera1_PictureFormatChangedCallback callback = new Camera1_PictureFormatChangedCallback(Camera1_PictureFormatChanged);
                this.Invoke(callback, new object[] {sender, e});
            }
            else
            {
                lbl_PictureDescription.Text = e.xRes.ToString() + " x " + e.yRes.ToString() + " " +
                                              e.BytesPerPixel.ToString() + " bytes per pixel";
            }
        }

        delegate void Camera1_PictureCompleteCallback(object sender, EventArgs e);
        private void Camera1_PictureComplete(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Camera1_PictureCompleteCallback callback = new Camera1_PictureCompleteCallback(Camera1_PictureComplete);
                this.Invoke(callback, new object[] {sender, e});
            }
            else
            {
                setStatus("Picture received completly");
                Camera1.RxDataSnifferComplete += Camera1RxDataSniffed;
            }
        }

        //Build Image
        private void controllerReadAllRegister()
        {
            Camera1.ReadCounter++;
            if (Camera1.ReadCounter < Camera1.AmountRegister)
            {
                Camera1.readRegister((Byte)Camera1.ReadCounter);
                setStatus("Read Register "+Camera1.ReadCounter);
                toolStripProgressBar1.Value++;
                Camera1.OnSccbRegisterWasChanged();
            }
            else
            {
                RefreshSCCBOverview(Camera1, LiVi_DeviceSettings);
                
                Camera1.OnSccbRegisterWasChanged();
                toolStripProgressBar1.Value = 0;
                cmd_ReadAllRegister.ForeColor = Color.Black;
                setStatus("Read all register - complete");
                //set Form Colors:
                cmd_ReadAllRegister.ForeColor = Color.Black;
                lbl_ReadAllNotUpdated.Visible = false;

            }
        }

        /// <summary>
        /// This function controlls the Programmstatus 60. In this status, all "status register" of the OV7670 will be read.
        /// After all, in the byte array StatusRegisterList contained Register are read, the Userform get updated
        /// </summary>
        private void controllerGetCameraStatus()
        {
            Camera1.ReadCounter++;
            try
            {
                toolStripProgressBar1.Value++;
            }

            catch
            {
                setStatus("Error, Mehr Daten empfangen als erwartet", Color.Red);
            }

            if (Camera1.ReadCounter < Camera1.StatusRegisterList.Length)
            {
                byte nextRegister = Camera1.StatusRegisterList[Camera1.ReadCounter];
                Camera1.readRegister(nextRegister);
            }
            else if (Camera1.ReadCounter > Camera1.StatusRegisterList.Length)
            {
                setStatus("Fehler! Mehr Daten empfangen als erwartet",Color.Red);
            }
            else
            {
                RefreshSCCBOverview(Camera1, LiVi_DeviceSettings);
                //Camera1.syncBetweenCameraAndTerminal();
                Camera1.UpdateOutputFormat();
                Camera1.updateColorFormat();
                this.refreshFormStatus(Camera1);
                compareLists(LiVi_LoadedSettings, Camera1);
                toolStripProgressBar1.Value = 0;
                setStatus("Status updated succsessfull");
                // Camera1.Programstatus = -1;
            }

        }
        private void Form_Terminal_Load(object sender, EventArgs e)
        {
            UpdateComList();

            this.myDelegate = new AddDataDelegate(AddDataMethod);
            //Load SCCB

            //Register Delegate
            Camera1.DataIsProceeded += Camera1_DataProceeded;
            Camera1.PictureRowReceived += Camera1_RowReceived;
            Camera1.SccbRegisterWasChanged += Camera1_SccbRegisterWasChanged;
            Camera1.ProgrammStatusChanged += Camera1_ProgrammStatusChanged;
            Camera1.RegisterWriteComplete += Camera1_RegisterWritten;
            Camera1.RxDataSnifferComplete += Camera1RxDataSniffed;
            Camera1.txDataSnifferComplete += Camera1_TxDataSniffed;
            Camera1.ErrorOccured += Camera1_ErrorOccured;
            Camera1.PictureFormatChanged += Camera1_PictureFormatChanged;
            Camera1.PictureComplete += Camera1_PictureComplete;

            //Setup ToolTip
            ToolTip myTooltip = new ToolTip();
            myTooltip.AutoPopDelay = 5000;
            myTooltip.InitialDelay = 1000;
            myTooltip.ReshowDelay = 500;
            myTooltip.ShowAlways = true;

            myTooltip.SetToolTip(cmd_ReadAllRegister, "Ruft alle Register der Kamera ab");
        }


        delegate void Camera1RowReceivedCallback(object sender, EventArgs e);
        private void Camera1_RowReceived(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Camera1RowReceivedCallback callback = new Camera1RowReceivedCallback(Camera1_RowReceived);
                this.Invoke(callback, new object[] { sender, e });
            }
            else
            {
                switch (Camera1.Programstatus)
                {
                    case 2:
                        PiBo_ImageBox.SizeMode = PictureBoxSizeMode.Zoom;
                        PiBo_ImageBox.Image = new Bitmap(Camera1._picture.Image);
                        toolStripProgressBar1.Maximum = Camera1._picture.ResolutionY;
                        toolStripProgressBar1.Value = Camera1.getRowCount();
                        setStatus("Empfange Bild",
                            Camera1.getRowCount()+1 + " von " + (Camera1._picture.ResolutionY) + "Zeilen importiert, " + Camera1.rowRepeatCounter + " RowRepeat requested",Color.Black);
                        

                        //Synchronise the Pictureboxes in picture tab, if Checkbox is checked checked
                        if (ChBo_LP_Sync.Checked == true)
                        {
                            PiBo_LeftPicture.Image = new Bitmap(Camera1._picture.Image);
                            updatePictureTab();
                        }

                        if (ChBo_RP_Sync.Checked == true)
                        {
                            PiBo_RightPicture.Image = new Bitmap(Camera1._picture.Image);
                            updatePictureTab();
                        }
                        break;
                    case 90:
                        PiBo_Manual.SizeMode = PictureBoxSizeMode.Zoom;
                        PiBo_Manual.Image = new Bitmap(Camera1._picture.Image);
                        toolStripProgressBar1.Maximum = Camera1._picture.ResolutionY;
                        try
                        {
                            toolStripProgressBar1.Value = Camera1.getRowCount();
                        }
                        catch (Exception Ex)
                        {
                            setStatus("Progressbar: " + Ex.Message,Color.Red);
                            toolStripProgressBar1.Value = 0;
                        }
                        setStatus("Empfange Bild",
                            Camera1.getRowCount()+1+ " von " + (Camera1._picture.ResolutionY) + "Zeilen importiert, " + Camera1.rowRepeatCounter + " RowRepeat requested", Color.Black);                    

                        //Synchronise the Pictureboxes in picture tab, if Checkbox is checked checked
                        if (ChBo_LP_Sync.Checked == true)
                        {
                            PiBo_LeftPicture.Image = new Bitmap(Camera1._picture.Image);
                            updatePictureTab();
                        }

                        if (ChBo_RP_Sync.Checked == true)
                        {
                            PiBo_RightPicture.Image = new Bitmap(Camera1._picture.Image);
                            updatePictureTab();
                        }
                        break;
                }
            }

        }

        private void updatePictureTab()
        {
            if (PiBo_LeftPicture.Image != null)
            {
                lbl_LP_Width.Text = "Width: " + PiBo_LeftPicture.Image.Width;
                lbl_LP_Height.Text = "Height: " + PiBo_LeftPicture.Image.Height;
            }

            if (PiBo_RightPicture.Image != null)
            {
                lbl_RP_Width.Text = "Width: " + PiBo_RightPicture.Image.Width;
                lbl_RP_Height.Text = "Height: " + PiBo_RightPicture.Image.Height;
            }
        }


        public void AddDataMethod(string myString)
        {

            //RiTeBo_receive.AppendText(myString);
        }

        private void Form_Terminal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SePo_Camera.IsOpen)
            {
                SePo_Camera.Close();
            }
        }

        //Serial Port 
        private void SePo_Camera_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            int Amount = SePo_Camera.BytesToRead;
            Byte[] myData = new Byte[Amount];
            SePo_Camera.Read(myData, 0, Amount);
            MyStream.Write(myData, 0, SePo_Camera.BytesToRead);
            //String receivedData = SePo_Camera.ReadExisting();
            //RiTeBo_receive.Invoke(this.myDelegate, new Object[] { receivedData });
        }

        //Userform

        //COM-Port 
        private void UpdateComList()
        {
            //Update ComList
            string[] ports = SerialPort.GetPortNames();
            CoBo_ComPort.Items.Clear();
            CoBo_ComPort.Items.AddRange(ports);
            CoBo_ComPort.SelectedIndex = ports.Length - 1;
            cmd_Port_disconnect.Enabled = false;

            //Update Baudrate
            String[] baudrates = { "2400", "4800", "9600", "14400", "19200", "28800", "38400", "57600", "76800", "115200", "230400", "250000", "500000", "1000000", "2000000" };
            CoBo_Baudrate.Items.AddRange(baudrates);
            CoBo_Baudrate.SelectedIndex = 9;

            //Update Stoppbits
            String[] stopbits = { "None", "One", "Two", "OneDotFive" };
            CoBo_StoppBits.Items.AddRange(stopbits);
            CoBo_StoppBits.SelectedIndex = 1;

            //Update DataBits
            String[] databits = { "8" };
            CoBo_Datenbits.Items.AddRange(databits);
            CoBo_Datenbits.SelectedIndex = 0;

            //Update Parity
            String[] paritäten = { "None", "Odd", "Even", "Mark", "Space" };
            CoBo_Parit.Items.AddRange(paritäten);
            CoBo_Parit.SelectedIndex = 0;

            //Update Handshake
            String[] handshake = { "none", "yes" };
            CoBo_Handshake.Items.AddRange(handshake);
            CoBo_Handshake.SelectedIndex = 0;


        }

        private void cmd_com_verbinden(object sender, EventArgs e)
        {
            ////Comport Settings
            Camera1.configSerialPort(
                CoBo_ComPort.Text,
                Convert.ToInt32(CoBo_Baudrate.Text),
                (Parity)Enum.Parse(typeof(Parity),
                (CoBo_Parit.Text), true),
                (StopBits)Enum.Parse(typeof(StopBits), CoBo_StoppBits.Text, true),
                (Handshake)Enum.Parse(typeof(Handshake),
                CoBo_Handshake.Text, true),
                Convert.ToInt16(CoBo_Datenbits.Text));

            if (Camera1.connect())
            {
                cmd_Port_connect.Enabled = false;
                cmd_Port_disconnect.Enabled = true;
                cmd_ReadAllRegister.Enabled = true;

                ToStSt_Connection.Text = "connected";
                ToStSt_Connection.ForeColor = Color.Green;
                lbl_Port_Status.Text = "Connected";
                lbl_Port_Status.ForeColor = Color.Green;
            }
            else
            {
                MessageBox.Show("Verbindung konnte nicht hergestellt werden");
            }
        }
        private void cmd_Port_disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                Camera1.disconnect();
                cmd_Port_connect.Enabled = true;
                cmd_Port_disconnect.Enabled = false;
                cmd_ReadAllRegister.Enabled = false;

                ToStSt_Connection.Text = "disconnected";
                ToStSt_Connection.ForeColor = Color.Red;
                lbl_Port_Status.Text = "Disconnected";
                lbl_Port_Status.ForeColor = Color.Red;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "disconnect failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmd_ComSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (Camera1.isConnected())
                {
                    if (Camera1.Programstatus == -1)
                    {
                        Camera1.readRegister(0x0A);
                        RiTeBo_send.Clear();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void cmd_ComRec_Click(object sender, EventArgs e)
        {
            try
            {
                if (SePo_Camera.IsOpen)
                {
                    RiTeBo_receive.Text = SePo_Camera.ReadExisting();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TeBo_xResolution_Leave(object sender, EventArgs e)
        {
            if (TeBo_xResolution.Text.All(char.IsDigit))
            {

            }
            else
            {
                TeBo_xResolution.Text = "0";
                MessageBox.Show("x Resolution must be an integer");
            }

        }
        private void TeBo_yResolution_Leave(object sender, EventArgs e)
        {
            if (TeBo_yResolution.Text.All(char.IsDigit))
            {

            }
            else
            {
                TeBo_yResolution.Text = "0";
                MessageBox.Show("y Resolution must be an integer");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cmd_ReadRegister_Click(object sender, EventArgs e)
        {
            if (Camera1.isConnected())
            {
                Camera1.Programstatus = 51;
                RegisterValue AddressValue = readTextBox_ManualSettingsAdjustment(TeBo_ReadRegister);
                Camera1.readRegister(AddressValue.getByte());
            }
            else
            {
                ToSt_Task.Text = "no Device connected!";
                ToSt_Task.ForeColor = Color.Red;
            }
        }
        /// <summary>
        /// This function check the chosen Format on the Form
        /// </summary>
        /// <param name="myTextboxToRead"></param>
        /// <returns>Returns the RegisterValue format oneByte format with different Methods</returns>
        private RegisterValue readTextBox_ManualSettingsAdjustment(TextBox myTextboxToRead)
        {

            RegisterValue RegisterToRead = new RegisterValue();
            if (RaBu_Bin.Checked)
            {
                RegisterToRead.setBin(myTextboxToRead.Text);
            }
            else if (RaBu_Dez.Checked)
            {
                RegisterToRead.setDez(myTextboxToRead.Text);
            }
            else if (RaBu_Hex.Checked)
            {
                RegisterToRead.setHex(myTextboxToRead.Text);
            }

            return RegisterToRead;
        }
        private string writeTextBox_ManualSettingsAdjustment(RegisterValue registerToWrite)
        {
            string registerToTextbox = "";
            if (RaBu_Bin.Checked)
            {
                registerToTextbox = registerToWrite.getBin();
            }
            else if (RaBu_Dez.Checked)
            {
                registerToTextbox = registerToWrite.getDez();
            }
            else if (RaBu_Hex.Checked)
            {
                registerToTextbox = registerToWrite.getHex();
            }

            return registerToTextbox;

        }

        private void cmd_WriteRegister_Click(object sender, EventArgs e)
        {
            if (Camera1.isConnected())
            {
                Camera1.Programstatus = 53;
                RegisterValue Address = new RegisterValue();
                RegisterValue Value = new RegisterValue();
                Address = readTextBox_ManualSettingsAdjustment(TeBo_WriteRegister);
                Value = readTextBox_ManualSettingsAdjustment(TeBo_WriteData);
                Camera1.writeRegister(Address.getByte(), Value.getByte());

                //set Form Colors:
                cmd_ReadAllRegister.ForeColor = Color.Red;
                lbl_ReadAllNotUpdated.Visible = true;
            }
            else
            {
                ToSt_Task.Text = "no Device connected!";
                ToSt_Task.ForeColor = Color.Red;
            }
        }

        private void RaBu_Hex_CheckedChanged(object sender, EventArgs e)
        {
            if (RaBu_Hex.Checked)
            {
                //Change Textboxes
                TeBo_ReadRegister.Text = MySCCB.ReadRegister.getHex();
                TeBo_SettingResult.Text = MySCCB.ReceivedValue.getHex();
                TeBo_WriteRegister.Text = MySCCB.WriteRegister.getHex();
                TeBo_WriteData.Text = MySCCB.WriteValue.getHex();


                //change label
                lbl_ReadRegister.Text = "0x";
                lbl_ReadResult.Text = "0x";
                lbl_WriteRegister.Text = "0x";
                lbl_WriteValue.Text = "0x";
            }
        }

        private void RaBu_Dez_CheckedChanged(object sender, EventArgs e)
        {
            if (RaBu_Dez.Checked)
            {
                //Change Textboxes
                TeBo_ReadRegister.Text = MySCCB.ReadRegister.getDez();
                TeBo_SettingResult.Text = MySCCB.ReceivedValue.getDez();
                TeBo_WriteRegister.Text = MySCCB.WriteRegister.getDez();
                TeBo_WriteData.Text = MySCCB.WriteValue.getDez();

                //change label
                lbl_ReadRegister.Text = "";
                lbl_ReadResult.Text = "";
                lbl_WriteRegister.Text = "";
                lbl_WriteValue.Text = "";
            }

        }
        private void RaBu_Bin_CheckedChanged(object sender, EventArgs e)
        {
            if (RaBu_Bin.Checked)
            {
                //Change Textboxes
                TeBo_ReadRegister.Text = MySCCB.ReadRegister.getBin();
                TeBo_SettingResult.Text = MySCCB.ReceivedValue.getBin();
                TeBo_WriteRegister.Text = MySCCB.WriteRegister.getBin();
                TeBo_WriteData.Text = MySCCB.WriteValue.getBin();

                //change label
                lbl_ReadRegister.Text = "0b";
                lbl_ReadResult.Text = "0b";
                lbl_WriteRegister.Text = "0b";
                lbl_WriteValue.Text = "0b";

            }
        }

        private void TeBo_ReadRegister_Leave(object sender, EventArgs e)
        {
            TeBo_ReadRegister = checkRegisterValue(TeBo_ReadRegister);
            string TempString = TeBo_ReadRegister.Text;

            if (RaBu_Bin.Checked)
            {
                MySCCB.ReadRegister.setBin(TempString);
            }

            if (RaBu_Dez.Checked)
            {
                MySCCB.ReadRegister.setDez(TempString);
            }

            if (RaBu_Hex.Checked)
            {
                MySCCB.ReadRegister.setHex(TempString);
            }
        }
        private void TeBo_SettingResult_Leave(object sender, EventArgs e)
        {
            TeBo_SettingResult = checkRegisterValue(TeBo_SettingResult);
            string TempString = TeBo_SettingResult.Text;

            if (RaBu_Bin.Checked)
            {
                MySCCB.ReceivedValue.setBin(TempString);
            }

            if (RaBu_Dez.Checked)
            {
                MySCCB.ReceivedValue.setDez(TempString);
            }

            if (RaBu_Hex.Checked)
            {
                MySCCB.ReceivedValue.setHex(TempString);
            }
        }
        private void TeBo_WriteRegister_Leave(object sender, EventArgs e)
        {
            TeBo_WriteRegister = checkRegisterValue(TeBo_WriteRegister);
            string TempString = TeBo_WriteRegister.Text;

            if (RaBu_Bin.Checked)
            {
                MySCCB.WriteRegister.setBin(TempString);
            }

            if (RaBu_Dez.Checked)
            {
                MySCCB.WriteRegister.setDez(TempString);
            }

            if (RaBu_Hex.Checked)
            {
                MySCCB.WriteRegister.setHex(TempString);
            }
        }
        private void TeBo_WriteData_Leave(object sender, EventArgs e)
        {
            TeBo_WriteData = checkRegisterValue(TeBo_WriteData);
            string TempString = TeBo_WriteData.Text;

            if (RaBu_Bin.Checked)
            {
                MySCCB.WriteValue.setBin(TempString);
            }

            if (RaBu_Dez.Checked)
            {
                MySCCB.WriteValue.setDez(TempString);
            }

            if (RaBu_Hex.Checked)
            {
                MySCCB.WriteValue.setHex(TempString);
            }
        }
        private void cmd_Durchsuchen_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog_LoadImage.ShowDialog() == DialogResult.OK)
            {
                StreamReader ReadFile = new StreamReader(OpenFileDialog_LoadImage.FileName);

                ImageFile MyImageData = new ImageFile();
                char[] Seperators = { ' ' };

                //TODO: include File decision
                MyImageData.ReadFile(ReadFile, 288, 352, 3, Seperators);
                PiBo_Manual.Image = MyImageData.Image;
            }

        }


        //additional Methods

        private Color ConvertYtoRGB(byte YValue)
        {
            const double Kr = 0.299;
            const double Kb = 0.114;

            int redPart = Convert.ToInt32(Kr * YValue);
            int bluePart = Convert.ToInt32(Kb * YValue);
            int greenPart = Convert.ToInt32((1 - Kr - Kb) * YValue);

            Color calculatedColor = Color.FromArgb(redPart, greenPart, bluePart);

            return calculatedColor;
        }

        private void init_StreamObject()
        {

        }

        private bool checkIsHex(String stringToCheck)
        {
            for (int i = 0; i < stringToCheck.Length; i++)
            {
                if (!((stringToCheck[i] >= 48) && (stringToCheck[i] <= 57)) && !((stringToCheck[i] >= 65) && (stringToCheck[i] <= 70)))
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkIsBin(string currentString)
        {
            for (int i = 0; i < currentString.Length; i++)
            {
                if (currentString[i] != '0' && currentString[i] != '1')
                {
                    return false;
                }
            }
            return true;
        }

        private string fillWithZeros(string myString, int amountOfCharacter)
        {
            for (int i = 0; myString.Length < amountOfCharacter; i++)
            {
                myString = "0" + myString;
            }
            return myString;
        }

        private TextBox checkRegisterValue(TextBox TextboxToCheck)
        {
            String currentString = TextboxToCheck.Text;
            if (RaBu_Bin.Checked)
            {
                currentString = fillWithZeros(currentString, 8);
                if (!checkIsBin(currentString) || !(currentString.Length <= 8))
                {
                    MessageBox.Show("Eingegebenes Format stimmt nicht mit dem benötigten 8Bit format überein.", "Error", MessageBoxButtons.OK);
                    currentString = "00000000";
                }

            }

            if (RaBu_Dez.Checked)
            {
                int Temp;
                currentString = fillWithZeros(currentString, 3);
                if (!Int32.TryParse(currentString, out Temp) || !(Temp <= 255))
                {
                    MessageBox.Show("Die maximale Adressgröße beträgt 255", "Error", MessageBoxButtons.OK);
                    currentString = "0";
                }
            }

            if (RaBu_Hex.Checked)
            {
                currentString = fillWithZeros(currentString, 2);

                if ((!(currentString.Length <= 2)) || (!checkIsHex(currentString)))
                {
                    MessageBox.Show("Eingegebenes Format stimmt nicht mit dem benötigten 0x00 überein.", "Error", MessageBoxButtons.OK);
                    currentString = "00";
                }
            }
            TextboxToCheck.Text = currentString;

            return TextboxToCheck;
        }

        private bool isStreamComplete(Stream StreamToCheck)
        {
            bool flag = false;
            Byte[] LastBytes = ReadLast2Bytes(StreamToCheck);

            if ((LastBytes[0] == 13) && (LastBytes[1] == 10))
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        private Byte[] ReadLast2Bytes(Stream StreamToRead)
        {
            Byte[] LastBytes = new Byte[2] { 0, 0 };
            int tempByte = 0;

            while (tempByte >= 0)
            {
                tempByte = StreamToRead.ReadByte();
                if (tempByte >= 0)
                {
                    LastBytes[1] = (Byte)tempByte;
                    LastBytes[0] = LastBytes[1];
                }
            }
            return LastBytes;
        }

        private bool savePictureBoxToFile(PictureBox PictureToSafe)
        {
            SaveFileDialog FileDialog = new SaveFileDialog();
            FileDialog.Filter = "bmp Files (*.bmp)|*.bmp|jpg Files (*.jpg)|*.jpg";
            FileDialog.InitialDirectory = Directory.GetCurrentDirectory();

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PictureToSafe.Image.Save(FileDialog.FileName);
                    //if (FileDialog.Filter.Contains("jpg"))
                    //    myBitmap.Save(FileDialog.FileName, ImageFormat.Jpeg);

                    // else if (FileDialog.Filter.Contains("bmp"))
                    //   myBitmap.Save(FileDialog.FileName, ImageFormat.Bmp);
                }
                catch (Exception saveException)
                {
                    MessageBox.Show(
                        "Bild konnte unter angegeben Pfad nicht gespeichert werden \n\n Error Code: " + saveException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return true;
        }

        private void ReadAllRegister_Click(object sender, EventArgs e)
        {
            if (Camera1.isConnected())
            {

                toolStripProgressBar1.Maximum = Camera1.AmountRegister;
                toolStripProgressBar1.Value = 0;
                Camera1.resetReceivedData();
                Camera1.ReadCounter = 0;
                Camera1.Programstatus = 10;
                Camera1.readRegister((Byte)Camera1.ReadCounter);
                setStatus("Read all register - start");
            }
            else
            {
                ToSt_Task.Text = "no device connected (" + DateTime.Now.ToString("hh:mm:ss");
            }

        }

        private void cmd_safeSCCBSettings_Click(object sender, EventArgs e)
        {
            Camera1.saveSccbSettings();
        }

        private void cmd_loadSCCBSettings_Click(object sender, EventArgs e)
        {
            openSettingsFile(LiVi_LoadedSettings, 1);
            compareLists(LiVi_LoadedSettings, Camera1);
        }

        /// <summary>
        /// This functions loads the settings from a file to a Listbox
        /// </summary>
        /// <param name="ListViewToShow"></param>
        /// <param name="type"></param>
        /// Format in File. 1: "0x11;0x12" 2: "{ 0x11, 0x12 },"  
        /// <returns>true if success</returns>
        private bool openSettingsFile(ListView ListViewToShow, int type)
        {
            OpenFileDialog SettingOpenDialog = new OpenFileDialog();
            String[] Elements = new String[2];
            RegisterValue tempRegistervalue = new RegisterValue();
            try
            {
                if ((SettingOpenDialog.ShowDialog() == DialogResult.OK) && (SettingOpenDialog.FileName != ""))
                {
                    ListViewToShow.Items.Clear();
                    String[] Lines = File.ReadAllLines(SettingOpenDialog.FileName);
                    for (int i = 0; i < Lines.Length; i++)
                    {
                        switch (type)
                        {
                            case 1:
                                Elements = Lines[i].Split(';');
                                ListViewItem nItem = new ListViewItem();
                                nItem.Text = Elements[0];
                                nItem.SubItems.Add(Elements[1]);
                                ListViewToShow.Items.Add(nItem);
                                break;
                            case 2:

                                Elements = Lines[i].Split(',');
                                Elements[0] = Elements[0].Remove(0, 2);
                                Elements[1] = Elements[1].Remove(0, 1);
                                Elements[1] = Elements[1].Remove(4, 2);
                                ListViewItem nItem2 = new ListViewItem();
                                nItem2.Text = Elements[0];
                                nItem2.SubItems.Add(Elements[1]);
                                ListViewToShow.Items.Add(nItem2);
                                break;
                            default:
                                break;
                        }
                    }


                    return true;
                }

                return false;
            }
            catch (FileLoadException)
            {
                MessageBox.Show("Datei konnte nicht geöffnet werden!");
                return false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Das Format konnte nicht verarbeitet werden: " + Ex.Message);
                return false;
            }
        }


        private void RefreshSCCBOverview(Ov7670Device InterfaceToRead, ListView ListViewToWrite)
        {
            ListViewToWrite.BeginUpdate();
            ListViewToWrite.Items.Clear();
            for(var i=0; i< InterfaceToRead.AmountRegister; i++)
            {
                ListViewItem nEntry = new ListViewItem();
                nEntry.Text = "0x"+InterfaceToRead.SccbRegisterList[i].MyAddress.getHex();
                nEntry.SubItems.Add("0x" + InterfaceToRead.SccbRegisterList[i].Value.getHex());
                ListViewToWrite.Items.Add(nEntry);
            }
            ListViewToWrite.EndUpdate();
            //TODO: delete following
            //ListToWrite.BeginUpdate();
            //ListToWrite.Items.Clear();
            //for (Byte i = 0; i < InterfaceToRead.AmountRegister; i++)
            //{
            //    ListToWrite.Items.Add(InterfaceToRead.SccbRegisterList[i].ToStringHex());
            //}
            //ListToWrite.EndUpdate();
        }
        private void compareLists(ListView ListToCompare, Ov7670Device _Camera)
        {
            SccbRegister RegisterToCompare;
            RegisterValue _address;
            RegisterValue _value;
            //var CopyOfItemList = new object[ListToCompare.Items.Count];
            //ListToCompare.Items.CopyTo(CopyOfItemList, 0);

            foreach (ListViewItem _entry in ListToCompare.Items)
            {
                _address = new RegisterValue();
                _address.setHex(_entry.Text.Remove(0, 2));
                _value = new RegisterValue();
                _value.setHex(_entry.SubItems[1].Text.Remove(0, 2));
                RegisterToCompare = new SccbRegister(_address, _value);

                if (RegisterToCompare.MyAddress.getByte() < _Camera.AmountRegister)
                {
                    if (!RegisterToCompare.AddAndValueEquals(_Camera.SccbRegisterList[RegisterToCompare.MyAddress.getByte()]))
                    {
                        _entry.BackColor = Color.Red;
                        _entry.ForeColor = Color.White;
                    }
                    else
                    {
                        _entry.BackColor = Color.White;
                        _entry.ForeColor = Color.Black;
                    }
                }

                else
                {
                    setStatus("Register Addresse außerhalb des zulässigen bereichs: " +
                              RegisterToCompare.MyAddress, Color.Red);
                }

            }
        }

        private void cmd_readForChange_Click(object sender, EventArgs e)
        {
            Camera1.Programstatus = 52;
            RegisterValue AddressValue = readTextBox_ManualSettingsAdjustment(TeBo_ReadRegister);
            Camera1.resetReceivedData();
            Camera1.readRegister(AddressValue.getByte());
        }

        private void cmd_WriteAllRegister_Click(object sender, EventArgs e)
        {
            if (Camera1.isConnected())
            {
                toolStripProgressBar1.Maximum = LiVi_LoadedSettings.Items.Count;
                toolStripProgressBar1.Value = 0;
                Camera1.ReadCounter = 0;
                Camera1.resetReceivedData();
                loadListViewToWriteList(LiVi_LoadedSettings, Camera1);
                Camera1.Programstatus = 11;
                Camera1.writeAllRegister();
                setStatus("Write all register - start");
            }
            else
            {
                ToSt_Task.Text = "no Device connected!";
            }
        }

        private void loadListViewToWriteList(ListView ListViewToRead, Ov7670Device CameraToWrite)
        {
            Camera1.clearRegisterToWrite();
            foreach (ListViewItem _item in ListViewToRead.Items)
            {
                RegisterValue _tempAddress = new RegisterValue();
                RegisterValue _tempValue = new RegisterValue();
                _tempAddress.setHex(_item.Text.Remove(0, 2));
                _tempValue.setHex(_item.SubItems[1].Text.Remove(0, 2));
                SccbRegister _tempRegister = new SccbRegister(_tempAddress, _tempValue);
                CameraToWrite.addRegisterToWrite(_tempRegister);
            }
        }

        private void refreshFormStatus(Ov7670Device CameraToRefresh)
        {
            //Update OutputResolution
            switch (CameraToRefresh.OutputResolution)
            {
                case EnumResolutionFormat.VGA:
                    lbl_OutPutResolution.ForeColor = Color.Black;
                    lbl_OutPutResolution.Text = "Resolution:    VGA";
                    break;
                case EnumResolutionFormat.QCIF:
                    lbl_OutPutResolution.ForeColor = Color.Black;
                    lbl_OutPutResolution.Text = "Resolution:    QCIF";
                    break;
                case EnumResolutionFormat.QVGA:
                    lbl_OutPutResolution.ForeColor = Color.Black;
                    lbl_OutPutResolution.Text = "Resolution:    QVGA";
                    break;
                case EnumResolutionFormat.CIF:
                    lbl_OutPutResolution.ForeColor = Color.Black;
                    lbl_OutPutResolution.Text = "Resolution:    CIF";
                    break;
                default:
                    lbl_OutPutResolution.ForeColor = Color.Red;
                    lbl_OutPutResolution.Text = "Resolution:    no OutputFormat selected!";
                    break;
            }
            //Update ColorFormat
            switch (CameraToRefresh.OutputColorFormat)
            {
                case EnumColorFormat.YUV:
                    lbl_ColorFormat.ForeColor = Color.Black;
                    lbl_ColorFormat.Text = "Color Format: YUV";
                    break;
                case EnumColorFormat.RGB444:
                    lbl_ColorFormat.ForeColor = Color.Black;
                    lbl_ColorFormat.Text = "Color Format: normal RGB444";
                    break;
                case EnumColorFormat.ProcessedBayerRaw:
                    lbl_ColorFormat.ForeColor = Color.Black;
                    lbl_ColorFormat.Text = "Color Format: processed Bayer RAW";
                    break;

                case EnumColorFormat.BayerRaw:
                    lbl_ColorFormat.ForeColor = Color.Black;
                    lbl_ColorFormat.Text = "Color Format: Bayer RAW";
                    break;
                case EnumColorFormat.RGB565:
                    lbl_ColorFormat.ForeColor = Color.Black;
                    lbl_ColorFormat.Text = "Color Format: RGB565";
                    break;
                case EnumColorFormat.RGB555:
                    lbl_ColorFormat.ForeColor = Color.Black;
                    lbl_ColorFormat.Text = "Color Format: RGB555";
                    break;
                default:
                    lbl_ColorFormat.ForeColor = Color.Red;
                    lbl_ColorFormat.Text = "Color Format: not selected";
                    break;
            }
            //Update Product ID
            lbl_VersionNo.Text = "Version:      0x" + CameraToRefresh.SccbRegisterList[0x0A].Value.toStringHex() + " 0x" +
                                 CameraToRefresh.SccbRegisterList[0x0B].Value.toStringHex();
            //Update TestPattern:
            if ((Camera1.SccbRegisterList[0x12].Value.getByte() & 0x02) == 0x02) //check if ColorBar enabled
            {
                if ((Camera1.SccbRegisterList[0x42].Value.getByte() & 0x08) != 0x08)    //Check if DSP is enabled
                {
                    lbl_TestPattern.Text = "Testpattern: DSP not activated";
                    lbl_TestPattern.ForeColor = Color.Red;
                }
                else
                {
                    lbl_TestPattern.Text = "Testpattern: Color Bar";
                    lbl_TestPattern.ForeColor = Color.Black;
                }
            }
            //TODO: Form Status update
        }

        private void cmd_caputeImage_Click(object sender, EventArgs e)
        {
            if (Camera1.isConnected())
            {
                Camera1.Programstatus = 3;
                Camera1.ReadCounter = 0;
                Camera1.UpdatePicture();
                Camera1.TakePicture();
                toolStripProgressBar1.Maximum = Camera1._picture.ResolutionY;
                toolStripProgressBar1.Value = 0;
                ToSt_Task.Text = "Empfange Bild";
            }
            else
            {
                ToSt_Task.Text = "no Device connected!";
            }
        }


        /// <summary>
        /// This function will request the current status not only from the software object, but also from the camera hardware.
        /// Afterwards the form is updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_getCameraStatus_Click(object sender, EventArgs e)
        {
            if (Camera1.isConnected())
            {
                //configure the Statusbar
                toolStripProgressBar1.Maximum = Camera1.StatusRegisterList.Length;
                toolStripProgressBar1.Value = 0;
                //reset the read buffer in case of unused data
                Camera1.resetReceivedData();
                //reset the readcounter, which will count how many bytes are already received and processed
                Camera1.ReadCounter = 0;
                //Set the current status code
                Camera1.Programstatus = 60;
                //start the reading, more registers are read during the Programmstatus 60
                Camera1.readRegister(Camera1.StatusRegisterList[0]);
            }
            else
            {
                ToStSt_Connection.Text = "disconnected";
                ToStSt_Connection.ForeColor = Color.Red;
            }
        }

        private void cmd_LP_Save_Click(object sender, EventArgs e)
        {
            if (savePictureBoxToFile(PiBo_LeftPicture))
            {
                ToSt_Task.ForeColor = Color.Green;
                ToSt_Task.Text = "Bild wurde erfolgreich gespeichert!";
            }
            else
            {
                ToSt_Task.ForeColor = Color.Red;
                ToSt_Task.Text = "Bild konnte nicht gespeichert werden.";
            }
        }

        private void cmd_RP_Save_Click(object sender, EventArgs e)
        {
            if (savePictureBoxToFile(PiBo_RightPicture))
            {
                ToSt_Task.ForeColor = Color.Green;
                ToSt_Task.Text = "Bild wurde erfolgreich gespeichert!";
            }
            else
            {
                ToSt_Task.ForeColor = Color.Red;
                ToSt_Task.Text = "Bild konnte nicht gespeichert werden.";
            }
        }

        private void ChBo_LP_Sync_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBo_LP_Sync.Checked == true)
            {
                PiBo_LeftPicture.Image = Camera1._picture.Image;
            }
        }

        private void ChBo_RP_Sync_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBo_RP_Sync.Checked == true)
            {
                PiBo_RightPicture.Image = Camera1._picture.Image;
            }
        }

        //TODO: Complete function for comparing images. What do you want to Compare? Colors, Brightness?
        private void cmd_CompareLpRp_Click(object sender, EventArgs e)
        {
            if (PiBo_LeftPicture.Image == null || PiBo_RightPicture.Image == null)
            {
                MessageBox.Show("Zum vergleichen muss auf jeder Seite ein Bild vorhanden sein.", "Fehlendes Bild",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Image LeftImage = PiBo_LeftPicture.Image;
            Image RightImage = PiBo_RightPicture.Image;
            Image PictureToShow = compareImages(LeftImage, RightImage);
            Form _compareImages = new ComparePictures(PictureToShow);
            _compareImages.Show();




        }

        private Image compareImages(Image firstImage, Image secondImage)
        {

            int maxWidth = firstImage.Width;
            int maxHeight = firstImage.Height;
            if (maxWidth < secondImage.Width)
            {
                maxWidth = secondImage.Width;
            }

            if (maxHeight < secondImage.Height)
            {
                maxHeight = secondImage.Height;
            }

            Image combinedImage = new Bitmap(maxWidth, maxHeight);
            //TODO: finish compare function


            return combinedImage;
        }

        private void cmd_Initialisierung_Click(object sender, EventArgs e)
        {
            if (Camera1.isConnected())
            {
                Camera1.Programstatus = 8;
                setStatus("initialisiere Kamera");
                Camera1.initializeCamera();
            }
            else
            {
                setStatus("No Device connected", Color.Red);
            }
        }

        private void setStatus(string Title)
        {
            ToSt_Task.Text = Title;
            ToSt_Task.ForeColor = Color.Black;
            RiTeBo_history.Text += "(" + DateTime.Now.ToString("hh:mm:ss") + ") " + Title + "\n";
            ToSt_Progress.Visible = false;
        }
        private void setStatus(string Title, Color _ColorToSet)
        {
            ToSt_Task.Text = Title;
            ToSt_Task.ForeColor = _ColorToSet;
            RiTeBo_history.Text += "(" + DateTime.Now.ToString("hh:mm:ss") + ") " + Title + "\n";
            ToSt_Progress.Visible = false;
        }
        private void setStatus(string Title, string Progress, Color _ColorToSet)
        {
            ToSt_Task.Text = Title;
            ToSt_Task.ForeColor = _ColorToSet;
            RiTeBo_history.Text = "(" + DateTime.Now.ToString("hh:mm:ss") + ") " + Title + "\n";
            ToSt_Progress.Visible = true;
            ToSt_Progress.Text = Progress;
        }


        private void CoBo_ComPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lbl_Port_Status_Click(object sender, EventArgs e)
        {

        }

        private void CoBo_ComPort_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateComList();
        }

        private void cmd_TakeCompleteImage_Click(object sender, EventArgs e)
        {
            if (Camera1.isConnected())
            {
                //stop the sniffer event
                Camera1.RxDataSnifferComplete -= Camera1RxDataSniffed;
                
                Camera1.Programstatus = 2;
                Camera1.ReadCounter = 0;
                Camera1.UpdatePicture();
                Camera1.TakePictureComplete();
                toolStripProgressBar1.Maximum = Camera1._picture.ResolutionY;
                toolStripProgressBar1.Value = 0;
                setStatus("Empfange Bild");
            }
            else
            {
                ToSt_Task.Text = "no Device connected!";
            }
        }

        private void cmd_requestImage_Click(object sender, EventArgs e)
        {
            try
            {
                int _xres = int.Parse(TeBo_xRes.Text);
                int _yres = int.Parse(TeBo_yRes.Text);
                int _BytesPerPixel = int.Parse(TeBo_BPP.Text);

                Camera1._picture.ResolutionX = _xres;
                Camera1._picture.ResolutionY = _yres;
                Camera1._picture.BytesPerPixel = _BytesPerPixel;
                Camera1.SetResolutionFormatManually(EnumResolutionFormat.manually);

                if (RaBu_RGB565.Checked == true)
                {
                    Camera1.SetColorFormatManualy(EnumColorFormat.RGB565);
                }
                else
                {
                    Camera1.SetColorFormatManualy(EnumColorFormat.NotSelected);
                }

                Camera1.UpdatePicture();//set the resolution of the picture
                Camera1.Programstatus = 90;  //Wait for picture

            }
            catch (FormatException Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

        private void cmd_SafeToStruct_Click(object sender, EventArgs e)
        {
            Camera1.saveSettingsToStruct();
        }

        private void cmd_OpenFromStruct_Click(object sender, EventArgs e)
        {
            openSettingsFile(LiVi_LoadedSettings, 2);
        }

        private void cmd_GetManualPicture_With_Commands_Click(object sender, EventArgs e)
        {
            try
            {
                int _xres = int.Parse(TeBo_xRes.Text);
                int _yres = int.Parse(TeBo_yRes.Text);
                int _BytesPerPixel = int.Parse(TeBo_BPP.Text);

                Camera1._picture.ResolutionX = _xres;
                Camera1._picture.ResolutionY = _yres;
                Camera1._picture.BytesPerPixel = _BytesPerPixel;
                Camera1.startSendResColFormatToCamera();

                if (RaBu_RGB565.Checked == true)
                {
                    Camera1.SetColorFormatManualy(EnumColorFormat.RGB565);
                }
                else
                {
                    Camera1.SetColorFormatManualy(EnumColorFormat.NotSelected);
                }
                Camera1.UpdatePicture();
                Camera1.TakePictureComplete();
                Camera1.Programstatus = 90;  //Wait for picture

            }
            catch (FormatException Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

        private void cmd_compareLists_Click(object sender, EventArgs e)
        {
            compareLists(LiVi_LoadedSettings, Camera1);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ToStStLbl_Programmstatus_MouseHover(object sender, EventArgs e)
        {

        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "OV76701_Terminal_help.chm");
            Help.ShowHelpIndex(this, "OV76701_Terminal_help.chm");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Camera1.syncBetweenCameraAndTerminal();
        }

        private void RiTeBo_history_TextChanged(object sender, EventArgs e)
        {
            //set caret position to the end
            RiTeBo_history.SelectionStart = RiTeBo_history.Text.Length;
            //Scroll to caret
            RiTeBo_history.ScrollToCaret();
        }

        private void RiTeBo_receive_TextChanged(object sender, EventArgs e)
        {

        }

        private void LiBo_DeviceSettings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GrBo_ComPort_Enter(object sender, EventArgs e)
        {

        }
    }

}
