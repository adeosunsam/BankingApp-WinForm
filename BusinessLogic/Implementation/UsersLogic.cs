using BusinessLogic.Interface;
using DataBase;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation
{
    public class UsersLogic : IUsersLogic
    {
        private readonly IUserDb _userDb;
        private readonly IBankAccountDb _bankAccountDb;

        public UsersLogic(IUserDb userDb, IBankAccountDb bankAccountDb)
        {
            _userDb = userDb;
            _bankAccountDb = bankAccountDb;
        }

        public static UserModel LogUser { get; set; }

        public void UserRegistration(UserModel customer)
        {
            _userDb.AddUser(customer);
        }

        public void UserLogin(string email, string password)
        {
            UserModel user = _userDb.GetCustomerByEmail(email);

            if (user != null)
            {
                List<BankAccountModel> accountHolder = _bankAccountDb.GetAccountByUserId(user.Id);
                if (user.PassWord == password)
                {
                    LogUser = user;
                    BankAccountDb.LoggedAccount = accountHolder[0];
                }
                else
                    throw new ArgumentException("Invalid email or password");
            }
            else
                throw new ArgumentException("Invalid email or password");

        }

        public bool userLogOut()
        {
            LogUser = null;
            return true;
        }
    }
}
