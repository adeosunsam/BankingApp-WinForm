using System;
using System.Windows.Forms;
using BusinessLogic;
using DataBase;
using Utility;

namespace BANKAPPs
{
    public partial class RegistrationForm : Form
    {
        string firstname;
        string lastname;
        string email;
        string password;
        string accountType;
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            firstname = textfirstname.Text;
            lastname = textlastname.Text;
            email = textemail.Text;
            password = textpass.Text;
            accountType = comboBox1.Text;

            BankAccountDb bank = new BankAccountDb();
           
            try
            {
                WinAppValidation.validateName(firstname);
                label6.Visible = false;
            }
            catch (Exception ex)
            {
                label6.Text = ex.Message;
                label6.Visible = true;
            }

            try
            {
                WinAppValidation.validateName(lastname);
                label7.Visible = false;
            }
            catch (Exception ex)
            {
                label7.Text = ex.Message;
                label7.Visible = true;
            }

            try
            {
                WinAppValidation.ValidateEmail(email);
                label8.Visible = false;
            }
            catch (Exception ex)
            {
                label8.Text = ex.Message;
                label8.Visible = true;
            }

            try
            {
                WinAppValidation.ValidatePassWord(password);
                label9.Visible = false;
            }
            catch (Exception ex)
            {
                label9.Text = ex.Message;
                label9.Visible = true;
            }

            try
            {
                NewAccountPopUp popUp = new NewAccountPopUp();
                popUp.Type(accountType);
                label10.Visible = false;
            }
            catch (Exception ex)
            {
                comboBox1.Text = string.Empty;
                label10.Text = ex.Message;
                label10.Visible = true;
            }

            try
            {
                if (checkBox1.Checked != true)
                {
                    throw new Exception("Agree to terms and Conditions");
                }
                WinAppValidation.ValidateSubmit(firstname, lastname, email, password, accountType);
                MessageBox.Show($"Congratulation {firstname + " " + lastname}, your {accountType} account has been created successfully,\n");
                this.Controls.Clear();
                InitializeComponent();
            }
            catch (Exception)
            {

            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textlastname.Text.Length != 0)
            {
                label7.Visible = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            SignInForm newForm = new SignInForm();
            newForm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textfirstname.Text.Length != 0)
            {
                label6.Visible = false;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textemail_TextChanged(object sender, EventArgs e)
        {
            if (textemail.Text.Length != 0)
            {
                label8.Visible = false;
            }
        }

        private void textpass_TextChanged(object sender, EventArgs e)
        {
            if (textpass.Text.Length != 0)
            {
                label9.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1 != null)
            {
                label10.Visible = false;
            }
        }
    }
}
