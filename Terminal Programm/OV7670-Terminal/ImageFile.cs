using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using System.Drawing;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OV7670_Terminal
{
    class ImageFile
    {
        
        //Constructor - Destructor
        public ImageFile()
        {
            ResolutionX = 0;
            ResolutionY = 0;
        }
        public ImageFile(int newResolutionX, int newResolutionY, int newBytesPerPixel)
        {
            ResolutionX = newResolutionX;
            ResolutionY = newResolutionY;
        }
        ~ImageFile()
        {

        }

        //Variables
        String _infoMessage = null;
        private int _rowCounter  = 0;

        //Properties
        public int ResolutionX { get; set;}
        public int ResolutionY { get; set;}
        public int BytesPerPixel { get; set; }
        public Bitmap Image { get; set; } = null;
        public EnumColorFormat myColorFormat { get; set; } = EnumColorFormat.NotSelected;

        //public Methods
        public bool ReadFile (StreamReader FileReader,int xRes, int yRes, int BytesPerPixelInFile, char[] sep)
        {
            int FehlerCounter = 0;
            MemoryStream Converted = new MemoryStream();

            while (!FileReader.EndOfStream)
            {

                String tempString = FileReader.ReadLine();
                String[] tempArray = tempString.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                                    
                //counterResX =  tempArray.Length / BytesPP;
                Byte[] tempCharArray = new Byte[tempArray.Length];
                if (tempCharArray.Length == xRes * BytesPerPixelInFile)
                {
                    for (int i = 0; i < xRes * BytesPerPixelInFile; i++)
                    {
                        tempCharArray[i] = Convert8BitBinToChar(tempArray[i]);
                    }
                }
                else
                {
                    FehlerCounter++;
                }
                Converted.Write(tempCharArray, 0, tempCharArray.Length);
                
            }
            Image = ConvertStreamToPicture_RGB888(Converted, xRes, yRes);
            _infoMessage = "" + FehlerCounter + " Zeilen konnten nicht gelesen werden.";
            return true;
        }
        public Bitmap ConvertStreamToPicture_RGB565(MemoryStream imageStream, int resX, int resY)
        {
            Bitmap myImage = new Bitmap(resX, resY);
            ColorFormat MyColor = new ColorFormat();
            byte[] PixelColor = new byte[2];

            imageStream.Position = 0;
            for(int y=0; y < resY; y++)
            {
                for(int x=0; x < resX; x++)
                {
                    imageStream.ReadAsync(PixelColor, 0, PixelColor.Length);
                    MyColor.ColorRgb565Value = PixelColor;
                    myImage.SetPixel(x, y, MyColor.ColorRgb888);
                }
            }

            return myImage;
        }
        public Bitmap ConvertStreamToPicture_RGB888(MemoryStream imageStream, int resX, int resY)
        {
            Bitmap myImage = new Bitmap(resX, resY);
            ColorFormat MyColor = new ColorFormat();
            byte[] pixelColor = new byte[3];

            imageStream.Position = 0;
            for (int y = 0; y < resY; y++)
            {
                for (int x = 0; x < resX; x++)
                {
                    imageStream.ReadAsync(pixelColor, 0, pixelColor.Length);
                    MyColor.ColorRgb888Value = pixelColor;
                    myImage.SetPixel(x, y, MyColor.ColorRgb888);
                }
            }
            return myImage;
        }

        public void ResetRowCounter()
        {
            _rowCounter = 0;
        }

        public int getRowCounter()
        {
            return _rowCounter;
        }

        public bool AddLineToImage(Color[] pixels)
        {
            if (pixels.Length < ResolutionX)
            {
                var notEnoughPixel = new Exception(message: $"There were not enough Pixel in this row!");
                MessageBox.Show(notEnoughPixel.Message);
                return false;
            }
            else if (pixels.Length > ResolutionX)
            {
                _infoMessage = "To many Pixels received for the Image resolution";
            }
            for (int i = 0; i < ResolutionX; i++)
            {
                Image.SetPixel(i, _rowCounter, pixels[i]);
            }

            _rowCounter++;
            return true;
        }
        public bool AddLineToImage(Color[] pixels, int row)
        {
            if (pixels.Length < ResolutionX)
            {
                var notEnoughPixel = new Exception(message: $"There were not enough Pixel in this row!");
                MessageBox.Show(notEnoughPixel.Message);
                return false;
            }
            else if (pixels.Length > ResolutionX)
            {
                _infoMessage = "To many Pixels received for the Image resolution";
            }
            for (int i = 0; i < ResolutionX; i++)
            {
                Image.SetPixel(i,row,pixels[i]);
            }
            return true;
        }
        /// <summary>
        /// This is the prefered function to add a complete row to an image.
        /// </summary>
        /// <param name="pictureRow"></param>
        /// an object that includes all information of one pixelrow
        /// <param name="row"></param>
        /// certain row number which should be added
        /// <returns></returns>
        /// 0: everything worked out proper
        /// -1: xResolution of image and of the Pixelrow do not match
        /// -2: the row number do not fit to the image
        public int AddLineToImage(PictureRow pictureRow, int row)
        {
            //if xResolution of PixelRow do not fit to xResolution of the Image return an error
            if (pictureRow.xRes != ResolutionX)
                return -1;
            if (row >= ResolutionY)
                return - 2;
            //write all Pixels into the Line.
            for (int i = 0; i < ResolutionX; i++)
            {
                Image.SetPixel(i, row, pictureRow.pixelRowList[i].ColorRgb888);
            }
            return 0;
        }
        /// <summary>
        /// This is the prefered function to add a complete row to an image. The rowCounter isincreases automaticly after adding a row 
        /// </summary>
        /// <param name="pictureRow"></param>
        /// an object that includes all information of one pixelrow
        /// <returns></returns>
        /// 0: everything worked out proper
        /// -1: xResolution of image and of the Pixelrow do not match
        /// -2: to many Lines would be added to the image
        public int AddLineToImage(PictureRow pictureRow)
        {
            //if xResolution of PixelRow do not fit to xResolution of the Image return an error
            if (pictureRow.xRes != ResolutionX)
                return -1;
            //check if not to many Lines will be added to the image
            if (_rowCounter >= ResolutionY)
                return -2;
            //write all Pixels into the Line.
            for (int i = 0; i < ResolutionX; i++)
            {
                Image.SetPixel(i, _rowCounter, pictureRow.pixelRowList[i].ColorRgb888);
            }
            _rowCounter++;
            return 0;
        }

        //private Methods
        private byte Convert8BitBinToChar(string myBinString)
        {
            var newByte = 0;
            for (var i = 0; (i < myBinString.Length) && (i < 8); i++)
            {
                newByte = newByte << 1;
                newByte |= myBinString[i] - 48;
            }
            return (byte)newByte;
        }



    }
}
