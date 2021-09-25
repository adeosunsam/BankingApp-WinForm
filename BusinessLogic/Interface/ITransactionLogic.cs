using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ITransactionLogic
    {
        decimal AccountBalance(string accountnumber);
        void CreditTransaction(string accountNumber, decimal amount, string desc);
        void DebitTransaction(string accountNumber, decimal amount, string desc);
        DataTable StatementOfAccount(string accountNumber);
    }
}
