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
    public class TransactionLogic : ITransactionLogic
    {
        private readonly ITransactionsDb _transactionsDb;
        private readonly IBankAccountDb _bankAccountDb;

        public TransactionLogic(ITransactionsDb transactionsDb, IBankAccountDb bankAccountDb)
        {
            _transactionsDb = transactionsDb;
            _bankAccountDb = bankAccountDb;
        }

        public void DebitTransaction(string accountNumber, decimal amount, string desc)
        {
            TransactionModel newTr = new TransactionModel(amount, accountNumber, TransactionType.Debit, desc);
            _transactionsDb.AddTransaction(newTr);
            var account = _bankAccountDb.GetAccountByAccountNumber(accountNumber);
            _bankAccountDb.UpdateAccountBalance(accountNumber, account.AccountBalance - amount);

        }

        public void CreditTransaction(string accountNumber, decimal amount, string desc)
        {
            TransactionModel newTr = new TransactionModel(amount, accountNumber, TransactionType.Credit, desc);
            _transactionsDb.AddTransaction(newTr);
            var account = _bankAccountDb.GetAccountByAccountNumber(accountNumber);
            _bankAccountDb.UpdateAccountBalance(accountNumber, amount + account.AccountBalance);

        }

        public DataTable StatementOfAccount(string accountNumber)
        {
            var transaction = _transactionsDb.GetAccountByAccountNumber(accountNumber);
            if (transaction.Count != 0)
            {
                DataTable table = new DataTable();

                table.Columns.Add("DATE", typeof(string));
                table.Columns.Add("DESCRIPTION", typeof(string));
                table.Columns.Add("TRANSACTION TYPE", typeof(string));
                table.Columns.Add("AMOUNT", typeof(decimal));

                for (int i = 0; i < transaction.Count; i++)
                {
                    table.Rows.Add(transaction[i].Updated_at.ToShortDateString(), transaction[i].TransactionDescription,
                        transaction[i].TransactionType, transaction[i].Amount);
                }
                return table;
            }
            else
                throw new ArgumentException("No record found for this account");

        }

        public decimal AccountBalance(string accountnumber)
        {
            var accntDetails = _bankAccountDb.GetAccountByAccountNumber(accountnumber);
            return accntDetails.AccountBalance;
        }
    }
}
