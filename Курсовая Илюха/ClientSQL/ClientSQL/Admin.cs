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
namespace ClientSQL
{
    public partial class Admin : Form
    {
        static XDocument xDoc = new XDocument();
        static string xmlUri = @"ClientSQL.exe.config";
        string connectionString;
        public Admin()
        {
            InitializeComponent();
            xDoc = XDocument.Load(xmlUri);
            connectionString = xDoc.Descendants("configuration").Descendants("connectionStrings").Descendants("add").First().Attribute("connectionString").Value;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowRoute1". При необходимости она может быть перемещена или удалена.
            this.showRoute1TableAdapter.Fill(this.shipilovDataSet.ShowRoute1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowPoint". При необходимости она может быть перемещена или удалена.
            this.showPointTableAdapter.Fill(this.shipilovDataSet.ShowPoint);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowProfessionUp". При необходимости она может быть перемещена или удалена.
            this.showProfessionUpTableAdapter.Fill(this.shipilovDataSet.ShowProfessionUp);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowPerson". При необходимости она может быть перемещена или удалена.
            this.showPersonTableAdapter.Fill(this.shipilovDataSet.ShowPerson);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowMechanics". При необходимости она может быть перемещена или удалена.
            this.showMechanicsTableAdapter.Fill(this.shipilovDataSet.ShowMechanics);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowDrivers". При необходимости она может быть перемещена или удалена.
            this.showDriversTableAdapter.Fill(this.shipilovDataSet.ShowDrivers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowConductors". При необходимости она может быть перемещена или удалена.
            this.showConductorsTableAdapter.Fill(this.shipilovDataSet.ShowConductors);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowTS". При необходимости она может быть перемещена или удалена.
            this.showTSTableAdapter.Fill(this.shipilovDataSet.ShowTS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowTrip". При необходимости она может быть перемещена или удалена.
            this.showTripTableAdapter.Fill(this.shipilovDataSet.ShowTrip);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowProfessionUp". При необходимости она может быть перемещена или удалена.
            this.showProfessionUpTableAdapter.Fill(this.shipilovDataSet.ShowProfessionUp);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowMechanics". При необходимости она может быть перемещена или удалена.
            this.showMechanicsTableAdapter.Fill(this.shipilovDataSet.ShowMechanics);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowDrivers". При необходимости она может быть перемещена или удалена.
            this.showDriversTableAdapter.Fill(this.shipilovDataSet.ShowDrivers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowConductors". При необходимости она может быть перемещена или удалена.
            this.showConductorsTableAdapter.Fill(this.shipilovDataSet.ShowConductors);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowPoint". При необходимости она может быть перемещена или удалена.
            this.showPointTableAdapter.Fill(this.shipilovDataSet.ShowPoint);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowTS". При необходимости она может быть перемещена или удалена.
            this.showTSTableAdapter.Fill(this.shipilovDataSet.ShowTS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowTrip". При необходимости она может быть перемещена или удалена.
            this.showTripTableAdapter.Fill(this.shipilovDataSet.ShowTrip);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowPerson". При необходимости она может быть перемещена или удалена.
            //this.showPersonTableAdapter.Fill(this.shipilovDataSet.ShowPerson);
            Login loginForm = this.Owner as Login;
            loginForm.Hide();
            this.Text = "Администратор";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yy HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yy HH:mm";
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            dateTimePicker2.Value = date;
            dateTimePicker1.Value = date;


        }

        private void AddTS()
        {
            char[] mass = textBox2.Text.ToArray();
            int i = mass.Length;
            string tsNum = textBox2.Text;
            int length = 0;
            int.TryParse(textBox6.Text, out length);
            int seat = 0;
            int.TryParse(textBox7.Text, out seat);
            int max = 0;
            int.TryParse(textBox8.Text, out max);
            string sqlExpression = "AddTS";
            if (length != 0 && seat != 0 && max != 0 && i == 6)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter numParam = new SqlParameter
                    {

                        ParameterName = "@Number",
                        Value = tsNum,
                    };
                    command.Parameters.Add(numParam);
                    SqlParameter seatParam = new SqlParameter
                    {

                        ParameterName = "@Seat",
                        Value = seat,
                    };
                    command.Parameters.Add(seatParam);
                    SqlParameter lengthParam = new SqlParameter
                    {

                        ParameterName = "@Length",
                        Value = length,
                    };
                    command.Parameters.Add(lengthParam);
                    SqlParameter maxParam = new SqlParameter
                    {

                        ParameterName = "@Max",
                        Value = max,
                    };
                    command.Parameters.Add(maxParam);
                    var result = command.ExecuteNonQuery();
                }
                this.showTSTableAdapter.Fill(this.shipilovDataSet.ShowTS);
            }
            else MessageBox.Show("Заполните все поля!");
        }

        private void UpdateTS()
        {
            char[] mass = textBox17.Text.ToArray();
            int i = mass.Length;
            object code = comboBox11.SelectedValue;
            string tsNum = textBox17.Text;
            int length = 0;
            int.TryParse(textBox14.Text, out length);
            int seat = 0;
            int.TryParse(textBox16.Text, out seat);
            int max = 0;
            int.TryParse(textBox15.Text, out max);
            string sqlExpression = "UpdateTS";

            if (length != 0 && seat != 0 && max != 0 && i == 6)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter codeParam = new SqlParameter
                    {

                        ParameterName = "@Number",
                        Value = code,
                    };
                    command.Parameters.Add(codeParam);
                    SqlParameter numParam = new SqlParameter
                    {

                        ParameterName = "@NumberUp",
                        Value = tsNum,
                    };
                    command.Parameters.Add(numParam);
                    SqlParameter seatParam = new SqlParameter
                    {

                        ParameterName = "@Seat",
                        Value = seat,
                    };
                    command.Parameters.Add(seatParam);
                    SqlParameter lengthParam = new SqlParameter
                    {

                        ParameterName = "@Length",
                        Value = length,
                    };
                    command.Parameters.Add(lengthParam);
                    SqlParameter maxParam = new SqlParameter
                    {

                        ParameterName = "@Max",
                        Value = max,
                    };
                    command.Parameters.Add(maxParam);
                    var result = command.ExecuteNonQuery();
                }
                this.showTSTableAdapter.Fill(this.shipilovDataSet.ShowTS);
                this.showTripTableAdapter.Fill(this.shipilovDataSet.ShowTrip);
            }
            else MessageBox.Show("Заполните все поля!");
        }

        private void AddPoint()
        {
            string name = textBox12.Text;
            string street = textBox13.Text;
            string sqlExpression = "AddPoint";

            if (name != "" && street != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter nameParam = new SqlParameter
                    {

                        ParameterName = "@Name",
                        Value = name,
                    };
                    command.Parameters.Add(nameParam);
                    SqlParameter streetParam = new SqlParameter
                    {

                        ParameterName = "@Street",
                        Value = street,
                    };
                    command.Parameters.Add(streetParam);
                    var result = command.ExecuteNonQuery();
                }
                this.showPointTableAdapter.Fill(this.shipilovDataSet.ShowPoint);
            }
            else MessageBox.Show("Заполните все поля!");
        }

