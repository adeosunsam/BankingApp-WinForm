using Models;
using System.Collections.Generic;

namespace DataBase
{
    public interface ITransactionsDb
    {
        void AddTransaction(TransactionModel user);
        List<TransactionModel> GetAccountByAccountNumber(string accountNumber);
        TransactionType Type(string transType);
    }
}