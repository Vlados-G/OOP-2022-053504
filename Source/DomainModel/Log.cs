using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Log
    {
        public String FileName { get; set; }
        private StreamWriter LogFileStream { get; }

        public Log(String logFileName)
        {
            FileName = logFileName + DateTime.Now.Day.ToString()+ DateTime.Now.Hour.ToString()+ DateTime.Now.Minute.ToString()+ DateTime.Now.Second.ToString() + ".txt";
            
            LogFileStream = File.CreateText(FileName);
    
            WriteLog("New application session started");
        }

        public void WriteLog(String message)
        {
            LogFileStream.WriteLine(DateTime.Now.ToString() + ": " + message);
        }

        public void CloseLog()
        {
            LogFileStream.WriteLine(DateTime.Now.ToString() + ": " + "Log file closed");
            LogFileStream.Close();
        }
    }
}