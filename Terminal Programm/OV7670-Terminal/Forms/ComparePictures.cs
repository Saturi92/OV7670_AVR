using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OV7670_Terminal.Forms
{
    public partial class ComparePictures : Form
    {
        private Image _myImage;

        public ComparePictures(Image ImageToShow)
        {
            InitializeComponent();
            _myImage = ImageToShow;
        }
        private void ComparePictures_Load(object sender, EventArgs e)
        {
            ToSt_Status.Text = "";
            PiBo_ComparedImage.Image = _myImage;
        }

        private void cmd_PictureSafe_Click(object sender, EventArgs e)
        {
            if (savePictureBoxToFile(PiBo_ComparedImage))
            {
                ToSt_Status.ForeColor = Color.Green;
                ToSt_Status.Text = "Bild wurde erfolgreich gespeichert!";
            }
            else
            {
                ToSt_Status.ForeColor = Color.Red;
                ToSt_Status.Text = "Bild konnte nicht gespeichert werden.";
            }
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
    }
}
