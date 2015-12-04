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

using System.Runtime.InteropServices;

using Awesomium.Core;



namespace SendScreenAway
{
    public partial class WebBrowser : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        enum ScreenPositions { Auto, TopLeft, TopRight, BottomLeft, BottomRight };
        Dictionary<String, ScreenPositions> screenPositionsDictionary = new Dictionary<string, ScreenPositions>();

        String whereIs = "";

        int width = 0;
        int height = 0;
        int zoom = 100;
        String urlString = "";
        bool isFullScreen = false;
        bool isYouTube = false;
        ScreenPositions screenPosition = ScreenPositions.Auto;

        const int hotkeyIDBossKeyHide = 99100;
        const int hotkeyIDBossKeyShow = 99101;

        public WebBrowser(int width, int height, String url)
        {
            InitializeComponent();

            this.width = width;
            this.height = height;
            this.urlString = url;

            this.Size = new Size(width, height);
            browser.Source = new Uri(urlString);

            for (int i = 0; i < Enum.GetValues(typeof(ScreenPositions)).Length; i++)
            {
                ScreenPositions tmpEnum = (ScreenPositions)Enum.GetValues(typeof(ScreenPositions)).GetValue(i);

                notifyMenu_ScreenPosition.Items.Add(tmpEnum.ToString());
                screenPositionsDictionary.Add(tmpEnum.ToString(), tmpEnum);
            }

        }

        protected override void WndProc(ref Message m)
        {
            
            if (m.Msg == 0x0312)
            {
                
                Console.WriteLine(m.Msg);
                Console.Write(m.WParam);
                if (m.WParam.ToInt32() == hotkeyIDBossKeyHide)
                {
                    this.Hide();
                    //if (this.Visible == false)
                    //{ this.Show(); }
                    //else
                    //{ this.Hide(); }
                }
                else if (m.WParam.ToInt32() == hotkeyIDBossKeyShow){this.Show();}
                
            }

            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            Console.WriteLine("DONE");
            this.TopMost = true;

            notifyMenu_ScreenPosition.SelectedItem = ScreenPositions.Auto.ToString();

            notifyMenu_Width.Text = width.ToString();
            notifyMenu_Height.Text = height.ToString();
            notifyMenu_Zoom.Text = zoom.ToString();
            notifyMenu_URL.Text = urlString.ToString();


            RegisterHotKey(this.Handle, hotkeyIDBossKeyHide, 6, (int)'D');
            RegisterHotKey(this.Handle, hotkeyIDBossKeyShow, 3, (int)'P');

        }

        private void CheckMousePosition_Tick(object sender, EventArgs e)
        {

            if (browser.IsDocumentReady) { browser.ExecuteJavascript("document.body.style.overflow = \"hidden\""); }

            if (isFullScreen == false)
            {
                String whereIsX = "";
                String whereIsY = "";
                if (screenPosition == ScreenPositions.Auto)
                {
                    if (MousePosition.X < (Screen.PrimaryScreen.WorkingArea.Width / 2))
                    { whereIsX = "Left"; }
                    else
                    { whereIsX = "Right"; }

                    if (MousePosition.Y < (Screen.PrimaryScreen.WorkingArea.Height / 2))
                    { whereIsY = "Up"; }
                    else
                    { whereIsY = "Down"; }
                }
                else
                {
                    switch (screenPosition)
                    {
                        case ScreenPositions.BottomLeft:
                            whereIsX = "Right";
                            whereIsY = "Up";
                            break;
                        case ScreenPositions.BottomRight:
                            whereIsX = "Left";
                            whereIsY = "Up";
                            break;
                        case ScreenPositions.TopLeft:
                            whereIsX = "Right";
                            whereIsY = "Down";
                            break;
                        case ScreenPositions.TopRight:
                            whereIsX = "Left";
                            whereIsY = "Down";
                            break;

                    }
                }

                whereIs = whereIsX + "-" + whereIsY;
                Console.WriteLine(MousePosition + " => " + whereIs);
                Point newPoint = new Point(0, 0);
                switch (whereIs)
                {
                    case "Left-Up":
                        newPoint = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
                        break;
                    case "Left-Down":
                        newPoint = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, 0);
                        break;
                    case "Right-Up":
                        newPoint = new Point(0, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
                        break;
                    case "Right-Down":
                        newPoint = new Point(0, 0);
                        break;
                }
                this.Location = newPoint;
                //counter++;
                //if (counter >= 20)
                //{
                //    browser.Refresh();
                //    counter = 0;
                //    Console.WriteLine("REFRESHED");
                //}
            }
        }

        private void Awesomium_Windows_Forms_WebControl_Click(object sender, EventArgs e)
        {
            Console.WriteLine("TEST");
            isFullScreen = true;
        }

        private void notifyMenu_Click(object sender, EventArgs e)
        {

        }

