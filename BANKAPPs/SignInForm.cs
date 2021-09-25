using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace BANKAPPs
{
    public partial class SignInForm : Form
    {
        string email;
        string password;
        
        public SignInForm()
        {
            InitializeComponent();
        }

        private void buttonsignin_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm newUser = new();
            newUser.Show();
        }

        private void buttonsubmit_Click(object sender, EventArgs e)
        {
            
            email = textemail.Text;
            password = textpass.Text;

            try
            {
                WinAppValidation.ValidateSubmit(email, password);
                label6.Visible = false;
                this.Hide();
                UserNewInterface newUser = new UserNewInterface();
                newUser.Show();
                
            }
            catch (ArgumentException ex)
            {
                label6.Text = ex.Message;
                label6.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textpass_TextChanged(object sender, EventArgs e)
        {
            if (textpass.Text.Length != 0)
            {
                label6.Visible = false;
            }
        }

        private void textemail_TextChanged(object sender, EventArgs e)
        {
            if (textemail.Text.Length != 0)
            {
                label6.Visible = false;
            }
        }
    }
}
