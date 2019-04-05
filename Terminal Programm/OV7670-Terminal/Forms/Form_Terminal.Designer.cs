namespace OV7670_Terminal
{
    partial class Form_Terminal
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PiBo_LeftPicture = new System.Windows.Forms.PictureBox();
            this.SePo_Camera = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.ToSt_Task = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToSt_Progress = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToStSt_Connection = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToStStLbl_Programmstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmd_LP_Save = new System.Windows.Forms.Button();
            this.cmd_LpToRp = new System.Windows.Forms.Button();
            this.CoBo_ComPort = new System.Windows.Forms.ComboBox();
            this.cmd_Port_connect = new System.Windows.Forms.Button();
            this.CoBo_Datenbits = new System.Windows.Forms.ComboBox();
            this.GrBo_ComPort = new System.Windows.Forms.GroupBox();
            this.lbl_handshake = new System.Windows.Forms.Label();
            this.CoBo_Handshake = new System.Windows.Forms.ComboBox();
            this.CoBo_Parit = new System.Windows.Forms.ComboBox();
            this.CoBo_Baudrate = new System.Windows.Forms.ComboBox();
            this.CoBo_StoppBits = new System.Windows.Forms.ComboBox();
            this.lbl_parity = new System.Windows.Forms.Label();
            this.lbl_Baud = new System.Windows.Forms.Label();
            this.lbl_Stoppbits = new System.Windows.Forms.Label();
            this.lbl_Datenbits = new System.Windows.Forms.Label();
            this.lbl_ComPort = new System.Windows.Forms.Label();
            this.lbl_Port_Status = new System.Windows.Forms.Label();
            this.cmd_Port_disconnect = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TaPa_Settings = new System.Windows.Forms.TabPage();
            this.GrBo_LoadedSettings = new System.Windows.Forms.GroupBox();
            this.LiVi_LoadedSettings = new System.Windows.Forms.ListView();
            this.Offline_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Offline_Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmd_OpenFromStruct = new System.Windows.Forms.Button();
            this.cmd_WriteAllRegister = new System.Windows.Forms.Button();
            this.cmd_loadSCCBSettings = new System.Windows.Forms.Button();
            this.GrBo_DeviceSettings = new System.Windows.Forms.GroupBox();
            this.LiVi_DeviceSettings = new System.Windows.Forms.ListView();
            this.Online_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Online_Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_ReadAllNotUpdated = new System.Windows.Forms.Label();
            this.cmd_ReadAllRegister = new System.Windows.Forms.Button();
            this.cmd_SaveSccbSettings = new System.Windows.Forms.Button();
            this.cmd_SafeToStruct = new System.Windows.Forms.Button();
            this.cmd_compareLists = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RaBu_Bin = new System.Windows.Forms.RadioButton();
            this.RaBu_Dez = new System.Windows.Forms.RadioButton();
            this.RaBu_Hex = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmd_readForChange = new System.Windows.Forms.Button();
            this.lbl_ReadResult = new System.Windows.Forms.Label();
            this.lbl_ReadRegister = new System.Windows.Forms.Label();
            this.TeBo_SettingResult = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TeBo_ReadRegister = new System.Windows.Forms.TextBox();
            this.cmd_ReadRegister = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbl_WriteRegister = new System.Windows.Forms.Label();
            this.lbl_WriteValue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TeBo_WriteData = new System.Windows.Forms.TextBox();
            this.TeBo_WriteRegister = new System.Windows.Forms.TextBox();
            this.cmd_WriteRegister = new System.Windows.Forms.Button();
            this.RiTeBo_history = new System.Windows.Forms.RichTextBox();
            this.TaPa_Image = new System.Windows.Forms.TabPage();
            this.GrBo_RightPicture = new System.Windows.Forms.GroupBox();
            this.lbl_RP_Height = new System.Windows.Forms.Label();
            this.ChBo_RP_Sync = new System.Windows.Forms.CheckBox();
            this.lbl_RP_Width = new System.Windows.Forms.Label();
            this.PiBo_RightPicture = new System.Windows.Forms.PictureBox();
            this.cmd_RP_Load = new System.Windows.Forms.Button();
            this.cmd_RP_Save = new System.Windows.Forms.Button();
            this.GrBo_LeftPicture = new System.Windows.Forms.GroupBox();
            this.lbl_LP_Height = new System.Windows.Forms.Label();
            this.lbl_LP_Width = new System.Windows.Forms.Label();
            this.ChBo_LP_Sync = new System.Windows.Forms.CheckBox();
            this.cmd_LP_Load = new System.Windows.Forms.Button();
            this.cmd_CompareLpRp = new System.Windows.Forms.Button();
            this.cmd_RpToLp = new System.Windows.Forms.Button();
            this.TabPage_Capture = new System.Windows.Forms.TabPage();
            this.cmd_RGB888 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TeBo_yResolution = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TeBo_xResolution = new System.Windows.Forms.TextBox();
            this.TaPa_manu_mode = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.RaBu_RGB565 = new System.Windows.Forms.RadioButton();
            this.TeBo_xRes = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TeBo_yRes = new System.Windows.Forms.TextBox();
            this.cmd_GetManualPicture_With_Commands = new System.Windows.Forms.Button();
            this.cmd_requestImage = new System.Windows.Forms.Button();
            this.TeBo_BPP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_PictureInformation = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.PiBo_Manual = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.RaBu_LoadFileRgb565 = new System.Windows.Forms.RadioButton();
            this.TeBo_FileName = new System.Windows.Forms.TextBox();
            this.cmd_Durchsuchen = new System.Windows.Forms.Button();
            this.lbl_Filename = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.cmd_ComSend = new System.Windows.Forms.Button();
            this.RiTeBo_send = new System.Windows.Forms.RichTextBox();
            this.RiTeBo_receive = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.PiBo_ImageBox = new System.Windows.Forms.PictureBox();
            this.cmd_caputeImage = new System.Windows.Forms.Button();
            this.GrBo_Camera_Status = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_TestPattern = new System.Windows.Forms.Label();
            this.lbl_ColorFormat = new System.Windows.Forms.Label();
            this.lbl_OutPutResolution = new System.Windows.Forms.Label();
            this.lbl_VersionNo = new System.Windows.Forms.Label();
            this.cmd_getCameraStaturs = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog_LoadImage = new System.Windows.Forms.OpenFileDialog();
            this.cmd_Initialisierung = new System.Windows.Forms.Button();
            this.cmd_TakeCompleteImage = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_PictureDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PiBo_LeftPicture)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.GrBo_ComPort.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.TaPa_Settings.SuspendLayout();
            this.GrBo_LoadedSettings.SuspendLayout();
            this.GrBo_DeviceSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.TaPa_Image.SuspendLayout();
            this.GrBo_RightPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PiBo_RightPicture)).BeginInit();
            this.GrBo_LeftPicture.SuspendLayout();
            this.TabPage_Capture.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TaPa_manu_mode.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PiBo_Manual)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PiBo_ImageBox)).BeginInit();
            this.GrBo_Camera_Status.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PiBo_LeftPicture
            // 
            this.PiBo_LeftPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PiBo_LeftPicture.Location = new System.Drawing.Point(26, 51);
            this.PiBo_LeftPicture.Name = "PiBo_LeftPicture";
            this.PiBo_LeftPicture.Size = new System.Drawing.Size(294, 245);
            this.PiBo_LeftPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PiBo_LeftPicture.TabIndex = 0;
            this.PiBo_LeftPicture.TabStop = false;
            // 
            // SePo_Camera
            // 
            this.SePo_Camera.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SePo_Camera_DataReceived);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.ToSt_Task,
            this.ToSt_Progress,
            this.ToStSt_Connection,
            this.ToStStLbl_Programmstatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 656);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1114, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // ToSt_Task
            // 
            this.ToSt_Task.Name = "ToSt_Task";
            this.ToSt_Task.Size = new System.Drawing.Size(118, 17);
            this.ToSt_Task.Text = "toolStripStatusLabel1";
            // 
            // ToSt_Progress
            // 
            this.ToSt_Progress.Name = "ToSt_Progress";
            this.ToSt_Progress.Size = new System.Drawing.Size(52, 17);
            this.ToSt_Progress.Text = "Progress";
            // 
            // ToStSt_Connection
            // 
            this.ToStSt_Connection.ForeColor = System.Drawing.Color.Red;
            this.ToStSt_Connection.Name = "ToStSt_Connection";
            this.ToStSt_Connection.Size = new System.Drawing.Size(78, 17);
            this.ToStSt_Connection.Text = "disconnected";
            // 
            // ToStStLbl_Programmstatus
            // 
            this.ToStStLbl_Programmstatus.Name = "ToStStLbl_Programmstatus";
            this.ToStStLbl_Programmstatus.Size = new System.Drawing.Size(99, 17);
            this.ToStStLbl_Programmstatus.Text = "Program Modus: ";
            this.ToStStLbl_Programmstatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToStStLbl_Programmstatus.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            this.ToStStLbl_Programmstatus.MouseHover += new System.EventHandler(this.ToStStLbl_Programmstatus_MouseHover);
            // 
            // cmd_LP_Save
            // 
            this.cmd_LP_Save.Location = new System.Drawing.Point(26, 327);
            this.cmd_LP_Save.Name = "cmd_LP_Save";
            this.cmd_LP_Save.Size = new System.Drawing.Size(84, 23);
            this.cmd_LP_Save.TabIndex = 4;
            this.cmd_LP_Save.Text = "Bild speichern";
            this.cmd_LP_Save.UseVisualStyleBackColor = true;
            this.cmd_LP_Save.Click += new System.EventHandler(this.cmd_LP_Save_Click);
            // 
            // cmd_LpToRp
            // 
            this.cmd_LpToRp.Location = new System.Drawing.Point(354, 110);
            this.cmd_LpToRp.Name = "cmd_LpToRp";
            this.cmd_LpToRp.Size = new System.Drawing.Size(75, 23);
            this.cmd_LpToRp.TabIndex = 5;
            this.cmd_LpToRp.Text = "kopieren -->";
            this.cmd_LpToRp.UseVisualStyleBackColor = true;
            // 
            // CoBo_ComPort
            // 
            this.CoBo_ComPort.FormattingEnabled = true;
            this.CoBo_ComPort.Location = new System.Drawing.Point(77, 19);
            this.CoBo_ComPort.Name = "CoBo_ComPort";
            this.CoBo_ComPort.Size = new System.Drawing.Size(75, 21);
            this.CoBo_ComPort.TabIndex = 6;
            this.CoBo_ComPort.SelectedIndexChanged += new System.EventHandler(this.CoBo_ComPort_SelectedIndexChanged);
            this.CoBo_ComPort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CoBo_ComPort_MouseClick);
            // 
            // cmd_Port_connect
            // 
            this.cmd_Port_connect.Location = new System.Drawing.Point(9, 101);
            this.cmd_Port_connect.Name = "cmd_Port_connect";
            this.cmd_Port_connect.Size = new System.Drawing.Size(64, 23);
            this.cmd_Port_connect.TabIndex = 7;
            this.cmd_Port_connect.Text = "verbinden";
            this.cmd_Port_connect.UseVisualStyleBackColor = true;
            this.cmd_Port_connect.Click += new System.EventHandler(this.cmd_com_verbinden);
            // 
            // CoBo_Datenbits
            // 
            this.CoBo_Datenbits.FormattingEnabled = true;
            this.CoBo_Datenbits.Location = new System.Drawing.Point(77, 44);
            this.CoBo_Datenbits.Name = "CoBo_Datenbits";
            this.CoBo_Datenbits.Size = new System.Drawing.Size(75, 21);
            this.CoBo_Datenbits.TabIndex = 8;
            // 
            // GrBo_ComPort
            // 
            this.GrBo_ComPort.Controls.Add(this.lbl_handshake);
            this.GrBo_ComPort.Controls.Add(this.CoBo_Handshake);
            this.GrBo_ComPort.Controls.Add(this.CoBo_Parit);
            this.GrBo_ComPort.Controls.Add(this.CoBo_Baudrate);
            this.GrBo_ComPort.Controls.Add(this.CoBo_StoppBits);
            this.GrBo_ComPort.Controls.Add(this.lbl_parity);
            this.GrBo_ComPort.Controls.Add(this.lbl_Baud);
            this.GrBo_ComPort.Controls.Add(this.lbl_Stoppbits);
            this.GrBo_ComPort.Controls.Add(this.lbl_Datenbits);
            this.GrBo_ComPort.Controls.Add(this.lbl_ComPort);
            this.GrBo_ComPort.Controls.Add(this.lbl_Port_Status);
            this.GrBo_ComPort.Controls.Add(this.cmd_Port_disconnect);
            this.GrBo_ComPort.Controls.Add(this.CoBo_ComPort);
            this.GrBo_ComPort.Controls.Add(this.CoBo_Datenbits);
            this.GrBo_ComPort.Controls.Add(this.cmd_Port_connect);
            this.GrBo_ComPort.Location = new System.Drawing.Point(8, 6);
            this.GrBo_ComPort.Name = "GrBo_ComPort";
            this.GrBo_ComPort.Size = new System.Drawing.Size(334, 140);
            this.GrBo_ComPort.TabIndex = 9;
            this.GrBo_ComPort.TabStop = false;
            this.GrBo_ComPort.Text = "Com-Port";
            this.GrBo_ComPort.Enter += new System.EventHandler(this.GrBo_ComPort_Enter);
            // 
            // lbl_handshake
            // 
            this.lbl_handshake.AutoSize = true;
            this.lbl_handshake.Location = new System.Drawing.Point(158, 74);
            this.lbl_handshake.Name = "lbl_handshake";
            this.lbl_handshake.Size = new System.Drawing.Size(62, 13);
            this.lbl_handshake.TabIndex = 20;
            this.lbl_handshake.Text = "Handshake";
            // 
            // CoBo_Handshake
            // 
            this.CoBo_Handshake.FormattingEnabled = true;
            this.CoBo_Handshake.Location = new System.Drawing.Point(222, 71);
            this.CoBo_Handshake.Name = "CoBo_Handshake";
            this.CoBo_Handshake.Size = new System.Drawing.Size(98, 21);
            this.CoBo_Handshake.TabIndex = 19;
            // 
            // CoBo_Parit
            // 
            this.CoBo_Parit.FormattingEnabled = true;
            this.CoBo_Parit.Location = new System.Drawing.Point(222, 44);
            this.CoBo_Parit.Name = "CoBo_Parit";
            this.CoBo_Parit.Size = new System.Drawing.Size(98, 21);
            this.CoBo_Parit.TabIndex = 18;
            // 
            // CoBo_Baudrate
            // 
            this.CoBo_Baudrate.FormattingEnabled = true;
            this.CoBo_Baudrate.Location = new System.Drawing.Point(222, 17);
            this.CoBo_Baudrate.Name = "CoBo_Baudrate";
            this.CoBo_Baudrate.Size = new System.Drawing.Size(98, 21);
            this.CoBo_Baudrate.TabIndex = 17;
            // 
            // CoBo_StoppBits
            // 
            this.CoBo_StoppBits.FormattingEnabled = true;
            this.CoBo_StoppBits.Location = new System.Drawing.Point(77, 71);
            this.CoBo_StoppBits.Name = "CoBo_StoppBits";
            this.CoBo_StoppBits.Size = new System.Drawing.Size(75, 21);
            this.CoBo_StoppBits.TabIndex = 16;
            // 
            // lbl_parity
            // 
            this.lbl_parity.AutoSize = true;
            this.lbl_parity.Location = new System.Drawing.Point(158, 46);
            this.lbl_parity.Name = "lbl_parity";
            this.lbl_parity.Size = new System.Drawing.Size(37, 13);
            this.lbl_parity.TabIndex = 15;
            this.lbl_parity.Text = "Parität";
            // 
            // lbl_Baud
            // 
            this.lbl_Baud.AutoSize = true;
            this.lbl_Baud.Location = new System.Drawing.Point(158, 20);
            this.lbl_Baud.Name = "lbl_Baud";
            this.lbl_Baud.Size = new System.Drawing.Size(50, 13);
            this.lbl_Baud.TabIndex = 14;
            this.lbl_Baud.Text = "Baudrate";
            // 
            // lbl_Stoppbits
            // 
            this.lbl_Stoppbits.AutoSize = true;
            this.lbl_Stoppbits.Location = new System.Drawing.Point(6, 71);
            this.lbl_Stoppbits.Name = "lbl_Stoppbits";
            this.lbl_Stoppbits.Size = new System.Drawing.Size(51, 13);
            this.lbl_Stoppbits.TabIndex = 13;
            this.lbl_Stoppbits.Text = "Stoppbits";
            // 
            // lbl_Datenbits
            // 
            this.lbl_Datenbits.AutoSize = true;
            this.lbl_Datenbits.Location = new System.Drawing.Point(6, 47);
            this.lbl_Datenbits.Name = "lbl_Datenbits";
            this.lbl_Datenbits.Size = new System.Drawing.Size(52, 13);
            this.lbl_Datenbits.TabIndex = 12;
            this.lbl_Datenbits.Text = "Datenbits";
            // 
            // lbl_ComPort
            // 
            this.lbl_ComPort.AutoSize = true;
            this.lbl_ComPort.Location = new System.Drawing.Point(6, 22);
            this.lbl_ComPort.Name = "lbl_ComPort";
            this.lbl_ComPort.Size = new System.Drawing.Size(53, 13);
            this.lbl_ComPort.TabIndex = 11;
            this.lbl_ComPort.Text = "COM-Port";
            // 
            // lbl_Port_Status
            // 
            this.lbl_Port_Status.AutoSize = true;
            this.lbl_Port_Status.ForeColor = System.Drawing.Color.Red;
            this.lbl_Port_Status.Location = new System.Drawing.Point(219, 106);
            this.lbl_Port_Status.Name = "lbl_Port_Status";
            this.lbl_Port_Status.Size = new System.Drawing.Size(82, 13);
            this.lbl_Port_Status.TabIndex = 10;
            this.lbl_Port_Status.Text = "Status: getrennt";
            this.lbl_Port_Status.Click += new System.EventHandler(this.lbl_Port_Status_Click);
            // 
            // cmd_Port_disconnect
            // 
            this.cmd_Port_disconnect.Enabled = false;
            this.cmd_Port_disconnect.Location = new System.Drawing.Point(79, 101);
            this.cmd_Port_disconnect.Name = "cmd_Port_disconnect";
            this.cmd_Port_disconnect.Size = new System.Drawing.Size(73, 23);
            this.cmd_Port_disconnect.TabIndex = 9;
            this.cmd_Port_disconnect.Text = "trennen";
            this.cmd_Port_disconnect.UseVisualStyleBackColor = true;
            this.cmd_Port_disconnect.Click += new System.EventHandler(this.cmd_Port_disconnect_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TaPa_Settings);
            this.TabControl.Controls.Add(this.TaPa_Image);
            this.TabControl.Controls.Add(this.TabPage_Capture);
            this.TabControl.Controls.Add(this.TaPa_manu_mode);
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Location = new System.Drawing.Point(6, 31);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(589, 622);
            this.TabControl.TabIndex = 11;
            // 
            // TaPa_Settings
            // 
            this.TaPa_Settings.Controls.Add(this.GrBo_LoadedSettings);
            this.TaPa_Settings.Controls.Add(this.GrBo_DeviceSettings);
            this.TaPa_Settings.Controls.Add(this.cmd_compareLists);
            this.TaPa_Settings.Controls.Add(this.groupBox3);
            this.TaPa_Settings.Controls.Add(this.RiTeBo_history);
            this.TaPa_Settings.Controls.Add(this.GrBo_ComPort);
            this.TaPa_Settings.Location = new System.Drawing.Point(4, 22);
            this.TaPa_Settings.Name = "TaPa_Settings";
            this.TaPa_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.TaPa_Settings.Size = new System.Drawing.Size(581, 596);
            this.TaPa_Settings.TabIndex = 1;
            this.TaPa_Settings.Text = "Settings";
            this.TaPa_Settings.UseVisualStyleBackColor = true;
            // 
            // GrBo_LoadedSettings
            // 
            this.GrBo_LoadedSettings.Controls.Add(this.LiVi_LoadedSettings);
            this.GrBo_LoadedSettings.Controls.Add(this.cmd_OpenFromStruct);
            this.GrBo_LoadedSettings.Controls.Add(this.cmd_WriteAllRegister);
            this.GrBo_LoadedSettings.Controls.Add(this.cmd_loadSCCBSettings);
            this.GrBo_LoadedSettings.Location = new System.Drawing.Point(461, 6);
            this.GrBo_LoadedSettings.Name = "GrBo_LoadedSettings";
            this.GrBo_LoadedSettings.Size = new System.Drawing.Size(112, 433);
            this.GrBo_LoadedSettings.TabIndex = 34;
            this.GrBo_LoadedSettings.TabStop = false;
            this.GrBo_LoadedSettings.Text = "Loaded Settings";
            // 
            // LiVi_LoadedSettings
            // 
            this.LiVi_LoadedSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Offline_Address,
            this.Offline_Value});
            this.LiVi_LoadedSettings.LabelEdit = true;
            this.LiVi_LoadedSettings.Location = new System.Drawing.Point(6, 17);
            this.LiVi_LoadedSettings.Name = "LiVi_LoadedSettings";
            this.LiVi_LoadedSettings.Size = new System.Drawing.Size(94, 292);
            this.LiVi_LoadedSettings.TabIndex = 32;
            this.LiVi_LoadedSettings.UseCompatibleStateImageBehavior = false;
            this.LiVi_LoadedSettings.View = System.Windows.Forms.View.Details;
            // 
            // Offline_Address
            // 
            this.Offline_Address.Text = "Address";
            this.Offline_Address.Width = 50;
            // 
            // Offline_Value
            // 
            this.Offline_Value.Text = "Value";
            this.Offline_Value.Width = 39;
            // 
            // cmd_OpenFromStruct
            // 
            this.cmd_OpenFromStruct.Location = new System.Drawing.Point(6, 400);
            this.cmd_OpenFromStruct.Name = "cmd_OpenFromStruct";
            this.cmd_OpenFromStruct.Size = new System.Drawing.Size(94, 23);
            this.cmd_OpenFromStruct.TabIndex = 29;
            this.cmd_OpenFromStruct.Text = "open from struct";
            this.cmd_OpenFromStruct.UseVisualStyleBackColor = true;
            this.cmd_OpenFromStruct.Click += new System.EventHandler(this.cmd_OpenFromStruct_Click);
            // 
            // cmd_WriteAllRegister
            // 
            this.cmd_WriteAllRegister.Location = new System.Drawing.Point(6, 329);
            this.cmd_WriteAllRegister.Name = "cmd_WriteAllRegister";
            this.cmd_WriteAllRegister.Size = new System.Drawing.Size(94, 36);
            this.cmd_WriteAllRegister.TabIndex = 31;
            this.cmd_WriteAllRegister.Text = "Write Device Settings";
            this.cmd_WriteAllRegister.UseVisualStyleBackColor = true;
            this.cmd_WriteAllRegister.Click += new System.EventHandler(this.cmd_WriteAllRegister_Click);
            // 
            // cmd_loadSCCBSettings
            // 
            this.cmd_loadSCCBSettings.Location = new System.Drawing.Point(6, 371);
            this.cmd_loadSCCBSettings.Name = "cmd_loadSCCBSettings";
            this.cmd_loadSCCBSettings.Size = new System.Drawing.Size(94, 23);
            this.cmd_loadSCCBSettings.TabIndex = 29;
            this.cmd_loadSCCBSettings.Text = "open from csv";
            this.cmd_loadSCCBSettings.UseVisualStyleBackColor = true;
            this.cmd_loadSCCBSettings.Click += new System.EventHandler(this.cmd_loadSCCBSettings_Click);
            // 
            // GrBo_DeviceSettings
            // 
            this.GrBo_DeviceSettings.Controls.Add(this.LiVi_DeviceSettings);
            this.GrBo_DeviceSettings.Controls.Add(this.lbl_ReadAllNotUpdated);
            this.GrBo_DeviceSettings.Controls.Add(this.cmd_ReadAllRegister);
            this.GrBo_DeviceSettings.Controls.Add(this.cmd_SaveSccbSettings);
            this.GrBo_DeviceSettings.Controls.Add(this.cmd_SafeToStruct);
            this.GrBo_DeviceSettings.Location = new System.Drawing.Point(348, 6);
            this.GrBo_DeviceSettings.Name = "GrBo_DeviceSettings";
            this.GrBo_DeviceSettings.Size = new System.Drawing.Size(107, 433);
            this.GrBo_DeviceSettings.TabIndex = 33;
            this.GrBo_DeviceSettings.TabStop = false;
            this.GrBo_DeviceSettings.Text = "Device Settings";
            // 
            // LiVi_DeviceSettings
            // 
            this.LiVi_DeviceSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Online_Address,
            this.Online_Value});
            this.LiVi_DeviceSettings.LabelEdit = true;
            this.LiVi_DeviceSettings.Location = new System.Drawing.Point(6, 17);
            this.LiVi_DeviceSettings.Name = "LiVi_DeviceSettings";
            this.LiVi_DeviceSettings.Size = new System.Drawing.Size(94, 292);
            this.LiVi_DeviceSettings.TabIndex = 32;
            this.LiVi_DeviceSettings.UseCompatibleStateImageBehavior = false;
            this.LiVi_DeviceSettings.View = System.Windows.Forms.View.Details;
            // 
            // Online_Address
            // 
            this.Online_Address.Text = "Address";
            this.Online_Address.Width = 50;
            // 
            // Online_Value
            // 
            this.Online_Value.Text = "Value";
            this.Online_Value.Width = 39;
            // 
            // lbl_ReadAllNotUpdated
            // 
            this.lbl_ReadAllNotUpdated.AutoSize = true;
            this.lbl_ReadAllNotUpdated.ForeColor = System.Drawing.Color.Red;
            this.lbl_ReadAllNotUpdated.Location = new System.Drawing.Point(8, 313);
            this.lbl_ReadAllNotUpdated.Name = "lbl_ReadAllNotUpdated";
            this.lbl_ReadAllNotUpdated.Size = new System.Drawing.Size(92, 13);
            this.lbl_ReadAllNotUpdated.TabIndex = 0;
            this.lbl_ReadAllNotUpdated.Text = "List not up to date";
            // 
            // cmd_ReadAllRegister
            // 
            this.cmd_ReadAllRegister.Enabled = false;
            this.cmd_ReadAllRegister.Location = new System.Drawing.Point(6, 329);
            this.cmd_ReadAllRegister.Name = "cmd_ReadAllRegister";
            this.cmd_ReadAllRegister.Size = new System.Drawing.Size(94, 36);
            this.cmd_ReadAllRegister.TabIndex = 25;
            this.cmd_ReadAllRegister.Text = "Read Device Settings";
            this.cmd_ReadAllRegister.UseVisualStyleBackColor = true;
            this.cmd_ReadAllRegister.Click += new System.EventHandler(this.ReadAllRegister_Click);
            // 
            // cmd_SaveSccbSettings
            // 
            this.cmd_SaveSccbSettings.Location = new System.Drawing.Point(6, 371);
            this.cmd_SaveSccbSettings.Name = "cmd_SaveSccbSettings";
            this.cmd_SaveSccbSettings.Size = new System.Drawing.Size(94, 23);
            this.cmd_SaveSccbSettings.TabIndex = 28;
            this.cmd_SaveSccbSettings.Text = "safe to csv";
            this.cmd_SaveSccbSettings.UseVisualStyleBackColor = true;
            this.cmd_SaveSccbSettings.Click += new System.EventHandler(this.cmd_safeSCCBSettings_Click);
            // 
            // cmd_SafeToStruct
            // 
            this.cmd_SafeToStruct.Location = new System.Drawing.Point(6, 400);
            this.cmd_SafeToStruct.Name = "cmd_SafeToStruct";
            this.cmd_SafeToStruct.Size = new System.Drawing.Size(94, 23);
            this.cmd_SafeToStruct.TabIndex = 28;
            this.cmd_SafeToStruct.Text = "safe to struct";
            this.cmd_SafeToStruct.UseVisualStyleBackColor = true;
            this.cmd_SafeToStruct.Click += new System.EventHandler(this.cmd_SafeToStruct_Click);
            // 
            // cmd_compareLists
            // 
            this.cmd_compareLists.Location = new System.Drawing.Point(258, 416);
            this.cmd_compareLists.Name = "cmd_compareLists";
            this.cmd_compareLists.Size = new System.Drawing.Size(84, 23);
            this.cmd_compareLists.TabIndex = 28;
            this.cmd_compareLists.Text = "compare Lists";
            this.cmd_compareLists.UseVisualStyleBackColor = true;
            this.cmd_compareLists.Click += new System.EventHandler(this.cmd_compareLists_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Location = new System.Drawing.Point(8, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 236);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "manual setting adjustment";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RaBu_Bin);
            this.groupBox4.Controls.Add(this.RaBu_Dez);
            this.groupBox4.Controls.Add(this.RaBu_Hex);
            this.groupBox4.Location = new System.Drawing.Point(6, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(163, 50);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Format";
            // 
            // RaBu_Bin
            // 
            this.RaBu_Bin.AutoSize = true;
            this.RaBu_Bin.Location = new System.Drawing.Point(6, 19);
            this.RaBu_Bin.Name = "RaBu_Bin";
            this.RaBu_Bin.Size = new System.Drawing.Size(40, 17);
            this.RaBu_Bin.TabIndex = 25;
            this.RaBu_Bin.TabStop = true;
            this.RaBu_Bin.Text = "Bin";
            this.RaBu_Bin.UseVisualStyleBackColor = true;
            this.RaBu_Bin.CheckedChanged += new System.EventHandler(this.RaBu_Bin_CheckedChanged);
            // 
            // RaBu_Dez
            // 
            this.RaBu_Dez.AutoSize = true;
            this.RaBu_Dez.Location = new System.Drawing.Point(52, 19);
            this.RaBu_Dez.Name = "RaBu_Dez";
            this.RaBu_Dez.Size = new System.Drawing.Size(44, 17);
            this.RaBu_Dez.TabIndex = 26;
            this.RaBu_Dez.TabStop = true;
            this.RaBu_Dez.Text = "Dez";
            this.RaBu_Dez.UseVisualStyleBackColor = true;
            this.RaBu_Dez.CheckedChanged += new System.EventHandler(this.RaBu_Dez_CheckedChanged);
            // 
            // RaBu_Hex
            // 
            this.RaBu_Hex.AutoSize = true;
            this.RaBu_Hex.Checked = true;
            this.RaBu_Hex.Location = new System.Drawing.Point(102, 21);
            this.RaBu_Hex.Name = "RaBu_Hex";
            this.RaBu_Hex.Size = new System.Drawing.Size(44, 17);
            this.RaBu_Hex.TabIndex = 24;
            this.RaBu_Hex.TabStop = true;
            this.RaBu_Hex.Text = "Hex";
            this.RaBu_Hex.UseVisualStyleBackColor = true;
            this.RaBu_Hex.CheckedChanged += new System.EventHandler(this.RaBu_Hex_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmd_readForChange);
            this.groupBox5.Controls.Add(this.lbl_ReadResult);
            this.groupBox5.Controls.Add(this.lbl_ReadRegister);
            this.groupBox5.Controls.Add(this.TeBo_SettingResult);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.TeBo_ReadRegister);
            this.groupBox5.Controls.Add(this.cmd_ReadRegister);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(6, 26);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(306, 74);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Read Register";
            // 
            // cmd_readForChange
            // 
            this.cmd_readForChange.Location = new System.Drawing.Point(202, 42);
            this.cmd_readForChange.Name = "cmd_readForChange";
            this.cmd_readForChange.Size = new System.Drawing.Size(98, 22);
            this.cmd_readForChange.TabIndex = 30;
            this.cmd_readForChange.Text = "read for change";
            this.cmd_readForChange.UseVisualStyleBackColor = true;
            this.cmd_readForChange.Click += new System.EventHandler(this.cmd_readForChange_Click);
            // 
            // lbl_ReadResult
            // 
            this.lbl_ReadResult.AutoSize = true;
            this.lbl_ReadResult.Location = new System.Drawing.Point(64, 48);
            this.lbl_ReadResult.Name = "lbl_ReadResult";
            this.lbl_ReadResult.Size = new System.Drawing.Size(18, 13);
            this.lbl_ReadResult.TabIndex = 29;
            this.lbl_ReadResult.Text = "0x";
            // 
            // lbl_ReadRegister
            // 
            this.lbl_ReadRegister.AutoSize = true;
            this.lbl_ReadRegister.Location = new System.Drawing.Point(64, 24);
            this.lbl_ReadRegister.Name = "lbl_ReadRegister";
            this.lbl_ReadRegister.Size = new System.Drawing.Size(18, 13);
            this.lbl_ReadRegister.TabIndex = 28;
            this.lbl_ReadRegister.Text = "0x";
            // 
            // TeBo_SettingResult
            // 
            this.TeBo_SettingResult.Enabled = false;
            this.TeBo_SettingResult.Location = new System.Drawing.Point(88, 45);
            this.TeBo_SettingResult.Name = "TeBo_SettingResult";
            this.TeBo_SettingResult.Size = new System.Drawing.Size(98, 20);
            this.TeBo_SettingResult.TabIndex = 27;
            this.TeBo_SettingResult.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Result:";
            // 
            // TeBo_ReadRegister
            // 
            this.TeBo_ReadRegister.Location = new System.Drawing.Point(88, 21);
            this.TeBo_ReadRegister.Name = "TeBo_ReadRegister";
            this.TeBo_ReadRegister.Size = new System.Drawing.Size(98, 20);
            this.TeBo_ReadRegister.TabIndex = 15;
            this.TeBo_ReadRegister.Text = "00";
            this.TeBo_ReadRegister.Leave += new System.EventHandler(this.TeBo_ReadRegister_Leave);
            // 
            // cmd_ReadRegister
            // 
            this.cmd_ReadRegister.Location = new System.Drawing.Point(202, 15);
            this.cmd_ReadRegister.Name = "cmd_ReadRegister";
            this.cmd_ReadRegister.Size = new System.Drawing.Size(98, 23);
            this.cmd_ReadRegister.TabIndex = 19;
            this.cmd_ReadRegister.Text = "read register";
            this.cmd_ReadRegister.UseVisualStyleBackColor = true;
            this.cmd_ReadRegister.Click += new System.EventHandler(this.cmd_ReadRegister_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Register:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbl_WriteRegister);
            this.groupBox6.Controls.Add(this.lbl_WriteValue);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.TeBo_WriteData);
            this.groupBox6.Controls.Add(this.TeBo_WriteRegister);
            this.groupBox6.Controls.Add(this.cmd_WriteRegister);
            this.groupBox6.Location = new System.Drawing.Point(6, 103);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(306, 74);
            this.groupBox6.TabIndex = 29;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Write Register";
            // 
            // lbl_WriteRegister
            // 
            this.lbl_WriteRegister.AutoSize = true;
            this.lbl_WriteRegister.Location = new System.Drawing.Point(64, 24);
            this.lbl_WriteRegister.Name = "lbl_WriteRegister";
            this.lbl_WriteRegister.Size = new System.Drawing.Size(18, 13);
            this.lbl_WriteRegister.TabIndex = 30;
            this.lbl_WriteRegister.Text = "0x";
            // 
            // lbl_WriteValue
            // 
            this.lbl_WriteValue.AutoSize = true;
            this.lbl_WriteValue.Location = new System.Drawing.Point(64, 47);
            this.lbl_WriteValue.Name = "lbl_WriteValue";
            this.lbl_WriteValue.Size = new System.Drawing.Size(18, 13);
            this.lbl_WriteValue.TabIndex = 31;
            this.lbl_WriteValue.Text = "0x";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "value:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Register:";
            // 
            // TeBo_WriteData
            // 
            this.TeBo_WriteData.Location = new System.Drawing.Point(88, 44);
            this.TeBo_WriteData.Name = "TeBo_WriteData";
            this.TeBo_WriteData.Size = new System.Drawing.Size(98, 20);
            this.TeBo_WriteData.TabIndex = 22;
            this.TeBo_WriteData.Text = "00";
            this.TeBo_WriteData.Leave += new System.EventHandler(this.TeBo_WriteData_Leave);
            // 
            // TeBo_WriteRegister
            // 
            this.TeBo_WriteRegister.Location = new System.Drawing.Point(88, 21);
            this.TeBo_WriteRegister.Name = "TeBo_WriteRegister";
            this.TeBo_WriteRegister.Size = new System.Drawing.Size(98, 20);
            this.TeBo_WriteRegister.TabIndex = 21;
            this.TeBo_WriteRegister.Text = "00";
            this.TeBo_WriteRegister.Leave += new System.EventHandler(this.TeBo_WriteRegister_Leave);
            // 
            // cmd_WriteRegister
            // 
            this.cmd_WriteRegister.Location = new System.Drawing.Point(202, 42);
            this.cmd_WriteRegister.Name = "cmd_WriteRegister";
            this.cmd_WriteRegister.Size = new System.Drawing.Size(98, 23);
            this.cmd_WriteRegister.TabIndex = 20;
            this.cmd_WriteRegister.Text = "write register";
            this.cmd_WriteRegister.UseVisualStyleBackColor = true;
            this.cmd_WriteRegister.Click += new System.EventHandler(this.cmd_WriteRegister_Click);
            // 
            // RiTeBo_history
            // 
            this.RiTeBo_history.Location = new System.Drawing.Point(17, 445);
            this.RiTeBo_history.Name = "RiTeBo_history";
            this.RiTeBo_history.Size = new System.Drawing.Size(556, 138);
            this.RiTeBo_history.TabIndex = 26;
            this.RiTeBo_history.Text = "";
            this.RiTeBo_history.TextChanged += new System.EventHandler(this.RiTeBo_history_TextChanged);
            // 
            // TaPa_Image
            // 
            this.TaPa_Image.Controls.Add(this.GrBo_RightPicture);
            this.TaPa_Image.Controls.Add(this.GrBo_LeftPicture);
            this.TaPa_Image.Controls.Add(this.cmd_CompareLpRp);
            this.TaPa_Image.Controls.Add(this.cmd_RpToLp);
            this.TaPa_Image.Controls.Add(this.cmd_LpToRp);
            this.TaPa_Image.Location = new System.Drawing.Point(4, 22);
            this.TaPa_Image.Name = "TaPa_Image";
            this.TaPa_Image.Padding = new System.Windows.Forms.Padding(3);
            this.TaPa_Image.Size = new System.Drawing.Size(809, 596);
            this.TaPa_Image.TabIndex = 0;
            this.TaPa_Image.Text = "_picture";
            this.TaPa_Image.UseVisualStyleBackColor = true;
            // 
            // GrBo_RightPicture
            // 
            this.GrBo_RightPicture.Controls.Add(this.lbl_RP_Height);
            this.GrBo_RightPicture.Controls.Add(this.ChBo_RP_Sync);
            this.GrBo_RightPicture.Controls.Add(this.lbl_RP_Width);
            this.GrBo_RightPicture.Controls.Add(this.PiBo_RightPicture);
            this.GrBo_RightPicture.Controls.Add(this.cmd_RP_Load);
            this.GrBo_RightPicture.Controls.Add(this.cmd_RP_Save);
            this.GrBo_RightPicture.Location = new System.Drawing.Point(438, 15);
            this.GrBo_RightPicture.Name = "GrBo_RightPicture";
            this.GrBo_RightPicture.Size = new System.Drawing.Size(370, 364);
            this.GrBo_RightPicture.TabIndex = 6;
            this.GrBo_RightPicture.TabStop = false;
            this.GrBo_RightPicture.Text = "Right Picture";
            // 
            // lbl_RP_Height
            // 
            this.lbl_RP_Height.AutoSize = true;
            this.lbl_RP_Height.Location = new System.Drawing.Point(129, 24);
            this.lbl_RP_Height.Name = "lbl_RP_Height";
            this.lbl_RP_Height.Size = new System.Drawing.Size(44, 13);
            this.lbl_RP_Height.TabIndex = 6;
            this.lbl_RP_Height.Text = "Height: ";
            // 
            // ChBo_RP_Sync
            // 
            this.ChBo_RP_Sync.AutoSize = true;
            this.ChBo_RP_Sync.Location = new System.Drawing.Point(26, 304);
            this.ChBo_RP_Sync.Name = "ChBo_RP_Sync";
            this.ChBo_RP_Sync.Size = new System.Drawing.Size(171, 17);
            this.ChBo_RP_Sync.TabIndex = 5;
            this.ChBo_RP_Sync.Text = "Mit Kamerabild synchronisieren";
            this.ChBo_RP_Sync.UseVisualStyleBackColor = true;
            this.ChBo_RP_Sync.CheckedChanged += new System.EventHandler(this.ChBo_RP_Sync_CheckedChanged);
            // 
            // lbl_RP_Width
            // 
            this.lbl_RP_Width.AutoSize = true;
            this.lbl_RP_Width.Location = new System.Drawing.Point(23, 24);
            this.lbl_RP_Width.Name = "lbl_RP_Width";
            this.lbl_RP_Width.Size = new System.Drawing.Size(41, 13);
            this.lbl_RP_Width.TabIndex = 6;
            this.lbl_RP_Width.Text = "Width: ";
            // 
            // PiBo_RightPicture
            // 
            this.PiBo_RightPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PiBo_RightPicture.Location = new System.Drawing.Point(26, 51);
            this.PiBo_RightPicture.Name = "PiBo_RightPicture";
            this.PiBo_RightPicture.Size = new System.Drawing.Size(321, 245);
            this.PiBo_RightPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PiBo_RightPicture.TabIndex = 0;
            this.PiBo_RightPicture.TabStop = false;
            // 
            // cmd_RP_Load
            // 
            this.cmd_RP_Load.Location = new System.Drawing.Point(125, 327);
            this.cmd_RP_Load.Name = "cmd_RP_Load";
            this.cmd_RP_Load.Size = new System.Drawing.Size(84, 23);
            this.cmd_RP_Load.TabIndex = 4;
            this.cmd_RP_Load.Text = "Bild laden";
            this.cmd_RP_Load.UseVisualStyleBackColor = true;
            this.cmd_RP_Load.Click += new System.EventHandler(this.cmd_LP_Save_Click);
            // 
            // cmd_RP_Save
            // 
            this.cmd_RP_Save.Location = new System.Drawing.Point(26, 327);
            this.cmd_RP_Save.Name = "cmd_RP_Save";
            this.cmd_RP_Save.Size = new System.Drawing.Size(93, 23);
            this.cmd_RP_Save.TabIndex = 4;
            this.cmd_RP_Save.Text = "Bild speichern";
            this.cmd_RP_Save.UseVisualStyleBackColor = true;
            this.cmd_RP_Save.Click += new System.EventHandler(this.cmd_RP_Save_Click);
            // 
            // GrBo_LeftPicture
            // 
            this.GrBo_LeftPicture.Controls.Add(this.lbl_LP_Height);
            this.GrBo_LeftPicture.Controls.Add(this.lbl_LP_Width);
            this.GrBo_LeftPicture.Controls.Add(this.ChBo_LP_Sync);
            this.GrBo_LeftPicture.Controls.Add(this.PiBo_LeftPicture);
            this.GrBo_LeftPicture.Controls.Add(this.cmd_LP_Load);
            this.GrBo_LeftPicture.Controls.Add(this.cmd_LP_Save);
            this.GrBo_LeftPicture.Location = new System.Drawing.Point(6, 15);
            this.GrBo_LeftPicture.Name = "GrBo_LeftPicture";
            this.GrBo_LeftPicture.Size = new System.Drawing.Size(342, 364);
            this.GrBo_LeftPicture.TabIndex = 6;
            this.GrBo_LeftPicture.TabStop = false;
            this.GrBo_LeftPicture.Text = "Left Picture";
            // 
            // lbl_LP_Height
            // 
            this.lbl_LP_Height.AutoSize = true;
            this.lbl_LP_Height.Location = new System.Drawing.Point(129, 24);
            this.lbl_LP_Height.Name = "lbl_LP_Height";
            this.lbl_LP_Height.Size = new System.Drawing.Size(44, 13);
            this.lbl_LP_Height.TabIndex = 6;
            this.lbl_LP_Height.Text = "Height: ";
            // 
            // lbl_LP_Width
            // 
            this.lbl_LP_Width.AutoSize = true;
            this.lbl_LP_Width.Location = new System.Drawing.Point(23, 24);
            this.lbl_LP_Width.Name = "lbl_LP_Width";
            this.lbl_LP_Width.Size = new System.Drawing.Size(41, 13);
            this.lbl_LP_Width.TabIndex = 6;
            this.lbl_LP_Width.Text = "Width: ";
            // 
            // ChBo_LP_Sync
            // 
            this.ChBo_LP_Sync.AutoSize = true;
            this.ChBo_LP_Sync.Location = new System.Drawing.Point(26, 304);
            this.ChBo_LP_Sync.Name = "ChBo_LP_Sync";
            this.ChBo_LP_Sync.Size = new System.Drawing.Size(171, 17);
            this.ChBo_LP_Sync.TabIndex = 5;
            this.ChBo_LP_Sync.Text = "Mit Kamerabild synchronisieren";
            this.ChBo_LP_Sync.UseVisualStyleBackColor = true;
            this.ChBo_LP_Sync.CheckedChanged += new System.EventHandler(this.ChBo_LP_Sync_CheckedChanged);
            // 
            // cmd_LP_Load
            // 
            this.cmd_LP_Load.Location = new System.Drawing.Point(116, 327);
            this.cmd_LP_Load.Name = "cmd_LP_Load";
            this.cmd_LP_Load.Size = new System.Drawing.Size(84, 23);
            this.cmd_LP_Load.TabIndex = 4;
            this.cmd_LP_Load.Text = "Bild laden";
            this.cmd_LP_Load.UseVisualStyleBackColor = true;
            this.cmd_LP_Load.Click += new System.EventHandler(this.cmd_LP_Save_Click);
            // 
            // cmd_CompareLpRp
            // 
            this.cmd_CompareLpRp.Location = new System.Drawing.Point(354, 198);
            this.cmd_CompareLpRp.Name = "cmd_CompareLpRp";
            this.cmd_CompareLpRp.Size = new System.Drawing.Size(75, 23);
            this.cmd_CompareLpRp.TabIndex = 5;
            this.cmd_CompareLpRp.Text = "vergleichen";
            this.cmd_CompareLpRp.UseVisualStyleBackColor = true;
            this.cmd_CompareLpRp.Click += new System.EventHandler(this.cmd_CompareLpRp_Click);
            // 
            // cmd_RpToLp
            // 
            this.cmd_RpToLp.Location = new System.Drawing.Point(354, 153);
            this.cmd_RpToLp.Name = "cmd_RpToLp";
            this.cmd_RpToLp.Size = new System.Drawing.Size(75, 23);
            this.cmd_RpToLp.TabIndex = 5;
            this.cmd_RpToLp.Text = "<-- kopieren";
            this.cmd_RpToLp.UseVisualStyleBackColor = true;
            // 
            // TabPage_Capture
            // 
            this.TabPage_Capture.Controls.Add(this.cmd_RGB888);
            this.TabPage_Capture.Controls.Add(this.button4);
            this.TabPage_Capture.Controls.Add(this.button3);
            this.TabPage_Capture.Controls.Add(this.groupBox2);
            this.TabPage_Capture.Controls.Add(this.groupBox1);
            this.TabPage_Capture.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Capture.Name = "TabPage_Capture";
            this.TabPage_Capture.Size = new System.Drawing.Size(809, 596);
            this.TabPage_Capture.TabIndex = 2;
            this.TabPage_Capture.Text = "Caputre Image";
            this.TabPage_Capture.UseVisualStyleBackColor = true;
            // 
            // cmd_RGB888
            // 
            this.cmd_RGB888.Location = new System.Drawing.Point(102, 162);
            this.cmd_RGB888.Name = "cmd_RGB888";
            this.cmd_RGB888.Size = new System.Drawing.Size(75, 23);
            this.cmd_RGB888.TabIndex = 18;
            this.cmd_RGB888.Text = "RGB888";
            this.cmd_RGB888.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(198, 162);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "RGB565";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 162);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "RAW";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(8, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 64);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Offset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "y";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "px";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "x";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(30, 22);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "px";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TeBo_yResolution);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TeBo_xResolution);
            this.groupBox1.Location = new System.Drawing.Point(8, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 64);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resulution";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "y";
            // 
            // TeBo_yResolution
            // 
            this.TeBo_yResolution.Location = new System.Drawing.Point(167, 22);
            this.TeBo_yResolution.Name = "TeBo_yResolution";
            this.TeBo_yResolution.Size = new System.Drawing.Size(100, 20);
            this.TeBo_yResolution.TabIndex = 14;
            this.TeBo_yResolution.Text = "px";
            this.TeBo_yResolution.Leave += new System.EventHandler(this.TeBo_yResolution_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "x";
            // 
            // TeBo_xResolution
            // 
            this.TeBo_xResolution.Location = new System.Drawing.Point(30, 22);
            this.TeBo_xResolution.Name = "TeBo_xResolution";
            this.TeBo_xResolution.Size = new System.Drawing.Size(100, 20);
            this.TeBo_xResolution.TabIndex = 12;
            this.TeBo_xResolution.Text = "px";
            this.TeBo_xResolution.Leave += new System.EventHandler(this.TeBo_xResolution_Leave);
            // 
            // TaPa_manu_mode
            // 
            this.TaPa_manu_mode.Controls.Add(this.groupBox8);
            this.TaPa_manu_mode.Controls.Add(this.lbl_PictureInformation);
            this.TaPa_manu_mode.Controls.Add(this.label12);
            this.TaPa_manu_mode.Controls.Add(this.PiBo_Manual);
            this.TaPa_manu_mode.Controls.Add(this.groupBox7);
            this.TaPa_manu_mode.Location = new System.Drawing.Point(4, 22);
            this.TaPa_manu_mode.Name = "TaPa_manu_mode";
            this.TaPa_manu_mode.Size = new System.Drawing.Size(809, 596);
            this.TaPa_manu_mode.TabIndex = 3;
            this.TaPa_manu_mode.Text = "Manueller Modus";
            this.TaPa_manu_mode.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.RaBu_RGB565);
            this.groupBox8.Controls.Add(this.TeBo_xRes);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.TeBo_yRes);
            this.groupBox8.Controls.Add(this.cmd_GetManualPicture_With_Commands);
            this.groupBox8.Controls.Add(this.cmd_requestImage);
            this.groupBox8.Controls.Add(this.TeBo_BPP);
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Location = new System.Drawing.Point(8, 148);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(321, 167);
            this.groupBox8.TabIndex = 37;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "groupBox8";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(221, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Bytes per Pixel";
            // 
            // RaBu_RGB565
            // 
            this.RaBu_RGB565.AutoSize = true;
            this.RaBu_RGB565.Checked = true;
            this.RaBu_RGB565.Location = new System.Drawing.Point(7, 32);
            this.RaBu_RGB565.Name = "RaBu_RGB565";
            this.RaBu_RGB565.Size = new System.Drawing.Size(66, 17);
            this.RaBu_RGB565.TabIndex = 4;
            this.RaBu_RGB565.TabStop = true;
            this.RaBu_RGB565.Text = "RGB565";
            this.RaBu_RGB565.UseVisualStyleBackColor = true;
            // 
            // TeBo_xRes
            // 
            this.TeBo_xRes.Location = new System.Drawing.Point(90, 32);
            this.TeBo_xRes.Name = "TeBo_xRes";
            this.TeBo_xRes.Size = new System.Drawing.Size(61, 20);
            this.TeBo_xRes.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(154, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Resolution y";
            // 
            // TeBo_yRes
            // 
            this.TeBo_yRes.Location = new System.Drawing.Point(157, 32);
            this.TeBo_yRes.Name = "TeBo_yRes";
            this.TeBo_yRes.Size = new System.Drawing.Size(61, 20);
            this.TeBo_yRes.TabIndex = 6;
            // 
            // cmd_GetManualPicture_With_Commands
            // 
            this.cmd_GetManualPicture_With_Commands.Location = new System.Drawing.Point(90, 81);
            this.cmd_GetManualPicture_With_Commands.Name = "cmd_GetManualPicture_With_Commands";
            this.cmd_GetManualPicture_With_Commands.Size = new System.Drawing.Size(96, 67);
            this.cmd_GetManualPicture_With_Commands.TabIndex = 1;
            this.cmd_GetManualPicture_With_Commands.Text = "Bild empfangen mit Start Kommando";
            this.cmd_GetManualPicture_With_Commands.UseVisualStyleBackColor = true;
            this.cmd_GetManualPicture_With_Commands.Click += new System.EventHandler(this.cmd_GetManualPicture_With_Commands_Click);
            // 
            // cmd_requestImage
            // 
            this.cmd_requestImage.Location = new System.Drawing.Point(201, 81);
            this.cmd_requestImage.Name = "cmd_requestImage";
            this.cmd_requestImage.Size = new System.Drawing.Size(96, 23);
            this.cmd_requestImage.TabIndex = 1;
            this.cmd_requestImage.Text = "Bild empfangen";
            this.cmd_requestImage.UseVisualStyleBackColor = true;
            this.cmd_requestImage.Click += new System.EventHandler(this.cmd_requestImage_Click);
            // 
            // TeBo_BPP
            // 
            this.TeBo_BPP.Location = new System.Drawing.Point(224, 32);
            this.TeBo_BPP.Name = "TeBo_BPP";
            this.TeBo_BPP.Size = new System.Drawing.Size(61, 20);
            this.TeBo_BPP.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(87, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Resolution x";
            // 
            // lbl_PictureInformation
            // 
            this.lbl_PictureInformation.AutoSize = true;
            this.lbl_PictureInformation.Location = new System.Drawing.Point(412, 318);
            this.lbl_PictureInformation.Name = "lbl_PictureInformation";
            this.lbl_PictureInformation.Size = new System.Drawing.Size(100, 13);
            this.lbl_PictureInformation.TabIndex = 36;
            this.lbl_PictureInformation.Text = "keine Informationen";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(332, 318);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Informationen:";
            // 
            // PiBo_Manual
            // 
            this.PiBo_Manual.Location = new System.Drawing.Point(335, 16);
            this.PiBo_Manual.Name = "PiBo_Manual";
            this.PiBo_Manual.Size = new System.Drawing.Size(348, 299);
            this.PiBo_Manual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PiBo_Manual.TabIndex = 34;
            this.PiBo_Manual.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.RaBu_LoadFileRgb565);
            this.groupBox7.Controls.Add(this.TeBo_FileName);
            this.groupBox7.Controls.Add(this.cmd_Durchsuchen);
            this.groupBox7.Controls.Add(this.lbl_Filename);
            this.groupBox7.Location = new System.Drawing.Point(8, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(321, 126);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "groupBox7";
            // 
            // RaBu_LoadFileRgb565
            // 
            this.RaBu_LoadFileRgb565.AutoSize = true;
            this.RaBu_LoadFileRgb565.Checked = true;
            this.RaBu_LoadFileRgb565.Location = new System.Drawing.Point(7, 38);
            this.RaBu_LoadFileRgb565.Name = "RaBu_LoadFileRgb565";
            this.RaBu_LoadFileRgb565.Size = new System.Drawing.Size(66, 17);
            this.RaBu_LoadFileRgb565.TabIndex = 4;
            this.RaBu_LoadFileRgb565.TabStop = true;
            this.RaBu_LoadFileRgb565.Text = "RGB565";
            this.RaBu_LoadFileRgb565.UseVisualStyleBackColor = true;
            // 
            // TeBo_FileName
            // 
            this.TeBo_FileName.Location = new System.Drawing.Point(7, 61);
            this.TeBo_FileName.Name = "TeBo_FileName";
            this.TeBo_FileName.Size = new System.Drawing.Size(289, 20);
            this.TeBo_FileName.TabIndex = 0;
            // 
            // cmd_Durchsuchen
            // 
            this.cmd_Durchsuchen.Location = new System.Drawing.Point(213, 89);
            this.cmd_Durchsuchen.Name = "cmd_Durchsuchen";
            this.cmd_Durchsuchen.Size = new System.Drawing.Size(83, 23);
            this.cmd_Durchsuchen.TabIndex = 1;
            this.cmd_Durchsuchen.Text = "Durchsuchen";
            this.cmd_Durchsuchen.UseVisualStyleBackColor = true;
            this.cmd_Durchsuchen.Click += new System.EventHandler(this.cmd_Durchsuchen_Click);
            // 
            // lbl_Filename
            // 
            this.lbl_Filename.AutoSize = true;
            this.lbl_Filename.Location = new System.Drawing.Point(1, 93);
            this.lbl_Filename.Name = "lbl_Filename";
            this.lbl_Filename.Size = new System.Drawing.Size(49, 13);
            this.lbl_Filename.TabIndex = 3;
            this.lbl_Filename.Text = "Filename";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Controls.Add(this.cmd_ComSend);
            this.tabPage1.Controls.Add(this.RiTeBo_send);
            this.tabPage1.Controls.Add(this.RiTeBo_receive);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(809, 596);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Sniffer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.radioButton1);
            this.groupBox9.Controls.Add(this.radioButton2);
            this.groupBox9.Controls.Add(this.radioButton3);
            this.groupBox9.Location = new System.Drawing.Point(429, 330);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(163, 50);
            this.groupBox9.TabIndex = 28;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Format";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(40, 17);
            this.radioButton1.TabIndex = 25;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Bin";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(52, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(44, 17);
            this.radioButton2.TabIndex = 26;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Dez";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(102, 21);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(44, 17);
            this.radioButton3.TabIndex = 24;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Hex";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // cmd_ComSend
            // 
            this.cmd_ComSend.Location = new System.Drawing.Point(24, 405);
            this.cmd_ComSend.Name = "cmd_ComSend";
            this.cmd_ComSend.Size = new System.Drawing.Size(75, 23);
            this.cmd_ComSend.TabIndex = 21;
            this.cmd_ComSend.Text = "senden";
            this.cmd_ComSend.UseVisualStyleBackColor = true;
            // 
            // RiTeBo_send
            // 
            this.RiTeBo_send.Location = new System.Drawing.Point(24, 347);
            this.RiTeBo_send.Name = "RiTeBo_send";
            this.RiTeBo_send.Size = new System.Drawing.Size(399, 33);
            this.RiTeBo_send.TabIndex = 20;
            this.RiTeBo_send.Text = "";
            // 
            // RiTeBo_receive
            // 
            this.RiTeBo_receive.Location = new System.Drawing.Point(24, 32);
            this.RiTeBo_receive.Name = "RiTeBo_receive";
            this.RiTeBo_receive.Size = new System.Drawing.Size(710, 170);
            this.RiTeBo_receive.TabIndex = 12;
            this.RiTeBo_receive.Text = "";
            this.RiTeBo_receive.TextChanged += new System.EventHandler(this.RiTeBo_receive_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "COM-Communication";
            // 
            // PiBo_ImageBox
            // 
            this.PiBo_ImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PiBo_ImageBox.Location = new System.Drawing.Point(625, 294);
            this.PiBo_ImageBox.Name = "PiBo_ImageBox";
            this.PiBo_ImageBox.Size = new System.Drawing.Size(279, 210);
            this.PiBo_ImageBox.TabIndex = 28;
            this.PiBo_ImageBox.TabStop = false;
            // 
            // cmd_caputeImage
            // 
            this.cmd_caputeImage.Location = new System.Drawing.Point(750, 531);
            this.cmd_caputeImage.Name = "cmd_caputeImage";
            this.cmd_caputeImage.Size = new System.Drawing.Size(119, 23);
            this.cmd_caputeImage.TabIndex = 27;
            this.cmd_caputeImage.Text = "take Picture RbyR";
            this.cmd_caputeImage.UseVisualStyleBackColor = true;
            this.cmd_caputeImage.Click += new System.EventHandler(this.cmd_caputeImage_Click);
            // 
            // GrBo_Camera_Status
            // 
            this.GrBo_Camera_Status.Controls.Add(this.label15);
            this.GrBo_Camera_Status.Controls.Add(this.label14);
            this.GrBo_Camera_Status.Controls.Add(this.lbl_TestPattern);
            this.GrBo_Camera_Status.Controls.Add(this.lbl_ColorFormat);
            this.GrBo_Camera_Status.Controls.Add(this.lbl_OutPutResolution);
            this.GrBo_Camera_Status.Controls.Add(this.lbl_VersionNo);
            this.GrBo_Camera_Status.Location = new System.Drawing.Point(625, 91);
            this.GrBo_Camera_Status.Name = "GrBo_Camera_Status";
            this.GrBo_Camera_Status.Size = new System.Drawing.Size(226, 158);
            this.GrBo_Camera_Status.TabIndex = 26;
            this.GrBo_Camera_Status.TabStop = false;
            this.GrBo_Camera_Status.Text = "Camera Status";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 128);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "noch zu implementieren";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "noch zu implementieren";
            // 
            // lbl_TestPattern
            // 
            this.lbl_TestPattern.AutoSize = true;
            this.lbl_TestPattern.Location = new System.Drawing.Point(6, 93);
            this.lbl_TestPattern.Name = "lbl_TestPattern";
            this.lbl_TestPattern.Size = new System.Drawing.Size(68, 13);
            this.lbl_TestPattern.TabIndex = 2;
            this.lbl_TestPattern.Text = "Test Pattern:";
            // 
            // lbl_ColorFormat
            // 
            this.lbl_ColorFormat.AutoSize = true;
            this.lbl_ColorFormat.Location = new System.Drawing.Point(6, 76);
            this.lbl_ColorFormat.Name = "lbl_ColorFormat";
            this.lbl_ColorFormat.Size = new System.Drawing.Size(69, 13);
            this.lbl_ColorFormat.TabIndex = 2;
            this.lbl_ColorFormat.Text = "Color Format:";
            // 
            // lbl_OutPutResolution
            // 
            this.lbl_OutPutResolution.AutoSize = true;
            this.lbl_OutPutResolution.Location = new System.Drawing.Point(6, 58);
            this.lbl_OutPutResolution.Name = "lbl_OutPutResolution";
            this.lbl_OutPutResolution.Size = new System.Drawing.Size(63, 13);
            this.lbl_OutPutResolution.TabIndex = 1;
            this.lbl_OutPutResolution.Text = "Resolution: ";
            // 
            // lbl_VersionNo
            // 
            this.lbl_VersionNo.AutoSize = true;
            this.lbl_VersionNo.Location = new System.Drawing.Point(6, 39);
            this.lbl_VersionNo.Name = "lbl_VersionNo";
            this.lbl_VersionNo.Size = new System.Drawing.Size(45, 13);
            this.lbl_VersionNo.TabIndex = 0;
            this.lbl_VersionNo.Text = "Version:";
            // 
            // cmd_getCameraStaturs
            // 
            this.cmd_getCameraStaturs.Location = new System.Drawing.Point(625, 255);
            this.cmd_getCameraStaturs.Name = "cmd_getCameraStaturs";
            this.cmd_getCameraStaturs.Size = new System.Drawing.Size(100, 23);
            this.cmd_getCameraStaturs.TabIndex = 17;
            this.cmd_getCameraStaturs.Text = "get camera status";
            this.cmd_getCameraStaturs.UseVisualStyleBackColor = true;
            this.cmd_getCameraStaturs.Click += new System.EventHandler(this.cmd_getCameraStatus_Click);
            // 
            // OpenFileDialog_LoadImage
            // 
            this.OpenFileDialog_LoadImage.FileName = "openFileDialog1";
            // 
            // cmd_Initialisierung
            // 
            this.cmd_Initialisierung.Location = new System.Drawing.Point(625, 62);
            this.cmd_Initialisierung.Name = "cmd_Initialisierung";
            this.cmd_Initialisierung.Size = new System.Drawing.Size(119, 23);
            this.cmd_Initialisierung.TabIndex = 22;
            this.cmd_Initialisierung.Text = "Kamera initialisieren";
            this.cmd_Initialisierung.UseVisualStyleBackColor = true;
            this.cmd_Initialisierung.Click += new System.EventHandler(this.cmd_Initialisierung_Click);
            // 
            // cmd_TakeCompleteImage
            // 
            this.cmd_TakeCompleteImage.Location = new System.Drawing.Point(625, 531);
            this.cmd_TakeCompleteImage.Name = "cmd_TakeCompleteImage";
            this.cmd_TakeCompleteImage.Size = new System.Drawing.Size(119, 23);
            this.cmd_TakeCompleteImage.TabIndex = 27;
            this.cmd_TakeCompleteImage.Text = "take Picture complete";
            this.cmd_TakeCompleteImage.UseVisualStyleBackColor = true;
            this.cmd_TakeCompleteImage.Click += new System.EventHandler(this.cmd_TakeCompleteImage_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "D:\\David\\Dokumente\\Visual Studio 2017\\Projects\\OV7670-Terminal\\OV7670-Terminal\\He" +
    "lp\\OV7670_Terminal_help.chm";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1114, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            this.hilfeToolStripMenuItem.Click += new System.EventHandler(this.hilfeToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(731, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "sync Camera";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_PictureDescription
            // 
            this.lbl_PictureDescription.AutoSize = true;
            this.lbl_PictureDescription.Location = new System.Drawing.Point(626, 507);
            this.lbl_PictureDescription.Name = "lbl_PictureDescription";
            this.lbl_PictureDescription.Size = new System.Drawing.Size(54, 13);
            this.lbl_PictureDescription.TabIndex = 2;
            this.lbl_PictureDescription.Text = "0x0 0 bpp";
            // 
            // Form_Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1114, 678);
            this.Controls.Add(this.lbl_PictureDescription);
            this.Controls.Add(this.cmd_Initialisierung);
            this.Controls.Add(this.PiBo_ImageBox);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.cmd_TakeCompleteImage);
            this.Controls.Add(this.cmd_caputeImage);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.GrBo_Camera_Status);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmd_getCameraStaturs);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Terminal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Right Picture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Terminal_FormClosing);
            this.Load += new System.EventHandler(this.Form_Terminal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PiBo_LeftPicture)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.GrBo_ComPort.ResumeLayout(false);
            this.GrBo_ComPort.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.TaPa_Settings.ResumeLayout(false);
            this.GrBo_LoadedSettings.ResumeLayout(false);
            this.GrBo_DeviceSettings.ResumeLayout(false);
            this.GrBo_DeviceSettings.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.TaPa_Image.ResumeLayout(false);
            this.GrBo_RightPicture.ResumeLayout(false);
            this.GrBo_RightPicture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PiBo_RightPicture)).EndInit();
            this.GrBo_LeftPicture.ResumeLayout(false);
            this.GrBo_LeftPicture.PerformLayout();
            this.TabPage_Capture.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TaPa_manu_mode.ResumeLayout(false);
            this.TaPa_manu_mode.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PiBo_Manual)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PiBo_ImageBox)).EndInit();
            this.GrBo_Camera_Status.ResumeLayout(false);
            this.GrBo_Camera_Status.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PiBo_LeftPicture;
        private System.IO.Ports.SerialPort SePo_Camera;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel ToSt_Task;
        private System.Windows.Forms.Button cmd_LP_Save;
        private System.Windows.Forms.Button cmd_LpToRp;
        private System.Windows.Forms.ComboBox CoBo_ComPort;
        private System.Windows.Forms.Button cmd_Port_connect;
        private System.Windows.Forms.ComboBox CoBo_Datenbits;
        private System.Windows.Forms.GroupBox GrBo_ComPort;
        private System.Windows.Forms.Button cmd_Port_disconnect;
        private System.Windows.Forms.Label lbl_Port_Status;
        private System.Windows.Forms.ToolStripStatusLabel ToStSt_Connection;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TaPa_Image;
        private System.Windows.Forms.TabPage TaPa_Settings;
        private System.Windows.Forms.ComboBox CoBo_Parit;
        private System.Windows.Forms.ComboBox CoBo_Baudrate;
        private System.Windows.Forms.ComboBox CoBo_StoppBits;
        private System.Windows.Forms.Label lbl_parity;
        private System.Windows.Forms.Label lbl_Baud;
        private System.Windows.Forms.Label lbl_Stoppbits;
        private System.Windows.Forms.Label lbl_Datenbits;
        private System.Windows.Forms.Label lbl_ComPort;
        private System.Windows.Forms.Label lbl_handshake;
        private System.Windows.Forms.ComboBox CoBo_Handshake;
        private System.Windows.Forms.TabPage TabPage_Capture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TeBo_xResolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TeBo_yResolution;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button cmd_RGB888;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage TaPa_manu_mode;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton RaBu_RGB565;
        private System.Windows.Forms.Label lbl_Filename;
        private System.Windows.Forms.TextBox TeBo_FileName;
        private System.Windows.Forms.Button cmd_Durchsuchen;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_LoadImage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TeBo_BPP;
        private System.Windows.Forms.TextBox TeBo_yRes;
        private System.Windows.Forms.TextBox TeBo_xRes;
        private System.Windows.Forms.Button cmd_ReadAllRegister;
        private System.Windows.Forms.RichTextBox RiTeBo_history;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton RaBu_Bin;
        private System.Windows.Forms.RadioButton RaBu_Dez;
        private System.Windows.Forms.RadioButton RaBu_Hex;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lbl_ReadResult;
        private System.Windows.Forms.Label lbl_ReadRegister;
        private System.Windows.Forms.TextBox TeBo_SettingResult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TeBo_ReadRegister;
        private System.Windows.Forms.Button cmd_ReadRegister;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbl_WriteRegister;
        private System.Windows.Forms.Label lbl_WriteValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TeBo_WriteData;
        private System.Windows.Forms.TextBox TeBo_WriteRegister;
        private System.Windows.Forms.Button cmd_WriteRegister;
        private System.Windows.Forms.Label lbl_PictureInformation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox PiBo_Manual;
        private System.Windows.Forms.Button cmd_loadSCCBSettings;
        private System.Windows.Forms.Button cmd_compareLists;
        private System.Windows.Forms.Button cmd_readForChange;
        private System.Windows.Forms.Button cmd_WriteAllRegister;
        private System.Windows.Forms.GroupBox GrBo_Camera_Status;
        private System.Windows.Forms.Label lbl_ColorFormat;
        private System.Windows.Forms.Label lbl_OutPutResolution;
        private System.Windows.Forms.Label lbl_VersionNo;
        private System.Windows.Forms.Button cmd_caputeImage;
        private System.Windows.Forms.PictureBox PiBo_ImageBox;
        private System.Windows.Forms.Button cmd_getCameraStaturs;
        private System.Windows.Forms.GroupBox GrBo_RightPicture;
        private System.Windows.Forms.CheckBox ChBo_RP_Sync;
        private System.Windows.Forms.PictureBox PiBo_RightPicture;
        private System.Windows.Forms.Button cmd_RP_Save;
        private System.Windows.Forms.GroupBox GrBo_LeftPicture;
        private System.Windows.Forms.CheckBox ChBo_LP_Sync;
        private System.Windows.Forms.Button cmd_CompareLpRp;
        private System.Windows.Forms.Button cmd_RpToLp;
        private System.Windows.Forms.Label lbl_RP_Height;
        private System.Windows.Forms.Label lbl_RP_Width;
        private System.Windows.Forms.Label lbl_LP_Height;
        private System.Windows.Forms.Label lbl_LP_Width;
        private System.Windows.Forms.Button cmd_RP_Load;
        private System.Windows.Forms.Button cmd_LP_Load;
        private System.Windows.Forms.ToolStripStatusLabel ToSt_Progress;
        private System.Windows.Forms.Button cmd_Initialisierung;
        private System.Windows.Forms.Button cmd_TakeCompleteImage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_TestPattern;
        private System.Windows.Forms.Button cmd_requestImage;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button cmd_OpenFromStruct;
        private System.Windows.Forms.Button cmd_SafeToStruct;
        private System.Windows.Forms.RadioButton RaBu_LoadFileRgb565;
        private System.Windows.Forms.Button cmd_GetManualPicture_With_Commands;
        private System.Windows.Forms.ToolStripStatusLabel ToStStLbl_Programmstatus;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button cmd_SaveSccbSettings;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_ReadAllNotUpdated;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox RiTeBo_receive;
        private System.Windows.Forms.Label lbl_PictureDescription;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button cmd_ComSend;
        private System.Windows.Forms.RichTextBox RiTeBo_send;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListView LiVi_DeviceSettings;
        private System.Windows.Forms.ColumnHeader Online_Address;
        private System.Windows.Forms.ColumnHeader Online_Value;
        private System.Windows.Forms.ListView LiVi_LoadedSettings;
        private System.Windows.Forms.ColumnHeader Offline_Address;
        private System.Windows.Forms.ColumnHeader Offline_Value;
        private System.Windows.Forms.GroupBox GrBo_DeviceSettings;
        private System.Windows.Forms.GroupBox GrBo_LoadedSettings;
    }
}

