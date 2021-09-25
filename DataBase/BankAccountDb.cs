using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DataBase
{
    public class BankAccountDb : IBankAccountDb
    {
        public static BankAccountModel LoggedAccount { get; set; }

        public void AddAccount(UserModel customer, string accountType)
        {
            var account = new BankAccountModel();
            Random random = new Random();
            using var connected = Connection.GetConnection();
            connected.Open();

            SqlCommand _sqlCommand = new SqlCommand("InsertIntoAccount", connected) 
            {
                CommandType = CommandType.StoredProcedure
            };

            _sqlCommand.Parameters.AddWithValue("@Id", account.Id);
            _sqlCommand.Parameters.AddWithValue("@UserId", customer.Id);
            _sqlCommand.Parameters.AddWithValue("@AccountType", accountType);
            _sqlCommand.Parameters.AddWithValue("@AccountName", customer.FirstName + " " + customer.LastName);
            _sqlCommand.Parameters.AddWithValue("@AccountNumber", account.AccountNumber = random.Next(1000000000, 1999999999).ToString());
            _sqlCommand.Parameters.AddWithValue("@AccountBalance", account.AccountBalance);
            _sqlCommand.Parameters.AddWithValue("@Email", customer.Email);
            _sqlCommand.Parameters.AddWithValue("@Updated_at", account.Updated_at);

            _sqlCommand.ExecuteNonQuery();
        }

        public List<BankAccountModel> GetAccountByUserId(string UserId)
        {

            var Account = new List<BankAccountModel>();
            BankAccountModel account;
            using (var connected = Connection.GetConnection())
            {
                connected.Open();

                SqlCommand _sqlCommand = new("GetAccountByUserId", connected) 
                {
                    CommandType = CommandType.StoredProcedure
                };
                _sqlCommand.Parameters.AddWithValue("@UserId", UserId);

                var readAccount = _sqlCommand.ExecuteReader();

                while (readAccount.Read())
                {
                    account = new BankAccountModel
                    {
                        Id = readAccount["Id"].ToString(),
                        UserId = readAccount["UserId"].ToString(),
                        AccountNumber = readAccount["AccountNumber"].ToString(),
                        AccountName = readAccount["AccountName"].ToString(),
                        AccountBalance = Convert.ToDecimal(readAccount["AccountBalance"]),
                        AccountType = Type(readAccount["AccountType"].ToString()),
                        Email = readAccount["Email"].ToString(),
                        Updated_at = Convert.ToDateTime(readAccount["Updated_at"].ToString())
                    };
                    Account.Add(account);
                }
            }
            return Account;
        }

        public BankAccountModel GetAccountByAccountNumber(string accountNumber)
        {
            BankAccountModel account = null;
            using (var connected = Connection.GetConnection())
            {
                connected.Open();

                SqlCommand _sqlCommand = new SqlCommand("GetAccountByAccountNumber", connected) 
                {
                    CommandType = CommandType.StoredProcedure
                };
                _sqlCommand.Parameters.AddWithValue("@accountNumber", accountNumber);

                var readAccount = _sqlCommand.ExecuteReader();

                while (readAccount.Read())
                {
                    account = new BankAccountModel
                    {
                        Id = readAccount["Id"].ToString(),
                        UserId = readAccount["UserId"].ToString(),
                        AccountNumber = readAccount["AccountNumber"].ToString(),
                        AccountName = readAccount["AccountName"].ToString(),
                        AccountBalance = Convert.ToDecimal(readAccount["AccountBalance"]),
                        AccountType = Type(readAccount["AccountType"].ToString()),
                        Email = readAccount["Email"].ToString(),
                        Updated_at = Convert.ToDateTime(readAccount["Updated_at"].ToString())

                    };
                }
            }
            return account;
        }  //done

        public AccountType Type(string accntType)
        {
            if (accntType == AccountType.Savings.ToString())
            {
                return AccountType.Savings;
            }
            return AccountType.Current;
        }

        public void UpdateAccountBalance(string accountNumber, decimal amount)
        {
            using var connected = Connection.GetConnection();
            connected.Open();
            var queryAccount = ("UPDATE Accounts SET AccountBalance = @amount WHERE AccountNumber = @accountNumber");

            SqlCommand _sqlCommand = new SqlCommand(queryAccount, connected);
            _sqlCommand.Parameters.AddWithValue("@amount", amount);
            _sqlCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            _sqlCommand.ExecuteScalar();

        }
    }
}
