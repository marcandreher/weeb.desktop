using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using weeb.desktop.Classes;

namespace weeb.desktop.Neues_Design
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private bool mouseDown;
        private Point lastLocation;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.Title = "Choose weebd Wallpaper";
            dia.Filter = "Weeb.Desktop files (*.weebd) | *.weebnew; *.weebd;";
            if (dia.ShowDialog() == DialogResult.OK)
            {
                string currentskinpath = Application.UserAppDataPath + "\\weeb.desktop\\currentwallpaper";

                System.IO.DirectoryInfo di = new DirectoryInfo(currentskinpath + "\\checkpaper");
                Directory.CreateDirectory(currentskinpath + "\\checkpaper");
                // CLEAR OLD FOLDER
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                Directory.CreateDirectory(currentskinpath + "\\checkpaper");
                ZipFile.ExtractToDirectory(dia.FileName, currentskinpath + "\\checkpaper");

                WallpaperChecker c = new WallpaperChecker(currentskinpath + "\\checkpaper" + "\\m.meta", dia.FileName);
                c.Show();
            }
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            Static.startWallpaper();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://kazukii.me/weeb/page1.html");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://kazukii.me/weeb/");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
               ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (checkBox1.Checked)
                rk.SetValue("weeb.desktop", Application.ExecutablePath);
            else
                rk.DeleteValue("weeb.desktop", false);
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            panel11.Visible = false;
            panel12.Visible = false;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            panel11.Visible = true;
            panel12.Visible = false;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            panel11.Visible = true;
            panel12.Visible = true;
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            Form i = new MainCreator();
            i.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
