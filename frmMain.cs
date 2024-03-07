using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Security.Policy;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using MultiSkillCer;
using Newtonsoft.Json;
namespace ManpowerCheckIn
{
    public partial class frmMain : Form
    {

        string oComPort = "0";
        string oMenuAlive = ""; // กำลังอยู่ที่เมนูใด
        string oDefaultX = "";
        string oDefaultY = "";
        string oFactory = "";
        string _f_id = "";
        string oLine = "";
        string oSub_line = "";
        string oPrefix = "";
        string oPositon = "";
        string oListOfColor = "";
        string oCHECKMQ = "";
        string oAUTOLOGIN = "FALSE";
        string url = "";
        int _defaultX = 0, _defaultY = 0;
        private IniFile initFile = new IniFile("Config.ini");

        string defaultByPass = "";

        public frmMain()
        {

            InitializeComponent();
            oComPort = initFile.GetString("PORT", "COM", "");
            url = initFile.GetString("MENU", "HOME", "");
            wViewMain.NavigationStarting += EnsureHttps;
            wViewMain.NavigationCompleted += CompletedHttps;
        }

        public SerialPort serialPort1 = new SerialPort();

        //*****************************************
        //       Setting  File Config
        //*****************************************

        private void frmMain_Load(object sender, EventArgs e)
        {
            #region Set Serial Port
            serialPort1.PortName = $"COM{oComPort}";
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            #endregion

            string defaultLayoutCode = initFile.GetString("DEFAULT", "LAYOUTCODE", "");
            defaultByPass = initFile.GetString("DEFAULT", "CHECKIN_BYPASS", "X");
            txtAddressBar.Text = defaultLayoutCode;
            wViewMain.Source = new Uri($"{url}/{txtAddressBar.Text}");
            oMenuAlive = initFile.GetString("MENU", "HOME", "");

            // show bypass
            txtByPass.Visible = (defaultByPass == "TRUE") ? true : false;

        }

        private void Form_Resize(object sender, EventArgs e)
        {

        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            wViewMain.Size = this.ClientSize - new System.Drawing.Size(wViewMain.Location);
            //goButton.Left = this.ClientSize.Width - goButton.Width;
            //addressBar.Width = goButton.Left - addressBar.Left;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            url = initFile.GetString("MENU", "HOME", "");
            url = $"{url}/{txtAddressBar.Text}";
            //url = $"http://dciweb.dci.daikin.co.jp/dcimanpower/{txtAddressBar.Text}";

            if (wViewMain != null && wViewMain.CoreWebView2 != null)
            {
                wViewMain.CoreWebView2.Navigate(url);
                oMenuAlive = initFile.GetString("MENU", "HOME", "");
                //this.wViewMain.CoreWebView2.ExecuteScriptAsync($"alert('load done')");
            }


            //this.wViewMain.Source = new Uri("https://programmingcsharp.com");
            //await wViewMain.CoreWebView2.ExecuteScriptAsync("document.querySelector('a.MuiTypography-inherit')");
        }

        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            //String uri = args.Uri;
            //if (!uri.StartsWith("https://"))
            //{
            //this.wViewMain.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
            //args.Cancel = true;
            //}
        }