        private void notifyMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //if (e.ClickedItem == notifyMenu_Fullscreen)
            //{
            //    if (isFullScreen == false && e.ClickedItem.Checked == true)
            //    {
            //        isFullScreen = true;
            //        this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //    }
            //    else if (isFullScreen == true && e.ClickedItem. .Checked == false)
            //    {
            //        this.Size = new Size(width, height);
            //        isFullScreen = false;
            //    }
            //}
        }

        private void notifyMenu_Close_Click(object sender, EventArgs e)
        {
            browser.Dispose();
            Awesomium.Core.WebCore.Shutdown();
            browser.Dispose();
            this.Close();
            this.Dispose();
        }

        private void notifyMenu_Fullscreen_CheckedChanged(object sender, EventArgs e)
        {
            if (isFullScreen == false && notifyMenu_Fullscreen.Checked == true)
            {
                isFullScreen = true;
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            }
            else if (isFullScreen == true && notifyMenu_Fullscreen.Checked == false)
            {
                this.Size = new Size(width, height);
                isFullScreen = false;
            }
        }

        private void notifyMenu_Height_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (notifyMenu_Height.Text != "")
                {
                    height = Convert.ToInt32(notifyMenu_Height.Text);
                    notifyMenu_Height.Text = height.ToString();

                    if (isFullScreen == false) { this.Size = new Size(width, height); }
                }
            }
            catch
            {
                notifyMenu_Height.Text = height.ToString();

                if (isFullScreen == false) { this.Size = new Size(width, height); }
            }
        }

        private void notifyMenu_Width_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (notifyMenu_Width.Text != "")
                {
                    width = Convert.ToInt32(notifyMenu_Width.Text);
                    notifyMenu_Width.Text = width.ToString();
                    if (isFullScreen == false) { this.Size = new Size(width, height); }
                }
            }
            catch
            {
                notifyMenu_Width.Text = width.ToString();
                if (isFullScreen == false) { this.Size = new Size(width, height); }
            }
        }

        private void notifyMenu_URL_TextChanged(object sender, EventArgs e)
        {
            try
            {

                urlString = notifyMenu_URL.Text;

                String searchString = "https://www.youtube.com/watch?v=";

                isYouTube = false;
                if (urlString.ToLower().Substring(0, searchString.Length) == searchString)
                {
                    isYouTube = true;

                    String templateString = "<!DOCTYPE html><html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\"><head><iframe width=\"VIDEOWIDTH\" height=\"VIDEOHEIGHT\" src=\"https://www.youtube.com/embed/VIDEOKEY?autoplay=1\" frameborder=\"0\" allowfullscreen></iframe></head><body></body></html>";
                    String webSiteFilePath = Application.StartupPath + "\\YouTube.html";

                    if (File.Exists(webSiteFilePath)) File.Delete(webSiteFilePath);

                    StreamWriter sw = new StreamWriter(webSiteFilePath);
                    String relaceString = urlString.Substring(searchString.Length, urlString.Length - searchString.Length);// https://www.youtube.com/watch?v=
                    String stringToWrite = templateString.Replace("VIDEOKEY", relaceString);
                    stringToWrite = stringToWrite.Replace("VIDEOWIDTH", width.ToString());
                    stringToWrite = stringToWrite.Replace("VIDEOHEIGHT", height.ToString());
                    sw.WriteLine(stringToWrite);

                    sw.Close();

                    urlString = webSiteFilePath;

                }



                //file.Close();

                /*
                StreamReader sr = new StreamReader(Properties.Resources.YouTube);
                do
                {
                    fileString.Add(sr.ReadLine());

                } while (sr.EndOfStream);

                for (int row = 0; row < fileString.Count; row++)
                {

                }

                Console.WriteLine(file.ToString());
                */

                //SendScreenAway.Properties.Resources.YouTube = urlString;


                notifyMenu_Width.Text = width.ToString();
                notifyMenu_Height.Text = height.ToString();
                notifyMenu_URL.Text = urlString.ToString();

                browser.Source = new Uri(urlString);
            }
            catch
            {

            }
        }

        private void WebBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            browser.Dispose();
            Awesomium.Core.WebCore.Shutdown();
            browser.Dispose();
            this.Dispose();
            Application.Exit();
        }

        private void Awesomium_Windows_Forms_WebControl_DocumentReady(object sender, UrlEventArgs e)
        {

        }

        private void notifyMenu_ScreenPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

            screenPosition = screenPositionsDictionary[notifyMenu_ScreenPosition.SelectedItem.ToString()];

            //screenPosition = (ScreenPositions)notifyMenu_ScreenPosition.SelectedText;
            //Enum.GetValues(typeof(ScreenPositions))
        }

        private void notifyMenu_Zoom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (notifyMenu_Zoom.Text != "")
                {
                    zoom = Convert.ToInt32(notifyMenu_Zoom.Text);
                    browser.Zoom = zoom;
                }
            }
            catch
            {
                notifyMenu_Zoom.Text = "100";
                zoom = 100;
                browser.Zoom = zoom;

            }

        }

        private void Awesomium_Windows_Forms_WebControl_ShowCreatedWebView(object sender, ShowCreatedWebViewEventArgs e)
        {

        }

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    MessageBox.Show(e.KeyCode.ToString());
        //    if (e.KeyCode == Keys.F12)
        //    {
        //        if (isFullScreen)
        //        { this.Size = new Size(width, height); }
        //        else
        //        { this.Size = Screen.PrimaryScreen.WorkingArea.Size; }
        //    }
        //}


    }
}
