using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IBankAccountLogic
    {
        DataTable AccountDetails();
        void CreateNewAccount(UserModel user, string accountType);
        void Deposit(string accountNumber, decimal amount, string description);
        void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount, string description);
        void WithdrawFromCurrent(string accountNumber, decimal amount, string description);
        void WithdrawFromSavings(string accountNumber, decimal amount, string description);
    }
}
