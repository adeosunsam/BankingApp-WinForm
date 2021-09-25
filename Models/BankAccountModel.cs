using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BankAccountModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public AccountType AccountType { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public decimal AccountBalance { get; set; } = 0;
        public string Email { get; set; }
        public DateTime Updated_at { get; set; } = DateTime.Now;

        public BankAccountModel()
        {

        }
        public BankAccountModel(string id,string userId, AccountType accountType,
            string accountname, string accountNumber,decimal amount,string email)
        {
            Id = id;
            UserId = userId;
            AccountType = accountType;
            AccountName = accountname;
            AccountNumber = accountNumber;
            AccountBalance = amount;
            Email = email;
        }
    }
}