        async void CompletedHttps(object sender, CoreWebView2NavigationCompletedEventArgs args)
        {
            int stsCode = args.HttpStatusCode;
            if (stsCode == 200)
            {

                //var html = wViewMain.CoreWebView2.ExecuteScriptAsync("document.body.outerHTML");
                //var htmldecoded = JsonConvert.DeserializeObject(html.ToString()).ToString();

                //var html = wViewMain.CoreWebView2.ExecuteScriptAsync("document.body.outerHTML");
                //var htmldecoded = System.Web.Helpers.Json.Decode(html);

                //String ss = this.wViewMain.CoreWebView2.ExecuteScriptAsync("document.querySelector('body').textContent;").ToString();

                //this.wViewMain.CoreWebView2.ExecuteScriptAsync($"alert(document.querySelector('body').textContent)");


            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        #region  Read Card By AKONE
        private void bgwCardRead_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwCardRead.CancelAsync();

            bgwCardRead.Dispose();

            string strReading = e.Argument as string;   // Define Syntax
            try
            {
                strReading = ReadCard();
            }
            catch { strReading = ""; }
            this.StrEmpCode = strReading;
            e.Result = strReading; // Return Result
        }

        private void bgwCardRead_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //string strReading = e.Result as string;     // Get Result
            //this.StrEmpCode = strReading;               // Set Data

            string strReading = (defaultByPass == "TRUE") ? txtByPass.Text : e.Result as string;
            this.StrEmpCode = (defaultByPass == "TRUE") ? txtByPass.Text : strReading;

            if (strReading.Trim().Length == 5 && (lbEmpCode.Text.ToString() == "" || lbEmpCode.Text.ToString() == "-"))
            {
                //WebClient web = new WebClient();
                //byte[] imgBytes = web.DownloadData($"http://websrv01.dci.daikin.co.jp/pic/{this.StrEmpCode}.jpg");

                //MemoryStream memImg = new MemoryStream(imgBytes);
                //imgProfile.Image = Image.FromStream(memImg);
                lbEmpCode.Text = this.StrEmpCode;
                lbEmpCode.BackColor = Color.White;
                lblError.Text = "";
                this.StatusAlive = true;                // Set Status Alive
            }
            else if (strReading.Trim().Length == 0)
            {
                if (this.StatusAlive)
                {
                    // ClearForm();
                    lblError.Text = "";
                    lbEmpCode.Text = "";
                    lbEmpCode.BackColor = Color.Navy;
                    this.StatusAlive = false;
                    if (oMenuAlive != initFile.GetString("MENU", "HOME", ""))
                    {
                        url = $"{url.Trim()}/{txtAddressBar.Text}";
                        openWeb(url);
                    }
                    // Clear Status Alive
                }
            }

            lbTime.Text = DateTime.Now.ToString("dd/MMM/yyyy HH:mm");
        }

        public bool StatusAlive = false;
        public string StrEmpCode = "";

        public string ReadCard()
        {
            string tempText = "";
            bool tr = true;
            while (tr)
            {
                try
                {
                    serialPort1.Open();
                    byte[] bf = new byte[15];
                    bf[0] = 0x01;
                    bf[1] = 0x30;
                    bf[2] = 0x30;
                    bf[3] = 0xBA;
                    bf[4] = 0x30;
                    bf[5] = 0x37;
                    bf[6] = 0x01;
                    bf[7] = 0x00;
                    bf[8] = 0xBC;
                    bf[9] = 0x03;

                    //Write initial Check Card;
                    serialPort1.Write(bf, 0, 10);
                    byte[] bfr = new byte[22];
                    Thread.Sleep(200);
                    serialPort1.Read(bfr, 0, 10);

                    byte[] byReq = { 0x04 };
                    serialPort1.Write(byReq, 0, 1);
                    Thread.Sleep(200);
                    int rcv;
                    //int rcv= serialPort1.ReadByte();

                    Thread tReadByte = new Thread(ReadCardByte);
                    if (!tReadByte.IsAlive)
                    {
                        tReadByte.Start();
                    }

                    bf[0] = 0x04;
                    bf[1] = 0x04;
                    bf[2] = 0x01;
                    bf[3] = 0x30;
                    bf[4] = 0x30;
                    bf[5] = 0xB9;
                    bf[6] = 0x02;
                    bf[7] = 0x02;
                    bf[8] = 0x01;
                    bf[9] = 0x01;
                    bf[10] = 0xB9;
                    bf[11] = 0x03;
                    serialPort1.Write(bf, 0, 12);

                    Thread.Sleep(200);
                    rcv = serialPort1.Read(bfr, 0, 10);

                    byReq[0] = 0x06;

                    serialPort1.Write(byReq, 0, 1);
                    Thread.Sleep(200);
                    rcv = serialPort1.Read(bfr, 0, 8);

                    serialPort1.Close();

                    tempText = "";
                    // 0-9 || A-Z || a-z
                    if ((bfr[3] >= 48 && bfr[3] <= 57) || bfr[3] >= 73 && bfr[3] <= 90 || bfr[3] >= 97 && bfr[3] <= 122)
                    //if (bfr[3] >= 48 && bfr[3] <= 57)
                    {

                        for (int i = 3; i < 8; i++)
                        {
                            tempText += Convert.ToChar(bfr[i]);
                        }

                    }
                    //  Thread.Sleep(500);
                    tr = false;
                }
                catch
                {
                    serialPort1.Close();
                    tempText = "";
                    //Thread.Sleep(500);
                }
            }
            //return tempText + "," + tmpName;
            return tempText;
        }

