using System.Drawing;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using System.Drawing.Drawing2D;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using System.Linq;
using System.Diagnostics;

namespace SimpleGmailCheck
{
    public partial class SGC : Form
    {
        private const string APP_ID = "SimpleGmailCheck";
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
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        static string[] Scopes = { GmailService.Scope.GmailReadonly };
        static string ApplicationName = "SimpleGmailCheck";
        private GmailService service;
        private UserCredential credential;
        private NotifyIcon ntf;
        private List<Google.Apis.Gmail.v1.Data.Message> messages;
        private bool debug = false;
        private int state = -1;
        private string status = "Sign In (Click)";
        private List<string> args;
        private bool message_found = false, running = true, lognow = false;
        private int max_message, cur_load;
        public bool shown = true;

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }
        private Bitmap LoadPicture(string url)
        {
            HttpWebRequest wreq;
            HttpWebResponse wresp;
            Stream mystream;
            Bitmap bmp;

            bmp = null;
            mystream = null;
            wresp = null;
            try
            {
                wreq = (HttpWebRequest)WebRequest.Create(url);
                wreq.AllowWriteStreamBuffering = true;
                wreq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36";

                wresp = (HttpWebResponse)wreq.GetResponse();

                if ((mystream = wresp.GetResponseStream()) != null)
                    bmp = new Bitmap(mystream);
            }
            finally
            {
                if (mystream != null)
                    mystream.Close();

                if (wresp != null)
                    wresp.Close();
            }
            return (bmp);
        }
        private static List<Google.Apis.Gmail.v1.Data.Message> ListMessages(GmailService service, string userId, string query)
        {
            List<Google.Apis.Gmail.v1.Data.Message> result = new List<Google.Apis.Gmail.v1.Data.Message>();
            UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
            request.Q = query;
            do
            {
                try
                {
                    ListMessagesResponse response = request.Execute();
                    result.AddRange(response.Messages);
                    request.PageToken = response.NextPageToken;
                }
                catch (Exception)
                {
                    //MessageBox.Show("ListMessages Error: " + e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            } while (!string.IsNullOrEmpty(request.PageToken));
            return result;
        }
        private static Google.Apis.Gmail.v1.Data.Message GetMessage(GmailService service, string userId, string messageId)
        {
            try
            {
                return service.Users.Messages.Get(userId, messageId).Execute();
            }
            catch (Exception)
            {
                //MessageBox.Show("An error occurred: " + e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return null;
        }
        private void LoadUnreadMessages()
        {
            List<EmailListItemAlt> items = new List<EmailListItemAlt>();
            cur_load = 0;
            messages = ListMessages(service, "me", "label:unread");
            if (messages != null && messages.Count > 0)
            {
                //loading_message = true;
                max_message = messages.Count;
                string sub = "";
                EmailListItemAlt item;
                Region rg = new Region(new Rectangle(0, 0, main_panel.Width, 30));
                //string from = "";
                //string web = "";
                foreach (var message in messages)
                {
                    Google.Apis.Gmail.v1.Data.Message msg = GetMessage(service, "me", message.Id);
                    foreach (var h in msg.Payload.Headers)
                    {
                        if (h.Name == "Subject")
                            sub = h.Value;
                    }
                    //    if (h.Name == "Reply-To")
                    //        from = h.Value;
                    //}
                    //Bitmap ico = Properties.Resources.email;
                    //if(from.Split('@').Length > 1)
                    //web = from.Split('@')[1];
                    //
                    //if(web!="")
                    //    ico = LoadPicture("http://www.google.com/s2/favicons?sz=256&domain_url="+web);
                    //Bitmap ico = LoadPicture("https://icons.duckduckgo.com/ip1/"+web+"ico");
                    //
                    //https://mail.google.com/mail/u/0/?ui=2&view=btop&ver=1nj101dboqm98&search=inbox&type=%2523thread-f%253A1669401905221732679&th=%23thread-f%3A1669438237674737453&cvid=1
                    item = new EmailListItemAlt(Properties.Resources.email, sub, msg.Snippet, "https://mail.google.com/mail/#inbox/" + msg.Id,msg);
                    //item = new EmailListItemAlt(Properties.Resources.email, sub, msg.Snippet, "https://mail.google.com/mail/u/0/?ui=2&view=btop&ver=1nj101dboqm98&search=inbox&type=%2523thread-f%25"+msg.ThreadId.ToUpper()+ "&th=%23thread-f%3A" + msg.ThreadId.ToUpper() + "&cvid=1",msg);
                    if (messages.Count <= 4)
                        item.Width = main_panel.Width - 22;
                    else
                        item.Width = main_panel.Width - 45;
                    if (messages[messages.Count - 1] == message)
                        item.Margin = new Padding(10, 10, 10, 10);
                    items.Add(item);
                    cur_load++;
                    main_panel.Refresh();
                }
                //loading_message = false;
                main_panel.Controls.AddRange(items.ToArray());
                message_found = true;
            }
            else
            {
                message_found = false;
            }
        }
        private void SignIn()
        {
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
            }
            service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
        }
        private void WatchNotify(GmailService service, string userId)
        {
            try
            {
                string date = DateTime.Today.ToShortDateString();
                List<Google.Apis.Gmail.v1.Data.Message> messages = ListMessages(service, "me", "after:" + date + " label:unread");

                if (messages != null && messages.Count > 0)
                {
                    string sub = "";
                    EmailListItemAlt item;
                    string from = "";
                    //string web = "";
                    foreach (var message in messages)
                    {
                        if (Properties.Settings.Default.notified_msg.Count > 0)
                            if (Properties.Settings.Default.notified_msg.Contains(message.Id))
                                continue;

                        Google.Apis.Gmail.v1.Data.Message msg = GetMessage(service, "me", message.Id);
                        XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);

                        foreach (var h in msg.Payload.Headers)
                        {
                            if (h.Name == "Subject")
                                sub = h.Value;
                            if (h.Name == "From")
                                from = h.Value;
                        }

                        XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
                        stringElements[0].AppendChild(toastXml.CreateTextNode(sub));
                        stringElements[1].AppendChild(toastXml.CreateTextNode(msg.Snippet));
                        stringElements[2].AppendChild(toastXml.CreateTextNode(from));

                        string imagePath = "file:///" + Path.GetFullPath("gmail.png");
                        XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
                        imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;

                        ToastNotification toast = new ToastNotification(toastXml);
                        toast.Activated += ToastActivated;
                        toast.Dismissed += ToastDismissed;
                        toast.Failed += ToastFailed;
                        toast.Tag = "https://mail.google.com/mail/#inbox/" + msg.Id;

                        item = new EmailListItemAlt(Properties.Resources.email, sub, msg.Snippet, "https://mail.google.com/mail/#inbox/" + msg.Id, msg);

                        if (main_panel.Controls.Count <= 4)
                            item.Width = main_panel.Width - 22;
                        else
                            item.Width = main_panel.Width - 45;
                        if (messages[messages.Count - 1] == message)
                            item.Margin = new Padding(10, 10, 10, 10);
                        main_panel.Controls.Add(item);

                        Properties.Settings.Default.notified_msg.Add(msg.Id);

                        ToastNotificationManager.CreateToastNotifier(APP_ID).Show(toast);
                    }
                    Properties.Settings.Default.Save();
                }
            }
            catch(Exception)
            {

            }
        }
        private void ToastFailed(ToastNotification sender, ToastFailedEventArgs args)
        {
            Properties.Settings.Default.notified_msg.Remove(sender.Tag.Split('/').Last());
            Properties.Settings.Default.Save();
        }
        private void ToastDismissed(ToastNotification sender, ToastDismissedEventArgs args)
        {
            //Process.Start(sender.Tag);
        }
        private void ToastActivated(ToastNotification sender, object args)
        {
            Process.Start(sender.Tag);
        }
        private Profile GetProfileData(GmailService service, string userId)
        {
            int try_count = 0;
            Profile p = new Profile();
            UsersResource.GetProfileRequest request = service.Users.GetProfile(userId);
            tryagain:
            try
            {
                p = request.Execute();
            }
            catch (Exception)
            {
                System.Threading.Thread.Sleep(30000);
                if (try_count < 5) 
                {
                    try_count++;
                    goto tryagain;
                }
                else
                {
                    Close();
                }
            }
            return p;
        }
        public SGC()
        {
            InitializeComponent();
            args = new List<string>(Environment.GetCommandLineArgs());
            ntf = new NotifyIcon();
            ntf.Visible = true;
            ntf.Icon = Icon;
            ntf.BalloonTipText = "SimpleGmailCheck";
            ntf.Text = "SimpleGmailCheck";
            ntf.ContextMenuStrip = notify_menu;
            ntf.DoubleClick += Ntf_DoubleClick;
            if (Properties.Settings.Default.notified_msg == null)
            {
                Properties.Settings.Default.notified_msg = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }
            BackImage.BackColor = Color.FromArgb(255, 0, 130, 215);
            if (!debug)
            {
                if (!Properties.Settings.Default.logged_in)
                {
                    state = -1;
                }
                else
                {
                    lognow = true;
                    check_internet.Stop();
                    loader.RunWorkerAsync();
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    EmailListItemAlt item = new EmailListItemAlt(Properties.Resources.email, $"Subject {i}", "Message", "",new Google.Apis.Gmail.v1.Data.Message());
                        item.Width = main_panel.Width - 45;
                    if (i == 7)
                        item.Margin = new Padding(10, 10, 10, 10);
                    main_panel.Controls.Add(item);
                }
            }
        }
        private void Ntf_DoubleClick(object sender, EventArgs e)
        {
            show_hide_Click(this, new EventArgs());
        }
        private void Status_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.logged_in == false)
            {
                if (loader.IsBusy)
                {
                    DialogResult dlg = MessageBox.Show(this, "Do you want try again?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    if (dlg == DialogResult.Yes)
                    {
                        state = -1;
                        loader.RunWorkerAsync();
                    }
                }
                else
                {
                    DialogResult dlg = MessageBox.Show(this, "Do you want to sign in?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    lognow = true;
                    if (dlg == DialogResult.Yes)
                    {
                        state = -1;
                        loader.RunWorkerAsync();
                    }
                }
            }
        }
        public Bitmap OutputGradientImage(Color from, Color to)
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, Width, Height),
                from,
                to,
                LinearGradientMode.ForwardDiagonal);
                brush.SetSigmaBellShape(0.5f);
            graphics.FillRectangle(brush, new Rectangle(0, 0, Width, Height));
            return bitmap;
        }
        private void MainWindowMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                    dragging = true;
                    dragCursorPoint = Cursor.Position;
                    dragFormPoint = Location;
            }
            else if(e.Button == MouseButtons.Right)
            {
                if(e.Location.X >= 12 && e.Location.Y >= 12 && e.Location.X <= (32+12) && e.Location.Y <= (32+12))
                {
                    IconContextMenu.Show(Cursor.Position);
                }
            }
        }
        private void MainWindowMouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            Cursor = Cursors.Default;
        }
        private void MainWindowMouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void CloseButtonClicked(object sender, System.EventArgs e)
        {
            Close();
        }
        private void minimizeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void closeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        private void OpenSettings(object sender, EventArgs e)
        {
            Settings swd = new Settings(credential);
            swd.ShowDialog();
            if(Properties.Settings.Default.logged_in==false)
            {
                state = -1;
                main_panel.Controls.Clear();
                main_panel.Refresh();
            }
        }
        private void BackImagePaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.DrawImage(Properties.Resources.gmail, new Rectangle(12,12,32,32));
            Font title = new Font("Segoe UI", 12f);
            e.Graphics.DrawString("SimpleGmailCheck", title, Brushes.White, new Point(50,11));
        }
        private void RefreshEmailList(object sender, EventArgs e)
        {
            main_panel.Controls.Clear();
            state = 2;
            loader.RunWorkerAsync();
        }
        private void email_check_tick(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.logged_in && IsConnectedToInternet())
                WatchNotify(service, "me");
        }
        private void show_hide_Click(object sender, EventArgs e)
        {
            if (shown)
            {
                Hide();
                shown = false;
            }
            else
            {
                Show();
                shown = true;
            }
            if(Properties.Settings.Default.hide_notify==true)
            {
                ntf.ShowBalloonTip(2000, "SimpleGmailCheck", "Hey, You can access it from here when its hidden!", ToolTipIcon.Info);
                Properties.Settings.Default.hide_notify = false;
                Properties.Settings.Default.Save();
            }
        }
        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void MainLoad(object sender, EventArgs e)
        {
            
        }
        private void MinimizeClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void internet_check_tick(object sender, EventArgs e)
        {
            if(IsConnectedToInternet())
            {
                state = -1;
                lognow = true;
                check_internet.Stop();
                loader.RunWorkerAsync();
            }
        }
        private void CheckHide(object sender, EventArgs e)
        {
            if (args == null)
                args = new List<string>(Environment.GetCommandLineArgs());
            if (args.Contains("--hide"))
            {
                Hide();
                shown = false;
                args.Remove("--hide");
            }
        }
        private void loader_work(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if(!IsConnectedToInternet())
            {
                MessageBox.Show("Internet Connection is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Invoke(new Action(() => check_internet.Start()));
                return;
            }
            while (state != 3 && running && lognow)
            {
                if(state==-1)
                {
                    Invoke(new Action(() => { SignIn(); state = 1; }));
                }
                else if (state == 1)
                {
                    Profile p=null;
                    try
                    {
                        UsersResource.GetProfileRequest rp = service.Users.GetProfile("me");
                        p = rp.Execute();
                    }
                    catch(Exception)
                    {

                    }
                    if(p!=null)
                    {
                        Invoke(new Action(() =>
                        {
                            Properties.Settings.Default.email = p.EmailAddress;
                            Properties.Settings.Default.logged_in = true;
                            Properties.Settings.Default.Save();
                            state = 2;
                            Activate();
                        }));
                    }
                }
                else if (state == 2)
                {
                    Invoke(new Action(() =>
                    {
                        LoadUnreadMessages();
                        if (!message_found)
                            state = -2;
                        else
                            state = 3;
                        check_email.Start();
                    }
                    ));
                    if (state == -2)
                    {
                        Invoke(new Action(() => main_panel.Refresh()));
                        break;
                    }
                }
                Invoke(new Action(() => main_panel.Refresh()));
            }
            return;
        }
        private void MainClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
        }
        private void MainPanelPaint(object sender, PaintEventArgs e)
        {
            if(state!=3)
            {
                if(state==-1)
                {
                    status = "Sign In (Click)";
                }
                if(state==0)
                {
                    status = "Signing in...";
                }
                else if(state==1)
                {
                    status = "Waiting for access...";
                }
                else if(state==2)
                {
                    status = $"Reading emails... ({cur_load}/{max_message})";
                }
                else if(state==-2)
                {
                    status = "There is no Unread emails!";
                }
                e.Graphics.DrawString(status, Font, Brushes.Black, new Point(10, 10));
                /*if(loading_message)
                {
                    const int width = 300;
                    const int height = 20;
                    int x = main_panel.Width / 2 - width / 2;
                    int y = main_panel.Height / 2 - height / 2;
                    int parts = width / max_message;
                    int loaded_x = cur_load * parts;

                    
                    e.Graphics.FillRectangle(Brushes.Blue, x, y, loaded_x, height);
                    e.Graphics.DrawRectangle(Pens.Black, x, y, width, height);

                }*/
            }
        }
    }
}
