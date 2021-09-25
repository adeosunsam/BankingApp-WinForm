using System;

namespace BankApp.Commom
{
    public class AccountTypeValidation
    {
        public static AccountType Type(string type)
        {
            if (type == AccountType.Savings.ToString())
            {
                return AccountType.Savings;
            }
            return AccountType.Current;
        }
    }
}
