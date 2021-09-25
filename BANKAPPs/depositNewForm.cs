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
    public partial class depositNewForm : UserControl
    {
        public depositNewForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string description;
            decimal amount;
            description = textBox3.Text;
            bool success = decimal.TryParse(textBox2.Text.Trim(), out amount);
            if (!success)
            {
                label8.Text = "Invalid Amount";
                label8.Visible = true;
            }
            try
            {
                ConfigService._bankAccountLogic.Deposit(BankAccountDb.LoggedAccount.AccountNumber, amount, description);
                label5.Text = String.Format("{0:N} deposited successfully", amount);
                label5.Visible = true;
            }
            catch (Exception ex)
            {
                label8.Text = ex.Message;
                label8.Visible = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0)
            {
                label8.Visible = false;
                label5.Visible = false;
            }
        }
    }
}
