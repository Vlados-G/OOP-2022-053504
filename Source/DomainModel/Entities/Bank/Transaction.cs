using System;

namespace DomainModel
{
    public class Transaction: ITransaction
    {

        public Guid ID { get; set; }
        public String ClientID { get; set; }

        public DateTime Date { get; set; }

        public Double Sum { get; set; }

        public Guid SourceBankID { get; set; }
        
        public Guid DestinationBankID { get; set; }
        
        public Guid SourceAccountID { get; set; }
        
        public Guid DestinationAccountID { get; set; }

        public TransactionStatus Status { get; set; }

        public Transaction()
        { }

        public Transaction(Guid sourceBankID, Guid destinatioBankID, Guid sourceAccountID, Guid destinatioAccountID, DateTime dt, Double sum, String clientID)
        {
            ID = Guid.NewGuid();
            SourceBankID = sourceBankID;
            DestinationBankID = destinatioBankID;
            Date = dt;
            Sum = sum;
            SourceAccountID = sourceAccountID;
            DestinationAccountID = destinatioAccountID;
            ClientID = clientID;
            Status = TransactionStatus.NotApproved;
        }
    }
}
