using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public enum AccountType
    {
        Installments,
        Credit,
        Encashment,
        Deposite,
        SalaryProject
    }

    public enum AccountStatus
    {
        NotApproved,
        Аpproved,
        Denied,
        Frozen,
        Blocked
    }

    interface IAccount
    {
        Guid ID { get; }

        String ClientID { get; }

        Guid BankID { get; }

        DateTime Date { get; }

        Double Sum { get;  }

        AccountStatus Status { get; }

        AccountType Type { get; }
    }
}
