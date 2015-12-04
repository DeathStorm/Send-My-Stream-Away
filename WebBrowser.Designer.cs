namespace SendScreenAway
{
    partial class WebBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebBrowser));
            this.CheckMousePosition = new System.Windows.Forms.Timer(this.components);
            this.browser = new Awesomium.Windows.Forms.WebControl(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyMenu_Fullscreen = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyMenu_ScreenPosition = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.heightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyMenu_Height = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyMenu_Width = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyMenu_Zoom = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyMenu_URL = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyMenu_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckMousePosition
            // 
            this.CheckMousePosition.Enabled = true;
            this.CheckMousePosition.Interval = 1000;
            this.CheckMousePosition.Tick += new System.EventHandler(this.CheckMousePosition_Tick);
            // 
            // browser
            // 
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.Location = new System.Drawing.Point(0, 0);
            this.browser.Size = new System.Drawing.Size(300, 300);
            this.browser.TabIndex = 0;
            this.browser.ShowCreatedWebView += new Awesomium.Core.ShowCreatedWebViewEventHandler(this.Awesomium_Windows_Forms_WebControl_ShowCreatedWebView);
            this.browser.DocumentReady += new Awesomium.Core.UrlEventHandler(this.Awesomium_Windows_Forms_WebControl_DocumentReady);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyMenu_Fullscreen,
            this.notifyMenu_ScreenPosition,
            this.toolStripSeparator1,
            this.heightToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.notifyMenu_Close});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(182, 175);
            this.notifyMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.notifyMenu_ItemClicked);
            this.notifyMenu.Click += new System.EventHandler(this.notifyMenu_Click);
            // 
            // notifyMenu_Fullscreen
            // 
            this.notifyMenu_Fullscreen.CheckOnClick = true;
            this.notifyMenu_Fullscreen.Name = "notifyMenu_Fullscreen";
            this.notifyMenu_Fullscreen.Size = new System.Drawing.Size(181, 22);
            this.notifyMenu_Fullscreen.Text = "Fullscreen";
            this.notifyMenu_Fullscreen.CheckedChanged += new System.EventHandler(this.notifyMenu_Fullscreen_CheckedChanged);
            // 
            // notifyMenu_ScreenPosition
            // 
            this.notifyMenu_ScreenPosition.Name = "notifyMenu_ScreenPosition";
            this.notifyMenu_ScreenPosition.Size = new System.Drawing.Size(121, 23);
            this.notifyMenu_ScreenPosition.SelectedIndexChanged += new System.EventHandler(this.notifyMenu_ScreenPosition_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // heightToolStripMenuItem
            // 
            this.heightToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyMenu_Height});
            this.heightToolStripMenuItem.Name = "heightToolStripMenuItem";
            this.heightToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.heightToolStripMenuItem.Text = "Height";
            // 
            // notifyMenu_Height
            // 
            this.notifyMenu_Height.Name = "notifyMenu_Height";
            this.notifyMenu_Height.Size = new System.Drawing.Size(100, 23);
            this.notifyMenu_Height.TextChanged += new System.EventHandler(this.notifyMenu_Height_TextChanged);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyMenu_Width});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem2.Text = "Width";
            // 
            // notifyMenu_Width
            // 
            this.notifyMenu_Width.Name = "notifyMenu_Width";
            this.notifyMenu_Width.Size = new System.Drawing.Size(100, 23);
            this.notifyMenu_Width.TextChanged += new System.EventHandler(this.notifyMenu_Width_TextChanged);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyMenu_Zoom});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem3.Text = "Zoom";
            // 
            // notifyMenu_Zoom
            // 
            this.notifyMenu_Zoom.Name = "notifyMenu_Zoom";
            this.notifyMenu_Zoom.Size = new System.Drawing.Size(100, 23);
            this.notifyMenu_Zoom.TextChanged += new System.EventHandler(this.notifyMenu_Zoom_TextChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyMenu_URL});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem1.Text = "URL";
            // 
            // notifyMenu_URL
            // 
            this.notifyMenu_URL.Name = "notifyMenu_URL";
            this.notifyMenu_URL.Size = new System.Drawing.Size(100, 23);
            this.notifyMenu_URL.TextChanged += new System.EventHandler(this.notifyMenu_URL_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // notifyMenu_Close
            // 
            this.notifyMenu_Close.Name = "notifyMenu_Close";
            this.notifyMenu_Close.Size = new System.Drawing.Size(181, 22);
            this.notifyMenu_Close.Text = "Close";
            this.notifyMenu_Close.Click += new System.EventHandler(this.notifyMenu_Close_Click);
            // 
            // WebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.browser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WebBrowser";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WebBrowser_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer CheckMousePosition;
        private Awesomium.Windows.Forms.WebControl browser;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem notifyMenu_Fullscreen;
        private System.Windows.Forms.ToolStripMenuItem notifyMenu_Close;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem heightToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox notifyMenu_Height;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripTextBox notifyMenu_Width;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox notifyMenu_URL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox notifyMenu_ScreenPosition;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripTextBox notifyMenu_Zoom;
    }
}

