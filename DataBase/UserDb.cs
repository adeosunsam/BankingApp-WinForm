 using Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class UserDb : IUserDb
    {
        public void AddUser(UserModel user)
        {
            try
            {
                using var connected = Connection.GetConnection();
                connected.Open();


                SqlCommand _sqlCommand = new SqlCommand("AddUser", connected) 
                {
                    CommandType = CommandType.StoredProcedure
                };

                _sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                _sqlCommand.Parameters.AddWithValue("@Firstname", user.FirstName);
                _sqlCommand.Parameters.AddWithValue("@Lastname", user.LastName);
                _sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                _sqlCommand.Parameters.AddWithValue("@PassWord", user.PassWord);
                _sqlCommand.Parameters.AddWithValue("@Updated_at", user.Updated_at);

                _sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occured. \n" + ex);
            }

        }

        public UserModel GetCustomerByEmail(string email)
        {

            UserModel user;
            using (var connected = Connection.GetConnection())
            {
                connected.Open();

                SqlCommand _sqlCommand = new SqlCommand("GetCustomerByEmail", connected) 
                {
                    CommandType = CommandType.StoredProcedure
                };

                _sqlCommand.Parameters.AddWithValue("@email", email);

                var readCustomer = _sqlCommand.ExecuteReader();

                while (readCustomer.Read())
                {
                    user = new UserModel
                    {
                        Id = readCustomer["Id"].ToString(),
                        FirstName = readCustomer["Firstname"].ToString(),
                        LastName = readCustomer["Lastname"].ToString(),
                        Email = readCustomer["Email"].ToString(),
                        PassWord = readCustomer["Password"].ToString()

                    };
                    return user;
                }
            }
            return null;

        }
    }
}
