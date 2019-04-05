namespace OV7670_Terminal.Forms
{
    partial class ComparePictures
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PiBo_ComparedImage = new System.Windows.Forms.PictureBox();
            this.cmd_PictureSafe = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToSt_Status = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PiBo_ComparedImage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PiBo_ComparedImage
            // 
            this.PiBo_ComparedImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PiBo_ComparedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PiBo_ComparedImage.Location = new System.Drawing.Point(12, 12);
            this.PiBo_ComparedImage.Name = "PiBo_ComparedImage";
            this.PiBo_ComparedImage.Size = new System.Drawing.Size(649, 525);
            this.PiBo_ComparedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PiBo_ComparedImage.TabIndex = 0;
            this.PiBo_ComparedImage.TabStop = false;
            // 
            // cmd_PictureSafe
            // 
            this.cmd_PictureSafe.Location = new System.Drawing.Point(12, 552);
            this.cmd_PictureSafe.Name = "cmd_PictureSafe";
            this.cmd_PictureSafe.Size = new System.Drawing.Size(115, 23);
            this.cmd_PictureSafe.TabIndex = 1;
            this.cmd_PictureSafe.Text = "Bild speichern";
            this.cmd_PictureSafe.UseVisualStyleBackColor = true;
            this.cmd_PictureSafe.Click += new System.EventHandler(this.cmd_PictureSafe_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToSt_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 584);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(683, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ToSt_Status
            // 
            this.ToSt_Status.Name = "ToSt_Status";
            this.ToSt_Status.Size = new System.Drawing.Size(36, 17);
            this.ToSt_Status.Text = "initial";
            // 
            // ComparePictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 606);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmd_PictureSafe);
            this.Controls.Add(this.PiBo_ComparedImage);
            this.Name = "ComparePictures";
            this.Text = "Compared Pictures";
            this.Load += new System.EventHandler(this.ComparePictures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PiBo_ComparedImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PiBo_ComparedImage;
        private System.Windows.Forms.Button cmd_PictureSafe;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ToSt_Status;
    }
}