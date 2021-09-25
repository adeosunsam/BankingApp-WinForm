using BusinessLogic.Interface;
using DataBase;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation
{
    public class BankAccountLogic : IBankAccountLogic
    {
        private readonly IBankAccountDb _bankAccountDb;
        private readonly ITransactionLogic _transactionLogic;

        public BankAccountLogic(IBankAccountDb bankAccountDb, ITransactionLogic transactionLogic)
        {
            _bankAccountDb = bankAccountDb;
            _transactionLogic = transactionLogic;
        }

        public void CreateNewAccount(UserModel user, string accountType)
        {
            _bankAccountDb.AddAccount(user, accountType);
        }

        public void Deposit(string accountNumber, decimal amount, string description)
        {
            if (amount > 0)
            {
                _transactionLogic.CreditTransaction(accountNumber, amount, description);
            }
            else
                throw new ArgumentException("Invalid amount");
        }

        public void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount, string description)
        {
            if (fromAccountNumber == toAccountNumber)
            {
                throw new ArgumentException("Cant transfer to self account");
            }

            BankAccountModel account = _bankAccountDb.GetAccountByAccountNumber(fromAccountNumber);
            BankAccountModel account1 = _bankAccountDb.GetAccountByAccountNumber(toAccountNumber);

            if (account1 == null)
            {
                throw new ArgumentException("Invalid account number");
            }

            if (account.AccountType == AccountType.Savings)
            {
                WithdrawFromSavings(fromAccountNumber, amount, description);
                Deposit(toAccountNumber, amount, description);
            }
            else
            {
                WithdrawFromCurrent(fromAccountNumber, amount, description);
                Deposit(toAccountNumber, amount, description);
            }

        }

        public void WithdrawFromSavings(string accountNumber, decimal amount, string description)
        {
            if (_transactionLogic.AccountBalance(accountNumber) - amount >= 1000)
            {
                _transactionLogic.DebitTransaction(accountNumber, amount, description);
            }
            else
                throw new Exception("Insufficient Balance");
        }

        public void WithdrawFromCurrent(string accountNumber, decimal amount, string description)
        {
            if (_transactionLogic.AccountBalance(accountNumber) - amount >= 0)
            {
                _transactionLogic.DebitTransaction(accountNumber, amount, description);
            }
            else
                throw new Exception("Insufficient Balance");
        }

        public DataTable AccountDetails()
        {
            List<BankAccountModel> accountDetails = _bankAccountDb.GetAccountByUserId(UsersLogic.LogUser.Id);
            DataTable table = new DataTable();

            table.Columns.Add("ACCOUNT NAME", typeof(string));
            table.Columns.Add("ACCOUNT NUMBER", typeof(string));
            table.Columns.Add("ACCOUNT TYPE", typeof(string));
            table.Columns.Add("BALANCE", typeof(decimal));

            for (int i = 0; i < accountDetails.Count; i++)
            {
                table.Rows.Add(accountDetails[i].AccountName, accountDetails[i].AccountNumber, accountDetails[i].AccountType, accountDetails[i].AccountBalance);
            }
            return table;
        }
    }
}
