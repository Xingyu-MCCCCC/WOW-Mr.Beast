using System;
using System.Media;
using System.Windows.Forms;
using System.Drawing;

namespace AudioTray
{
    static class Program
    {
        private static NotifyIcon notifyIcon;
        private static SoundPlayer player;

        [STAThread]
        static void Main()
        {
            string audioFile = @"Main.wav";

            if (!System.IO.File.Exists(audioFile))
            {
                MessageBox.Show("音频文件不存在: " + audioFile, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            player = new SoundPlayer(audioFile);

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("Main.ico");
            notifyIcon.Visible = true;
            notifyIcon.Text = "WOW Mr.Beast";

            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("播放", null, new EventHandler(PlayAudio));
            menu.Items.Add("停止", null, new EventHandler(StopAudio));
            menu.Items.Add("退出", null, new EventHandler(ExitApp));

            notifyIcon.ContextMenuStrip = menu;
            notifyIcon.MouseClick += new MouseEventHandler((s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    PlayAudio(s, e);
            });

            Application.Run();
        }

        private static void PlayAudio(object sender, EventArgs e)
        {
            player.Play();
        }

        private static void StopAudio(object sender, EventArgs e)
        {
            player.Stop();
        }

        private static void ExitApp(object sender, EventArgs e)
        {
            player.Stop();
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
