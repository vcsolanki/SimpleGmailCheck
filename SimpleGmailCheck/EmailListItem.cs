using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;

namespace SimpleGmailCheck
{
    public partial class EmailListItem : UserControl
    {

        private Color bcol;
        private Color hcol;
        private string email_link;

        public EmailListItem(Bitmap image, string title, string text, string link)
        {
            InitializeComponent();
            bcol = Color.White;
            hcol = Color.LightBlue;
            email_image.Image = image;
            email_title.Text = title;
            email_text.Text = text;
            email_link = link;
        }

        private void OnMouseHover(object sender, EventArgs e)
        {
                BackColor = hcol;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            Control l = GetChildAtPoint(Cursor.Position);
            if(l==email_image || l==email_text || l==email_title)
            {

            }
            else
            {
                BackColor = bcol;
            }
        }

        private void OpenEmailLink(object sender, EventArgs e)
        {
            email_image.Image = Properties.Resources.open_email;
            System.Diagnostics.Process.Start(email_link);
        }

        private void EmailListItem_Load(object sender, EventArgs e)
        {

        }

        private void OnMouseEntered(object sender, EventArgs e)
        {
            
            BackColor = hcol;
        }
    }
}
