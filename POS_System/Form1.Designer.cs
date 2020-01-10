namespace CashierApp
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
            this.companyTitle = new System.Windows.Forms.Label();
            this.aNameLbl = new System.Windows.Forms.Label();
            this.aPassLbl = new System.Windows.Forms.Label();
            this.aNameIn = new System.Windows.Forms.TextBox();
            this.aPassIn = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.creditLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // companyTitle
            // 
            this.companyTitle.AutoSize = true;
            this.companyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyTitle.Location = new System.Drawing.Point(350, 162);
            this.companyTitle.Name = "companyTitle";
            this.companyTitle.Size = new System.Drawing.Size(563, 91);
            this.companyTitle.TabIndex = 0;
            this.companyTitle.Text = "Company Title";
            // 
            // aNameLbl
            // 
            this.aNameLbl.AutoSize = true;
            this.aNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aNameLbl.Location = new System.Drawing.Point(209, 326);
            this.aNameLbl.Name = "aNameLbl";
            this.aNameLbl.Size = new System.Drawing.Size(250, 46);
            this.aNameLbl.TabIndex = 1;
            this.aNameLbl.Text = "Admin Name";
            // 
            // aPassLbl
            // 
            this.aPassLbl.AutoSize = true;
            this.aPassLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aPassLbl.Location = new System.Drawing.Point(209, 435);
            this.aPassLbl.Name = "aPassLbl";
            this.aPassLbl.Size = new System.Drawing.Size(320, 46);
            this.aPassLbl.TabIndex = 2;
            this.aPassLbl.Text = "Admin Password";
            // 
            // aNameIn
            // 
            this.aNameIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aNameIn.Location = new System.Drawing.Point(607, 331);
            this.aNameIn.Name = "aNameIn";
            this.aNameIn.Size = new System.Drawing.Size(306, 41);
            this.aNameIn.TabIndex = 3;
            // 
            // aPassIn
            // 
            this.aPassIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aPassIn.Location = new System.Drawing.Point(607, 440);
            this.aPassIn.Name = "aPassIn";
            this.aPassIn.Size = new System.Drawing.Size(306, 41);
            this.aPassIn.TabIndex = 4;
            this.aPassIn.UseSystemPasswordChar = true;
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(607, 541);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(305, 65);
            this.loginBtn.TabIndex = 5;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            // 
            // creditLbl
            // 
            this.creditLbl.AutoSize = true;
            this.creditLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditLbl.Location = new System.Drawing.Point(480, 858);
            this.creditLbl.Name = "creditLbl";
            this.creditLbl.Size = new System.Drawing.Size(432, 36);
            this.creditLbl.TabIndex = 6;
            this.creditLbl.Text = "Powered by Bucheeri Solutions";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1332, 903);
            this.Controls.Add(this.creditLbl);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.aPassIn);
            this.Controls.Add(this.aNameIn);
            this.Controls.Add(this.aPassLbl);
            this.Controls.Add(this.aNameLbl);
            this.Controls.Add(this.companyTitle);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label companyTitle;
        private System.Windows.Forms.Label aNameLbl;
        private System.Windows.Forms.Label aPassLbl;
        private System.Windows.Forms.TextBox aNameIn;
        private System.Windows.Forms.TextBox aPassIn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label creditLbl;
    }
}

