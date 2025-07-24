namespace FootballStats
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.ComboBox cmbTeam1;
        private System.Windows.Forms.ComboBox cmbTeam2;
        private System.Windows.Forms.TextBox txtScore1;
        private System.Windows.Forms.TextBox txtScore2;
        private System.Windows.Forms.Button btnAddMatch;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.DataGridView dgvTable;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.cmbTeam1 = new System.Windows.Forms.ComboBox();
            this.cmbTeam2 = new System.Windows.Forms.ComboBox();
            this.txtScore1 = new System.Windows.Forms.TextBox();
            this.txtScore2 = new System.Windows.Forms.TextBox();
            this.btnAddMatch = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.btnSaveTable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbViewMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRemoveMatch = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Location = new System.Drawing.Point(373, 17);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(120, 30);
            this.btnLoadExcel.TabIndex = 0;
            this.btnLoadExcel.Text = "Загрузить таблицу";
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // cmbTeam1
            // 
            this.cmbTeam1.Location = new System.Drawing.Point(22, 35);
            this.cmbTeam1.Name = "cmbTeam1";
            this.cmbTeam1.Size = new System.Drawing.Size(120, 21);
            this.cmbTeam1.TabIndex = 1;
            // 
            // cmbTeam2
            // 
            this.cmbTeam2.Location = new System.Drawing.Point(233, 35);
            this.cmbTeam2.Name = "cmbTeam2";
            this.cmbTeam2.Size = new System.Drawing.Size(120, 21);
            this.cmbTeam2.TabIndex = 2;
            // 
            // txtScore1
            // 
            this.txtScore1.Location = new System.Drawing.Point(56, 81);
            this.txtScore1.Name = "txtScore1";
            this.txtScore1.Size = new System.Drawing.Size(58, 20);
            this.txtScore1.TabIndex = 3;
            // 
            // txtScore2
            // 
            this.txtScore2.Location = new System.Drawing.Point(265, 81);
            this.txtScore2.Name = "txtScore2";
            this.txtScore2.Size = new System.Drawing.Size(58, 20);
            this.txtScore2.TabIndex = 4;
            // 
            // btnAddMatch
            // 
            this.btnAddMatch.Location = new System.Drawing.Point(148, 61);
            this.btnAddMatch.Name = "btnAddMatch";
            this.btnAddMatch.Size = new System.Drawing.Size(79, 40);
            this.btnAddMatch.TabIndex = 5;
            this.btnAddMatch.Text = "Добавить матч";
            this.btnAddMatch.Click += new System.EventHandler(this.btnAddMatch_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(373, 48);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(120, 30);
            this.btnSort.TabIndex = 6;
            this.btnSort.Text = "Сортировать";
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.AllowUserToDeleteRows = false;
            this.dgvTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTable.Location = new System.Drawing.Point(12, 119);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.ReadOnly = true;
            this.dgvTable.Size = new System.Drawing.Size(760, 429);
            this.dgvTable.TabIndex = 7;
            // 
            // btnSaveTable
            // 
            this.btnSaveTable.Location = new System.Drawing.Point(373, 81);
            this.btnSaveTable.Name = "btnSaveTable";
            this.btnSaveTable.Size = new System.Drawing.Size(120, 29);
            this.btnSaveTable.TabIndex = 8;
            this.btnSaveTable.Text = "Сохранить";
            this.btnSaveTable.UseVisualStyleBackColor = true;
            this.btnSaveTable.Click += new System.EventHandler(this.btnSaveTable_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Команда 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Команда 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Голы 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Голы 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Benzin-Semibold", 12.25F);
            this.label5.Location = new System.Drawing.Point(626, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 48);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tournament \r\nagregator";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbViewMode
            // 
            this.cmbViewMode.FormattingEnabled = true;
            this.cmbViewMode.Location = new System.Drawing.Point(642, 26);
            this.cmbViewMode.Name = "cmbViewMode";
            this.cmbViewMode.Size = new System.Drawing.Size(121, 21);
            this.cmbViewMode.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(670, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(661, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Лист таблицы";
            // 
            // btnRemoveMatch
            // 
            this.btnRemoveMatch.Location = new System.Drawing.Point(148, 17);
            this.btnRemoveMatch.Name = "btnRemoveMatch";
            this.btnRemoveMatch.Size = new System.Drawing.Size(79, 39);
            this.btnRemoveMatch.TabIndex = 18;
            this.btnRemoveMatch.Text = "Удалить матч";
            this.btnRemoveMatch.Click += new System.EventHandler(this.btnRemoveMatch_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(663, 554);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(109, 23);
            this.btnAbout.TabIndex = 19;
            this.btnAbout.Text = "О программе";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(276, 560);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(97, 13);
            this.labelStatus.TabIndex = 20;
            this.labelStatus.Text = "С возвращением!";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FootballStats.Properties.Resources.logo;
            this.pictureBox1.InitialImage = global::FootballStats.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(520, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 582);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnRemoveMatch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbViewMode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveTable);
            this.Controls.Add(this.btnLoadExcel);
            this.Controls.Add(this.cmbTeam1);
            this.Controls.Add(this.cmbTeam2);
            this.Controls.Add(this.txtScore1);
            this.Controls.Add(this.txtScore2);
            this.Controls.Add(this.btnAddMatch);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.dgvTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Tournament agregator 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnSaveTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbViewMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRemoveMatch;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label labelStatus;
    }
}