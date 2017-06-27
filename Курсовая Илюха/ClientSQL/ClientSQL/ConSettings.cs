using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ClientSQL
{
    public partial class ConSettings : Form
    {
        

        Login login;
        static XDocument xDoc = new XDocument();
        static string xmlUri = @"ClientSQL.exe.config";
        public ConSettings(Login login)
        {
            InitializeComponent();
            this.login = login;
            xDoc = XDocument.Load(xmlUri);
        }

        public ConSettings()
        {
            InitializeComponent();
        }

        private void ConSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] str = new string[3];
            str[0] = textBox1.Text;
            str[1] = textBox2.Text;
            str[2] = checkBox1.Checked.ToString();
            string xml = "";
            System.IO.File.WriteAllLines(@"settings.txt", str);
            System.IO.File.WriteAllText(@"ClientSQL.exe.config", xml);
            string connectionString = @"Data Source=" + textBox1.Text + "; Initial Catalog=" + textBox2.Text + ";Integrated Security=" + checkBox1.Checked.ToString();
            xDoc.Descendants("configuration").Descendants("connectionStrings").Descendants("add").First().Attribute("connectionString").Value = connectionString;
            xDoc.Save(xmlUri);
            Application.Restart();
        }

        private void ConSettings_Load(object sender, EventArgs e)
        {
            this.Text = "Настройка соединения";
                try
                {
                    string[] str = System.IO.File.ReadAllLines(@"settings.txt");
                    textBox1.Text = str[0];
                    textBox2.Text = str[1];
                    if (str[2] == "True") checkBox1.Checked = true;
                    else checkBox1.Checked = false;

                }
                catch
                {
                }
        }
    }
}
