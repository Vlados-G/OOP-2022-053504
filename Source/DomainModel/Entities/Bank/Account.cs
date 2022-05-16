using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Account : IAccount
    {
        public Guid ID { get; set; }

        public String ClientID { get; set; }
        
        public Guid BankID { get; set; }
        
        public DateTime Date { get; set;  }
        
        public Double Sum { get; set; }

        public AccountStatus Status { get; set; }

        public AccountType Type { get; set; }

        public Account()
        { 
        }

        public Account(IBank bank, String clientID, AccountType type, DateTime dt, Double sum)
        {
            ID = Guid.NewGuid();
            BankID = bank.ID;
            ClientID = clientID;
            Date = dt;
            Sum = sum;
            this.Type = type;
            Status = AccountStatus.Аpproved;
        }

    }
}
