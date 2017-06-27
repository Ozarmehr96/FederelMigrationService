using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace Federal_Migration_Service
{
    public partial class Quest : Form
    {
        UpdateTab up;
        Form1 form1;
       public  SqlConnection connection;
        public Quest(Form1 form, Form1 form1)
        {
           this.form1 = form1;
            InitializeComponent();
            this.up = new UpdateTab(form);
           connection = new SqlConnection("Data Source="+form1.CheckServer()+";Initial Catalog=Federal_Migration_Service;Integrated Security=True");            
        }
        private void Quest_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data Source=" + form1.CheckServer() + ";Initial Catalog=Federal_Migration_Service;Integrated Security=True");
            //connection = new SqlConnection("Data Source=" + form1.CheckServer() + ";Initial Catalog=Federal_Migration_Service;Integrated Security=True");            
            this.CenterToScreen();
            //up.AllRefresh();
           RefreshDataGrid("ShowPersons", dataGridViewPersons);
            
        }
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void сменитьПользовательяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сменитьПользовательяToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 60; i++)
            {
                Thread.Sleep(2);
                Cursor.Current = Cursors.AppStarting;
            }
            form1.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowQuery();
        }
        public void Delay()
        {
            for (int i = 0; i < 60; i++)
            {
                Thread.Sleep(2);
                Cursor.Current = Cursors.AppStarting;
            }
        }
        public void ShowQuery()
        {
            SqlDataAdapter sqldat = new SqlDataAdapter("Exec SearchShowPersons '" + textBox1.Text.ToString() + "'", connection);
            if (textBox1.Text != "")
            {
                try
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    int res = sqldat.Fill(dt);
                    if (res != 0)
                    {
                        Delay();
                        dataGridView1.DataSource = dt;
                        tabControl1.Visible = true;
                        Fill("SearchShowAddress", dataGridView2, label8);
                        Fill("SearchShowFMS", dataGridView3, label13);
                        Fill("SearchShowEducation", dataGridView4, label9);
                        Fill("SearchShowRVP", dataGridView5, label10);
                        Fill("SearchShowVNJ", dataGridView6, label11);
                        textBox1.Text = "";
                        label15.Visible = true;
                        label15.Text = "Результат запроса: " + res + "";
                    }
                    else
                    {
                        Delay();
                        tabControl1.Visible = false;
                        label15.Visible = false;
                        MessageBox.Show("По вашему запросу ничего не найдено!\nПерсоны с такой фамилей не существует!", "Внимаение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
            else MessageBox.Show("Заполните поле", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void Fill(string StoredName,System.Windows.Forms.DataGridView dgrid, Label label)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    SqlDataAdapter sqldat = new SqlDataAdapter("Exec " + StoredName + " '" + textBox1.Text.ToString() + "'", connection);
                    DataTable dt = new DataTable();
                    int res = sqldat.Fill(dt);
                    dgrid.DataSource = dt;
                    if (res == 0)
                    {
                        dgrid.Visible = false;
                        label.Visible = true;
                    }
                    if (res > 1)
                    {
                        dgrid.Visible = true;
                        label.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public void RefreshDataGrid(string ShowProcedureName, System.Windows.Forms.DataGridView datgridname)
        {
            datgridname.AllowUserToAddRows = false;
            datgridname.AllowUserToDeleteRows = false;
            datgridname.AllowUserToOrderColumns = true;
            datgridname.ReadOnly = true;
            try
            {
                connection.Open();
                SqlDataAdapter sqldat = new SqlDataAdapter("Exec " + ShowProcedureName + "", connection);
                DataTable dt = new DataTable();
                sqldat.Fill(dt);
                datgridname.DataSource = dt;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}

