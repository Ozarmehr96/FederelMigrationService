using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
namespace Federal_Migration_Service
{


    //FillingComBoxNameNoInMethod(comboBox6, "Person", "AddressPers"); // для добавление имени персоны
    //FillingComBoxMethodAdd(comboBoxFMSAdd, "FMS"); // для добавлении номер персоны 
    //FillingComBoxMethodIDUp(comboBoxUpdateFMS, "FMS");  для обновлении номер персоны
    //FillingComBoxNameMethodUpName(comboBox7, "AddressPers"); для обновлении имени персоны

    public partial class UpdateTab : Form
    {
        
        Form1 form1;
        DateTime dt = new DateTime(1900, 01, 01);
        public SqlConnection connection;
        public UpdateTab(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }
        public void WidthColumns()
        { 
        }
        private void ShowFMS_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data Source="+form1.CheckServer()+";Initial Catalog=Federal_Migration_Service;Integrated Security=True");
            AllRefresh();
            connection.Open();
            FillingComBoxMethod(comboBox1, "Nationality", "Nations", "NationID");
            FillingComBoxMethod(comboBoxNationUpdate, "Nationality", "Nations", "NationID");
            connection.Close();
            
        }
        public  void AllRefresh()
        {
            WidthColumns();
            RefreshDataGrid("ShowPersons", dataGridViewPerson); // dataGridViewPerson
            RefreshDataGrid("ShowAddressPers", dataGridViewAddressPerson); //dataGridViewAddressPerson
            RefreshDataGrid("ShowFMS", dataGridViewFMS); //dataGridViewAddressPerson
            RefreshDataGrid("ShowEducation", dataGridViewEducation); //ShowEducation
            RefreshDataGrid("ShowRVP", dataGridViewRVP); //dataGridViewRVP
            RefreshDataGrid("ShowVNJ", dataGridViewVNJ); //dataGridViewRVP
            Point location = new Point(250, 50);
            this.DesktopLocation = location;
            connection.Open();
            //FillingComBoxMethod(comboBox3, "id", "Person", "Surname");
            FillingComBoxMethod(comboBox2, "id", "Person", "Surname");
            FillingComBoxNameMethod(comboBox3, "Person", comboBox2);
           
            
            connection.Close();
            
            connection.Open();
            FillingComBoxMethodAdd(comboBoxFMSAdd, "FMS");
            FillingComBoxMethodIDUp(comboBoxUpdateFMS, "FMS");
            connection.Close();
        }
       
