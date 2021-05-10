namespace PostgreKurs
{
    partial class auto_personel
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
            this.textID = new System.Windows.Forms.TextBox();
            this.textLastName = new System.Windows.Forms.TextBox();
            this.textPatherName = new System.Windows.Forms.TextBox();
            this.textFistName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dvgData = new System.Windows.Forms.DataGridView();
            this.btnInsert = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgData)).BeginInit();
            this.SuspendLayout();
            // 
            // textID
            // 
            this.textID.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textID.Location = new System.Drawing.Point(584, 109);
            this.textID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(106, 20);
            this.textID.TabIndex = 0;
            // 
            // textLastName
            // 
            this.textLastName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textLastName.Location = new System.Drawing.Point(584, 189);
            this.textLastName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textLastName.Name = "textLastName";
            this.textLastName.Size = new System.Drawing.Size(106, 20);
            this.textLastName.TabIndex = 1;
            // 
            // textPatherName
            // 
            this.textPatherName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textPatherName.Location = new System.Drawing.Point(584, 240);
            this.textPatherName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textPatherName.Name = "textPatherName";
            this.textPatherName.Size = new System.Drawing.Size(106, 20);
            this.textPatherName.TabIndex = 2;
            // 
            // textFistName
            // 
            this.textFistName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textFistName.Location = new System.Drawing.Point(584, 146);
            this.textFistName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textFistName.Name = "textFistName";
            this.textFistName.Size = new System.Drawing.Size(106, 20);
            this.textFistName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(440, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(440, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(439, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "Фамилия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(440, 235);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Отчество";
            // 
            // dvgData
            // 
            this.dvgData.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dvgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgData.Location = new System.Drawing.Point(16, 91);
            this.dvgData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dvgData.Name = "dvgData";
            this.dvgData.RowHeadersWidth = 51;
            this.dvgData.RowTemplate.Height = 24;
            this.dvgData.Size = new System.Drawing.Size(419, 238);
            this.dvgData.TabIndex = 8;
            this.dvgData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgData_CellClick);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInsert.Location = new System.Drawing.Point(462, 10);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(143, 66);
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Text = "Добавить";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(283, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 66);
            this.button2.TabIndex = 10;
            this.button2.Text = "Изменить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(609, 12);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 64);
            this.button3.TabIndex = 11;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelect.Location = new System.Drawing.Point(478, 285);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(173, 60);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.Text = "Обновить";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Crimson;
            this.label5.Location = new System.Drawing.Point(30, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 39);
            this.label5.TabIndex = 13;
            this.label5.Text = "Владельцы авто";
            // 
            // auto_personel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(724, 353);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.dvgData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textFistName);
            this.Controls.Add(this.textPatherName);
            this.Controls.Add(this.textLastName);
            this.Controls.Add(this.textID);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "auto_personel";
            this.Text = "auto_personel";
            this.Load += new System.EventHandler(this.auto_personel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.TextBox textLastName;
        private System.Windows.Forms.TextBox textPatherName;
        private System.Windows.Forms.TextBox textFistName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dvgData;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label5;
    }
}