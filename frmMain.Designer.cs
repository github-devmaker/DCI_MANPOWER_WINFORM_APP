namespace ManpowerCheckIn
{
    partial class frmMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            wViewMain = new Microsoft.Web.WebView2.WinForms.WebView2();
            tlStpBar = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            txtAddressBar = new ToolStripTextBox();
            toolStripSeparator3 = new ToolStripSeparator();
            btnSearch = new ToolStripButton();
            btnExit = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            lbTime = new ToolStripLabel();
            toolStripSeparator4 = new ToolStripSeparator();
            txtByPass = new ToolStripTextBox();
            lbEmpCode = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            lblError = new ToolStripLabel();
            btnCheckIN = new ToolStripButton();
            btnCheckOUT = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSeparator11 = new ToolStripSeparator();
            toolStripSeparator6 = new ToolStripSeparator();
            btnHome = new ToolStripButton();
            toolStripSeparator10 = new ToolStripSeparator();
            toolStripSeparator7 = new ToolStripSeparator();
            btnTraining = new ToolStripButton();
            toolStripSeparator8 = new ToolStripSeparator();
            toolStripSeparator9 = new ToolStripSeparator();
            btnTrainingHistory = new ToolStripButton();
            toolStripLabel2 = new ToolStripLabel();
            bgwCardRead = new System.ComponentModel.BackgroundWorker();
            timer_readcard = new System.Windows.Forms.Timer(components);
            bgwButton = new System.ComponentModel.BackgroundWorker();
            timer_button = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)wViewMain).BeginInit();
            tlStpBar.SuspendLayout();
            SuspendLayout();
            // 
            // wViewMain
            // 
            wViewMain.AllowExternalDrop = true;
            wViewMain.BackColor = Color.White;
            wViewMain.CreationProperties = null;
            wViewMain.DefaultBackgroundColor = Color.White;
            wViewMain.Dock = DockStyle.Fill;
            wViewMain.Location = new Point(0, 49);
            wViewMain.Name = "wViewMain";
            wViewMain.Size = new Size(1050, 625);
            wViewMain.Source = new Uri("https://scm.dci.co.th/dci_manpower_checkin/LAY23001", UriKind.Absolute);
            wViewMain.TabIndex = 1;
            wViewMain.ZoomFactor = 1D;
            wViewMain.Click += wViewMain_Click;
            // 
            // tlStpBar
            // 
            tlStpBar.BackColor = Color.Transparent;
            tlStpBar.Items.AddRange(new ToolStripItem[] { toolStripLabel1, txtAddressBar, toolStripSeparator3, btnSearch, btnExit, toolStripSeparator5, lbTime, toolStripSeparator4, txtByPass, lbEmpCode, toolStripSeparator1, lblError, btnCheckIN, btnCheckOUT, toolStripSeparator2, toolStripSeparator11, toolStripSeparator6, btnHome, toolStripSeparator10, toolStripSeparator7, btnTraining, toolStripSeparator8, toolStripSeparator9, btnTrainingHistory, toolStripLabel2 });
            tlStpBar.Location = new Point(0, 0);
            tlStpBar.Name = "tlStpBar";
            tlStpBar.Size = new Size(1050, 49);
            tlStpBar.TabIndex = 2;
            tlStpBar.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(56, 46);
            toolStripLabel1.Text = "LAYOUT :";
            // 
            // txtAddressBar
            // 
            txtAddressBar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtAddressBar.Name = "txtAddressBar";
            txtAddressBar.Size = new Size(100, 49);
            txtAddressBar.Text = "LAY23001";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 49);
            // 
            // btnSearch
            // 
            btnSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSearch.Image = Properties.Resources.refresh_icon;
            btnSearch.ImageScaling = ToolStripItemImageScaling.None;
            btnSearch.ImageTransparentColor = Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Padding = new Padding(25, 5, 25, 5);
            btnSearch.Size = new Size(86, 46);
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnExit
            // 
            btnExit.Alignment = ToolStripItemAlignment.Right;
            btnExit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExit.Image = Properties.Resources.exit_32_icon;
            btnExit.ImageScaling = ToolStripItemImageScaling.None;
            btnExit.ImageTransparentColor = Color.Magenta;
            btnExit.Margin = new Padding(10, 2, 10, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(36, 45);
            btnExit.Text = "EXIT";
            btnExit.Click += btnExit_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 49);
            // 
            // lbTime
            // 
            lbTime.Alignment = ToolStripItemAlignment.Right;
            lbTime.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbTime.ForeColor = SystemColors.HotTrack;
            lbTime.Name = "lbTime";
            lbTime.Size = new Size(183, 46);
            lbTime.Text = "01/JAN/1900 00:00";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 49);
            // 
            // txtByPass
            // 
            txtByPass.Name = "txtByPass";
            txtByPass.Size = new Size(100, 49);
            txtByPass.Visible = false;
            // 
            // lbEmpCode
            // 
            lbEmpCode.ActiveLinkColor = Color.Red;
            lbEmpCode.Alignment = ToolStripItemAlignment.Right;
            lbEmpCode.BackColor = Color.Yellow;
            lbEmpCode.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbEmpCode.ForeColor = Color.Black;
            lbEmpCode.Name = "lbEmpCode";
            lbEmpCode.Size = new Size(29, 46);
            lbEmpCode.Text = "-";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 49);
            // 
            // lblError
            // 
            lblError.Alignment = ToolStripItemAlignment.Right;
            lblError.Name = "lblError";
            lblError.Size = new Size(12, 46);
            lblError.Text = "-";
            // 
            // btnCheckIN
            // 
            btnCheckIN.Alignment = ToolStripItemAlignment.Right;
            btnCheckIN.BackColor = Color.FromArgb(192, 255, 192);
            btnCheckIN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCheckIN.Image = Properties.Resources.Cute_Ball_Go_icon;
            btnCheckIN.ImageScaling = ToolStripItemImageScaling.None;
            btnCheckIN.ImageTransparentColor = Color.Magenta;
            btnCheckIN.Margin = new Padding(10, 1, 10, 2);
            btnCheckIN.Name = "btnCheckIN";
            btnCheckIN.Padding = new Padding(25, 5, 25, 5);
            btnCheckIN.Size = new Size(148, 46);
            btnCheckIN.Text = "CHECK-IN";
            btnCheckIN.Visible = false;
            btnCheckIN.Click += btnCheckIN_Click;
            // 
            // btnCheckOUT
            // 
            btnCheckOUT.Alignment = ToolStripItemAlignment.Right;
            btnCheckOUT.BackColor = Color.MistyRose;
            btnCheckOUT.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCheckOUT.Image = Properties.Resources.Cute_Ball_Stop_icon;
            btnCheckOUT.ImageScaling = ToolStripItemImageScaling.None;
            btnCheckOUT.ImageTransparentColor = Color.Magenta;
            btnCheckOUT.Margin = new Padding(10, 1, 10, 2);
            btnCheckOUT.Name = "btnCheckOUT";
            btnCheckOUT.Padding = new Padding(25, 5, 25, 5);
            btnCheckOUT.Size = new Size(160, 46);
            btnCheckOUT.Text = "CHECK-OUT";
            btnCheckOUT.Visible = false;
            btnCheckOUT.Click += btnCheckOUT_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 49);
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(6, 49);
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 49);
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.LightSkyBlue;
            btnHome.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnHome.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnHome.ForeColor = SystemColors.ControlText;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.ImageTransparentColor = Color.Magenta;
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(116, 46);
            btnHome.Text = "   หน้าเช็คอิน   ";
            btnHome.Click += btnHome_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(6, 49);
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 49);
            // 
            // btnTraining
            // 
            btnTraining.BackColor = Color.Lavender;
            btnTraining.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTraining.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnTraining.Image = (Image)resources.GetObject("btnTraining.Image");
            btnTraining.ImageTransparentColor = Color.Magenta;
            btnTraining.Name = "btnTraining";
            btnTraining.Size = new Size(166, 46);
            btnTraining.Text = "อบรม / ทำแบบทดสอบ";
            btnTraining.Click += btnTraining_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(6, 49);
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(6, 49);
            // 
            // btnTrainingHistory
            // 
            btnTrainingHistory.BackColor = Color.Thistle;
            btnTrainingHistory.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnTrainingHistory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnTrainingHistory.Image = Properties.Resources.search;
            btnTrainingHistory.ImageTransparentColor = Color.Magenta;
            btnTrainingHistory.Name = "btnTrainingHistory";
            btnTrainingHistory.Size = new Size(143, 46);
            btnTrainingHistory.Text = "ดูประวัติการทดสอบ";
            btnTrainingHistory.Click += btnTrainingHistory_Click;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(36, 13);
            toolStripLabel2.Text = "(v.1.2)";
            // 
            // bgwCardRead
            // 
            bgwCardRead.WorkerSupportsCancellation = true;
            bgwCardRead.DoWork += bgwCardRead_DoWork;
            bgwCardRead.RunWorkerCompleted += bgwCardRead_RunWorkerCompleted;
            // 
            // timer_readcard
            // 
            timer_readcard.Enabled = true;
            timer_readcard.Interval = 800;
            timer_readcard.Tick += timer_readcard_Tick;
            // 
            // bgwButton
            // 
            bgwButton.WorkerSupportsCancellation = true;
            bgwButton.RunWorkerCompleted += bgwButton_RunWorkerCompleted;
            // 
            // timer_button
            // 
            timer_button.Enabled = true;
            timer_button.Interval = 1600;
            timer_button.Tick += timer_button_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 674);
            Controls.Add(wViewMain);
            Controls.Add(tlStpBar);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MANPOWER CHECK-IN";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
            Resize += frmMain_Resize;
            ((System.ComponentModel.ISupportInitialize)wViewMain).EndInit();
            tlStpBar.ResumeLayout(false);
            tlStpBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 wViewMain;
        private ToolStrip tlStpBar;
        private ToolStripTextBox txtAddressBar;
        private ToolStripButton btnSearch;
        private ToolStripLabel lbEmpCode;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnExit;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton btnCheckIN;
        private ToolStripButton btnCheckOUT;
        internal System.ComponentModel.BackgroundWorker bgwCardRead;
        private ToolStripLabel lblError;
        private System.Windows.Forms.Timer timer_readcard;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel lbTime;
        private ToolStripSeparator toolStripSeparator4;
        internal System.ComponentModel.BackgroundWorker bgwButton;
        private System.Windows.Forms.Timer timer_button;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton btnTraining;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripButton btnTrainingHistory;
        private ToolStripButton btnHome;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripTextBox txtByPass;
        private ToolStripLabel toolStripLabel2;
    }
}