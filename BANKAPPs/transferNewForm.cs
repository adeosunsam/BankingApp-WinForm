using BusinessLogic;
using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANKAPPs
{
    public partial class transferNewForm : UserControl
    {
        string description;

        public transferNewForm()
        {
            InitializeComponent();
        }

        private void transferNewForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //amt = textBox2.Text;
            decimal amount;
            //accountnumber = textBox4.Text;
            description = textBox3.Text;
            bool success = decimal.TryParse(textBox2.Text, out amount);
            if (!success)
            {
                label8.Text = "Invalid input";
                label8.Visible = true;
            }
            try
            {
                ConfigService._bankAccountLogic.Transfer(BankAccountDb.LoggedAccount.AccountNumber.ToString(),textBox4.Text, amount, description);
                label5.Text = "Transaction Successfull!";
                label5.Visible = true;
            }
            catch (Exception ex)
            {
                label8.Text = ex.Message;
                label8.Visible = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length != 0)
            {
                label8.Visible = false;
                label5.Visible = false;
            }
            if (textBox2.Text.Length != 0)
            {
                label8.Visible = false;
                label5.Visible = false;
            }
        }
    }
}