        //*************************************  Метод заполнения combox  ********************************************
        public void FillingComBoxNameNoInMethod(ComboBox ComboxName, string TableName, string table2)
        {
         //   SqlCommand sqlcmdCombox = new SqlCommand("select id from Person where id not in (select PersonId from FMS) Order by id", connection);

            SqlCommand sqlcmdCombox = new SqlCommand("Select Surname, Name, MiddleName, id from " + TableName + " where id not in (select PersonId from " + table2 + ")  Order By Surname", connection);
            try
            {
                string full = "";
                SqlDataReader dr = sqlcmdCombox.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr[0].ToString();
                    string surname = dr[1].ToString();
                    string middle = dr[2].ToString();
                    full = name + " " + surname + " " + middle;
                    ComboxName.Items.Add(full);
                }
                dr.Close();
                int mycurrentxomboxindex = 0;
                mycurrentxomboxindex += Convert.ToInt32(ComboxName.SelectedItem);
                ComboxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }
        public void FillingComBoxMethodAdd(ComboBox ComboxName, string TableName)
        {
            //select id from Person where id not in (select PersonId from FMS) Join Person On Order by id
            SqlCommand sqlcmdCombox = new SqlCommand("select id from Person where id not in (select PersonId from "+TableName+") Order by Surname", connection);
            try
            {
                SqlDataReader dr = sqlcmdCombox.ExecuteReader();
                while (dr.Read())
                {
                    ComboxName.Items.Add(dr["id"]);
                }
                dr.Close();
                ComboxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void FillingComBoxNameMethodUpName(ComboBox ComboxName, string TableName)
        {
            SqlCommand sqlcmdCombox = new SqlCommand("select  Surname,Name,MiddleName,id from Person where id in (select PersonId from " + TableName + ") Order by Surname", connection);
            try
            {
                string full = "";
                SqlDataReader dr = sqlcmdCombox.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr[0].ToString();
                    string surname = dr[1].ToString();
                    string middle = dr[2].ToString();
                    full = name + " " + surname + " " + middle;
                    ComboxName.Items.Add(full);
                }
                dr.Close();
                int mycurrentxomboxindex = 0;
                mycurrentxomboxindex += Convert.ToInt32(ComboxName.SelectedItem);
                ComboxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }


        public void FillingComBoxNameMethod(ComboBox ComboxName, string TableName, ComboBox ComboxName2)
        {
            SqlCommand sqlcmdCombox = new SqlCommand("Select Surname,Name,MiddleName, id From " + TableName + " Order By Surname", connection);
            try
            {
                string full = "";
                SqlDataReader dr = sqlcmdCombox.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr[0].ToString();
                    string surname = dr[1].ToString();
                    string middle = dr[2].ToString();
                    full = name + " " + surname + " " + middle;
                    ComboxName.Items.Add(full);
                }
                dr.Close();
                int mycurrentxomboxindex = 0;
                mycurrentxomboxindex += Convert.ToInt32(ComboxName.SelectedItem);
                ComboxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                ComboxName2.SelectedValue = Convert.ToInt32(ComboxName.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }
       
    public void FillingComBoxMethodIDUp(ComboBox ComboxName, string TableName)
        {
            SqlCommand sqlcmdCombox = new SqlCommand(" Select PersonId From " + TableName + " JOIN Person On  Person.id= " + TableName + ".PersonId Order By Surname", connection);
            try
            {
                SqlDataReader dr = sqlcmdCombox.ExecuteReader();
                while (dr.Read())
                {
                    ComboxName.Items.Add(dr["PersonId"]);
                }
                dr.Close();
                ComboxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        

        public void FillingComBoxMethod(ComboBox ComboxName, string Columname, string TableName, string Orderby)
        {
            SqlCommand sqlcmdCombox = new SqlCommand("Select " + Columname + " From " + TableName + " Order By " + Orderby + "", connection);
            try
            {
                SqlDataReader dr = sqlcmdCombox.ExecuteReader();
                while (dr.Read())
                {
                    ComboxName.Items.Add(dr[Columname]);
                }
                dr.Close();
                ComboxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void ShowFMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = DialogResult.Yes != MessageBox.Show("Вы действительно хотите выйти ?", "Внимание",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            form1.Close();
        }
        public void RefreshDataGrid(string ShowProcedureName, System.Windows.Forms.DataGridView datgridname)
        {
            datgridname.AllowUserToAddRows = false;
            datgridname.AllowUserToDeleteRows = false;
            datgridname.AllowUserToOrderColumns = true;
            datgridname.ReadOnly = true;
            connection.Close();
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
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        public bool ReturnMethod(RadioButton radio1, RadioButton radio2)
        {

            bool check = false;
            if (radio1.Checked == true)
            {
                check = true;
            }
            else if (radio2.Checked == true)
            {
                check = false;
            }
            return check;
        }

        //*************************************  Персона  ********************************************
        private void button1_Click(object sender, EventArgs e)
        {
            IsNum(textBoxPassport);
            if (textBoxSurname.Text == "" || textBoxMiddle.Text == "" || textBoxPassport.Text == "" || textBoxPhone.Text == "" || comboBox1.Text == "" || !radioButton.Checked && !radioButton1.Checked)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxPassport.Text.Length > 9 || textBoxPassport.Text.Length < 9)
            {
                MessageBox.Show("Серия паспорта должна содержать не больше и не меньше 9 цыфр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool gender = false;
                if (radioButton.Checked == true)
                {
                    gender = false;
                }
                else if (radioButton1.Checked == true)
                {
                    gender = true;

                }
                try
                {
                    connection.Open();
                    //@Name varchar (30),           @Surname varchar (30),          @MiddleName varchar (30), @DateBirth DATE,                               @Gender bit, @NationId varchar(50),                        @Phone nchar (11), @passport int)
                    SqlDataAdapter sqldataadapter = new SqlDataAdapter("Exec AddPerson'" + textBoxName.Text + "','" + textBoxSurname.Text + "','" + textBoxMiddle.Text + "','" + dateTimePicker1.Value + "', '" + Convert.ToBoolean(gender) + "', '" + comboBox1.SelectedItem.ToString() + "','" + textBoxPhone.Text + "', " + Convert.ToInt64(textBoxPassport.Text) + "", connection);
                    DataTable datatable = new DataTable();
                    sqldataadapter.Fill(datatable);
                    dataGridViewPerson.DataSource = datatable;
                    MessageBox.Show("Данные успешно добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                RefreshDataGrid("ShowPersons", dataGridViewPerson);
                
                WidthColumns();
                connection.Close();
                textBoxName.Text = "";
                textBoxSurname.Text = "";
                textBoxMiddle.Text = "";
                textBoxPassport.Text = "";
                textBoxPhone.Text = "";
                connection.Open();
                comboBox3.Items.Clear();
                FillingComBoxNameMethod(comboBox3, "Person", comboBox2);
                connection.Close();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //  Проверка полкей 
            IsNum(textBoxPassportUpdate);
            if (textBoxNameUpdate.Text == "" || textBoxSurnameUpdate.Text == "" || textBoxMiddleUpdate.Text == "" || textBoxPassportUpdate.Text == "" || comboBox2.Text == "" || textBoxPhoneUpdate.Text == "" || comboBoxNationUpdate.Text == "" || !radioButtonFemale.Checked && !radioButtonUpdateMale.Checked)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxPassportUpdate.Text.Length > 9 || textBoxPassportUpdate.Text.Length < 9)
            {
                MessageBox.Show("Серия паспорта должна содержать не больше и не меньше 9 цыфр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Радиоbuttons
                bool gender = false;
                if (radioButtonUpdateMale.Checked == true)
                {
                    gender = true;
                }
                else if (radioButtonFemale.Checked == true)
                {
                    gender = false;

                }
                try
                {
                    connection.Open();
                    int mycurrentxomboxindex = 0;
                    mycurrentxomboxindex += Convert.ToInt32(comboBox2.SelectedItem);
                    SqlDataAdapter updatecmd = new SqlDataAdapter("Exec UpdatePerson " + mycurrentxomboxindex +
                                    ", '" + textBoxNameUpdate.Text + "', '" + textBoxSurnameUpdate.Text + "', '" + textBoxMiddleUpdate.Text + "','" + dateTimePickerUpdate.Value + "', '" + Convert.ToBoolean(gender) + "','" +
                                    comboBoxNationUpdate.SelectedItem.ToString() + "', '" + textBoxPhoneUpdate.Text + "'," + Convert.ToInt32(textBoxPassportUpdate.Text) + "", connection);
                    DataTable dtupdate = new DataTable();
                    updatecmd.Fill(dtupdate);
                    dataGridViewPerson.DataSource = dtupdate;
                    MessageBox.Show("Данные успешно сохранены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                RefreshDataGrid("ShowPersons", dataGridViewPerson);
                textBoxNameUpdate.Text = "";
                textBoxSurnameUpdate.Text = "";
                textBoxMiddleUpdate.Text = "";
                textBoxPassportUpdate.Text = "";
                textBoxPhoneUpdate.Text = "";
                connection.Close();
            }

        }
        //************************************* Конец персоны  ********************************************



        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            comboBox2.Items.Clear();
            comboBoxFMSAdd.Items.Clear();
            connection.Open();
            FillingComBoxMethod(comboBox2, "id", "Person", "Surname");
            //FillingComBoxNameMethod(comboBox2, "Person");
           // FillingComBoxMethod(comboBoxFMSAdd, "id", "Person", "Surname");
            //FillingComBoxMethod2(comboBoxFMSAdd, "id", "Person");
            RefreshDataGrid("ShowPersons", dataGridViewPerson);
            connection.Close();
            connection.Open();
            comboBox3.Items.Clear();
            FillingComBoxNameMethod(comboBox3, "Person", comboBox2);
            connection.Close();
            connection.Open();
            FillingComBoxMethodAdd(comboBoxFMSAdd, "FMS");
            connection.Close();

        }

        //*************************************  Федеральная миграционная служба  *****************************

        private void buttonAddToFMS_Click(object sender, EventArgs e)
        {
            if (comboBoxFMSAdd.Text == "")
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!radioButtonPolisNo.Checked && !radioButtonPolisHas.Checked)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!radioButtonPNo.Checked && !radioButtonPHas.Checked)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();
                    AddToTableMethod();
                    RefreshDataGrid("ShowFMS", dataGridViewFMS);
                    MessageBox.Show("Данные успешно добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxFMSAdd.Items.Clear();
                    connection.Close();
                    comboBox4.Items.Clear();
                    connection.Open();
                    FillingComBoxMethodAdd(comboBox4, "FMS");
                    connection.Close();
                    comboBox5.Items.Clear();
                    connection.Open();
                    FillingComBoxNameMethodUpName(comboBox5, "FMS");
                    FillingComBoxMethodIDUp(comboBoxUpdateFMS, "FMS");
                    connection.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        public void AddToTableMethod()
        {
            int mycurindexcombox = 0;
            mycurindexcombox += Convert.ToInt32(comboBoxFMSAdd.SelectedItem);
            if (ReturnMethod(radioButtonPHas, radioButtonPNo) == false)
            {
                SqlDataAdapter sqldta = new SqlDataAdapter("Exec AddPersonToFMS " + mycurindexcombox + ", '" + dateTimePickArrival.Value +
                               "', '" + dateTimePickRegis.Value + "','" + dateTimePickRegisTO.Value + "','" + ReturnMethod(radioButtonPolisHas, radioButtonPolisNo) + "','" + ReturnMethod(radioButtonPHas, radioButtonPNo) + "','" + null + "','" + null + "' ", connection);
                DataTable dt = new DataTable();
                sqldta.Fill(dt);
                dataGridViewFMS.DataSource = dt;
            }
            else
            {
                SqlDataAdapter sqldta = new SqlDataAdapter("Exec AddPersonToFMS " + mycurindexcombox + ", '" + dateTimePickArrival.Value +
              "', '" + dateTimePickRegis.Value + "','" + dateTimePickRegisTO.Value + "','" + ReturnMethod(radioButtonPolisHas, radioButtonPolisNo) + "','" + ReturnMethod(radioButtonPHas, radioButtonPNo) + "','" + dateTimePickerPermitFrom.Value + "','" + dateTimePickerPermitTo.Value + "' ", connection);
                DataTable dt = new DataTable();
                sqldta.Fill(dt);
                dataGridViewFMS.DataSource = dt;
            }
        }
        // заполнение Combox10
        public void ComboxFMS()
        {
          //  SqlCommand sqlcmdCombox = new SqlCommand("Select " + Columname + " From " + TableName + " Join Person On  " + TableName + ".PersonId=Person Order By Surname", connection);

            SqlCommand sqlcmdCombox = new SqlCommand("select id from Person where id not in (select PersonId from FMS) Join Person On Order by id", connection);
            try
            {

                SqlDataReader dr = sqlcmdCombox.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxFMSAdd.Items.Add(dr["id"]);
                }
                dr.Close();
                dr.Dispose();
                comboBoxFMSAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                Console.WriteLine("  Message: {0}", ex.Message);
            }

        }


        private void buttonUpdateFMS_Click(object sender, EventArgs e)
        {
            int mycurindexcombox = 0;
            mycurindexcombox += Convert.ToInt32(comboBoxUpdateFMS.SelectedItem);
            if (mycurindexcombox == 0)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!radioButtonPolisNoUp.Checked && !radioButtonPolisHasUp.Checked)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!radioButtonPatHasUp.Checked && !radioButtonPatNoUp.Checked)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //SqlConnection con = new SqlConnection("Data Source=Ozar-PC\\SQLEXPRESS;Initial Catalog=Federal_Migration_Service;Integrated Security=True");
                try
                {
                    if (ReturnMethod(radioButtonPatHasUp, radioButtonPatNoUp) == false)
                    {
                        dateTimePickerPermitFromUp.Value = dt;
                        dateTimePickerPermitToUp.Value = dt;
                    }
                    // SqlCommand sqlprocedure = new SqlCommand("EXECUTE UpdateFMS @id, @arrival, @RTimeFrom, @RTimeTo, @Polis, @Wper, @PerTFrom, @PerTtO",connection);
                    SqlCommand sqlprocedure = new SqlCommand();
                    sqlprocedure.Connection = connection;
                    sqlprocedure.CommandType = CommandType.StoredProcedure;
                    sqlprocedure.CommandText = "UpdateFMS";
                    sqlprocedure.Parameters.AddWithValue("@id", SqlDbType.Int).Value = mycurindexcombox;
                    sqlprocedure.Parameters.Add("@arrival", SqlDbType.DateTime).Value = dateTimePickArrivalUp.Value;
                    sqlprocedure.Parameters.Add("@RTimeFrom", SqlDbType.DateTime).Value = dateTimePickRegisUp.Value;
                    sqlprocedure.Parameters.Add("@RTimeTo", SqlDbType.DateTime).Value = dateTimePickRegisTOUp.Value;
                    sqlprocedure.Parameters.Add("@Polis", SqlDbType.Bit).Value = ReturnMethod(radioButtonPolisHasUp, radioButtonPolisNoUp);
                    sqlprocedure.Parameters.Add("@Wper", SqlDbType.Bit).Value = ReturnMethod(radioButtonPatHasUp, radioButtonPatNoUp);
                    sqlprocedure.Parameters.Add("@PerTFrom", SqlDbType.DateTime).Value = dateTimePickerPermitFromUp.Value;
                    sqlprocedure.Parameters.Add("@PerTtO", SqlDbType.DateTime).Value = dateTimePickerPermitToUp.Value;
                    connection.Open();
                    sqlprocedure.ExecuteNonQuery();
                    MessageBox.Show("Данне успешно сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGrid("ShowFMS", dataGridViewFMS);

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

        }
        private void buttonDeleteFMS_Click(object sender, EventArgs e)
        {
            DeletePersonFromFMS();
            connection.Open();
            comboBoxUpdateFMS.Items.Clear();
            FillingComBoxMethodIDUp(comboBoxUpdateFMS, "FMS");
            connection.Close();
            //DeleteMethod(textBox2, "FMS");
        }
        //*********************************************************************************************************************************
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel13.Visible = true;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel13.Visible = false;
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            panel14.Visible = true;
        }

        private void radioButtonPatNoUp_CheckedChanged(object sender, EventArgs e)
        {
            panel14.Visible = false;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            panel12.Visible = true;
        }

        private void radioButton3_CheckedChanged_2(object sender, EventArgs e)
        {
            panel12.Visible = false;
        }

        private void radioButtonRVPnoUp_CheckedChanged(object sender, EventArgs e)
        {
            panel15.Visible = false;
        }

        private void radioButtonRVPhasUp_CheckedChanged(object sender, EventArgs e)
        {
            panel15.Visible = true;
        }

        private void radioButtonVNJHas_CheckedChanged(object sender, EventArgs e)
        {
            panel17.Visible = true;
        }

        private void radioButtonVNJNo_CheckedChanged(object sender, EventArgs e)
        {
            panel17.Visible = false;
        }

        private void radioButtonVNJHasUp_CheckedChanged(object sender, EventArgs e)
        {
            panel19.Visible = true;
        }

        private void radioButtonVNJNoUp_CheckedChanged(object sender, EventArgs e)
        {
            panel19.Visible = false;
        }
        // **********************************************************************************************************************************
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox4.Items.Clear();
            connection.Open();
            FillingComBoxNameNoInMethod(comboBox4, "Person", "FMS");
            connection.Close();
            comboBoxFMSAdd.Items.Clear();
            comboBoxUpdateFMS.Items.Clear();
            comboBoxPersonNumberAdressUp.Items.Clear();
            comboBox7.Items.Clear();
            comboBox6.Items.Clear();
            comboBoxPersonCityAdressUp.Items.Clear();
            comboBoxPersonCityAdress.Items.Clear();
            comboBoxPersonNumberAdress.Items.Clear();
            comboBox6.Items.Clear();
            connection.Open();
            FillingComBoxMethodAdd(comboBoxFMSAdd, "FMS");
            FillingComBoxMethodAdd(comboBoxPersonNumberAdress, "AddressPers");
            FillingComBoxNameNoInMethod(comboBox6, "Person", "AddressPers");
            connection.Close();
            connection.Open();
           // NotInCombobox("PersonId", "AddressPers", comboBoxPersonNumberAdress);
            FillingComBoxMethod(comboBoxPersonCityAdress, "Name", "Cities", "Name");
            FillingComBoxMethod(comboBoxPersonCityAdressUp, "Name", "Cities", "Name");
            connection.Close();
            UpdateEducation();
            UpdateRVP();
            UpdateVNJ();
            comboBox5.Items.Clear();
            connection.Open();
            FillingComBoxNameMethodUpName(comboBox5, "FMS");
            FillingComBoxMethodIDUp(comboBoxUpdateFMS, "FMS");
            FillingComBoxMethodIDUp(comboBoxPersonNumberAdressUp, "AddressPers");
            FillingComBoxNameMethodUpName(comboBox7, "AddressPers");
            connection.Close();
            
        }
        //*************************************************** Адрес персоны **************************************************************///
        private void buttonAddressPerson_Click(object sender, EventArgs e)
        {
            IsNum(textBoxPersonApartrAdress);
            if (comboBoxPersonNumberAdress.Text == "" || comboBoxPersonCityAdress.Text == "" || textBoxPersonSreetAddress.Text == "" || textBoxPersonApartrAdress.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlCommand sqlprocedure = new SqlCommand();
                    sqlprocedure.Connection = connection;
                    sqlprocedure.CommandType = CommandType.StoredProcedure;
                    sqlprocedure.CommandText = "AddAddressFroPerson";
                    sqlprocedure.Parameters.AddWithValue("@PersonId", SqlDbType.Int).Value = comboBoxPersonNumberAdress.SelectedItem;
                    sqlprocedure.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = comboBoxPersonCityAdress.SelectedItem.ToString();
                    sqlprocedure.Parameters.Add("@street", SqlDbType.VarChar, 30).Value = textBoxPersonSreetAddress.Text;
                    sqlprocedure.Parameters.Add("@Apart", SqlDbType.Int).Value = Convert.ToInt32(textBoxPersonApartrAdress.Text);
                    connection.Open();
                    sqlprocedure.ExecuteNonQuery();
                    MessageBox.Show("Данне успешно добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGrid("ShowAddressPers", dataGridViewAddressPerson);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    //throw ex;
                }
                finally
                {
                    connection.Close();
                    UpdateComboboxAdress();
                }
            }
        }

        private void buttonAddressPersonUp_Click(object sender, EventArgs e)
        {
            IsNum(textBox1);
            if (comboBoxPersonNumberAdressUp.Text == "" || comboBoxPersonCityAdressUp.Text == "" || textBoxPersonSreetAddressUp.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlCommand sqlprocedure = new SqlCommand();
                    sqlprocedure.Connection = connection;
                    sqlprocedure.CommandType = CommandType.StoredProcedure;
                    sqlprocedure.CommandText = "UpdatePersonAddress";
                    sqlprocedure.Parameters.AddWithValue("@PersonId", SqlDbType.Int).Value = comboBoxPersonNumberAdressUp.SelectedItem;
                    sqlprocedure.Parameters.Add("@City", SqlDbType.VarChar, 30).Value = comboBoxPersonCityAdressUp.SelectedItem.ToString();
                    sqlprocedure.Parameters.Add("@street", SqlDbType.VarChar, 30).Value = textBoxPersonSreetAddressUp.Text;
                    sqlprocedure.Parameters.Add("@Apart", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                    connection.Open();
                    sqlprocedure.ExecuteNonQuery();
                    MessageBox.Show("Данне успешно сохранены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGrid("ShowAddressPers", dataGridViewAddressPerson);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                    UpdateComboboxAdress();
                }
            }
        }
        private void buttonDeleteAddress_Click(object sender, EventArgs e)
        {
            DeleteMethod(textBox3, "AddressPers");
            UpdateComboboxAdress();
        }
        //*************************************************** Конец **************************************************************///

        public void NotInCombobox(string id2, string Table2, ComboBox cmb)
        {
            SqlCommand sqlcmdCombox = new SqlCommand("select id from Person where id not in (select " + id2 + " from " + Table2 + ") Order by id", connection);
            try
            {

                SqlDataReader dr = sqlcmdCombox.ExecuteReader();
                while (dr.Read())
                {
                    cmb.Items.Add(dr["id"]);
                }
                dr.Close();
                dr.Dispose();
                cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                Console.WriteLine("  Message: {0}", ex.Message);
            }
        }
        public void UpdateComboboxAdress()
        {
            comboBoxPersonNumberAdress.Items.Clear();
            comboBox6.Items.Clear();
            comboBoxPersonCityAdress.Items.Clear();
            comboBoxPersonNumberAdressUp.Items.Clear();
            comboBox7.Items.Clear();
            comboBoxPersonCityAdressUp.Items.Clear();
            textBoxPersonSreetAddress.Text = "";
            textBoxPersonSreetAddressUp.Text = "";
            textBoxPersonApartrAdress.Text = "";
            textBox1.Text = "";
            connection.Open();
            FillingComBoxMethod(comboBoxPersonCityAdress, "Name", "Cities", "Name");
            FillingComBoxMethod(comboBoxPersonCityAdressUp, "Name", "Cities", "Name");
            connection.Close();
            connection.Open();
            FillingComBoxMethodAdd(comboBoxPersonNumberAdress, "AddressPers");
            FillingComBoxNameNoInMethod(comboBox6, "Person", "AddressPers");
            FillingComBoxMethodIDUp(comboBoxPersonNumberAdressUp, "AddressPers");
            FillingComBoxNameMethodUpName(comboBox7, "AddressPers");
            connection.Close();

        }
        //**********************************************            Образование             ****************************************************************************
        private void buttonEducation_Click(object sender, EventArgs e)
        {
            if (comboBoxPersonNumberEd.Text == "" || comboBoxUniverEd.Text == "" || comboBoxFacEd.Text == "" || comboBoxCourse.Text == "" || comboBoxSpec.Text == "")
            {
                MessageBox.Show("Заполняйте все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlCommand sqlprocedure = new SqlCommand();
                    sqlprocedure.Connection = connection;
                    sqlprocedure.CommandType = CommandType.StoredProcedure;
                    sqlprocedure.CommandText = "AddForPersonEducation";
                    sqlprocedure.Parameters.AddWithValue("@PersonId", SqlDbType.Int).Value = comboBoxPersonNumberEd.SelectedItem;
                    sqlprocedure.Parameters.Add("@University", SqlDbType.VarChar, 30).Value = comboBoxUniverEd.SelectedItem.ToString();
                    sqlprocedure.Parameters.Add("@Fac", SqlDbType.VarChar, 30).Value = comboBoxFacEd.SelectedItem.ToString();
                    sqlprocedure.Parameters.Add("@Spec", SqlDbType.VarChar, 30).Value = comboBoxSpec.SelectedItem.ToString();
                    sqlprocedure.Parameters.Add("@course", SqlDbType.Int).Value = comboBoxCourse.SelectedItem;
                    connection.Open();
                    sqlprocedure.ExecuteNonQuery();
                    MessageBox.Show("Данне успешно добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGrid("ShowEducation", dataGridViewEducation); //ShowEducation
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                finally
                {
                    connection.Close();
                    UpdateEducation();
                }
            }
        }

        private void buttonEducationUP_Click(object sender, EventArgs e)
        {
            if (comboBoxPersonNumberEdUp.Text == "" || comboBoxUniverEdUp.Text == "" || comboBoxFacEdUp.Text == "" || comboBoxSpecUp.Text == "" || comboBoxCourseUp.Text == "")
            {
                MessageBox.Show("Заполняйте все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlCommand sqlprocedure = new SqlCommand();
                    sqlprocedure.Connection = connection;
                    sqlprocedure.CommandType = CommandType.StoredProcedure;
                    sqlprocedure.CommandText = "UpDateEducation";
                    sqlprocedure.Parameters.AddWithValue("@PersonId", SqlDbType.Int).Value = comboBoxPersonNumberEdUp.SelectedItem;
                    sqlprocedure.Parameters.Add("@University", SqlDbType.VarChar, 30).Value = comboBoxUniverEdUp.SelectedItem.ToString();
                    sqlprocedure.Parameters.Add("@Fac", SqlDbType.VarChar, 30).Value = comboBoxFacEdUp.SelectedItem.ToString();
                    sqlprocedure.Parameters.Add("@Spec", SqlDbType.VarChar, 30).Value = comboBoxSpecUp.SelectedItem.ToString();
                    sqlprocedure.Parameters.Add("@course", SqlDbType.Int).Value = comboBoxCourseUp.SelectedItem;
                    connection.Open();
                    sqlprocedure.ExecuteNonQuery();
                    MessageBox.Show("Данне успешно сохранены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGrid("ShowEducation", dataGridViewEducation); //ShowEducation
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                finally
                {
                    connection.Close();
                    UpdateEducation();
                }
            }
        }

        public void UpdateEducation()
        {
            comboBoxPersonNumberEd.Items.Clear();
            comboBox8.Items.Clear();
            comboBoxPersonNumberEdUp.Items.Clear();
            comboBox9.Items.Clear();
            comboBoxUniverEd.Items.Clear();
            comboBoxUniverEdUp.Items.Clear();
            comboBoxFacEd.Items.Clear();
            comboBoxFacEdUp.Items.Clear();
            comboBoxCourse.Items.Clear();
            comboBoxCourseUp.Items.Clear();
            comboBoxSpecUp.Items.Clear();
            comboBoxSpec.Items.Clear();
            connection.Open();
            //NotInCombobox("PersonId", "Education", comboBoxPersonNumberEd);
            FillingComBoxMethodAdd(comboBoxPersonNumberEd, "Education");
            //FillingComBoxMethod(comboBoxPersonNumberEdUp, "PersonId", "Education", "PersonId");
            //FillingComBoxMethodIDUp(comboBoxPersonNumberEdUp, "Education");
            FillingComBoxMethodIDUp(comboBoxPersonNumberEdUp, "Education");
            FillingComBoxNameNoInMethod(comboBox8, "Person", "Education"); // для добавление имени персоны
            FillingComBoxNameMethodUpName(comboBox9, "Education");
            FillingComBoxMethod(comboBoxUniverEd, "Name", "University", "Name");
            FillingComBoxMethod(comboBoxUniverEdUp, "Name", "University", "Name");
            FillingComBoxMethod(comboBoxFacEd, "Name", "Faculty", "Name");
            FillingComBoxMethod(comboBoxFacEdUp, "Name", "Faculty", "Name");
            FillingComBoxMethod(comboBoxSpec, "Name", "Specialty", "Name");
            FillingComBoxMethod(comboBoxSpecUp, "Name", "Specialty", "Name");
            CourseFill();
            connection.Close();
        }
        public void CourseFill()
        {
            for (int i = 1; i <= 5; i++) comboBoxCourseUp.Items.Add(i);
            for (int i = 1; i <= 5; i++) comboBoxCourse.Items.Add(i);
            comboBoxCourseUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        private void buttonDeleteEducation_Click(object sender, EventArgs e)
        {
            DeleteMethod(textBox4, "Education");
            UpdateEducation();
        }
        //**********************************************   КОНЕЦ   ****************************************************************************


        //************************************************  РВП   **************************************************************************
        private void buttonAddRVP_Click(object sender, EventArgs e)
        {
            if (comboBoxPersonNumPVP.Text == "") MessageBox.Show("Заполните все поля!");
            else if (!radioButtonRVPhas.Checked && !radioButtonRVPno.Checked) MessageBox.Show("Заполните все поля!");
            else
            {
               // SqlConnection con = new SqlConnection("Data Source=Ozar-PC\\SQLEXPRESS;Initial Catalog=Federal_Migration_Service;Integrated Security=True");
                try
                {
                    if (ReturnMethod(radioButtonRVPhas, radioButtonRVPno) == false)
                    {
                        dateTimePickerRvpFrom.Value = dt;
                        dateTimePickerRvpTo.Value = dt;
                    }
                    SqlCommand sqlprocedure = new SqlCommand();
                    sqlprocedure.Connection = connection;
                    sqlprocedure.CommandType = CommandType.StoredProcedure;
                    sqlprocedure.CommandText = "AddRVP";
                    sqlprocedure.Parameters.AddWithValue("@PersonId", SqlDbType.Int).Value = comboBoxPersonNumPVP.SelectedItem;
                    sqlprocedure.Parameters.Add("@HasOrNo", SqlDbType.Bit).Value = ReturnMethod(radioButtonRVPhas, radioButtonRVPno);
                    sqlprocedure.Parameters.Add("@ResepDate", SqlDbType.DateTime).Value = dateTimePickerRvpFrom.Value;
                    sqlprocedure.Parameters.Add("@Datadeayst", SqlDbType.DateTime).Value = dateTimePickerRvpTo.Value;
                    connection.Open();
                    sqlprocedure.ExecuteNonQuery();
                    MessageBox.Show("Данне успешно сохранены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGrid("ShowRVP", dataGridViewRVP); //ShowEducation
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                finally
                {
                    connection.Close();
                    UpdateRVP();
                }
            }
        }

        public void UpdateRVP()
        {
            comboBoxPersonNumPVP.Items.Clear();
            comboBox10.Items.Clear();
            comboBox11.Items.Clear();
            comboBoxPersonNumPVPUp.Items.Clear();
            connection.Open();
            FillingComBoxMethodAdd(comboBoxPersonNumPVP, "RVP"); 
            FillingComBoxMethodIDUp(comboBoxPersonNumPVPUp, "RVP");
            FillingComBoxNameMethodUpName(comboBox11, "RVP");
            FillingComBoxNameNoInMethod(comboBox10, "Person", "RVP");
            connection.Close();
        }

        private void buttonAddRVPUp_Click(object sender, EventArgs e)
        {
            if (comboBoxPersonNumPVPUp.Text == "") MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!radioButtonRVPhasUp.Checked && !radioButtonRVPnoUp.Checked) MessageBox.Show("Заполните все поля!");
            else
            {
                try
                {
                    if (ReturnMethod(radioButtonRVPhasUp, radioButtonRVPnoUp) == false)
                    {
                        dateTimePickerRvpFromUp.Value = dt;
                        dateTimePickerRvpToUp.Value = dt;
                    }
                    SqlCommand sqlprocedure = new SqlCommand();
                    sqlprocedure.Connection = connection;
                    sqlprocedure.CommandType = CommandType.StoredProcedure;
                    sqlprocedure.CommandText = "UpdateRVP";
                    sqlprocedure.Parameters.AddWithValue("@PersonId", SqlDbType.Int).Value = comboBoxPersonNumPVPUp.SelectedItem;
                    sqlprocedure.Parameters.Add("@HasOrNo", SqlDbType.Bit).Value = ReturnMethod(radioButtonRVPhasUp, radioButtonRVPnoUp);
                    sqlprocedure.Parameters.Add("@ResepDate", SqlDbType.DateTime).Value = dateTimePickerRvpFromUp.Value;
                    sqlprocedure.Parameters.Add("@Datadeayst", SqlDbType.DateTime).Value = dateTimePickerRvpToUp.Value;
                    connection.Open();
                    sqlprocedure.ExecuteNonQuery();
                    MessageBox.Show("Данне успешно сохранены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGrid("ShowRVP", dataGridViewRVP); //ShowEducation
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                finally
                {
                    connection.Close();
                    UpdateRVP();
                }
            }
        }

        private void buttonDeleteRVP_Click(object sender, EventArgs e)
        {
            DeleteMethod(textBox5, "RVP");
            UpdateRVP();
        }
        //************************************************  КОНЕЦ   **************************************************************************

        //************************************************  ВНЖ   **************************************************************************

        private void buttonAddVNJ_Click(object sender, EventArgs e)
        {
            if (comboBoxPersonNumVNJ.Text == "") MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!radioButtonVNJHas.Checked && !radioButtonVNJNo.Checked) MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //SqlConnection con = new SqlConnection("Data Source=Ozar-PC\\SQLEXPRESS;Initial Catalog=Federal_Migration_Service;Integrated Security=True");
                try
                {
                    if (ReturnMethod(radioButtonVNJHas, radioButtonVNJNo) == false)
                    {
                        dateTimePickVNJFrom.Value = dt;
                        dateTimePickVNJTo.Value = dt;
                    }
                    SqlCommand sqlprocedure = new SqlCommand();
                    sqlprocedure.Connection = connection;
                    sqlprocedure.CommandType = CommandType.StoredProcedure;
                    sqlprocedure.CommandText = "AddVNJ";
                    sqlprocedure.Parameters.AddWithValue("@PersonId", SqlDbType.Int).Value = comboBoxPersonNumVNJ.SelectedItem;
                    sqlprocedure.Parameters.Add("@HasOrNo", SqlDbType.Bit, 30).Value = ReturnMethod(radioButtonVNJHas, radioButtonVNJNo);
                    sqlprocedure.Parameters.Add("@ResepDate", SqlDbType.DateTime).Value = dateTimePickVNJFrom.Value;
                    sqlprocedure.Parameters.Add("@Datadeayst", SqlDbType.DateTime).Value = dateTimePickVNJTo.Value;
                    connection.Open();
                    sqlprocedure.ExecuteNonQuery();
                    MessageBox.Show("Данне успешно добавлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGrid("ShowVNJ", dataGridViewVNJ); //ShowEducation
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                finally
                {
                    connection.Close();
                    UpdateVNJ();
                }
            }
        }
//*****************************************
        public void UpdateVNJ()
        {
            comboBoxPersonNumVNJ.Items.Clear();
            comboBoxPersonNumVNJUp.Items.Clear();
            comboBox12.Items.Clear();
            comboBox13.Items.Clear();
            connection.Open();
            FillingComBoxNameNoInMethod(comboBox12, "Person", "VNJ");
            FillingComBoxNameMethodUpName(comboBox13, "VNJ");
            FillingComBoxMethodAdd(comboBoxPersonNumVNJ, "VNJ"); // для добавлении номер персоны 
            FillingComBoxMethodIDUp(comboBoxPersonNumVNJUp, "VNJ");
            connection.Close();
        }

        private void buttonAddVNJUp_Click(object sender, EventArgs e)
        {
            if (comboBoxPersonNumVNJUp.Text == "") MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!radioButtonVNJHasUp.Checked && !radioButtonVNJNoUp.Checked) MessageBox.Show("Заполните все поля!");
            else
            {
               // SqlConnection con = new SqlConnection("Data Source=Ozar-PC\\SQLEXPRESS;Initial Catalog=Federal_Migration_Service;Integrated Security=True");
                try
                {
                    if (ReturnMethod(radioButtonVNJHasUp, radioButtonVNJNoUp) == false)
                    {
                        dateTimePickVNJFromUp.Value = dt;
                        dateTimePickVNJToUp.Value = dt;
                    }
                    SqlCommand sqlprocedure = new SqlCommand();
                    sqlprocedure.Connection = connection;
                    sqlprocedure.CommandType = CommandType.StoredProcedure;
                    sqlprocedure.CommandText = "UpdateVNJ";
                    sqlprocedure.Parameters.AddWithValue("@PersonId", SqlDbType.Int).Value = comboBoxPersonNumVNJUp.SelectedItem;
                    sqlprocedure.Parameters.Add("@HasOrNo", SqlDbType.Bit, 30).Value = ReturnMethod(radioButtonVNJHasUp, radioButtonVNJNoUp);
                    sqlprocedure.Parameters.Add("@ResepDate", SqlDbType.DateTime).Value = dateTimePickVNJFromUp.Value;
                    sqlprocedure.Parameters.Add("@Datadeayst", SqlDbType.DateTime).Value = dateTimePickVNJToUp.Value;
                    connection.Open();
                    sqlprocedure.ExecuteNonQuery();
                    MessageBox.Show("Данне успешно сохранены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGrid("ShowVNJ", dataGridViewVNJ);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                finally
                {
                    connection.Close();
                    UpdateVNJ();
                }
            }
        }
        private void buttonVNJ_Click(object sender, EventArgs e)
        {
            DeleteMethod(textBox6, "VNJ");
            UpdateVNJ();
        }
        //*****************************************************************************************************************************************
        private void сменитьПользовательяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(5);
                Cursor.Current = Cursors.AppStarting;
            }
            form1.Show();
            this.Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void buttonDeletePerson_Click(object sender, EventArgs e)
        {
            connection.Open();
            DeletePerson();
            connection.Close();

        }
        public int DeletePerson()
        {

            int res = 0;
            int parsedValue;

            if (textBoxDelete.Text == "")
            {
                MessageBox.Show("Заполните поля!");
            }
            else if (!int.TryParse(textBoxDelete.Text, out parsedValue))
            {
                MessageBox.Show("Введите только цыфры!");
                return parsedValue;
            }
            else
            {
                DialogResult result = MessageBox.Show("Указанная персона будет удалена полностью из всей базы\n Продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SqlCommand slqcmddel = new SqlCommand("Delete From Person Where id =" + Convert.ToInt32(textBoxDelete.Text) + "", connection);
                    res += slqcmddel.ExecuteNonQuery();
                    connection.Close();
                    if (res == 0)
                    {
                        MessageBox.Show("Персона с таким номером не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Указанная персона успешно удалена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AllRefresh();
                    }
                }
            }
            return res;
        }


        public int DeletePersonFromFMS()
        {

            int res = 0;
            int parsedValue;

            if (textBox2.Text == "")
            {
                MessageBox.Show("Заполните поля!");
            }
            else if (!int.TryParse(textBox2.Text, out parsedValue))
            {
                MessageBox.Show("Введите только цыфры!");
                return parsedValue;
            }
            else
            {
                DialogResult result = MessageBox.Show("Указанная персона будет удалена полностью из всей базы\n Вы уверены?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connection.Open();
                    SqlCommand slqcmddel = new SqlCommand("Delete From FMS Where PersonId =" + Convert.ToInt32(textBox2.Text) + "", connection);
                    res += slqcmddel.ExecuteNonQuery();
                    connection.Close();
                    if (res == 0)
                    {
                        MessageBox.Show("Персона с таким номером не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Указанная персона успешно удалена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AllRefresh();
                    }
                }
            }
            return res;
        }

        public int DeleteMethod(TextBox texboxName, string TableName)
        {
            int res = 0;
            int parsedValue;

            if (texboxName.Text == "")
            {
                MessageBox.Show("Заполните поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(texboxName.Text, out parsedValue))
            {
                MessageBox.Show("Введите пожалуйста только цыфры!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                texboxName.Text = "";
                return parsedValue;
            }
            else
            {
                DialogResult result = MessageBox.Show("Указанная персона будет удалена только из этой таблицы\n Продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    connection.Open();
                    SqlCommand slqcmddel = new SqlCommand("Delete From " + TableName + " Where PersonId =" + Convert.ToInt32(texboxName.Text) + "", connection);
                    res += slqcmddel.ExecuteNonQuery();
                    connection.Close();
                    if (res == 0)
                    {
                        MessageBox.Show("Персона с таким номером не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        texboxName.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Указанная персона успешно удалена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AllRefresh();
                    }
                }
            }
            return res;
        }
        public int IsNum(TextBox texboxName)
        {
            int parsedValue;
            if (!int.TryParse(texboxName.Text, out parsedValue))
            {
                MessageBox.Show("Введите пожалуйста только целочисленные цыфры!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                texboxName.Text = "";
                return parsedValue;
            }
            else if (texboxName.Text == "")
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return parsedValue;
        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxUpdateFMS.Items.Clear();
            comboBox5.Items.Clear();
            connection.Open();
            FillingComBoxMethodIDUp(comboBoxUpdateFMS, "FMS");
            FillingComBoxNameMethodUpName(comboBox5, "FMS");
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Wait();
            SelectRegisPerson();
        }
        
        public void Wait()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(5);
                Cursor.Current = Cursors.AppStarting;
            }
        }

//**********************************************************************************************************************


        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Tables[1].PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 10;

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }
                //table style 
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                //header text
                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Федеральная Миграционная Служба";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    oDoc.PageSetup.PaperSize = Word.WdPaperSize.wdPaperA4;
                }
                //save the file
                oDoc.SaveAs(filename);

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveAs2 = new SaveFileDialog();
            SaveAs2.Filter = "WORD Documents (*.doc)|*.doc";
            if(SaveAs2.ShowDialog() == DialogResult.OK)
            Export_Data_To_Word(dataGridView1, SaveAs2.FileName);
        }
        public void SelectRegisPerson()
        {
            connection.Open();
            try
            {
                SqlDataAdapter sqldt = new SqlDataAdapter("Execute SelectRegisPerson '" + dateTimePicker2.Value + "', '"+dateTimePicker3.Value+"'", connection);
                DataTable dt = new DataTable();
                int res =  sqldt.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[6].Width = 110;
                if (res == 0)
                {
                    label80.Visible = false;
                    dataGridView1.Visible = false;
                    button3.Visible = false;
                    MessageBox.Show("По вашему запросу ничего не найдено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    label80.Visible = true;
                    label80.Text = "Рузультат: "+res+"";
                    dataGridView1.Visible = true;
                    button3.Visible = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox3.SelectedIndex;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxFMSAdd.SelectedIndex = comboBox4.SelectedIndex;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxUpdateFMS.SelectedIndex = comboBox5.SelectedIndex;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPersonNumberAdress.SelectedIndex = comboBox6.SelectedIndex;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPersonNumberAdressUp.SelectedIndex = comboBox7.SelectedIndex;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPersonNumberEd.SelectedIndex = comboBox8.SelectedIndex;
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPersonNumberEdUp.SelectedIndex = comboBox9.SelectedIndex;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPersonNumPVP.SelectedIndex = comboBox10.SelectedIndex;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPersonNumPVPUp.SelectedIndex = comboBox11.SelectedIndex;
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPersonNumVNJ.SelectedIndex = comboBox12.SelectedIndex;
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPersonNumVNJUp.SelectedIndex = comboBox13.SelectedIndex;
        }
     }
 }





