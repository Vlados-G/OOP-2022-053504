using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Log
    {
        public String FileName { get; }
        private StreamWriter LogFileStream { get; }

        public Log(String logFileName)
        {
            FileName = logFileName;
            LogFileStream = File.CreateText(FileName);
            LogFileStream.WriteLine(DateTime.Now.ToString() + ": " + "Log file opened");
        }

        public void WriteLog(String message)
        {
            LogFileStream.WriteLine(DateTime.Now.ToString() + ": " + message);
        }

        public static Log AppLog = new Log("C://Temp//LogFile");
    }
}