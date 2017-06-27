using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Smo.UnSafeInternals;
using Microsoft.SqlServer.Management.Common;

namespace Federal_Migration_Service
{
    public partial class Form1 : Form
    {
        Form2 form2;
        public SqlConnection connection;
         
        //public SqlConnection connection = new SqlConnection("Data Source=Ozar-PC\\SQLEXPRESS;Initial Catalog=Federal_Migration_Service;Integrated Security=True");
        public Form1()
        { 
            InitializeComponent();
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text != "" || textBoxServer.Text != "" || comboBox1.Text != "")
            {
                connection = new SqlConnection("Data Source=" + textBoxServer.Text + ";Initial Catalog=Federal_Migration_Service;Integrated Security=True");
                if (connection.State != ConnectionState.Connecting)
                {

                    SqlDataAdapter sqladapter = new SqlDataAdapter("Select role From Login Where login='" + comboBox1.Text.ToString() + "' and pass = '" + textBoxPassword.Text + "'", connection);
                    DataTable datatable = new System.Data.DataTable();
                    sqladapter.Fill(datatable);
                    if (datatable.Rows.Count == 1)
                    {
                        progressBar1.Visible = true;
                        timer1.Start();
                        textBoxPassword.Text = "";
                        connection.Close();

                    }
                    else
                    {
                        MessageBox.Show("Неправильный пароль или логин!", "Вход", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBox1.Items.Clear();
                        Fil();
                    }
                }
                else
                {
                    MessageBox.Show("Возникла ошибка при подключении к базе данных!");
                }
            }
            else
            {
                MessageBox.Show("Заполните вс поля!");
            }
        }
        
        public string CheckServer()
        {
            string s = textBoxServer.Text;
            return s;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           textBoxServer.Text = "Ozar-PC\\SQLEXPRESS";
           // connection = new SqlConnection("Data Source=" + textBoxServer.Text + ";Initial Catalog=Federal_Migration_Service;Integrated Security=True"); 
            this.CenterToScreen();
        }
        public void Fil()
        {
            comboBox1.Items.AddRange(new object[] { "Администратор" });
        }
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = Convert.ToInt32(progressBar1.Value) + (1);
            Cursor.Current = Cursors.AppStarting;
            if (Convert.ToInt32(progressBar1.Value) > 95)
            {
                timer1.Stop();
                this.Hide();
                UpdateTab shFMS = new UpdateTab(this);
                shFMS.Show();
                progressBar1.Value = 0;
                progressBar1.Visible = false;
            }
        }

        private void buttonQuest_Click(object sender, EventArgs e)
        {
                connection = new SqlConnection("Data Source=" + textBoxServer.Text + ";Initial Catalog=Federal_Migration_Service;Integrated Security=True");
                progressBar2.Visible = true;
                timer2.Start();
                CheckServer();
                //ChechDatabase();
                
            //C:\Program Files\Microsoft SQL Server\110\SDK\Assemblies
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
            progressBar2.Value = Convert.ToInt32(progressBar2.Value) + (5);
            Cursor.Current = Cursors.AppStarting;
            if (Convert.ToInt32(progressBar2.Value) > 95)
            {
                timer2.Stop();
                this.Hide();
                textBoxPassword.Text = "";
                Quest quest = new Quest(this, this);
                quest.Show();
                progressBar2.Value = 0;
                progressBar2.Visible = false;
                textBoxPassword.Text = "";
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            label9.Visible = false;
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            
            label9.ForeColor = Color.White;
            label9.BackColor = Color.Black;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.ForeColor = Color.Black;
            label9.BackColor = Color.LightGray;
        }


        public Boolean testDatabaseExists()
        {
            String connString = ("Data Source=" + textBoxServer.Text + ";Initial Catalog=master;Integrated Security=True;");
            String cmdText = ("select * from master.dbo.sysdatabases where name=\'Federal_Migration_Service\'");
            Boolean bRet;

            System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connString);
            System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand(cmdText, sqlConnection);
            
            try
            {
            sqlConnection.Open();
            System.Data.SqlClient.SqlDataReader reader = sqlCmd.ExecuteReader();
            bRet = reader.HasRows;
            sqlConnection.Close();
            }
            catch (Exception e) 
            {
            bRet = false;
            sqlConnection.Close();
            MessageBox.Show(e.Message);
            return false;
            } //End Try Catch Block
                       
            
            if (bRet == true)
            {
                MessageBox.Show("База данных с названием Federal_Migration_Service существует!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                if (MessageBox.Show("База данных с названием Federal_Migration_Service не существует.\nВам необходимо ее восстановить для дальнешей работы с программой!\nВосстановить?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    form2 = new Form2(this); form2.Show();
                }
                return false;
            } //END OF IF

            
        } //END FUNCTION
        private void восстановитьБазуДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBoxServer.Text != "")
            {
                form2 = new Form2(this); form2.Show();
            }
            else MessageBox.Show("Сначала укажите имя сервера!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void проверитьВстроеннуюБаззыДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBoxServer.Text != "")
            {
                testDatabaseExists();
            }
            else MessageBox.Show("Сначала укажите имя сервера!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
        }

        private void оПрограммеFederalMigrationService2016ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (panel4.Visible == true)
            {
                panel4.Visible = false;
                label9.Visible = false;
                label9.ForeColor = Color.Black;
                label9.BackColor = Color.LightGray;
            }
            else
            {
                panel4.Visible = true;
                label9.Visible = true;
                label9.ForeColor = Color.White;
                label9.BackColor = Color.Black;
            } 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

