using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TransactionModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AccountId { get; set; }
        public decimal Amount { get; set; }
        public string AccountNumber { get; set; }
        public TransactionType TransactionType { get; set; }
        public string TransactionDescription { get; set; }
        public DateTime Updated_at { get; set; } = DateTime.Now;

        public TransactionModel() { }

        public TransactionModel(decimal amount, string accountNumber, TransactionType transactionType, string transactionDescription)
        {
            Amount = amount;
            AccountNumber = accountNumber;
            TransactionType = transactionType;
            TransactionDescription = transactionDescription;
        }
    }
}
