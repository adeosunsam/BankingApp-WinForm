using BusinessLogic.Implementation;
using BusinessLogic.Interface;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ConfigService
    {
        public static ITransactionLogic _transactionLogic;
        public static IBankAccountLogic _bankAccountLogic;
        public static IUsersLogic _usersLogic;
        public static IUserDb _userDb;
        public static IBankAccountDb _bankAccountDb;
        public static ITransactionsDb _transactionsDb;

        public ConfigService()
        {
            _userDb = new UserDb();
            _bankAccountDb = new BankAccountDb();
            _transactionsDb = new TransactionsDb();
            _transactionLogic = new TransactionLogic(_transactionsDb, _bankAccountDb);
            _bankAccountLogic = new BankAccountLogic(_bankAccountDb, _transactionLogic);
            _usersLogic = new UsersLogic(_userDb, _bankAccountDb);
           
        }
    }
}
