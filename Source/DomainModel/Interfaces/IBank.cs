using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IBank
    {
        String Name { get;  }

        Guid ID { get; }

        Dictionary <String, PhysicalClient> PhysicalClients { get;  }

        Dictionary<String, EnterpriseClient> EnterpriseClients { get; set; }

        Dictionary<String, Employee> Employees { get; }

        Dictionary<Guid, Account> Accounts { get;  }

        Dictionary<Guid, Transaction> Transactions { get; }

    }
}
