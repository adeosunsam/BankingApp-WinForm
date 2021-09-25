using System.Text.RegularExpressions;

namespace Validations
{
    public class Validation
    {
        public static bool NameValidation(string name)
        {
            return Regex.IsMatch(name, "^[A-Z]{1}[a-z]*$");
        }

        public static bool EmailValidation(string email)
        {
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        public static bool PasswordValidation(string password)
        {
            return Regex.IsMatch(password, @"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[!*@#$%^&+=]).*$");
        }
    }
}
