namespace StudentRegistration
{
    partial class Form1
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
            this.dataGridViewStudent = new System.Windows.Forms.DataGridView();
            this.dataGridViewCourse = new System.Windows.Forms.DataGridView();
            this.dataGridViewRegistration = new System.Windows.Forms.DataGridView();
            this.firstNameTxt = new System.Windows.Forms.TextBox();
            this.lastNameTxt = new System.Windows.Forms.TextBox();
            this.addStudentBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DepartmentList = new System.Windows.Forms.ListBox();
            this.updateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistration)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStudent
            // 
            this.dataGridViewStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudent.Location = new System.Drawing.Point(69, 69);
            this.dataGridViewStudent.Name = "dataGridViewStudent";
            this.dataGridViewStudent.Size = new System.Drawing.Size(388, 167);
            this.dataGridViewStudent.TabIndex = 0;
            // 
            // dataGridViewCourse
            // 
            this.dataGridViewCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCourse.Location = new System.Drawing.Point(481, 69);
            this.dataGridViewCourse.Name = "dataGridViewCourse";
            this.dataGridViewCourse.Size = new System.Drawing.Size(422, 167);
            this.dataGridViewCourse.TabIndex = 1;
            // 
            // dataGridViewRegistration
            // 
            this.dataGridViewRegistration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegistration.Location = new System.Drawing.Point(358, 331);
            this.dataGridViewRegistration.Name = "dataGridViewRegistration";
            this.dataGridViewRegistration.Size = new System.Drawing.Size(522, 167);
            this.dataGridViewRegistration.TabIndex = 2;
            // 
            // firstNameTxt
            // 
            this.firstNameTxt.Location = new System.Drawing.Point(144, 292);
            this.firstNameTxt.Name = "firstNameTxt";
            this.firstNameTxt.Size = new System.Drawing.Size(100, 20);
            this.firstNameTxt.TabIndex = 3;
            // 
            // lastNameTxt
            // 
            this.lastNameTxt.Location = new System.Drawing.Point(144, 318);
            this.lastNameTxt.Name = "lastNameTxt";
            this.lastNameTxt.Size = new System.Drawing.Size(100, 20);
            this.lastNameTxt.TabIndex = 4;
            // 
            // addStudentBtn
            // 
            this.addStudentBtn.Location = new System.Drawing.Point(36, 477);
            this.addStudentBtn.Name = "addStudentBtn";
            this.addStudentBtn.Size = new System.Drawing.Size(128, 21);
            this.addStudentBtn.TabIndex = 7;
            this.addStudentBtn.Text = "Add Student";
            this.addStudentBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "FirstName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "LastName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Department";
            // 
            // DepartmentList
            // 
            this.DepartmentList.FormattingEnabled = true;
            this.DepartmentList.Location = new System.Drawing.Point(144, 351);
            this.DepartmentList.Name = "DepartmentList";
            this.DepartmentList.Size = new System.Drawing.Size(120, 95);
            this.DepartmentList.TabIndex = 12;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(208, 477);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(128, 21);
            this.updateBtn.TabIndex = 13;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 560);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.DepartmentList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addStudentBtn);
            this.Controls.Add(this.lastNameTxt);
            this.Controls.Add(this.firstNameTxt);
            this.Controls.Add(this.dataGridViewRegistration);
            this.Controls.Add(this.dataGridViewCourse);
            this.Controls.Add(this.dataGridViewStudent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStudent;
        private System.Windows.Forms.DataGridView dataGridViewCourse;
        private System.Windows.Forms.DataGridView dataGridViewRegistration;
        private System.Windows.Forms.TextBox firstNameTxt;
        private System.Windows.Forms.TextBox lastNameTxt;
        private System.Windows.Forms.Button addStudentBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox DepartmentList;
        private System.Windows.Forms.Button updateBtn;
    }
}

