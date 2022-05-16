using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel

{
    public enum TransactionStatus
    {
        NotApproved,
        Approved
    }

    public interface ITransaction
    {
        Guid ID { get; }
        
        String ClientID { get; }
        
        DateTime Date { get; }

        Double Sum { get; }

        Guid SourceBankID { get; }

        Guid DestinationBankID { get; }

        Guid SourceAccountID { get; }

        Guid DestinationAccountID { get; }

        TransactionStatus Status { get; }


    }
}
