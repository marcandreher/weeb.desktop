using Microsoft.Win32;
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
using weeb.desktop.Classes;
using weeb.desktop.Forms;

namespace weeb.desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (checkBox1.Checked)
                rk.SetValue("weeb.desktop", Application.ExecutablePath);
            else
                rk.DeleteValue("weeb.desktop", false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new wallpapercreator();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog dia = new OpenFileDialog();
            dia.Title = "Choose weebd Wallpaper";
            dia.Filter = "Weeb.Desktop files (*.weebd) | *.weebnew; *.weebd;";
            if (dia.ShowDialog() == DialogResult.OK)
            {
                string currentskinpath = Application.UserAppDataPath + "\\weeb.desktop\\currentwallpaper";
                System.IO.DirectoryInfo di = new DirectoryInfo(currentskinpath+ "\\wallpaper");
                // CLEAR OLD FOLDER
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                var filePath = dia.FileName;
                Directory.CreateDirectory(currentskinpath + "\\wallpaper");
                ZipFile.ExtractToDirectory(filePath, currentskinpath + "\\wallpaper");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Static.t.Interrupt();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Static.startWallpaper();
        }
    }
}
