namespace SimpleGmailCheck
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.main_panel = new System.Windows.Forms.Panel();
            this.settings_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.app_settings_group = new System.Windows.Forms.GroupBox();
            this.admin_info = new System.Windows.Forms.Label();
            this.run_at_startup = new System.Windows.Forms.CheckBox();
            this.account_settings_group = new System.Windows.Forms.GroupBox();
            this.sign_out_button = new System.Windows.Forms.Button();
            this.email_info = new System.Windows.Forms.Label();
            this.close_button = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.main_panel.SuspendLayout();
            this.settings_panel.SuspendLayout();
            this.app_settings_group.SuspendLayout();
            this.account_settings_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.main_panel.Controls.Add(this.settings_panel);
            this.main_panel.Controls.Add(this.close_button);
            this.main_panel.Controls.Add(this.title);
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.Location = new System.Drawing.Point(0, 0);
            this.main_panel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(685, 282);
            this.main_panel.TabIndex = 0;
            // 
            // settings_panel
            // 
            this.settings_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settings_panel.Controls.Add(this.app_settings_group);
            this.settings_panel.Controls.Add(this.account_settings_group);
            this.settings_panel.Location = new System.Drawing.Point(3, 39);
            this.settings_panel.Name = "settings_panel";
            this.settings_panel.Padding = new System.Windows.Forms.Padding(3);
            this.settings_panel.Size = new System.Drawing.Size(677, 238);
            this.settings_panel.TabIndex = 10;
            // 
            // app_settings_group
            // 
            this.app_settings_group.Controls.Add(this.admin_info);
            this.app_settings_group.Controls.Add(this.run_at_startup);
            this.app_settings_group.Location = new System.Drawing.Point(6, 6);
            this.app_settings_group.Name = "app_settings_group";
            this.app_settings_group.Size = new System.Drawing.Size(662, 80);
            this.app_settings_group.TabIndex = 0;
            this.app_settings_group.TabStop = false;
            this.app_settings_group.Text = "Application";
            // 
            // admin_info
            // 
            this.admin_info.AutoSize = true;
            this.admin_info.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_info.Location = new System.Drawing.Point(192, 34);
            this.admin_info.Name = "admin_info";
            this.admin_info.Size = new System.Drawing.Size(294, 28);
            this.admin_info.TabIndex = 1;
            this.admin_info.Text = "(Need Administrator Permission)";
            // 
            // run_at_startup
            // 
            this.run_at_startup.AutoSize = true;
            this.run_at_startup.Location = new System.Drawing.Point(24, 33);
            this.run_at_startup.Name = "run_at_startup";
            this.run_at_startup.Size = new System.Drawing.Size(162, 32);
            this.run_at_startup.TabIndex = 0;
            this.run_at_startup.Text = "Run At Startup";
            this.run_at_startup.UseVisualStyleBackColor = true;
            this.run_at_startup.CheckedChanged += new System.EventHandler(this.run_at_startup_CheckedChanged);
            this.run_at_startup.Click += new System.EventHandler(this.CheckPermission);
            // 
            // account_settings_group
            // 
            this.account_settings_group.Controls.Add(this.sign_out_button);
            this.account_settings_group.Controls.Add(this.email_info);
            this.account_settings_group.Location = new System.Drawing.Point(6, 92);
            this.account_settings_group.Name = "account_settings_group";
            this.account_settings_group.Size = new System.Drawing.Size(662, 139);
            this.account_settings_group.TabIndex = 1;
            this.account_settings_group.TabStop = false;
            this.account_settings_group.Text = "Account";
            // 
            // sign_out_button
            // 
            this.sign_out_button.Location = new System.Drawing.Point(24, 88);
            this.sign_out_button.Name = "sign_out_button";
            this.sign_out_button.Size = new System.Drawing.Size(113, 38);
            this.sign_out_button.TabIndex = 1;
            this.sign_out_button.Text = "Sign Out";
            this.sign_out_button.UseVisualStyleBackColor = true;
            this.sign_out_button.Click += new System.EventHandler(this.sign_out_button_Click);
            // 
            // email_info
            // 
            this.email_info.AutoSize = true;
            this.email_info.Location = new System.Drawing.Point(19, 42);
            this.email_info.Name = "email_info";
            this.email_info.Size = new System.Drawing.Size(73, 28);
            this.email_info.TabIndex = 0;
            this.email_info.Text = "Email : ";
            // 
            // close_button
            // 
            this.close_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_button.Image = global::SimpleGmailCheck.Properties.Resources.close;
            this.close_button.Location = new System.Drawing.Point(640, 3);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(32, 32);
            this.close_button.TabIndex = 9;
            this.close_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.CloseClicked);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(11, 3);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(83, 28);
            this.title.TabIndex = 0;
            this.title.Text = "Settings";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 282);
            this.Controls.Add(this.main_panel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            this.settings_panel.ResumeLayout(false);
            this.app_settings_group.ResumeLayout(false);
            this.app_settings_group.PerformLayout();
            this.account_settings_group.ResumeLayout(false);
            this.account_settings_group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.FlowLayoutPanel settings_panel;
        private System.Windows.Forms.GroupBox app_settings_group;
        private System.Windows.Forms.Label admin_info;
        private System.Windows.Forms.CheckBox run_at_startup;
        private System.Windows.Forms.GroupBox account_settings_group;
        private System.Windows.Forms.Button sign_out_button;
        private System.Windows.Forms.Label email_info;
    }
}