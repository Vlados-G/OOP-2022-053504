using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Client : IClient
    {
        public String Name { get; set; }
        public String ID { get; set; }
        public String Telephone { get; set; }
        public String Mail { get; set; }
        public ClientStatus Status { get; set; }
        public RoleList Role { get; set; }

        public Client()
        {
            Role = RoleList.Client;
        }

    }
}
