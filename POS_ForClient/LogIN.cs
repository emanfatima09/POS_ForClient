using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POS_ForClient
{
    public partial class LogIN : Form
    {
        public LogIN()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = txtPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtUserName.Text.Equals(""))
                errorProvider1.SetError(txtUserName, "Name is missing");

            else if (txtPassword.Text.Equals(""))
                errorProvider1.SetError(txtPassword, "Password is missing");

            else
            {
                if (IsvalidUser(txtUserName.Text, txtPassword.Text))
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("User Name or Password is Incorrect");
            }
        }
        private bool IsvalidUser(string userName, string password)
        {
            AllDataContext ldc = new AllDataContext();
            var q = from p in ldc.Logins
                    where p.Name == txtUserName.Text
                    && p.Password == txtPassword.Text
                    select p;
            if (q.Any())
                return true;

            else
                return false;
        }

    }
}
