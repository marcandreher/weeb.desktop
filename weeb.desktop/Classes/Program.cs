using Microsoft.Win32;
using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using weeb.desktop.Neues_Design;

namespace weeb.desktop
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string endstring = "";
            for (int i = 0; i < args.Length; i++)
            {
                endstring = endstring + args[i];
            }

            //OPEN FILE VIA .weebd
            if (!(endstring == ""))
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
                ZipFile.ExtractToDirectory(endstring, currentskinpath + "\\checkpaper");
                Application.Run(new WallpaperChecker(currentskinpath + "\\checkpaper" + "\\m.meta", endstring, true));

            }
            // Run Main Activity if the program is sure that it don't must parse a File
            Application.Run(new MainForm());

        }

    }
}
