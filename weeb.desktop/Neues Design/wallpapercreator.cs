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
using weeb.desktop.Neues_Design;

namespace weeb.desktop.Forms
{
    public partial class wallpapercreator : Form
    {
        public wallpapercreator()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem == null)
            {
                pictureBox1.Image = null;
                return;
            }
            pictureBox1.Image = Image.FromFile(listBox1.GetItemText(listBox1.SelectedItem));
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            string currentskinpath = Application.UserAppDataPath + "\\weeb.desktop\\wallpapercreatorbuffer";
            System.IO.DirectoryInfo di = new DirectoryInfo(currentskinpath);
            // CLEAR OLD FOLDER
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            // META FILE EXPORT
            string meta = textBox1.Text + "\n" + textBox2.Text + "\n" + textBox3.Text + "\n" + "1.1metafiletype";
            
            if (!File.Exists(currentskinpath))
            {
                TextWriter tw = new StreamWriter(currentskinpath + "\\m.meta");
                tw.WriteLine(textBox1.Text);
                tw.WriteLine(textBox2.Text);
                tw.WriteLine(textBox3.Text);
                tw.WriteLine("1.1weebmetatype");
                tw.Close();
            }
            else if (File.Exists(currentskinpath))
            {
                TextWriter tw = new StreamWriter(currentskinpath + "\\m.meta");
                tw.WriteLine(textBox1.Text);
                tw.WriteLine(textBox2.Text);
                tw.WriteLine(textBox3.Text);
                tw.WriteLine("1.1weebmetatype");
                tw.Close();
            }
            int i = 1;
            //ADD FILES TO TEMP FOLDER
            foreach (object obj in listBox1.Items) {
                File.Copy(listBox1.GetItemText(obj), currentskinpath + "\\" + i + ".jpg");
                i++;
            }
            // ZIP FILES
            Directory.CreateDirectory(Application.UserAppDataPath + "\\weeb.desktop\\skins\\");
            ZipFile.CreateFromDirectory(currentskinpath, Application.UserAppDataPath + "\\weeb.desktop\\skins\\" + textBox2.Text + ".weebd");

            MessageBox.Show("Created Wallpaper");

        }

        private void wallpapercreator_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainCreator c = new MainCreator();
            c.Show();
            this.Close();
        }
    }
}
