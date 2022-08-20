using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PasswordLockerLib.Infrasturcture.Utilities;

namespace PasswordLockerLib.Infrasturcture
{
    public class Logger
    {
        public static void Log(LogCategory cat, string txt)
        {
            if (!Directory.Exists(Config.LogDir))
            {
                Directory.CreateDirectory(Config.LogDir);
            }
            txt = DateTime.Now.ToString("s") + "\t" + cat.ToString() + "\t" + txt;
            string fileName = DateTime.Now.ToString("D") + ".log";
            string[] lines = new string[] { txt };
            System.IO.File.AppendAllLines(Config.LogDir + fileName, lines);
        }
    }
}
