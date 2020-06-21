using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1.Data;
using Microsoft.Win32;

namespace SimpleGmailCheck
{
    public partial class Settings : Form
    {
        [DllImport("shell32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsUserAnAdmin();

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private UserCredential cred;

        public Settings(UserCredential cred)
        {
            InitializeComponent();
            if(IsUserAnAdmin())
            {
                admin_info.Hide();
            }
            if (Properties.Settings.Default.run_at_startup)
                run_at_startup.Checked = true;
            if(Properties.Settings.Default.logged_in)
            {
                email_info.Text = "Email : " + Properties.Settings.Default.email;
            }
            else
            {
                sign_out_button.Enabled = false;
            }
            this.cred=cred;
        }

        private void CloseClicked(object sender, EventArgs e)
        {
            Close();
        }
        private void run_at_startup_CheckedChanged(object sender, EventArgs e)
        {
            if (IsUserAnAdmin())
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (run_at_startup.Checked)
                {
                    rk.SetValue("SimpleGmailCheck", Application.ExecutablePath + "  --hide");
                    Properties.Settings.Default.run_at_startup = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    rk.DeleteValue("SimpleGmailCheck", false);
                    Properties.Settings.Default.run_at_startup = false;
                    Properties.Settings.Default.Save();
                }
            }
        }
        private void sign_out_button_Click(object sender, EventArgs e)
        {
            if (IsConnectedToInternet())
            {
                DialogResult dlg = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (dlg == DialogResult.Yes)
                {
                    sign_out_button.Text = "Signing Out...";
                    sign_out_button.AutoSize = true;
                    sign_out_button.Enabled = false;

                    string data = "?token=" + cred.Token.AccessToken;
                    HttpWebRequest webr = WebRequest.CreateHttp("https://accounts.google.com/o/oauth2/revoke" + data);
                    webr.ContentType = "application/x-www-form-urlencoded";
                    webr.Method = "GET";
                    HttpWebResponse webs;
                    try
                    {
                        webs = (HttpWebResponse)webr.GetResponse();
                        if (webs.StatusCode == HttpStatusCode.OK)
                        {
                            Properties.Settings.Default.logged_in = false;
                            Properties.Settings.Default.email = "";
                            Properties.Settings.Default.Save();
                            sign_out_button.Text = "Done!";
                            sign_out_button.Enabled = false;
                            Directory.Delete(Environment.CurrentDirectory + "/token.json/", true);
                        }
                        else
                        {
                            sign_out_button.Text = "Sign Out (Try again)";
                            sign_out_button.Enabled = true;
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message + "\nAccesed URL : "+webr.RequestUri.AbsoluteUri, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sign_out_button.Text = "Sign Out (Try again)";
                        sign_out_button.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("You need internet connection!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void CheckPermission(object sender, EventArgs e)
        {
            if(!IsUserAnAdmin())
            {
                MessageBox.Show("You need to start this application as Administrator to do that!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                run_at_startup.Checked = false;
            }
        }
    }
}
