using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;

namespace ClientSQL
{
    public partial class Operator : Form
    {
        static XDocument xDoc = new XDocument();
        static string xmlUri = @"ClientSQL.exe.config";
        string connectionString;
        
        public Operator()
        {
            InitializeComponent();
            xDoc = XDocument.Load(xmlUri);
            connectionString = xDoc.Descendants("configuration").Descendants("connectionStrings").Descendants("add").First().Attribute("connectionString").Value;
        }

        private void Operator_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowPoint". При необходимости она может быть перемещена или удалена.
            this.showPointTableAdapter.Fill(this.shipilovDataSet.ShowPoint);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.operatorShow3". При необходимости она может быть перемещена или удалена.
            this.operatorShow3TableAdapter.Fill(this.shipilovDataSet.operatorShow3);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowTS". При необходимости она может быть перемещена или удалена.
            this.showTSTableAdapter.Fill(this.shipilovDataSet.ShowTS);
            Login loginForm = this.Owner as Login;
            loginForm.Hide();
            this.Text = "Отслеживание автобусов";
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yy HH:mm";
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            dateTimePicker1.Value = date;
        }

        private string procName()
        {
            string proc = "";
            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    if (checkBox3.Checked)
                    {
                        proc = "SearchTSandRouteandDate";
                    }
                    else
                    {
                        proc = "SearchTSandRoute";
                    }
                }
                else if (checkBox3.Checked)
                {
                    proc = "SearchTSandDate";
                }
                else
                {
                    proc = "SearchTS";
                }
            }
            else if (checkBox2.Checked)
            {
                if (checkBox3.Checked)
                {
                    proc = "SearchRouteandDate";
                }
                else
                {
                    proc = "SearchRoute";
                }
            }
            else if(checkBox3.Checked)
            {
                proc = "SearchDate";
            }
            return proc;
        }

        private void Searh()
        {
            object ts = comboBox1.SelectedValue;
            object send = comboBox2.SelectedValue;
            object arrive = comboBox3.SelectedValue;
            object date = dateTimePicker1.Value;
            string proc = procName();
            string queue = "";
            switch (proc)
            {
                case "SearchTS":
                    {
                        queue = "Execute " + proc + " '" + ts + "'"; break;
                    }
                case "SearchRoute":
                    {
                        queue = "Execute " + proc + " " + send + ", " + arrive; break;
                    }
                case "SearchDate":
                    {
                        queue = "Execute " + proc + " '" + date + "'"; break;
                    }
                case "SearchTSandRoute":
                    {
                        queue = "Execute " + proc + " '" + ts + "'," + " " + send + ", " + arrive; break;
                    }
                case "SearchTSandDate":
                    {
                        queue = "Execute " + proc + " '" + ts + "', '" + date + "'"; break;
                    }
                case "SearchRouteandDate":
                    {
                        queue = "Execute " + proc + " " + send + ", " + arrive + ", '" + date + "'"; break;
                    }
                case "SearchTSandRouteandDate":
                    {
                        queue = "Execute " + proc + " '" + ts + "', " + send + ", " + arrive + ", '" + date + "'"; break;
                    }
                default:
                    {
                        queue = "Execute SearchAll"; break;
                    }
            }
            using (var sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlDataAdapter sqldt =  new SqlDataAdapter(queue, sqlConn);
                DataTable dt = new DataTable();
                sqldt.Fill(dt);
                dataGridViewSearchTS.DataSource = dt;
            }
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Searh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = !comboBox1.Enabled;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = !comboBox2.Enabled;
            comboBox3.Enabled = !comboBox3.Enabled;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = !dateTimePicker1.Enabled;
        }

        private void выводВWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int col = dataGridViewSearchTS.Columns.Count;
            int row = dataGridViewSearchTS.Rows.Count;

            if (row > 0)
            {
                Word.Application app = new Word.Application();
                object missing = Type.Missing;
                app.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                Word.Document document = app.ActiveDocument;
                Word.Range range = app.Selection.Range;
                object behavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
                object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitFixed;
                document.Tables.Add(range, row +1, col, ref behavior, ref autoFitBehavior);
                document.Tables[1].Cell(1, 1).Range.Text = "Номер ТС";
                document.Tables[1].Cell(1, 2).Range.Text = "Пункт отправления";
                document.Tables[1].Cell(1, 3).Range.Text = "Пункт прибытия";
                document.Tables[1].Cell(1, 4).Range.Text = "Дата отправления";
                document.Tables[1].Cell(1, 5).Range.Text = "Цена билета";
                document.Tables[1].Cell(1, 6).Range.Text = "Кондуктор";
                document.Tables[1].Cell(1, 7).Range.Text = "Водитель";
                document.Tables[1].Cell(1, 8).Range.Text = "Механик";
                for (int j = 0; j < row; j++)
                {
                    for (int i = 0; i < col; i++)
                    {
                        document.Tables[1].Cell(j + 2, i + 1).Range.Text = dataGridViewSearchTS[i, j].Value.ToString();
                    }
                    app.Visible = true;
                }
            }
            else MessageBox.Show("Нечего выводить!");
        }
    }
}
