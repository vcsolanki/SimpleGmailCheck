namespace SimpleGmailCheck
{
    partial class EmailListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.email_image = new System.Windows.Forms.PictureBox();
            this.email_title = new System.Windows.Forms.Label();
            this.email_text = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.email_image)).BeginInit();
            this.SuspendLayout();
            // 
            // email_image
            // 
            this.email_image.Location = new System.Drawing.Point(4, 5);
            this.email_image.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.email_image.Name = "email_image";
            this.email_image.Size = new System.Drawing.Size(100, 100);
            this.email_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.email_image.TabIndex = 0;
            this.email_image.TabStop = false;
            this.email_image.Click += new System.EventHandler(this.OpenEmailLink);
            this.email_image.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // email_title
            // 
            this.email_title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.email_title.AutoEllipsis = true;
            this.email_title.Location = new System.Drawing.Point(111, 5);
            this.email_title.Name = "email_title";
            this.email_title.Size = new System.Drawing.Size(509, 26);
            this.email_title.TabIndex = 1;
            this.email_title.Text = "email_title";
            this.email_title.Click += new System.EventHandler(this.OpenEmailLink);
            this.email_title.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // email_text
            // 
            this.email_text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.email_text.AutoEllipsis = true;
            this.email_text.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_text.Location = new System.Drawing.Point(116, 44);
            this.email_text.Name = "email_text";
            this.email_text.Size = new System.Drawing.Size(504, 59);
            this.email_text.TabIndex = 2;
            this.email_text.Text = "email_text";
            this.email_text.Click += new System.EventHandler(this.OpenEmailLink);
            this.email_text.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // EmailListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.email_text);
            this.Controls.Add(this.email_title);
            this.Controls.Add(this.email_image);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.Name = "EmailListItem";
            this.Size = new System.Drawing.Size(623, 108);
            this.Load += new System.EventHandler(this.EmailListItem_Load);
            this.Click += new System.EventHandler(this.OpenEmailLink);
            this.DoubleClick += new System.EventHandler(this.OpenEmailLink);
            this.MouseEnter += new System.EventHandler(this.OnMouseEntered);
            this.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.email_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox email_image;
        private System.Windows.Forms.Label email_title;
        private System.Windows.Forms.Label email_text;
    }
}
