using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace YouSaw_0._3
{
    static class Methods
    {
        public enum MenuOption
        {
            isOpen = -1,
            isClose = -2,
        }
        public static string[] videos_extention = { ".mp4", ".avi", ".mpg", ".3gp", ".wmv", ".mkv", ".rm" };
        public static string[] images_extention = { ".jpg", ".jpeg"};
        public static int MenuOptions = 5;

        public static IWMPMedia mediainfo;
        private static WindowsMediaPlayer windowsMediaPlayer = new WindowsMediaPlayer();
        public static int scroll_max = 20;
        public static Random random = new Random(Methods.timeNow());
        public static double getDuration(string url)
        {
            int duracion = 3;
            {
                mediainfo = windowsMediaPlayer.newMedia(url);
                if (mediainfo != null)
                    if (mediainfo.duration != 0)
                    {
                        duracion = (int)mediainfo.duration;
                    }

            }
            return duracion;
        }
        public static string getDurationString(string url)
        {
            return TimeSpan.FromSeconds(getDuration(url)).ToString();
        }
        public static string getTimeLabel()
        {
            return Convert.ToString(TimeSpan.FromSeconds(timeNow()));
        }
        public static string getTimeLabel(double time)
        {
            return Convert.ToString(TimeSpan.FromSeconds(time));
        }
        public static int getViews(string path)
        {
            string p = path.Remove(path.Length - path.Split('.')[path.Split('.').Length - 1].Length) + "txt";
            if (File.Exists(p))
            {
                using (var readtext = new StreamReader(p))
                {
                    string readText = readtext.ReadLine();
                    return int.Parse(readText.Split('-')[0]);
                }
            }
            return 0;
        }
        public static bool IsDirectory(string path)
        {
            System.IO.FileAttributes fa = System.IO.File.GetAttributes(path);
            return (fa & FileAttributes.Directory) != 0;
        }
        public static int timeNow()
        {
            return int.Parse(TimeSpan.Parse(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second).TotalSeconds.ToString());
        }
        public static int getRandom(int maxValue)
        {
            return random.Next(maxValue);
        }
        public static int getRandom(int maxValue,int minValue)
        {
            return random.Next(maxValue, minValue);
        }
    }
}
