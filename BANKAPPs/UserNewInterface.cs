using BusinessLogic;
using BusinessLogic.Implementation;
using DataBase;
using Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BANKAPPs
{
    public partial class UserNewInterface : Form
    {

        public UserNewInterface()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            depositNewForm1.Hide();
            transferNewForm1.Hide();

            withdrawNewForm1.Show();
            withdrawNewForm1.BringToFront();
           /* Control ctrl = ((Control)sender);
            ctrl.ForeColor = Color.DarkMagenta;*/
        }

        private void UserNewInterface_Load(object sender, EventArgs e)
        {
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            withdrawNewForm1.Hide();
            transferNewForm1.Hide();

            depositNewForm1.Show();
            depositNewForm1.BringToFront();
            /*Control ctrl = ((Control)sender);
            ctrl.ForeColor = Color.DarkMagenta;*/
        }

        private void label6_Click(object sender, EventArgs e)
        {
            withdrawNewForm1.Hide();
            depositNewForm1.Hide();

            transferNewForm1.Show();
            transferNewForm1.BringToFront();
            /*Control ctrl = ((Control)sender);
            ctrl.ForeColor = Color.DarkMagenta;*/
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void withdrawNewForm1_Load(object sender, EventArgs e)
        {
            depositNewForm1.Show();
            withdrawNewForm1.Hide();
            transferNewForm1.Hide();
            string newDate = DateTime.Now.ToShortTimeString();
            string[] dateEvening = new string[] { "16","17","18","19","20","21","22","23","00"};
            string[] dateMorning = new string[] { "01","02","03","04","05","06","07","08","09","10","11"};
            if (newDate.StartsWith("12") || newDate.StartsWith("13") || newDate.StartsWith("14") || newDate.StartsWith("15"))
            {
                label15.Text = "Afternoon, " + UsersLogic.LogUser.LastName + " " + UsersLogic.LogUser.FirstName;
            }
            for (int i = 0; i < dateEvening.Length; i++)
            {
                if (newDate.StartsWith(dateEvening[i]))
                {
                    label15.Text = "Evening, " + UsersLogic.LogUser.LastName + " " + UsersLogic.LogUser.FirstName;
                }
            }
            for (int i = 0; i < dateMorning.Length; i++)
            {
                if (newDate.StartsWith(dateMorning[i]))
                {
                    label15.Text = "Morning, " + UsersLogic.LogUser.LastName + " " + UsersLogic.LogUser.FirstName;
                }
            }
            label12.Text = BankAccountDb.LoggedAccount.AccountNumber.ToString();
            label17.Text = BankAccountDb.LoggedAccount.AccountType.ToString();
            label2.Text = String.Format("{0:N}", ConfigService._transactionLogic.AccountBalance(label12.Text));

            InitialiseComboBox();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            ConfigService._usersLogic.userLogOut();
            this.Dispose();
            SignInForm gotoSignIn = new SignInForm();
            gotoSignIn.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void InitialiseComboBox()
        {
            var accntDetail = ConfigService._bankAccountDb.GetAccountByUserId(UsersLogic.LogUser.Id);
            List<string> userAccnts = new List<string>();
            for (int i = 0; i < accntDetail.Count; i++)
            {
                userAccnts.Add(accntDetail[i].AccountNumber);
            }
            comboBox1.DataSource = userAccnts;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            NewAccountPopUp newAccnt = new NewAccountPopUp();
            newAccnt.Show();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            AccountType type;
            string accountNum = comboBox1.SelectedValue.ToString();
            BankAccountModel getAccountType = ConfigService._bankAccountDb.GetAccountByAccountNumber(accountNum);

            if (getAccountType.AccountType == AccountType.Savings)
            {
                type = AccountType.Savings;
            }
            else
                type = AccountType.Current;

            label2.Text = String.Format("{0:N}", ConfigService._transactionLogic.AccountBalance(accountNum));
            label12.Text = accountNum;
            label17.Text = type.ToString();
            BankAccountModel account = BankAccountDb.LoggedAccount;

            try
            {
                dataGridView1.DataSource = ConfigService._transactionLogic.StatementOfAccount(accountNum);
                label23.Visible = false;
            }
            catch (Exception ex)
            {
                dataGridView1.DataSource = null;
                label23.Text = ex.Message;
                label23.Visible = true;
            }

            dataGridView2.DataSource = ConfigService._bankAccountLogic.AccountDetails();

            BankAccountModel newModel = new BankAccountModel(account.Id, account.UserId, type,
                account.AccountName, accountNum, Convert.ToDecimal(label2.Text), account.Email);
            BankAccountDb.LoggedAccount = newModel;
        }
    }
}
