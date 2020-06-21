namespace SimpleGmailCheck
{
    partial class EmailListItemAlt
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
            this.components = new System.ComponentModel.Container();
            this.smoother = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // smoother
            // 
            this.smoother.Enabled = true;
            this.smoother.Interval = 5;
            this.smoother.Tick += new System.EventHandler(this.smooth_tick);
            // 
            // EmailListItemAlt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.Name = "EmailListItemAlt";
            this.Size = new System.Drawing.Size(623, 108);
            this.Load += new System.EventHandler(this.ItemLoaded);
            this.Click += new System.EventHandler(this.OpenEmailLink);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DoPaintEvent);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.MouseHover += new System.EventHandler(this.OnMouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer smoother;
    }
}
