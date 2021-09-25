using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IUsersLogic
    {
        void UserLogin(string email, string password);
        bool userLogOut();
        void UserRegistration(UserModel customer);
    }
}
