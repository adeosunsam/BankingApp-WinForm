using Models;
using System.Collections.Generic;

namespace DataBase
{
    public interface IBankAccountDb
    {
        void AddAccount(UserModel customer, string accountType);
        BankAccountModel GetAccountByAccountNumber(string accountNumber);
        List<BankAccountModel> GetAccountByUserId(string UserId);
        AccountType Type(string accntType);
        void UpdateAccountBalance(string accountNumber, decimal amount);
    }
}