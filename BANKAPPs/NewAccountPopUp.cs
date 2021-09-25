using BusinessLogic;
using BusinessLogic.Implementation;
using DataBase;
using Models;
using System;
using System.Windows.Forms;

namespace BANKAPPs
{
    public partial class NewAccountPopUp : Form
    {
        public NewAccountPopUp()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public string Type(string accntType)
        {
            if (accntType == AccountType.Savings.ToString())
            {
                return accntType;
            }
            if (accntType == AccountType.Current.ToString())
            {
                return accntType;
            }
            throw new Exception("Please choose account type");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string accountType = comboBox1.Text;
            var user = UsersLogic.LogUser;
            try
            {
                label10.Visible = false;
                UserModel newModel = new UserModel(user.Id, user.FirstName, user.LastName, user.Email, user.PassWord);
                ConfigService._bankAccountLogic.CreateNewAccount(newModel, Type(accountType));
                MessageBox.Show($"Your new {Type(accountType)}" +
                    $" account has been created successfully");
            }
            catch (Exception ex)
            {
                comboBox1.Text = string.Empty;
                label10.Text = ex.Message;
                label10.Visible = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void NewAccountPopUp_Load(object sender, EventArgs e)
        {
            label2.Text =  UsersLogic.LogUser.LastName + " " + UsersLogic.LogUser.FirstName;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                label10.Visible = false;
            }
        }
    }
}