        private void ReadCardByte()
        {
            try
            {
                serialPort1.ReadByte();
            }
            catch { }
        }


        private void timer_readcard_Tick(object sender, EventArgs e)
        {

            if (!bgwCardRead.IsBusy)
            {
                bgwCardRead.RunWorkerAsync();
            }


            // check from is open : read card
            //if (!IsFormOpen(typeof(frmPopupManPower_2)))
            //{

            //}
            //else
            //{
            //    lbEmpCode.Text = "";
            //    this.StatusAlive = false;
            //}


        }

        #endregion


        private async void bgwButton_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string paramEmpCode = "", paramYMD = "", paramShift = "";

            try
            {
                paramEmpCode = await wViewMain.ExecuteScriptAsync("document.querySelector('input#inpEmpCode').value");
            }
            catch { }

            try
            {
                paramYMD = await wViewMain.ExecuteScriptAsync("document.querySelector('input#inpYMD').value");
            }
            catch { }

            try
            {
                paramShift = await wViewMain.ExecuteScriptAsync("document.querySelector('input#inpShift').value");
            }
            catch { }

            //lblError.Text = $"{paramEmpCode}|{paramYMD}|{paramShift}";


            string CK_YMD = DateTime.Now.AddHours(-8).ToString("yyyyMMdd");
            string CK_SHIFT = (DateTime.Now.AddHours(-8).Hour < 12) ? "D" : "N";

            if (paramYMD != CK_YMD && (paramYMD == "" || paramYMD == "\"\""))
            {
                wViewMain.ExecuteScriptAsync($"document.querySelector('input#inpYMD').value = '{CK_YMD}' ");
            }

            if (paramShift != CK_SHIFT && (paramShift == "" || paramShift == "\"\""))
            {
                wViewMain.ExecuteScriptAsync($"document.querySelector('input#inpShift').value = '{CK_SHIFT}' ");
            }

            wViewMain.ExecuteScriptAsync($"document.querySelector('input#inpEmpCode').value = '{lbEmpCode.Text}' ");




            string objCode = "";
            string _objCode = "";
            try
            {
                objCode = await wViewMain.ExecuteScriptAsync("document.querySelector('input#inpObjCode').value");
                if (objCode != null && objCode != "" && objCode != "null")
                {
                    _objCode = JsonConvert.DeserializeObject(objCode).ToString();
                }
            }
            catch { }


            string empCode = "";
            string _empCode = "";
            try
            {
                empCode = await wViewMain.ExecuteScriptAsync("document.querySelector('input#disEmpCode').value");
                if (empCode != null && empCode != "" && empCode != "null")
                {
                    _empCode = JsonConvert.DeserializeObject(empCode).ToString();
                }
            }
            catch { }


