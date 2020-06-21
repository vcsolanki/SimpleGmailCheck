namespace SimpleGmailCheck
{
    partial class SGC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SGC));
            this.IconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.loader = new System.ComponentModel.BackgroundWorker();
            this.refresh_emails = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.setting = new System.Windows.Forms.Button();
            this.BackImage = new System.Windows.Forms.PictureBox();
            this.check_email = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.notify_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.show_hide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.close = new System.Windows.Forms.ToolStripMenuItem();
            this.check_internet = new System.Windows.Forms.Timer(this.components);
            this.IconContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackImage)).BeginInit();
            this.notify_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // IconContextMenu
            // 
            this.IconContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.IconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.minimizeToolStripMenuItem,
            this.maximizeToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.IconContextMenu.Name = "IconContextMenu";
            this.IconContextMenu.Size = new System.Drawing.Size(174, 154);
            this.IconContextMenu.Click += new System.EventHandler(this.CloseButtonClicked);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Enabled = false;
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.restoreToolStripMenuItem.Text = "Restore";
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Enabled = false;
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.moveToolStripMenuItem.Text = "Move";
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Enabled = false;
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.sizeToolStripMenuItem.Text = "Size";
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // maximizeToolStripMenuItem
            // 
            this.maximizeToolStripMenuItem.Enabled = false;
            this.maximizeToolStripMenuItem.Name = "maximizeToolStripMenuItem";
            this.maximizeToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.maximizeToolStripMenuItem.Text = "Maximize";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // main_panel
            // 
            this.main_panel.AutoScroll = true;
            this.main_panel.BackColor = System.Drawing.SystemColors.Control;
            this.main_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.main_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.main_panel.Location = new System.Drawing.Point(12, 50);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(870, 495);
            this.main_panel.TabIndex = 14;
            this.main_panel.Click += new System.EventHandler(this.Status_Click);
            this.main_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanelPaint);
            // 
            // loader
            // 
            this.loader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loader_work);
            // 
            // refresh_emails
            // 
            this.refresh_emails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refresh_emails.FlatAppearance.BorderSize = 0;
            this.refresh_emails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.refresh_emails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.refresh_emails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refresh_emails.Location = new System.Drawing.Point(720, 12);
            this.refresh_emails.Name = "refresh_emails";
            this.refresh_emails.Size = new System.Drawing.Size(85, 32);
            this.refresh_emails.TabIndex = 17;
            this.refresh_emails.Text = "Refresh";
            this.refresh_emails.UseVisualStyleBackColor = true;
            this.refresh_emails.Click += new System.EventHandler(this.RefreshEmailList);
            // 
            // close_button
            // 
            this.close_button.BackgroundImage = global::SimpleGmailCheck.Properties.Resources.close;
            this.close_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.close_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Location = new System.Drawing.Point(849, 12);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(32, 32);
            this.close_button.TabIndex = 16;
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.CloseButtonClicked);
            // 
            // setting
            // 
            this.setting.BackgroundImage = global::SimpleGmailCheck.Properties.Resources.settings;
            this.setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.setting.FlatAppearance.BorderSize = 0;
            this.setting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.setting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setting.Location = new System.Drawing.Point(811, 12);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(32, 32);
            this.setting.TabIndex = 15;
            this.setting.UseVisualStyleBackColor = true;
            this.setting.Click += new System.EventHandler(this.OpenSettings);
            // 
            // BackImage
            // 
            this.BackImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackImage.Location = new System.Drawing.Point(0, 0);
            this.BackImage.Name = "BackImage";
            this.BackImage.Size = new System.Drawing.Size(894, 557);
            this.BackImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackImage.TabIndex = 1;
            this.BackImage.TabStop = false;
            this.BackImage.VisibleChanged += new System.EventHandler(this.CheckHide);
            this.BackImage.Paint += new System.Windows.Forms.PaintEventHandler(this.BackImagePaint);
            this.BackImage.DoubleClick += new System.EventHandler(this.MinimizeClick);
            this.BackImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindowMouseDown);
            this.BackImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindowMouseMove);
            this.BackImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWindowMouseUp);
            // 
            // check_email
            // 
            this.check_email.Interval = 10000;
            this.check_email.Tick += new System.EventHandler(this.email_check_tick);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(653, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 32);
            this.button1.TabIndex = 18;
            this.button1.Text = "Hide";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.show_hide_Click);
            // 
            // notify_menu
            // 
            this.notify_menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.notify_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.show_hide,
            this.toolStripSeparator2,
            this.close});
            this.notify_menu.Name = "notify_menu";
            this.notify_menu.Size = new System.Drawing.Size(161, 58);
            // 
            // show_hide
            // 
            this.show_hide.Name = "show_hide";
            this.show_hide.Size = new System.Drawing.Size(160, 24);
            this.show_hide.Text = "Show / Hide";
            this.show_hide.Click += new System.EventHandler(this.show_hide_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // close
            // 
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(160, 24);
            this.close.Text = "Close";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // check_internet
            // 
            this.check_internet.Enabled = true;
            this.check_internet.Interval = 2000;
            this.check_internet.Tick += new System.EventHandler(this.internet_check_tick);
            // 
            // SGC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(894, 557);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.refresh_emails);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.setting);
            this.Controls.Add(this.main_panel);
            this.Controls.Add(this.BackImage);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SGC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimpleGmailCheck";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainClosing);
            this.Load += new System.EventHandler(this.MainLoad);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindowMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindowMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWindowMouseUp);
            this.IconContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackImage)).EndInit();
            this.notify_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip IconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maximizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.PictureBox BackImage;
        private System.Windows.Forms.FlowLayoutPanel main_panel;
        private System.Windows.Forms.Button setting;
        private System.Windows.Forms.Button close_button;
        private System.ComponentModel.BackgroundWorker loader;
        private System.Windows.Forms.Button refresh_emails;
        private System.Windows.Forms.Timer check_email;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip notify_menu;
        private System.Windows.Forms.ToolStripMenuItem show_hide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem close;
        private System.Windows.Forms.Timer check_internet;
    }
}

