using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DataBase
{
    public class TransactionsDb : ITransactionsDb
    {

        public void AddTransaction(TransactionModel user)
        {
            try
            {
                using var connected = Connection.GetConnection();
                connected.Open();

                SqlCommand _sqlCommand = new SqlCommand("AddTransaction", connected) 
                {
                    CommandType = CommandType.StoredProcedure
                };

                _sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                _sqlCommand.Parameters.AddWithValue("@AccountId", BankAccountDb.LoggedAccount.Id);
                _sqlCommand.Parameters.AddWithValue("@Amount", user.Amount);
                _sqlCommand.Parameters.AddWithValue("@AccountNumber", user.AccountNumber);
                _sqlCommand.Parameters.AddWithValue("@TransactionType", user.TransactionType.ToString());
                _sqlCommand.Parameters.AddWithValue("@TransactionDescription", user.TransactionDescription);
                _sqlCommand.Parameters.AddWithValue("@Updated_at", user.Updated_at);

                _sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occured. \n" + ex);
            }
        }

        public List<TransactionModel> GetAccountByAccountNumber(string accountNumber)
        {

            var Account = new List<TransactionModel>();
            TransactionModel account;
            using (var connected = Connection.GetConnection())
            {
                connected.Open();

                SqlCommand _sqlCommand = new("GetTransactionByAccountNumber", connected) 
                {
                    CommandType = CommandType.StoredProcedure
                };

                _sqlCommand.Parameters.AddWithValue("@accountNumber", accountNumber);

                var readTransaction = _sqlCommand.ExecuteReader();

                while (readTransaction.Read())
                {
                    account = new TransactionModel
                    {
                        Id = readTransaction["Id"].ToString(),
                        AccountId = readTransaction["AccountId"].ToString(),
                        Amount = Convert.ToDecimal(readTransaction["Amount"].ToString()),
                        AccountNumber = readTransaction["AccountNumber"].ToString(),
                        TransactionType = Type(readTransaction["TransactionType"].ToString()),
                        TransactionDescription = readTransaction["TransactionDescription"].ToString(),
                        Updated_at = Convert.ToDateTime(readTransaction["Updated_at"].ToString())
                    };
                    Account.Add(account);
                }
            }
            return Account;
        }

        public TransactionType Type(string transType)
        {
            if (transType == TransactionType.Credit.ToString())
            {
                return TransactionType.Credit;
            }
            return TransactionType.Debit;
        }
    }
}
