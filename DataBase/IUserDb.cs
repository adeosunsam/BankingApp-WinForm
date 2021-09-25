using Models;

namespace DataBase
{
    public interface IUserDb
    {
        void AddUser(UserModel user);
        UserModel GetCustomerByEmail(string email);
    }
}