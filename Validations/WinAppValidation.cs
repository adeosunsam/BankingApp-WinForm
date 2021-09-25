using BusinessLogic;
using DataBase;
using Models;
using System;
using Validations;

namespace Utility
{
    public class WinAppValidation
    {
        public static string validateName(string name)
        {
            if (!Validation.NameValidation(name))
            {
                if (name.Trim() == "")
                {
                    throw new ArgumentException("This field is required");
                }
                else
                    throw new ArgumentException("Name must start with upper case followed by lower");
            }
            else
                return name;
        }

        public static string ValidateEmail(string email)
        {
            if (ConfigService._userDb.GetCustomerByEmail(email) != null)
            {
                throw new ArgumentException("This Email has been taken");
            }

            if (!Validation.EmailValidation(email))
            {

                if (email.Trim() == "")
                {
                    throw new ArgumentException("This field is required");
                }
                else
                    throw new ArgumentException("Please enter a valid email address");
            }
            return email;
        }

        public static string ValidatePassWord(string password)
        {
            if (!Validation.PasswordValidation(password))
            {
                if (password.Trim() == "")
                {
                    throw new ArgumentException("This field is required");
                }
                else
                    throw new ArgumentException("minimum of 6 character, at least 1 special character and 1 number");
            }
            return password;
        }

        public static string ValidateAccountType(string accountType)
        {

            if (accountType == AccountType.Savings.ToString())
            {
                return accountType;
            }
            if (accountType == AccountType.Current.ToString())
            {
                return accountType;
            }
            throw new Exception("Please choose account type");
        }

        public static void ValidateSubmit(string firstname, string lastname, string email, string password, string accountType)
        {
            try
            {
                validateName(firstname);
                validateName(lastname);
                ValidateEmail(email);
                ValidatePassWord(password);
                ValidateAccountType(accountType);

                UserModel newModel = new UserModel(firstname,lastname,email,password);
                ConfigService._usersLogic.UserRegistration(newModel);
                ConfigService._bankAccountLogic.CreateNewAccount(newModel, accountType);
                
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public static void ValidateSubmit(string email, string password)
        {
            ConfigService._usersLogic.UserLogin(email, password);

        }

        public static decimal GetBalance(string accountnumber)
        {
            return ConfigService._transactionLogic.AccountBalance(accountnumber);
        }
    }
}
