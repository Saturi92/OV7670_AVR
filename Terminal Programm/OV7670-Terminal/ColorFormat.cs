using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OV7670_Terminal
{
    class ColorFormat
    {
        Color RGB565 = new Color();
        Color RGB888 = new Color();
        byte[] RGB565Value = { 0, 0 };
        byte[] RGB888Value = { 0, 0, 0 };

        public ColorFormat()
        {
            //Konstruktor
        }

        //public methods
        public Color ColorRgb565
        {
            get { return RGB565; }
            set
            {
                RGB565 = value;
                RGB888 = convertRGB565ToRGB888(value);
                RGB565Value = convertRGB565toArray565(value);
            }
        }
        public Color ColorRgb888
        {
            get { return RGB888; }
            set
            {
                RGB888 = value;
                RGB565 = convertRGB888toRGB565(value);
                RGB565Value = convertRGB565toArray565(RGB565);
            }
        }
        public byte[] ColorRgb565Value
        {
            get { return RGB565Value; }
            set
            {
                RGB565Value = value;
                RGB565 = convertArray565ToRGB565(RGB565Value);
                RGB888 = convertRGB565ToRGB888(RGB565);
            }
        }
        public byte[] ColorRgb888Value
        {
            get { return RGB888Value; }
            set
            {
                RGB888Value = value;
                RGB888 = convertArray888ToRGB888(value);
                RGB565 = convertRGB888toRGB565(RGB888);
            }
        }
        
        //internal methods

        private Color convertRGB565ToRGB888(Color RGB565Color)
        {
            var RGB888Color = new Color();
            var R = (float)RGB565Color.R / (float)31 * (float)255;
            var G = (float)RGB565Color.G / (float)63 * (float)255;
            var B = (float)RGB565Color.B / (float)31 * (float)255;
            RGB888Color = Color.FromArgb((byte)R, (byte)G, (byte)B);
            return RGB888Color;
        }

        private Color convertRGB888toRGB565(Color RGB888Color)
        {
            var RGB565Color = new Color();
            var R = (float)RGB888Color.R / 255 * 31;
            var G = (float)RGB888Color.G / 255 * 31;
            var B = (float)RGB888Color.B / 255 * 31;
            RGB565Color = Color.FromArgb((byte)R, (byte)G, (byte)B);

            return RGB565Color;
        }

        /// <summary>
        /// this function converts a Color with RGB565Values to an array with the two necessary Bytes.
        /// </summary>
        /// <param name="RGB565Color"></param>
        /// <returns></returns>
        private byte[] convertRGB565toArray565(Color RGB565Color)
        {
            var myArray = new byte[2];

            myArray[0] = (byte)((RGB565Color.R << 3) & 0xF8);
            myArray[0] |= (byte)((RGB565Color.G >> 3) & 0x07);
            myArray[1] = (byte)((RGB565Color.G & 0x07) << 5);
            myArray[1] |= (byte)(RGB565Color.B & 0x1F);

            return myArray;
        }

        /// <summary>
        /// This function converts an array in RGB565 format with the length 2 into a Color with RGB565 value
        /// 
        /// </summary>
        /// <param name="ColorArray"></param>
        /// The Color Array with the length 2 in RGB565 Format
        /// <returns>name="newColor"</returns>
        /// returns the Color format with a spectrum from 0 to 31 in one Color
        private Color convertArray565ToRGB565(byte[] ColorArray)
        {
            var newColor = new Color();
            byte Byte_R;
            byte Byte_G;
            byte Byte_B;

            if (ColorArray.Length < 2)  //Cancel because Arraylength is to short to extract the Color. Expected Array Length: 2
                return newColor;

            Byte_R = (byte)((ColorArray[0] & 0xF8) >> 3); //Mask the Green bits and shift them to normal Mode
            Byte_G = (byte)(((ColorArray[0] & 0x07)<<3) | ((ColorArray[1] & 0xE0) >> 5));
            Byte_B = (byte)(ColorArray[1] & 0x1F);

            newColor = Color.FromArgb(Byte_R, Byte_G, Byte_B);
            return newColor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ColorArray"></param>
        /// <returns></returns>
        private Color convertArray888ToRGB888(byte[] ColorArray)
        {
            var newColor = new Color();
            if (ColorArray.Length < 3)  //Cancel if Color is to short
                return newColor;

            newColor = Color.FromArgb(ColorArray[0], ColorArray[1], ColorArray[2]);
            return newColor;
        }

        private byte[] convertRGB888ToArray888(Color myColor)
        {
            var newArray = new byte[3];
            newArray[0] = myColor.R;
            newArray[1] = myColor.G;
            newArray[2] = myColor.B;

            return newArray;
        }

    }
}
