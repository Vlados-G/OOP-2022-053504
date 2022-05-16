using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class EnterpriseClient : Client
    {
        public String Type { get; set; }

        public String Address { get; set; }

        public String UNB{ get; set; }

        public String BIK { get; set; }

        public EnterpriseClient() { }
    }
}
