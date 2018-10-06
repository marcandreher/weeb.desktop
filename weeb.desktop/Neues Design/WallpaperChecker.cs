using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weeb.desktop.Neues_Design
{
    public partial class WallpaperChecker : Form
    {

        private String pathmeta;
        private String filename;

        public WallpaperChecker(String pathtometa, String diafilename)
        {
            InitializeComponent();
            pathmeta = pathtometa;
            filename = diafilename;
            if(GetLine(pathmeta, 4).Equals("1.1weebmetatype"))
            {
                label6.Visible = true;
                label6.Text = "Old Wallpaper, tell the Creator to update";

                //OLD File
                label2.Text = "Thread Timeout: " + GetLine(pathmeta, 1);
                label3.Text = "Wallpaper Name: " + GetLine(pathmeta, 2);
                label4.Text = "Wallpaper Description: " + GetLine(pathmeta, 3);
                label5.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                
            }else if(GetLine(pathmeta, 4).Equals("2.1weebmetatype"))
            {
                label2.Text = "Thread Timeout: " + GetLine(pathmeta, 1);
                label3.Text = "Wallpaper Name: " + GetLine(pathmeta, 2);
                label4.Text = "Wallpaper Description: " + GetLine(pathmeta, 3);
                label5.Text = "Wallpaper Author: " + GetLine(pathmeta, 5);
                label7.Text = "Wallpaper Key: " + GetLine(pathtometa, 6);
                label8.Text = "Wallpaper Tags: " + GetLine(pathtometa, 7);

            }

        }

        private string GetLine(string fileName, int line)
        {
            using (var sr = new StreamReader(fileName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string currentskinpath = Application.UserAppDataPath + "\\weeb.desktop\\currentwallpaper";
            Directory.CreateDirectory(currentskinpath + "\\wallpaper");
            System.IO.DirectoryInfo di = new DirectoryInfo(currentskinpath + "\\wallpaper");
            // CLEAR OLD FOLDER
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            var filePath = filename;
            Directory.CreateDirectory(currentskinpath + "\\wallpaper");
            ZipFile.ExtractToDirectory(filePath, currentskinpath + "\\wallpaper");
            this.Close();
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
    }
}
