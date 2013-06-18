namespace DataHubServicesAddin.Dialogs
{
    partial class ConfigureLocatorForm
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
            this.butOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pnlHub = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radAuthToken = new System.Windows.Forms.RadioButton();
            this.chkUseCurrentCredntials = new System.Windows.Forms.CheckBox();
            this.radAuthNone = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.radAuthWindows = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.butConnect = new System.Windows.Forms.Button();
            this.lblDesc = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboLocator = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboUrl = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radOnline = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.radHubConnection = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Definition = new System.Windows.Forms.GroupBox();
            this.pnlDataHub = new System.Windows.Forms.Panel();
            this.lblDhubLocator = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cboDhubLocator = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.pnlHub.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Definition.SuspendLayout();
            this.pnlDataHub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(536, 402);
            this.butOK.Margin = new System.Windows.Forms.Padding(2);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(56, 23);
            this.butOK.TabIndex = 1;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(597, 401);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(680, 58);
            this.panel3.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(316, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Provides the facilities for adding or editing the definition of Locator";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Configure Locator";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 56);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(680, 2);
            this.panel4.TabIndex = 0;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // pnlHub
            // 
            this.pnlHub.Controls.Add(this.groupBox2);
            this.pnlHub.Controls.Add(this.butConnect);
            this.pnlHub.Controls.Add(this.lblDesc);
            this.pnlHub.Controls.Add(this.label5);
            this.pnlHub.Controls.Add(this.cboLocator);
            this.pnlHub.Controls.Add(this.label4);
            this.pnlHub.Controls.Add(this.cboUrl);
            this.pnlHub.Location = new System.Drawing.Point(1, 16);
            this.pnlHub.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHub.Name = "pnlHub";
            this.pnlHub.Size = new System.Drawing.Size(430, 280);
            this.pnlHub.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radAuthToken);
            this.groupBox2.Controls.Add(this.chkUseCurrentCredntials);
            this.groupBox2.Controls.Add(this.radAuthNone);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.radAuthWindows);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Location = new System.Drawing.Point(51, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 126);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Authentication";
            // 
            // radAuthToken
            // 
            this.radAuthToken.AutoSize = true;
            this.radAuthToken.Location = new System.Drawing.Point(146, 18);
            this.radAuthToken.Name = "radAuthToken";
            this.radAuthToken.Size = new System.Drawing.Size(56, 17);
            this.radAuthToken.TabIndex = 14;
            this.radAuthToken.TabStop = true;
            this.radAuthToken.Text = "Token";
            this.radAuthToken.UseVisualStyleBackColor = true;
            this.radAuthToken.CheckedChanged += new System.EventHandler(this.securityOption_CheckedChanged);
            // 
            // chkUseCurrentCredntials
            // 
            this.chkUseCurrentCredntials.AutoSize = true;
            this.chkUseCurrentCredntials.Location = new System.Drawing.Point(69, 97);
            this.chkUseCurrentCredntials.Name = "chkUseCurrentCredntials";
            this.chkUseCurrentCredntials.Size = new System.Drawing.Size(82, 17);
            this.chkUseCurrentCredntials.TabIndex = 19;
            this.chkUseCurrentCredntials.Text = "Use Current";
            this.chkUseCurrentCredntials.UseVisualStyleBackColor = true;
            this.chkUseCurrentCredntials.CheckedChanged += new System.EventHandler(this.chkUseCurrentCredntials_CheckedChanged);
            // 
            // radAuthNone
            // 
            this.radAuthNone.AutoSize = true;
            this.radAuthNone.Location = new System.Drawing.Point(14, 18);
            this.radAuthNone.Name = "radAuthNone";
            this.radAuthNone.Size = new System.Drawing.Size(51, 17);
            this.radAuthNone.TabIndex = 12;
            this.radAuthNone.TabStop = true;
            this.radAuthNone.Text = "None";
            this.radAuthNone.UseVisualStyleBackColor = true;
            this.radAuthNone.CheckedChanged += new System.EventHandler(this.securityOption_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Password";
            // 
            // radAuthWindows
            // 
            this.radAuthWindows.AutoSize = true;
            this.radAuthWindows.Location = new System.Drawing.Point(71, 18);
            this.radAuthWindows.Name = "radAuthWindows";
            this.radAuthWindows.Size = new System.Drawing.Size(69, 17);
            this.radAuthWindows.TabIndex = 13;
            this.radAuthWindows.TabStop = true;
            this.radAuthWindows.Text = "Windows";
            this.radAuthWindows.UseVisualStyleBackColor = true;
            this.radAuthWindows.CheckedChanged += new System.EventHandler(this.securityOption_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(67, 67);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(191, 20);
            this.txtPassword.TabIndex = 16;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.connectionSettings_TextChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(67, 41);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(191, 20);
            this.txtUsername.TabIndex = 15;
            this.txtUsername.TextChanged += new System.EventHandler(this.connectionSettings_TextChanged);
            // 
            // butConnect
            // 
            this.butConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butConnect.Location = new System.Drawing.Point(313, 171);
            this.butConnect.Margin = new System.Windows.Forms.Padding(2);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(81, 23);
            this.butConnect.TabIndex = 11;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesc.Location = new System.Drawing.Point(48, 231);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(336, 41);
            this.lblDesc.TabIndex = 9;
            this.lblDesc.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 202);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Locator:";
            // 
            // cboLocator
            // 
            this.cboLocator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocator.FormattingEnabled = true;
            this.cboLocator.Location = new System.Drawing.Point(49, 198);
            this.cboLocator.Margin = new System.Windows.Forms.Padding(2);
            this.cboLocator.Name = "cboLocator";
            this.cboLocator.Size = new System.Drawing.Size(345, 21);
            this.cboLocator.TabIndex = 7;
            this.cboLocator.SelectedIndexChanged += new System.EventHandler(this.cboLocator_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Url:";
            // 
            // cboUrl
            // 
            this.cboUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUrl.FormattingEnabled = true;
            this.cboUrl.Location = new System.Drawing.Point(51, 15);
            this.cboUrl.Margin = new System.Windows.Forms.Padding(2);
            this.cboUrl.Name = "cboUrl";
            this.cboUrl.Size = new System.Drawing.Size(258, 21);
            this.cboUrl.TabIndex = 5;
            this.cboUrl.TextChanged += new System.EventHandler(this.connectionSettings_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radOnline);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.radHubConnection);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(9, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(198, 334);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // radOnline
            // 
            this.radOnline.AutoSize = true;
            this.radOnline.Checked = true;
            this.radOnline.Location = new System.Drawing.Point(33, 125);
            this.radOnline.Margin = new System.Windows.Forms.Padding(2);
            this.radOnline.Name = "radOnline";
            this.radOnline.Size = new System.Drawing.Size(55, 17);
            this.radOnline.TabIndex = 11;
            this.radOnline.TabStop = true;
            this.radOnline.Text = "Online";
            this.radOnline.UseVisualStyleBackColor = true;
            this.radOnline.CheckedChanged += new System.EventHandler(this.radLocalDefinition_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 101);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Connection Method:";
            // 
            // radHubConnection
            // 
            this.radHubConnection.AutoSize = true;
            this.radHubConnection.Location = new System.Drawing.Point(33, 146);
            this.radHubConnection.Margin = new System.Windows.Forms.Padding(2);
            this.radHubConnection.Name = "radHubConnection";
            this.radHubConnection.Size = new System.Drawing.Size(85, 17);
            this.radHubConnection.TabIndex = 12;
            this.radHubConnection.Text = "Local Server";
            this.radHubConnection.UseVisualStyleBackColor = true;
            this.radHubConnection.CheckedChanged += new System.EventHandler(this.radLocalDefinition_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 36);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(184, 20);
            this.txtName.TabIndex = 8;
            // 
            // Definition
            // 
            this.Definition.Controls.Add(this.pnlDataHub);
            this.Definition.Controls.Add(this.pnlHub);
            this.Definition.Location = new System.Drawing.Point(219, 63);
            this.Definition.Margin = new System.Windows.Forms.Padding(2);
            this.Definition.Name = "Definition";
            this.Definition.Padding = new System.Windows.Forms.Padding(2);
            this.Definition.Size = new System.Drawing.Size(434, 334);
            this.Definition.TabIndex = 10;
            this.Definition.TabStop = false;
            // 
            // pnlDataHub
            // 
            this.pnlDataHub.Controls.Add(this.lblDhubLocator);
            this.pnlDataHub.Controls.Add(this.label15);
            this.pnlDataHub.Controls.Add(this.cboDhubLocator);
            this.pnlDataHub.Location = new System.Drawing.Point(4, 610);
            this.pnlDataHub.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDataHub.Name = "pnlDataHub";
            this.pnlDataHub.Size = new System.Drawing.Size(430, 172);
            this.pnlDataHub.TabIndex = 12;
            // 
            // lblDhubLocator
            // 
            this.lblDhubLocator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDhubLocator.Location = new System.Drawing.Point(51, 45);
            this.lblDhubLocator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDhubLocator.Name = "lblDhubLocator";
            this.lblDhubLocator.Size = new System.Drawing.Size(336, 0);
            this.lblDhubLocator.TabIndex = 9;
            this.lblDhubLocator.Text = "label6";
            this.lblDhubLocator.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 16);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Locator:";
            // 
            // cboDhubLocator
            // 
            this.cboDhubLocator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDhubLocator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDhubLocator.FormattingEnabled = true;
            this.cboDhubLocator.Location = new System.Drawing.Point(52, 13);
            this.cboDhubLocator.Margin = new System.Windows.Forms.Padding(2);
            this.cboDhubLocator.Name = "cboDhubLocator";
            this.cboDhubLocator.Size = new System.Drawing.Size(345, 21);
            this.cboDhubLocator.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DataHubServicesAddin.Properties.Resources.Edit_Locator_48;
            this.pictureBox1.Location = new System.Drawing.Point(629, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 49);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ConfigureLocatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(680, 431);
            this.Controls.Add(this.Definition);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.butOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConfigureLocatorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Locator";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlHub.ResumeLayout(false);
            this.pnlHub.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Definition.ResumeLayout(false);
            this.pnlDataHub.ResumeLayout(false);
            this.pnlDataHub.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radHubConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox Definition;
        private System.Windows.Forms.Panel pnlHub;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboLocator;
        private System.Windows.Forms.RadioButton radOnline;
        private System.Windows.Forms.Panel pnlDataHub;
        private System.Windows.Forms.Label lblDhubLocator;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboDhubLocator;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radAuthToken;
        private System.Windows.Forms.CheckBox chkUseCurrentCredntials;
        private System.Windows.Forms.RadioButton radAuthNone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radAuthWindows;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button butConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboUrl;

    }
}