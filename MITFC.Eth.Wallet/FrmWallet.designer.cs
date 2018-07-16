namespace MITFC.Eth.Wallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWallet));
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.lblAccount = new System.Windows.Forms.Label();
            this.btnCopyAccount = new System.Windows.Forms.Button();
            this.lblEtherName = new System.Windows.Forms.Label();
            this.lblMITFCName = new System.Windows.Forms.Label();
            this.lblBalanceEther = new System.Windows.Forms.Label();
            this.lblBalanceMITFC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLocked = new System.Windows.Forms.Label();
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
            // lblMITFCName
            // 
            this.lblMITFCName.AutoSize = true;
            this.lblMITFCName.Location = new System.Drawing.Point(284, 53);
            this.lblMITFCName.Name = "lblMITFCName";
            this.lblMITFCName.Size = new System.Drawing.Size(42, 13);
            this.lblMITFCName.TabIndex = 5;
            this.lblMITFCName.Text = "MITFC:";
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
            // lblBalanceMITFC
            // 
            this.lblBalanceMITFC.AutoSize = true;
            this.lblBalanceMITFC.Location = new System.Drawing.Point(333, 53);
            this.lblBalanceMITFC.Name = "lblBalanceMITFC";
            this.lblBalanceMITFC.Size = new System.Drawing.Size(13, 13);
            this.lblBalanceMITFC.TabIndex = 5;
            this.lblBalanceMITFC.Text = "0";
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
            // FrmWallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(670, 564);
            this.Controls.Add(this.btnCopyAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMITFCName);
            this.Controls.Add(this.lblEtherName);
            this.Controls.Add(this.lblLocked);
            this.Controls.Add(this.lblBalanceMITFC);
            this.Controls.Add(this.lblBalanceEther);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.btnAddAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(686, 600);
            this.MinimumSize = new System.Drawing.Size(686, 600);
            this.Name = "FrmWallet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MITFC - Wallet";
            this.Load += new System.EventHandler(this.FrmCommand_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Button btnCopyAccount;
        private System.Windows.Forms.Label lblEtherName;
        private System.Windows.Forms.Label lblMITFCName;
        private System.Windows.Forms.Label lblBalanceEther;
        private System.Windows.Forms.Label lblBalanceMITFC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLocked;
    }
}

