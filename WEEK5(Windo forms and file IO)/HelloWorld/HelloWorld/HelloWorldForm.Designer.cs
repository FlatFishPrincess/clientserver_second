namespace HelloWorld
{
    partial class HelloWorldFormOther
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
        private void InitializeComponent() // this function is called in HelloWorldForm.cs
        {
            this.myLb = new System.Windows.Forms.Label();
            this.outputLb = new System.Windows.Forms.Label();
            this.clickBtn = new System.Windows.Forms.Button();
            this.againBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myLb
            // 
            this.myLb.AutoSize = true;
            this.myLb.Location = new System.Drawing.Point(88, 70);
            this.myLb.Name = "myLb";
            this.myLb.Size = new System.Drawing.Size(45, 13);
            this.myLb.TabIndex = 0;
            this.myLb.Text = "My Text";
            // 
            // outputLb
            // 
            this.outputLb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputLb.Location = new System.Drawing.Point(88, 116);
            this.outputLb.Name = "outputLb";
            this.outputLb.Size = new System.Drawing.Size(100, 23);
            this.outputLb.TabIndex = 1;
            this.outputLb.Text = "label1";
            // 
            // clickBtn
            // 
            this.clickBtn.Location = new System.Drawing.Point(91, 177);
            this.clickBtn.Name = "clickBtn";
            this.clickBtn.Size = new System.Drawing.Size(75, 23);
            this.clickBtn.TabIndex = 2;
            this.clickBtn.Text = "Click Me";
            this.clickBtn.UseVisualStyleBackColor = true;
            // 
            // againBtn
            // 
            this.againBtn.Location = new System.Drawing.Point(91, 236);
            this.againBtn.Name = "againBtn";
            this.againBtn.Size = new System.Drawing.Size(134, 23);
            this.againBtn.TabIndex = 3;
            this.againBtn.Text = "Click Me Again";
            this.againBtn.UseVisualStyleBackColor = true;
            // 
            // HelloWorldFormOther
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 437);
            this.Controls.Add(this.againBtn);
            this.Controls.Add(this.clickBtn);
            this.Controls.Add(this.outputLb);
            this.Controls.Add(this.myLb);
            this.Name = "HelloWorldFormOther";
            this.Text = "Hello World";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label myLb;
        private System.Windows.Forms.Label outputLb;
        private System.Windows.Forms.Button clickBtn;
        private System.Windows.Forms.Button againBtn;
    }
}

