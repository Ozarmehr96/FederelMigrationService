namespace ClientSQL
{
    partial class Operator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAllTS = new System.Windows.Forms.DataGridView();
            this.номерТСDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.пунктОтправленияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.пунктПрибытияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаОтправленияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ценаБилетаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.кондукторDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.водительDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.механикDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatorShow3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shipilovDataSet = new ClientSQL.ShipilovDataSet();
            this.showTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сменитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выводВWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTSTableAdapter = new ClientSQL.ShipilovDataSetTableAdapters.ShowTSTableAdapter();
            this.dataGridViewSearchTS = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.showPointBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.showPointBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.operatorShow3TableAdapter = new ClientSQL.ShipilovDataSetTableAdapters.operatorShow3TableAdapter();
            this.operatorSearch2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.operatorSearch2TableAdapter = new ClientSQL.ShipilovDataSetTableAdapters.operatorSearch2TableAdapter();
            this.showPointTableAdapter = new ClientSQL.ShipilovDataSetTableAdapters.ShowPointTableAdapter();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorShow3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipilovDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showTSBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchTS)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showPointBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPointBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorSearch2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridViewAllTS);
            this.groupBox1.Location = new System.Drawing.Point(13, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(856, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Рейсы:";
            // 
            // dataGridViewAllTS
            // 
            this.dataGridViewAllTS.AllowUserToAddRows = false;
            this.dataGridViewAllTS.AllowUserToDeleteRows = false;
            this.dataGridViewAllTS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAllTS.AutoGenerateColumns = false;
            this.dataGridViewAllTS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAllTS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllTS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерТСDataGridViewTextBoxColumn,
            this.пунктОтправленияDataGridViewTextBoxColumn,
            this.пунктПрибытияDataGridViewTextBoxColumn,
            this.датаОтправленияDataGridViewTextBoxColumn,
            this.ценаБилетаDataGridViewTextBoxColumn,
            this.кондукторDataGridViewTextBoxColumn,
            this.водительDataGridViewTextBoxColumn,
            this.механикDataGridViewTextBoxColumn1});
            this.dataGridViewAllTS.DataSource = this.operatorShow3BindingSource;
            this.dataGridViewAllTS.Location = new System.Drawing.Point(7, 19);
            this.dataGridViewAllTS.Name = "dataGridViewAllTS";
            this.dataGridViewAllTS.ReadOnly = true;
            this.dataGridViewAllTS.Size = new System.Drawing.Size(843, 152);
            this.dataGridViewAllTS.TabIndex = 0;
            // 
            // номерТСDataGridViewTextBoxColumn
            // 
            this.номерТСDataGridViewTextBoxColumn.DataPropertyName = "Номер ТС";
            this.номерТСDataGridViewTextBoxColumn.HeaderText = "Номер ТС";
            this.номерТСDataGridViewTextBoxColumn.Name = "номерТСDataGridViewTextBoxColumn";
            this.номерТСDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // пунктОтправленияDataGridViewTextBoxColumn
            // 
            this.пунктОтправленияDataGridViewTextBoxColumn.DataPropertyName = "Пункт отправления";
            this.пунктОтправленияDataGridViewTextBoxColumn.HeaderText = "Пункт отправления";
            this.пунктОтправленияDataGridViewTextBoxColumn.Name = "пунктОтправленияDataGridViewTextBoxColumn";
            this.пунктОтправленияDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // пунктПрибытияDataGridViewTextBoxColumn
            // 
            this.пунктПрибытияDataGridViewTextBoxColumn.DataPropertyName = "Пункт прибытия";
            this.пунктПрибытияDataGridViewTextBoxColumn.HeaderText = "Пункт прибытия";
            this.пунктПрибытияDataGridViewTextBoxColumn.Name = "пунктПрибытияDataGridViewTextBoxColumn";
            this.пунктПрибытияDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // датаОтправленияDataGridViewTextBoxColumn
            // 
            this.датаОтправленияDataGridViewTextBoxColumn.DataPropertyName = "Дата отправления";
            this.датаОтправленияDataGridViewTextBoxColumn.HeaderText = "Дата отправления";
            this.датаОтправленияDataGridViewTextBoxColumn.Name = "датаОтправленияDataGridViewTextBoxColumn";
            this.датаОтправленияDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ценаБилетаDataGridViewTextBoxColumn
            // 
            this.ценаБилетаDataGridViewTextBoxColumn.DataPropertyName = "Цена билета";
            this.ценаБилетаDataGridViewTextBoxColumn.HeaderText = "Цена билета";
            this.ценаБилетаDataGridViewTextBoxColumn.Name = "ценаБилетаDataGridViewTextBoxColumn";
            this.ценаБилетаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // кондукторDataGridViewTextBoxColumn
            // 
            this.кондукторDataGridViewTextBoxColumn.DataPropertyName = "Кондуктор";
            this.кондукторDataGridViewTextBoxColumn.HeaderText = "Кондуктор";
            this.кондукторDataGridViewTextBoxColumn.Name = "кондукторDataGridViewTextBoxColumn";
            this.кондукторDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // водительDataGridViewTextBoxColumn
            // 
            this.водительDataGridViewTextBoxColumn.DataPropertyName = "Водитель";
            this.водительDataGridViewTextBoxColumn.HeaderText = "Водитель";
            this.водительDataGridViewTextBoxColumn.Name = "водительDataGridViewTextBoxColumn";
            this.водительDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // механикDataGridViewTextBoxColumn1
            // 
            this.механикDataGridViewTextBoxColumn1.DataPropertyName = "Механик";
            this.механикDataGridViewTextBoxColumn1.HeaderText = "Механик";
            this.механикDataGridViewTextBoxColumn1.Name = "механикDataGridViewTextBoxColumn1";
            this.механикDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // operatorShow3BindingSource
            // 
            this.operatorShow3BindingSource.DataMember = "operatorShow3";
            this.operatorShow3BindingSource.DataSource = this.shipilovDataSet;
            // 
            // shipilovDataSet
            // 
            this.shipilovDataSet.DataSetName = "ShipilovDataSet";
            this.shipilovDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // showTSBindingSource
            // 
            this.showTSBindingSource.DataMember = "ShowTS";
            this.showTSBindingSource.DataSource = this.shipilovDataSet;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сменитьПользователяToolStripMenuItem,
            this.выводВWordToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сменитьПользователяToolStripMenuItem
            // 
            this.сменитьПользователяToolStripMenuItem.Name = "сменитьПользователяToolStripMenuItem";
            this.сменитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.сменитьПользователяToolStripMenuItem.Text = "Сменить пользователя";
            this.сменитьПользователяToolStripMenuItem.Click += new System.EventHandler(this.сменитьПользователяToolStripMenuItem_Click);
            // 
            // выводВWordToolStripMenuItem
            // 
            this.выводВWordToolStripMenuItem.Name = "выводВWordToolStripMenuItem";
            this.выводВWordToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.выводВWordToolStripMenuItem.Text = "Вывод в Word";
            this.выводВWordToolStripMenuItem.Click += new System.EventHandler(this.выводВWordToolStripMenuItem_Click);
            // 
            // showTSTableAdapter
            // 
            this.showTSTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewSearchTS
            // 
            this.dataGridViewSearchTS.AllowUserToAddRows = false;
            this.dataGridViewSearchTS.AllowUserToDeleteRows = false;
            this.dataGridViewSearchTS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSearchTS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSearchTS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchTS.Location = new System.Drawing.Point(7, 63);
            this.dataGridViewSearchTS.Name = "dataGridViewSearchTS";
            this.dataGridViewSearchTS.ReadOnly = true;
            this.dataGridViewSearchTS.Size = new System.Drawing.Size(843, 132);
            this.dataGridViewSearchTS.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "По номеру ТС:";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(647, 31);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.showTSBindingSource;
            this.comboBox1.DisplayMember = "Номер ТС";
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(27, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.ValueMember = "Номер ТС";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.buttonSearch);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dataGridViewSearchTS);
            this.groupBox2.Location = new System.Drawing.Point(13, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(856, 201);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поиск:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(430, 33);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(196, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.showPointBindingSource1;
            this.comboBox3.DisplayMember = "Название";
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(282, 34);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 6;
            this.comboBox3.ValueMember = "Код";
            // 
            // showPointBindingSource1
            // 
            this.showPointBindingSource1.DataMember = "ShowPoint";
            this.showPointBindingSource1.DataSource = this.shipilovDataSet;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.showPointBindingSource;
            this.comboBox2.DisplayMember = "Название";
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(155, 34);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.ValueMember = "Код";
            // 
            // showPointBindingSource
            // 
            this.showPointBindingSource.DataMember = "ShowPoint";
            this.showPointBindingSource.DataSource = this.shipilovDataSet;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(409, 36);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(134, 37);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "По дате:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Пункт прибытия:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пункт отправления:";
            // 
            // operatorShow3TableAdapter
            // 
            this.operatorShow3TableAdapter.ClearBeforeFill = true;
            // 
            // operatorSearch2BindingSource
            // 
            this.operatorSearch2BindingSource.DataMember = "operatorSearch2";
            this.operatorSearch2BindingSource.DataSource = this.shipilovDataSet;
            // 
            // operatorSearch2TableAdapter
            // 
            this.operatorSearch2TableAdapter.ClearBeforeFill = true;
            // 
            // showPointTableAdapter
            // 
            this.showPointTableAdapter.ClearBeforeFill = true;
            // 
            // Operator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 423);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Operator";
            this.Text = "Operator";
            this.Load += new System.EventHandler(this.Operator_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorShow3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipilovDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showTSBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchTS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showPointBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPointBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorSearch2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewAllTS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сменитьПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выводВWordToolStripMenuItem;
        private ShipilovDataSet shipilovDataSet;
        private System.Windows.Forms.BindingSource showTSBindingSource;
        private ShipilovDataSetTableAdapters.ShowTSTableAdapter showTSTableAdapter;
        private System.Windows.Forms.DataGridView dataGridViewSearchTS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource operatorShow3BindingSource;
        private ShipilovDataSetTableAdapters.operatorShow3TableAdapter operatorShow3TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерТСDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn пунктОтправленияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn пунктПрибытияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаОтправленияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ценаБилетаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn кондукторDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn водительDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn механикDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource operatorSearch2BindingSource;
        private ShipilovDataSetTableAdapters.operatorSearch2TableAdapter operatorSearch2TableAdapter;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource showPointBindingSource;
        private ShipilovDataSetTableAdapters.ShowPointTableAdapter showPointTableAdapter;
        private System.Windows.Forms.BindingSource showPointBindingSource1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}