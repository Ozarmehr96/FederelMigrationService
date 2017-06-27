using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientSQL
{
    public partial class Login : Form
    {
        Users adminUser = new Users("Администратор");
        Users OperatorUser = new Users("Оператор");
        List<Users> users = new List<Users>();
        string password = "zzz";
        

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin adminForm = new Admin();
            Operator operatorForm = new Operator();
            if (comboBoxUsers.SelectedIndex == 0)
            {
                operatorForm.Owner = this;
                operatorForm.ShowDialog();
                this.Close();
            }
            else if (textBoxPassword.Text == password)
            {
                adminForm.Owner = this;
                adminForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный пароль! Повторите попытку.");
            }
        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedIndex == 0)
            {
                labelPassword.Hide();
                textBoxPassword.Hide();
            }
            else
            {
                labelPassword.Show();
                textBoxPassword.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            users.Add(OperatorUser);
            users.Add(adminUser);
            foreach (Users u in users)
            {
                comboBoxUsers.Items.Add(u);
            }
            comboBoxUsers.SelectedIndex = 0;
            this.Text = "Вход";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            ConSettings settings = new ConSettings(this);
            settings.ShowDialog();
        }
    }
}
