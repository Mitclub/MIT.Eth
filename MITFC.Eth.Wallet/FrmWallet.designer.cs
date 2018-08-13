namespace MIT.Eth.Wallet
{
    partial class FrmWallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWallet));
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.lblAccount = new System.Windows.Forms.Label();
            this.btnCopyAccount = new System.Windows.Forms.Button();
            this.lblEtherName = new System.Windows.Forms.Label();
            this.lblMITName = new System.Windows.Forms.Label();
            this.lblBalanceEther = new System.Windows.Forms.Label();
            this.lblBalanceMIT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLocked = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.rdoEther = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoMIT = new System.Windows.Forms.RadioButton();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.bgwkUpdate = new System.ComponentModel.BackgroundWorker();
            this.timUpdate = new System.Windows.Forms.Timer(this.components);
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(13, 12);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(62, 30);
            this.btnAddAccount.TabIndex = 4;
            this.btnAddAccount.Text = "Account";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(82, 21);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(18, 13);
            this.lblAccount.TabIndex = 5;
            this.lblAccount.Text = "0x";
            // 
            // btnCopyAccount
            // 
            this.btnCopyAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyAccount.Location = new System.Drawing.Point(583, 12);
            this.btnCopyAccount.Name = "btnCopyAccount";
            this.btnCopyAccount.Size = new System.Drawing.Size(75, 30);
            this.btnCopyAccount.TabIndex = 6;
            this.btnCopyAccount.Text = "Copy";
            this.btnCopyAccount.UseVisualStyleBackColor = true;
            this.btnCopyAccount.Click += new System.EventHandler(this.btnCopyAccount_Click);
            // 
            // lblEtherName
            // 
            this.lblEtherName.AutoSize = true;
            this.lblEtherName.Location = new System.Drawing.Point(40, 53);
            this.lblEtherName.Name = "lblEtherName";
            this.lblEtherName.Size = new System.Drawing.Size(35, 13);
            this.lblEtherName.TabIndex = 5;
            this.lblEtherName.Text = "Ether:";
            // 
            // lblMITName
            // 
            this.lblMITName.AutoSize = true;
            this.lblMITName.Location = new System.Drawing.Point(284, 53);
            this.lblMITName.Name = "lblMITName";
            this.lblMITName.Size = new System.Drawing.Size(42, 13);
            this.lblMITName.TabIndex = 5;
            this.lblMITName.Text = "MIT:";
            // 
            // lblBalanceEther
            // 
            this.lblBalanceEther.AutoSize = true;
            this.lblBalanceEther.Location = new System.Drawing.Point(82, 53);
            this.lblBalanceEther.Name = "lblBalanceEther";
            this.lblBalanceEther.Size = new System.Drawing.Size(13, 13);
            this.lblBalanceEther.TabIndex = 5;
            this.lblBalanceEther.Text = "0";
            // 
            // lblBalanceMIT
            // 
            this.lblBalanceMIT.AutoSize = true;
            this.lblBalanceMIT.Location = new System.Drawing.Point(333, 53);
            this.lblBalanceMIT.Name = "lblBalanceMIT";
            this.lblBalanceMIT.Size = new System.Drawing.Size(13, 13);
            this.lblBalanceMIT.TabIndex = 5;
            this.lblBalanceMIT.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(530, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Locked:";
            // 
            // lblLocked
            // 
            this.lblLocked.AutoSize = true;
            this.lblLocked.Location = new System.Drawing.Point(583, 53);
            this.lblLocked.Name = "lblLocked";
            this.lblLocked.Size = new System.Drawing.Size(32, 13);
            this.lblLocked.TabIndex = 5;
            this.lblLocked.Text = "False";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(13, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(645, 1);
            this.label2.TabIndex = 5;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Send";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "To:";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(85, 157);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(573, 20);
            this.txtTo.TabIndex = 7;
            this.txtTo.Text = "0xb1928f80369c51f95ff0971d888da2a52243816d";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(85, 260);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(573, 20);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.Text = "10";
            // 
            // rdoEther
            // 
            this.rdoEther.AutoSize = true;
            this.rdoEther.Location = new System.Drawing.Point(6, 14);
            this.rdoEther.Name = "rdoEther";
            this.rdoEther.Size = new System.Drawing.Size(50, 17);
            this.rdoEther.TabIndex = 8;
            this.rdoEther.Text = "Ether";
            this.rdoEther.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoMIT);
            this.groupBox1.Controls.Add(this.rdoEther);
            this.groupBox1.Location = new System.Drawing.Point(85, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 37);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // rdoMIT
            // 
            this.rdoMIT.AutoSize = true;
            this.rdoMIT.Checked = true;
            this.rdoMIT.Location = new System.Drawing.Point(97, 14);
            this.rdoMIT.Name = "rdoMIT";
            this.rdoMIT.Size = new System.Drawing.Size(57, 17);
            this.rdoMIT.TabIndex = 8;
            this.rdoMIT.TabStop = true;
            this.rdoMIT.Text = "MIT";
            this.rdoMIT.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(583, 340);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 32);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(82, 283);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(95, 13);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "[Amount] is invalid.";
            this.lblError.Visible = false;
            // 
            // bgwkUpdate
            // 
            this.bgwkUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwkUpdate_DoWork);
            // 
            // timUpdate
            // 
            this.timUpdate.Interval = 60000;
            this.timUpdate.Tick += new System.EventHandler(this.timUpdate_Tick);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(85, 303);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(573, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Password:";
            // 
            // FrmWallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(670, 384);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.btnCopyAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMITName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEtherName);
            this.Controls.Add(this.lblLocked);
            this.Controls.Add(this.lblBalanceMIT);
            this.Controls.Add(this.lblBalanceEther);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.btnAddAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(686, 420);
            this.MinimumSize = new System.Drawing.Size(686, 380);
            this.Name = "FrmWallet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MIT - Wallet";
            this.Load += new System.EventHandler(this.FrmCommand_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Button btnCopyAccount;
        private System.Windows.Forms.Label lblEtherName;
        private System.Windows.Forms.Label lblMITName;
        private System.Windows.Forms.Label lblBalanceEther;
        private System.Windows.Forms.Label lblBalanceMIT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLocked;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.RadioButton rdoEther;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoMIT;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblError;
        private System.ComponentModel.BackgroundWorker bgwkUpdate;
        private System.Windows.Forms.Timer timUpdate;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
    }
}

