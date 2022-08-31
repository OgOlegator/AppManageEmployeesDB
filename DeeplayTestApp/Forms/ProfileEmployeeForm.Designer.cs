
namespace DeeplayTestApp.Forms
{
    partial class ProfileEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileEmployeeForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxJobTitle = new System.Windows.Forms.TextBox();
            this.textBoxSubDivision = new System.Windows.Forms.TextBox();
            this.textBoxBirthday = new System.Windows.Forms.TextBox();
            this.textBoxAdditionalInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PromoteButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSalary = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 212);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(430, 24);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(358, 27);
            this.textBoxName.TabIndex = 6;
            // 
            // textBoxJobTitle
            // 
            this.textBoxJobTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxJobTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxJobTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxJobTitle.Location = new System.Drawing.Point(430, 115);
            this.textBoxJobTitle.Name = "textBoxJobTitle";
            this.textBoxJobTitle.ReadOnly = true;
            this.textBoxJobTitle.Size = new System.Drawing.Size(358, 27);
            this.textBoxJobTitle.TabIndex = 7;
            // 
            // textBoxSubDivision
            // 
            this.textBoxSubDivision.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxSubDivision.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSubDivision.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSubDivision.Location = new System.Drawing.Point(430, 165);
            this.textBoxSubDivision.Name = "textBoxSubDivision";
            this.textBoxSubDivision.ReadOnly = true;
            this.textBoxSubDivision.Size = new System.Drawing.Size(367, 27);
            this.textBoxSubDivision.TabIndex = 8;
            // 
            // textBoxBirthday
            // 
            this.textBoxBirthday.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxBirthday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxBirthday.Location = new System.Drawing.Point(430, 64);
            this.textBoxBirthday.Name = "textBoxBirthday";
            this.textBoxBirthday.ReadOnly = true;
            this.textBoxBirthday.Size = new System.Drawing.Size(358, 27);
            this.textBoxBirthday.TabIndex = 9;
            // 
            // textBoxAdditionalInfo
            // 
            this.textBoxAdditionalInfo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxAdditionalInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAdditionalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAdditionalInfo.Location = new System.Drawing.Point(430, 209);
            this.textBoxAdditionalInfo.Name = "textBoxAdditionalInfo";
            this.textBoxAdditionalInfo.ReadOnly = true;
            this.textBoxAdditionalInfo.Size = new System.Drawing.Size(367, 27);
            this.textBoxAdditionalInfo.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(197, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Оклад:";
            // 
            // PromoteButton
            // 
            this.PromoteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PromoteButton.Location = new System.Drawing.Point(472, 401);
            this.PromoteButton.Name = "PromoteButton";
            this.PromoteButton.Size = new System.Drawing.Size(316, 37);
            this.PromoteButton.TabIndex = 13;
            this.PromoteButton.Text = "Повысить сотрудника";
            this.PromoteButton.UseVisualStyleBackColor = true;
            this.PromoteButton.Click += new System.EventHandler(this.PromoteButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(197, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "ФИО:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(197, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 29);
            this.label3.TabIndex = 15;
            this.label3.Text = "Дата рождения:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(197, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 29);
            this.label4.TabIndex = 16;
            this.label4.Text = "Должность:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(197, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 29);
            this.label5.TabIndex = 17;
            this.label5.Text = "Подразделение:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(197, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 29);
            this.label6.TabIndex = 18;
            this.label6.Text = "Доп. информация:";
            // 
            // textBoxSalary
            // 
            this.textBoxSalary.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxSalary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSalary.Location = new System.Drawing.Point(430, 254);
            this.textBoxSalary.Name = "textBoxSalary";
            this.textBoxSalary.ReadOnly = true;
            this.textBoxSalary.Size = new System.Drawing.Size(358, 27);
            this.textBoxSalary.TabIndex = 19;
            // 
            // ProfileEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxSalary);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PromoteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAdditionalInfo);
            this.Controls.Add(this.textBoxBirthday);
            this.Controls.Add(this.textBoxSubDivision);
            this.Controls.Add(this.textBoxJobTitle);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProfileEmployeeForm";
            this.Text = "Профиль сотрудника";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxJobTitle;
        private System.Windows.Forms.TextBox textBoxSubDivision;
        private System.Windows.Forms.TextBox textBoxBirthday;
        private System.Windows.Forms.TextBox textBoxAdditionalInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PromoteButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSalary;
    }
}