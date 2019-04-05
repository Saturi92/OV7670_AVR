using System.Collections.Generic;
using System.Drawing;

namespace OV7670_Terminal
{
    class PictureRow
    {
        public IList<ColorFormat> pixelRowList = new List<ColorFormat>();
        private int _xRes = 0;
        private int _pixelInserted = 0;
        private EnumColorFormat _myColorFormat = EnumColorFormat.NotSelected;

        public PictureRow(int xRes, EnumColorFormat theColorFormat)
        {
            _xRes = xRes;
            _pixelInserted = 0;
            _myColorFormat = theColorFormat;
        }

        /// <summary>
        /// clears the List of Pixels and resets the counter
        /// </summary>
        public void ResetPictureRow()
        {
            pixelRowList.Clear();
            _pixelInserted = 0;
        }

        /// <summary>
        /// add a Pixel to the PictureRow and rise the counter by one
        /// </summary>
        /// <param name="pixelColor"></param>
        /// Color of the Pixel, must be in accordance to the ColorFormat of the Pixelrow
        /// <returns></returns>
        /// 0: everything okay
        /// -1: unknown ColorFormat
        /// -2: more Pixels then expacted
        public int AddPixel(Color pixelColor)
        {
            //configure the new Pixel
            ColorFormat newColor = new ColorFormat();
            if (_myColorFormat == EnumColorFormat.ProcessedBayerRaw || _myColorFormat == EnumColorFormat.YUV)
            {
                newColor.ColorRgb888 = pixelColor;
            }
            else if (_myColorFormat == EnumColorFormat.RGB565)
            {
                newColor.ColorRgb888 = pixelColor;
            }
           

            //if no suitable Colorformat was set, return an errorcode
            else
            {
                return -1;
            }

            // if mor pixels will be added as expacted, return an errorcode
            if (_pixelInserted >= _xRes)
            {
                return -2;
            }

            //Add the pixel to the List
            pixelRowList.Add(newColor);
            _pixelInserted++;

            return 0;

        }

        public int xRes
        {
            get { return _xRes; }
        }
    }
}
