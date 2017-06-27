using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Federal_Migration_Service
{
    public partial class Form2 : Form
    {
        Form1 form;
        public int i = 0;
        public SqlConnection connection;
        OpenFileDialog open = new OpenFileDialog();
                
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form = form1;
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        public string s;
        private void Form2_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            button1.Text = "Выбрать";
            comboBox1.SelectedItem = "Federal_Migration_Service";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            i++;
            if (i == 1)
            {
                open.Filter = "Файлы восстановления (*.bak)|*.bak";
                open.FilterIndex = 0; open.RestoreDirectory = false;
                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = open.FileName;
                    string a = System.IO.Path.GetFileName(@"" + textBox1.Text + "");// a = "dr"
                    if (a != "Federal_Migration_Service.bak")
                    {
                        MessageBox.Show("Выберите файл, который совпадает с именем базы данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Text = "";
                        button1.Text = "Выбрать";
                        i = i - 1;
                    }
                    else
                    {
                        button1.Text = "Восcтановить";
                    }
                }
                else
                {
                    button1.Text = "Выбрать";
                    i = i - 1;
                }
    
            }
            else if (i == 2 && comboBox1.Text != "")
            {
                Restore();
            }
        }

        public void Restore()
        {
            if (textBox1.Text != "" || comboBox1.Text != "")
            {
                s = form.CheckServer();
                try
                {
                    connection = new SqlConnection("Data Source=" + form.CheckServer() + ";Initial Catalog=master;Integrated Security=True;");
                    connection.Open();
                    string sql = "";
                    sql = "Restore database Federal_Migration_Service from disk = '" + textBox1.Text + "'";
                    SqlCommand com = new SqlCommand(sql, connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("База данных успешно восстановлена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else MessageBox.Show("Заполните поле!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
