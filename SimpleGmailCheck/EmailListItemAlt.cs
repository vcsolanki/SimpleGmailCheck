using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace SimpleGmailCheck
{
    public partial class EmailListItemAlt : UserControl
    {
        private string email_title, email_text, email_link;
        private Bitmap icon;
        private bool high_lit = false;
        private bool clicked = false, read=false;
        private Point MouseLocation;
        private Font title_font = new Font("Segoe UI", 12f, FontStyle.Bold);
        private Rectangle title_rect, text_rect,control_size;
        private Font text_font = new Font("Segoe UI", 9f);
        private LinearGradientBrush brush;
        private float per = 0;
        private int alpha = 0;
        private Google.Apis.Gmail.v1.Data.Message message;
        public EmailListItemAlt(Bitmap image, string title, string text, string link, Google.Apis.Gmail.v1.Data.Message message)
        {
            InitializeComponent();
            icon = image;
            email_title = title;
            email_text = text;
            email_link = link;
            DoubleBuffered = true;
            this.message = message;
            smoother.Stop();
        }
        private void OnMouseEnter(object sender, EventArgs e)
        {
            high_lit = true;
            smoother.Start();
            Refresh();
        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            high_lit = false;
            Refresh();
        }
        private void OpenEmailLink(object sender, EventArgs e)
        {
            if (clicked)
            {
                //icon = Properties.Resources.open_email;
                read = true;
                if(email_link!="")
                    Process.Start(email_link);
            }
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                clicked = true;
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }
        private void ItemLoaded(object sender, EventArgs e)
        {
            text_rect = new Rectangle(116, 44, Width - 116, 59);
            title_rect = new Rectangle(111, 5, Width - 111, 32);
            control_size = new Rectangle(0, 0, Width, Height);
        }

        private void smooth_tick(object sender, EventArgs e)
        {
            if(high_lit)
            {
                if(alpha < 255)
                {
                    alpha+=15;
                    Refresh();
                }
            }
            else
            {
                if (alpha > 0)
                {
                    alpha-=15;
                    Refresh();
                }
                else
                {
                    smoother.Stop();
                }
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation = e.Location;
            Refresh();
        }
        private void OnMouseHover(object sender, EventArgs e)
        {

        }
        private void DoPaintEvent(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            if (read)
            {
                Brush bray = new SolidBrush(Color.FromArgb(60, 0, 0, 0));
                FillRoundedRectangle(e.Graphics, bray, control_size, 7);
            }
            if (high_lit==true || alpha!=0)
            {
                per = (float)MouseLocation.X / (float)Width;
                brush = new LinearGradientBrush(control_size, Color.FromArgb(alpha, 0, 155, 255), Color.FromArgb(alpha, 0, 212, 255), LinearGradientMode.Horizontal);
                brush.SetSigmaBellShape(per);
                FillRoundedRectangle(e.Graphics, brush, control_size, 7);
            }
            DrawRoundedRectangle(e.Graphics, Pens.Black, 0, 0, Width-1, Height-1, 7, 7);
            e.Graphics.DrawImage(icon, new Rectangle(4+5, 5+5, 100-10, 100-10));
            TextRenderer.DrawText(e.Graphics, email_title, title_font, title_rect , Color.Black,Color.Transparent,TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis);
            TextRenderer.DrawText(e.Graphics, email_text, text_font, text_rect, Color.Black, Color.Transparent, TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis);
            
        }

        private void DrawRoundedRectangle(Graphics g, Pen p, int x, int y, int w, int h, int rx, int ry)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(x, y, rx + rx, ry + ry, 180, 90);
            path.AddLine(x + rx, y, x + w - rx, y);
            path.AddArc(x + w - 2 * rx, y, 2 * rx, 2 * ry, 270, 90);
            path.AddLine(x + w, y + ry, x + w, y + h - ry);
            path.AddArc(x + w - 2 * rx, y + h - 2 * ry, rx + rx, ry + ry, 0, 91);
            path.AddLine(x + rx, y + h, x + w - rx, y + h);
            path.AddArc(x, y + h - 2 * ry, 2 * rx, 2 * ry, 90, 91);
            path.CloseFigure();
            g.DrawPath(p, path);
        }
        private void FillRoundedRectangle(Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (brush == null)
                throw new ArgumentNullException("brush");

            using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.FillPath(brush, path);
            }
        }
        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
