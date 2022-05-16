using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace ApplicationModel
{
    public class AppModel
    {
        public IBank CurrentBank { get; set; }
        public IUser CurrentUser { get; set; }

        public List<String> LogList = new List<String>();

        public void Initialization()
        {
            CurrentBank = null;
            CurrentUser = null;
        }

        private Log AppLogFile = new Log("C://Temp//Laba1LogFile");

        public void WriteLog(String message)
        {
            LogList.Add(DateTime.Now.ToString() + ": " + message);
            AppLogFile.WriteLog(message);
        }

        public void CloseLog()
        {
            AppLogFile.CloseLog();
        }
    }
}
