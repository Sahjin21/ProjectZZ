namespace ProjectZZ
{
    partial class CustomerAcct
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
            this.lstvwCustomerAccts = new System.Windows.Forms.ListView();
            this.acctType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.balance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAcctNumber = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbxMoney = new System.Windows.Forms.TextBox();
            this.cmbbxWithdrawDeposit = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.cmbbxType = new System.Windows.Forms.ComboBox();
            this.btnCreateAcct = new System.Windows.Forms.Button();
            this.groupBoxAccount = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnLogoff = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBoxAccount.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstvwCustomerAccts
            // 
            this.lstvwCustomerAccts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.acctType,
            this.balance});
            this.lstvwCustomerAccts.HideSelection = false;
            this.lstvwCustomerAccts.Location = new System.Drawing.Point(6, 24);
            this.lstvwCustomerAccts.Name = "lstvwCustomerAccts";
            this.lstvwCustomerAccts.Size = new System.Drawing.Size(165, 190);
            this.lstvwCustomerAccts.TabIndex = 0;
            this.lstvwCustomerAccts.UseCompatibleStateImageBehavior = false;
            this.lstvwCustomerAccts.View = System.Windows.Forms.View.Details;
            this.lstvwCustomerAccts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstvwCustomerAccts_MouseDoubleClick);
            // 
            // acctType
            // 
            this.acctType.Text = "Type";
            this.acctType.Width = 80;
            // 
            // balance
            // 
            this.balance.Text = "Balance";
            this.balance.Width = 80;
            // 
            // lblAcctNumber
            // 
            this.lblAcctNumber.AutoSize = true;
            this.lblAcctNumber.Location = new System.Drawing.Point(7, 16);
            this.lblAcctNumber.Name = "lblAcctNumber";
            this.lblAcctNumber.Size = new System.Drawing.Size(93, 13);
            this.lblAcctNumber.TabIndex = 2;
            this.lblAcctNumber.Text = "Account Number: ";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(7, 44);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 13);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Account Type: ";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(7, 71);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(67, 13);
            this.lblBalance.TabIndex = 4;
            this.lblBalance.Text = "Balance: 0.0";
            this.lblBalance.Click += new System.EventHandler(this.lblBalance_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Amount";
            // 
            // txtbxMoney
            // 
            this.txtbxMoney.Location = new System.Drawing.Point(93, 44);
            this.txtbxMoney.Name = "txtbxMoney";
            this.txtbxMoney.Size = new System.Drawing.Size(80, 20);
            this.txtbxMoney.TabIndex = 8;
            this.txtbxMoney.TextChanged += new System.EventHandler(this.txtbxMoney_TextChanged);
            // 
            // cmbbxWithdrawDeposit
            // 
            this.cmbbxWithdrawDeposit.FormattingEnabled = true;
            this.cmbbxWithdrawDeposit.Items.AddRange(new object[] {
            "Withdraw",
            "Deposit"});
            this.cmbbxWithdrawDeposit.Location = new System.Drawing.Point(11, 43);
            this.cmbbxWithdrawDeposit.Name = "cmbbxWithdrawDeposit";
            this.cmbbxWithdrawDeposit.Size = new System.Drawing.Size(76, 21);
            this.cmbbxWithdrawDeposit.TabIndex = 9;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(179, 45);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(32, 19);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cmbbxType
            // 
            this.cmbbxType.AutoCompleteCustomSource.AddRange(new string[] {
            "Savings",
            "Checking",
            "MMA"});
            this.cmbbxType.FormattingEnabled = true;
            this.cmbbxType.Items.AddRange(new object[] {
            "Savings",
            "Checking",
            "MMA"});
            this.cmbbxType.Location = new System.Drawing.Point(17, 29);
            this.cmbbxType.Name = "cmbbxType";
            this.cmbbxType.Size = new System.Drawing.Size(82, 21);
            this.cmbbxType.TabIndex = 11;
            // 
            // btnCreateAcct
            // 
            this.btnCreateAcct.Location = new System.Drawing.Point(117, 30);
            this.btnCreateAcct.Name = "btnCreateAcct";
            this.btnCreateAcct.Size = new System.Drawing.Size(62, 20);
            this.btnCreateAcct.TabIndex = 12;
            this.btnCreateAcct.Text = "Create";
            this.btnCreateAcct.UseVisualStyleBackColor = true;
            this.btnCreateAcct.Click += new System.EventHandler(this.btnCreateAcct_Click);
            // 
            // groupBoxAccount
            // 
            this.groupBoxAccount.Controls.Add(this.groupBox6);
            this.groupBoxAccount.Controls.Add(this.groupBox2);
            this.groupBoxAccount.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAccount.Name = "groupBoxAccount";
            this.groupBoxAccount.Size = new System.Drawing.Size(417, 118);
            this.groupBoxAccount.TabIndex = 13;
            this.groupBoxAccount.TabStop = false;
            this.groupBoxAccount.Text = "Account";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGo);
            this.groupBox2.Controls.Add(this.txtbxMoney);
            this.groupBox2.Controls.Add(this.cmbbxWithdrawDeposit);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(192, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 94);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deposit or Withdraw";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCreateAcct);
            this.groupBox3.Controls.Add(this.cmbbxType);
            this.groupBox3.Location = new System.Drawing.Point(232, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 59);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create Account";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstvwCustomerAccts);
            this.groupBox4.Location = new System.Drawing.Point(11, 136);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(182, 220);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Your Accounts";
            // 
            // btnLogoff
            // 
            this.btnLogoff.Location = new System.Drawing.Point(359, 324);
            this.btnLogoff.Name = "btnLogoff";
            this.btnLogoff.Size = new System.Drawing.Size(70, 26);
            this.btnLogoff.TabIndex = 17;
            this.btnLogoff.Text = "Logoff";
            this.btnLogoff.UseVisualStyleBackColor = true;
            this.btnLogoff.Click += new System.EventHandler(this.btnLogoff_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblID);
            this.groupBox5.Controls.Add(this.lblLastName);
            this.groupBox5.Controls.Add(this.lblFirstName);
            this.groupBox5.Location = new System.Drawing.Point(229, 136);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 100);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Customer";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(15, 24);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(63, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name: ";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(15, 48);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(64, 13);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name: ";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(15, 72);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 13);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "ID: ";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblAcctNumber);
            this.groupBox6.Controls.Add(this.lblType);
            this.groupBox6.Controls.Add(this.lblBalance);
            this.groupBox6.Location = new System.Drawing.Point(6, 18);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(180, 94);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Info";
            // 
            // CustomerAcct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 365);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnLogoff);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxAccount);
            this.Name = "CustomerAcct";
            this.Text = "CustomerAcct";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomerAcct_FormClosing);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CustomerAcct_MouseDoubleClick);
            this.groupBoxAccount.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstvwCustomerAccts;
        private System.Windows.Forms.ColumnHeader acctType;
        private System.Windows.Forms.ColumnHeader balance;
        private System.Windows.Forms.Label lblAcctNumber;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbxMoney;
        private System.Windows.Forms.ComboBox cmbbxWithdrawDeposit;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ComboBox cmbbxType;
        private System.Windows.Forms.Button btnCreateAcct;
        private System.Windows.Forms.GroupBox groupBoxAccount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLogoff;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}