        private void UpdatePoint()
        {
            string name = textBox24.Text;
            string street = textBox23.Text;
            object code = comboBox14.SelectedValue;
            string sqlExpression = "UpdatePoint";

            if (name != "" && street != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter codeParam = new SqlParameter
                    {

                        ParameterName = "@Code",
                        Value = code,
                    };
                    command.Parameters.Add(codeParam);
                    SqlParameter nameParam = new SqlParameter
                    {

                        ParameterName = "@Name",
                        Value = name,
                    };
                    command.Parameters.Add(nameParam);
                    SqlParameter streetParam = new SqlParameter
                    {

                        ParameterName = "@Street",
                        Value = street,
                    };
                    command.Parameters.Add(streetParam);
                    var result = command.ExecuteNonQuery();
                }
                this.showPointTableAdapter.Fill(this.shipilovDataSet.ShowPoint);
            }
            else MessageBox.Show("Заполните все поля!");
        }

        private void AddRoute()
        {
            object send = comboBox24.SelectedValue;
            object arrive = comboBox8.SelectedValue;
            string sqlExpression = "AddRoute";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter sendParam = new SqlParameter
                {

                    ParameterName = "@SendCode",
                    Value = send,
                };
                command.Parameters.Add(sendParam);
                SqlParameter arriveParam = new SqlParameter
                {

                    ParameterName = "@ArriveCode",
                    Value = arrive,
                };
                command.Parameters.Add(arriveParam);
                var result = command.ExecuteNonQuery();
            }
            this.showRoute1TableAdapter.Fill(this.shipilovDataSet.ShowRoute1);
        }

        private void UpdateRoute()
        {
            object send = comboBox10.SelectedValue;
            object arrive = comboBox9.SelectedValue;
            object code = comboBox13.SelectedValue;
            string sqlExpression = "UpdateRoute";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter codeParam = new SqlParameter
                {

                    ParameterName = "@Code",
                    Value = code,
                };
                command.Parameters.Add(codeParam);
                SqlParameter sendParam = new SqlParameter
                {

                    ParameterName = "@SendCode",
                    Value = send,
                };
                command.Parameters.Add(sendParam);
                SqlParameter arriveParam = new SqlParameter
                {

                    ParameterName = "@ArriveCode",
                    Value = arrive,
                };
                command.Parameters.Add(arriveParam);
                var result = command.ExecuteNonQuery();
            }
            this.showRoute1TableAdapter.Fill(this.shipilovDataSet.ShowRoute1);
        }

        private void AddTrip()
        {
            object ts = comboBox1.SelectedValue;
            object route = comboBox2.SelectedValue;
            object date = dateTimePicker1.Value;
            int price = 0;
            int.TryParse(textBox1.Text, out price);
            object conductor = comboBox4.SelectedValue;
            object driver = comboBox5.SelectedValue;
            object mechanic = comboBox6.SelectedValue;
            string sqlExpression = "AddTrip";

            if (price != 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter tsParam = new SqlParameter
                    {

                        ParameterName = "@TS",
                        Value = ts,
                    };
                    command.Parameters.Add(tsParam);
                    SqlParameter routeParam = new SqlParameter
                    {

                        ParameterName = "@Route",
                        Value = route,
                    };
                    command.Parameters.Add(routeParam);
                    SqlParameter dateParam = new SqlParameter
                    {

                        ParameterName = "@Date",
                        Value = date,
                    };
                    command.Parameters.Add(dateParam);
                    SqlParameter priceParam = new SqlParameter
                    {

                        ParameterName = "@Price",
                        Value = price,
                    };
                    command.Parameters.Add(priceParam);
                    SqlParameter conductorParam = new SqlParameter
                    {

                        ParameterName = "@Conductor",
                        Value = conductor,
                    };
                    command.Parameters.Add(conductorParam);
                    SqlParameter driverParam = new SqlParameter
                    {

                        ParameterName = "@Driver",
                        Value = driver,
                    };
                    command.Parameters.Add(driverParam);
                    SqlParameter mechanicParam = new SqlParameter
                    {

                        ParameterName = "@Mechanic",
                        Value = mechanic,
                    };
                    command.Parameters.Add(mechanicParam);
                    var result = command.ExecuteNonQuery();
                }
                this.showTripTableAdapter.Fill(this.shipilovDataSet.ShowTrip);
            }
            else MessageBox.Show("Заполните все поля!");
        }

        private void DeleteTrip()
        {
            object ts = comboBox15.SelectedValue;
            object date = dateTimePicker2.Value;
            string sqlExpression = "DeleteTrip";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter tsParam = new SqlParameter
                {

                    ParameterName = "@TS",
                    Value = ts,
                };
                command.Parameters.Add(tsParam);
                SqlParameter dateParam = new SqlParameter
                {

                    ParameterName = "@Date",
                    Value = date,
                };
                command.Parameters.Add(dateParam);
                var result = command.ExecuteNonQuery();
            }
            this.showTripTableAdapter.Fill(this.shipilovDataSet.ShowTrip);
        }

        private void AddPerson()
        {
            string secName = textBox3.Text;
            string name = textBox9.Text;
            string thirdName = textBox10.Text;
            object profCode = comboBox7.SelectedValue;
            string sqlExpression = "AddPerson";

            if (secName != "" && name != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter secNameParam = new SqlParameter
                    {

                        ParameterName = "@SecondName",
                        Value = secName,
                    };
                    command.Parameters.Add(secNameParam);
                    SqlParameter nameParam = new SqlParameter
                    {

                        ParameterName = "@Name",
                        Value = name,
                    };
                    command.Parameters.Add(nameParam);
                    SqlParameter thirdNameParam = new SqlParameter
                    {

                        ParameterName = "@ThirdName",
                        Value = thirdName,
                    };
                    command.Parameters.Add(thirdNameParam);
                    SqlParameter profParam = new SqlParameter
                    {

                        ParameterName = "@ProfessionCode",
                        Value = profCode,
                    };
                    command.Parameters.Add(profParam);
                    var result = command.ExecuteNonQuery();
                }
                RefreshPersons();
            }
            else MessageBox.Show("Поля фамилии и имени должны быть заполнены!");
        }

        private void UpdatePerson()
        {
            string secName = textBox18.Text;
            string name = textBox19.Text;
            string thirdName = textBox20.Text;
            object profCode = comboBox3.SelectedValue;
            object code = comboBox12.SelectedValue;
            string sqlExpression = "UpdatePerson";

            if (secName != "" && name != "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter codeParam = new SqlParameter
                    {

                        ParameterName = "@Code",
                        Value = code,
                    };
                    command.Parameters.Add(codeParam);
                    SqlParameter secNameParam = new SqlParameter
                    {

                        ParameterName = "@SecondName",
                        Value = secName,
                    };
                    command.Parameters.Add(secNameParam);
                    SqlParameter nameParam = new SqlParameter
                    {

                        ParameterName = "@Name",
                        Value = name,
                    };
                    command.Parameters.Add(nameParam);
                    SqlParameter thirdNameParam = new SqlParameter
                    {

                        ParameterName = "@ThirdName",
                        Value = thirdName,
                    };
                    command.Parameters.Add(thirdNameParam);
                    SqlParameter profParam = new SqlParameter
                    {

                        ParameterName = "@ProfessionCode",
                        Value = profCode,
                    };
                    command.Parameters.Add(profParam);
                    var result = command.ExecuteNonQuery();
                }
                RefreshPersons();
            }
            else MessageBox.Show("Поля фамилии и имени должны быть заполнены!");
        }



        private void RefreshPersons()
        {
            this.showPersonTableAdapter.Fill(this.shipilovDataSet.ShowPerson);
            this.showMechanicsTableAdapter.Fill(this.shipilovDataSet.ShowMechanics);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowDrivers". При необходимости она может быть перемещена или удалена.
            this.showDriversTableAdapter.Fill(this.shipilovDataSet.ShowDrivers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shipilovDataSet.ShowConductors". При необходимости она может быть перемещена или удалена.
            this.showConductorsTableAdapter.Fill(this.shipilovDataSet.ShowConductors);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddPerson();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdatePerson();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddTS();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateTS();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AddPoint();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdatePoint();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddRoute();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateRoute();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTrip();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DeleteTrip();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }

        private void OnlyInt(KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void OnlyString(KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsLetter(c) && e.KeyChar != (char)Keys.Back && c !='-')
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyString(e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyString(e);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyString(e);
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyString(e);
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyString(e);
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyString(e);
        }

        public void OnlyTS(KeyPressEventArgs e, string text)
        {
            char[] mass = text.ToArray();
            int i = mass.Length;
            char c = e.KeyChar;
            switch (i)
            {
                case 0:
                    if (c != 'А' && c != 'В' && c != 'Е' && c != 'К'
                        && c != 'М' && c != 'Н' && c != 'О' && c != 'Р' && c != 'С' && c != 'Т' && c != 'У' && c != 'Х')
                    {
                        e.Handled = true;
                    }
                    break;
                case 1:
                    if (e.KeyChar != (char)Keys.Back && !char.IsDigit(c))
                    {
                        e.Handled = true;
                    }
                    break;
                case 2:
                    if (e.KeyChar != (char)Keys.Back && !char.IsDigit(c))
                    {
                        e.Handled = true;
                    }
                    break;
                case 3:
                    if (e.KeyChar != (char)Keys.Back && !char.IsDigit(c))
                    {
                        e.Handled = true;
                    }
                    break;
                case 4:
                    if (e.KeyChar != (char)Keys.Back && c != 'А' && c != 'В' && c != 'Е' && c != 'К'
                        && c != 'М' && c != 'Н' && c != 'О' && c != 'Р' && c != 'С' && c != 'Т' && c != 'У' && c != 'Х')
                    {
                        e.Handled = true;
                    }
                    break;
                case 5:
                    if (e.KeyChar != (char)Keys.Back && c != 'А' && c != 'В' && c != 'Е' && c != 'К'
                        && c != 'М' && c != 'Н' && c != 'О' && c != 'Р' && c != 'С' && c != 'Т' && c != 'У' && c != 'Х')
                    {
                        e.Handled = true;
                    }
                    break;
                default:
                    if(e.KeyChar != (char)Keys.Back)
                        {
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTS(e, textBox2.Text);
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTS(e, textBox17.Text);
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox11.SelectedIndex;
            if (i >= 0)
            {
                textBox17.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
                textBox16.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
                textBox14.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
                textBox15.Text = dataGridView2.Rows[i].Cells[3].Value.ToString();
            }
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox12.SelectedIndex;
            if (i >= 0)
            {
                textBox18.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();
                textBox19.Text = dataGridView3.Rows[i].Cells[2].Value.ToString();
                textBox20.Text = dataGridView3.Rows[i].Cells[3].Value.ToString();
                string prof = dataGridView3.Rows[i].Cells[4].Value.ToString();
                switch (prof)
                {
                    case ("Кондуктор"):
                        comboBox3.SelectedIndex = 0;
                        break;
                    case ("Водитель"):
                        comboBox3.SelectedIndex = 1;
                        break;
                    case ("Механик"):
                        comboBox3.SelectedIndex = 2;
                        break;
                }
            }
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox14.SelectedIndex;
            if (i >= 0)
            {
                textBox24.Text = dataGridView5.Rows[i].Cells[1].Value.ToString();
                textBox23.Text = dataGridView5.Rows[i].Cells[2].Value.ToString();
            }
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }


        //private void dataGridView3_CurrentCellChanged(object sender, EventArgs e)
        //{
        //    textBox18.Text = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].ToString();
        //    textBox19.Text = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[1].ToString();
        //    textBox20.Text = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[2].ToString();
        //}
    }
}
