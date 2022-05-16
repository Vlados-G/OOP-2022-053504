using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class PhysicalClient : Client
    {
        public String Fulname { get; set; }
        public String Patronymic { get; set; }
        public String PassportSeries { get; set; }
        public String PassportNumber { get; set; }
    

        public PhysicalClient()
        {
        }
    }
}
