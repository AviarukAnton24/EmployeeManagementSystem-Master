namespace EmployeeManagementSystem
{
    partial class Salary
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Salary_ClearButton = new System.Windows.Forms.Button();
            this.Salary_UpdateButton = new System.Windows.Forms.Button();
            this.Salary_Salary = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Salary_Position = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Salary_FullName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Salary_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(242)))), ((int)(((byte)(90)))));
            this.panel1.Controls.Add(this.Salary_ClearButton);
            this.panel1.Controls.Add(this.Salary_UpdateButton);
            this.panel1.Controls.Add(this.Salary_Salary);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Salary_Position);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Salary_FullName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Salary_ID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 795);
            this.panel1.TabIndex = 0;
            // 
            // Salary_ClearButton
            // 
            this.Salary_ClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.Salary_ClearButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Salary_ClearButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Salary_ClearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Salary_ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Salary_ClearButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Salary_ClearButton.ForeColor = System.Drawing.Color.White;
            this.Salary_ClearButton.Location = new System.Drawing.Point(185, 549);
            this.Salary_ClearButton.Name = "Salary_ClearButton";
            this.Salary_ClearButton.Size = new System.Drawing.Size(146, 66);
            this.Salary_ClearButton.TabIndex = 23;
            this.Salary_ClearButton.Text = "CLEAR";
            this.Salary_ClearButton.UseVisualStyleBackColor = false;
            this.Salary_ClearButton.Click += new System.EventHandler(this.Salary_ClearButton_Click);
            // 
            // Salary_UpdateButton
            // 
            this.Salary_UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.Salary_UpdateButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Salary_UpdateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Salary_UpdateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.Salary_UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Salary_UpdateButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Salary_UpdateButton.ForeColor = System.Drawing.Color.White;
            this.Salary_UpdateButton.Location = new System.Drawing.Point(17, 549);
            this.Salary_UpdateButton.Name = "Salary_UpdateButton";
            this.Salary_UpdateButton.Size = new System.Drawing.Size(146, 66);
            this.Salary_UpdateButton.TabIndex = 21;
            this.Salary_UpdateButton.Text = "UPDATE";
            this.Salary_UpdateButton.UseVisualStyleBackColor = false;
            this.Salary_UpdateButton.Click += new System.EventHandler(this.Salary_UpdateButton_Click);
            // 
            // Salary_Salary
            // 
            this.Salary_Salary.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Salary_Salary.Location = new System.Drawing.Point(38, 449);
            this.Salary_Salary.Multiline = true;
            this.Salary_Salary.Name = "Salary_Salary";
            this.Salary_Salary.Size = new System.Drawing.Size(270, 35);
            this.Salary_Salary.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(32, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 32);
            this.label5.TabIndex = 6;
            this.label5.Text = "Salary:";
            // 
            // Salary_Position
            // 
            this.Salary_Position.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Salary_Position.Location = new System.Drawing.Point(38, 332);
            this.Salary_Position.Multiline = true;
            this.Salary_Position.Name = "Salary_Position";
            this.Salary_Position.Size = new System.Drawing.Size(270, 35);
            this.Salary_Position.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(32, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Position:";
            // 
            // Salary_FullName
            // 
            this.Salary_FullName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Salary_FullName.Location = new System.Drawing.Point(38, 214);
            this.Salary_FullName.Multiline = true;
            this.Salary_FullName.Name = "Salary_FullName";
            this.Salary_FullName.Size = new System.Drawing.Size(270, 35);
            this.Salary_FullName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(32, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Full Name:";
            // 
            // Salary_ID
            // 
            this.Salary_ID.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Salary_ID.Location = new System.Drawing.Point(38, 97);
            this.Salary_ID.Multiline = true;
            this.Salary_ID.Name = "Salary_ID";
            this.Salary_ID.Size = new System.Drawing.Size(270, 35);
            this.Salary_ID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(32, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Employee ID:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(242)))), ((int)(((byte)(90)))));
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(337, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(849, 795);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(34, 81);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(787, 634);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employees";
            // 
            // Salary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Salary";
            this.Size = new System.Drawing.Size(1186, 795);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Salary_ID;
        private System.Windows.Forms.TextBox Salary_Salary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Salary_Position;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Salary_FullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Salary_ClearButton;
        private System.Windows.Forms.Button Salary_UpdateButton;
    }
}