            //***** Set Button Visible ******
            btnCheckIN.Visible = false;
            btnCheckOUT.Visible = false;
            if (_objCode.Trim() != "" && lbEmpCode.Text != "")
            {
                if (_empCode == "")
                {
                    wViewMain.ExecuteScriptAsync($"document.querySelector('input#inpType').value = 'IN' ");
                    //btnCheckIN.Visible = true;
                }
                else
                {
                    if (lbEmpCode.Text == _empCode)
                    {
                        wViewMain.ExecuteScriptAsync($"document.querySelector('input#inpType').value = 'OUT' ");
                        //btnCheckOUT.Visible = true;
                    }
                }
            }

        }

        private void timer_button_Tick(object sender, EventArgs e)
        {
            if (!bgwButton.IsBusy)
            {
                bgwButton.RunWorkerAsync();
            }

        }


        private async void btnCheckIN_Click(object sender, EventArgs e)
        {
            if (lbEmpCode.Text.Length == 5)
            {
                await wViewMain.ExecuteScriptAsync("document.querySelector('button#handleCheckInOut').click()");
            }


            //string html = await wViewMain.ExecuteScriptAsync("document.documentElement.outerHTML");
            //string html = await wViewMain.ExecuteScriptAsync("document.querySelector('div#divEqpId').textContent");
            //string html2 = await wViewMain.ExecuteScriptAsync("document.querySelector('input#inpEqpId').value");
            //string htmldecoded = JsonConvert.DeserializeObject(html).ToString();
            //txtTest.Text = htmldecoded;






            //await wViewMain.ExecuteScriptAsync($"handalAlert('{lbEmpCode.Text}', '{CK_SHIFT}', '{CK_YMD}', '{CK_TYPE}')");

            //await wViewMain.ExecuteScriptAsync("document.querySelector('button#handleCheckInOut').click()");


        }

        private async void btnCheckOUT_Click(object sender, EventArgs e)
        {
            if (lbEmpCode.Text.Length == 5)
            {
                await wViewMain.ExecuteScriptAsync("document.querySelector('button#handleCheckInOut').click()");
            }

            /*
            if (lbEmpCode.Text.Length == 5)
            {
                string CK_YMD = DateTime.Now.AddHours(-8).ToString("yyyyMMdd");
                string CK_SHIFT = (DateTime.Now.AddHours(-8).Hour < 12) ? "D" : "N";
                string CK_TYPE = "OUT";

                //await wViewMain.ExecuteScriptAsync("document.querySelector('button#btnEvent').click()");
                await wViewMain.ExecuteScriptAsync("document.querySelector('button#handalAlert').click()");

                //await wViewMain.ExecuteScriptAsync("alert(document.querySelector('input#inpEqpId').value);");
            }
            else
            {
                await wViewMain.ExecuteScriptAsync("alert('please input employee card');");
            }
            */

        }

        private void wViewMain_Click(object sender, EventArgs e)
        {

        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            url = initFile.GetString("MENU", "MQTRAINING", "");
            if (this.StrEmpCode.Trim() == "")
            {
                MessageBox.Show("กรุณาแตะบัตร !");
            }
            else
            {
                oMenuAlive = initFile.GetString("MENU", "MQTRAINING", "");
                url = $"{url}/{this.StrEmpCode}";
                openWeb(url);
            }
        }

        private void openWeb(string url = "")
        {
            // string url = $"http://dciweb.dci.daikin.co.jp/dcimanpower/{txtAddressBar.Text}";

            if (url != "" && wViewMain != null && wViewMain.CoreWebView2 != null)
            {
                wViewMain.CoreWebView2.Navigate(url);
            }
        }

        private void btnTrainingHistory_Click(object sender, EventArgs e)
        {
            url = initFile.GetString("MENU", "MQTRAININGHISTORY", "");
            if (this.StrEmpCode.Trim() == "")
            {
                MessageBox.Show("กรุณาแตะบัตร !");
            }
            else
            {
                oMenuAlive = initFile.GetString("MENU", "MQTRAININGHISTORY", "");
                url = $"{url}/{this.StrEmpCode}";
                openWeb(url);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            url = initFile.GetString("MENU", "HOME", "");
            string layoutCode = txtAddressBar.Text;
            if (url == "" || layoutCode == "")
            {
                MessageBox.Show($"ไมพบข้อมูลที่ระบบต้องการ url : {url}, layout code : {layoutCode}");
            }
            else
            {
                oMenuAlive = initFile.GetString("MENU", "HOME", "");
                url = $"{url.Trim()}/{layoutCode.Trim()}";
                openWeb(url);
            }
        }
    }
}