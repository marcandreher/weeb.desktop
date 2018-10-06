using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weeb.desktop.Classes
{
    class Static
    {
       public static string meta = Application.UserAppDataPath + "\\weeb.desktop\\currentwallpaper\\wallpaper\\m.meta";
        public static string f = Application.UserAppDataPath + "\\weeb.desktop\\currentwallpaper\\wallpaper\\";
        public static Thread t = new Thread(wallpaper);
        public static void startWallpaper()
        {
                t.Start();
        }

        public static void wallpaper()
        {
            while(true)
            {
                int i2 = System.Convert.ToInt32(readFPS());
                

                // Change Wallpaper
                System.IO.DirectoryInfo di = new DirectoryInfo(f);
                int i3 = 0;
                foreach (FileInfo file in di.GetFiles())
                {
                    if(file.Name.Contains(".jpg"))
                    {
                        i3++;
                    }
                    
                }

                
                for (int i = 1; i < i3; i++)
                {
                    Wallpaper.Set(new Uri(f + i + ".jpg"), Wallpaper.Style.Stretched);
                }
            }
        }

        public static string readFPS()
        {
            return GetLine(meta, 1);
        }

       public static string GetLine(string fileName, int line)
        {
            using (var sr = new StreamReader(fileName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }

    }
}
