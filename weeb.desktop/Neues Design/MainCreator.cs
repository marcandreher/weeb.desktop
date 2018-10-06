using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weeb.desktop.Neues_Design
{
    public partial class MainCreator : Form
    {
        public MainCreator()
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

        private void panel3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.gif, *.png) | *.jpg; *.gif; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.Title = "Add file to your Wallpaper";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = dialog.FileName;
                listBox1.Items.Add(filePath);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                pictureBox5.Image = null;
                return;
            }
            pictureBox5.Image = Image.FromFile(listBox1.GetItemText(listBox1.SelectedItem));
        }

        private void label5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            if(panel7.Visible == true)
            {
                panel7.Visible = false;
            }
            else
            {
                panel7.Visible = true;
            }
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            string currentskinpath = Application.UserAppDataPath + "\\weeb.desktop\\wallpapercreatorbuffer";
            Directory.CreateDirectory(currentskinpath);
            System.IO.DirectoryInfo di = new DirectoryInfo(currentskinpath);
            // CLEAR OLD FOLDER
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            

            if (!File.Exists(currentskinpath))
            {
                TextWriter tw = new StreamWriter(currentskinpath + "\\m.meta");
                tw.WriteLine(threadtimeout.Text);
                tw.WriteLine(filename.Text);
                tw.WriteLine(description.Text);
                tw.WriteLine("2.1weebmetatype");
                tw.WriteLine(author.Text);
                tw.WriteLine(key.Text);
                tw.WriteLine(tags.Text);
                tw.Close();
            }
            else if (File.Exists(currentskinpath))
            {
                TextWriter tw = new StreamWriter(currentskinpath + "\\m.meta");
                tw.WriteLine(threadtimeout.Text);
                tw.WriteLine(filename.Text);
                tw.WriteLine(description.Text);
                tw.WriteLine("2.1weebmetatype");
                tw.WriteLine(author.Text);
                tw.WriteLine(key.Text);
                tw.WriteLine(tags.Text);
                tw.Close();
            }
            int i = 1;
            //ADD FILES TO TEMP FOLDER
            foreach (object obj in listBox1.Items)
            {
                File.Copy(listBox1.GetItemText(obj), currentskinpath + "\\" + i + ".jpg");
                i++;
            }
            if(i == 1)
            {
                MessageBox.Show("Don't export Empty Wallpapers");
                return;
            }
            // ZIP FILES
            Directory.CreateDirectory(Application.UserAppDataPath + "\\weeb.desktop\\skins\\");
            try
            {
                ZipFile.CreateFromDirectory(currentskinpath, Application.UserAppDataPath + "\\weeb.desktop\\skins\\" + filename.Text + ".weebd");
            }
            catch(Exception e2)
            {
                MessageBox.Show("Choose another Name the File already exist!");
                return;
            }
            
            Process.Start("explorer.exe", "/select, " + Application.UserAppDataPath + "\\weeb.desktop\\skins\\");

            MessageBox.Show("Created Wallpaper");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
