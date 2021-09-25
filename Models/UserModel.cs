using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public DateTime Updated_at { get; set; } = DateTime.Now;

        public UserModel(string firstName, string lastName, string email, string passWord)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PassWord = passWord;
        }
        public UserModel(string id, string firstName, string lastName, string email, string passWord)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PassWord = passWord;
        }
        public UserModel()
        {

        }
    }
}
