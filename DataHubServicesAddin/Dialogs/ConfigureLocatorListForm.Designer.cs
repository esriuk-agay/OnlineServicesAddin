namespace DataHubServicesAddin.Dialogs
{
    partial class ConfigureLocatorListForm
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
            this.lstLocators = new System.Windows.Forms.ListBox();
            this.butAddLocator = new System.Windows.Forms.Button();
            this.butRemoveLocator = new System.Windows.Forms.Button();
            this.butEditLocatorDefinition = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.butMoveLocatorDown = new System.Windows.Forms.Button();
            this.cboTarget = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butMoveLocatorUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstLocators
            // 
            this.lstLocators.FormattingEnabled = true;
            this.lstLocators.Location = new System.Drawing.Point(10, 62);
            this.lstLocators.Margin = new System.Windows.Forms.Padding(2);
            this.lstLocators.Name = "lstLocators";
            this.lstLocators.Size = new System.Drawing.Size(437, 147);
            this.lstLocators.TabIndex = 0;
            this.lstLocators.SelectedIndexChanged += new System.EventHandler(this.lstLocators_SelectedIndexChanged);
            // 
            // butAddLocator
            // 
            this.butAddLocator.Location = new System.Drawing.Point(451, 132);
            this.butAddLocator.Margin = new System.Windows.Forms.Padding(2);
            this.butAddLocator.Name = "butAddLocator";
            this.butAddLocator.Size = new System.Drawing.Size(67, 23);
            this.butAddLocator.TabIndex = 3;
            this.butAddLocator.Text = "Add";
            this.butAddLocator.UseVisualStyleBackColor = true;
            this.butAddLocator.Click += new System.EventHandler(this.butAddLocator_Click);
            // 
            // butRemoveLocator
            // 
            this.butRemoveLocator.Location = new System.Drawing.Point(451, 186);
            this.butRemoveLocator.Margin = new System.Windows.Forms.Padding(2);
            this.butRemoveLocator.Name = "butRemoveLocator";
            this.butRemoveLocator.Size = new System.Drawing.Size(67, 23);
            this.butRemoveLocator.TabIndex = 5;
            this.butRemoveLocator.Text = "Remove";
            this.butRemoveLocator.UseVisualStyleBackColor = true;
            this.butRemoveLocator.Click += new System.EventHandler(this.butRemoveLocator_Click);
            // 
            // butEditLocatorDefinition
            // 
            this.butEditLocatorDefinition.Location = new System.Drawing.Point(451, 159);
            this.butEditLocatorDefinition.Margin = new System.Windows.Forms.Padding(2);
            this.butEditLocatorDefinition.Name = "butEditLocatorDefinition";
            this.butEditLocatorDefinition.Size = new System.Drawing.Size(67, 23);
            this.butEditLocatorDefinition.TabIndex = 4;
            this.butEditLocatorDefinition.Text = "Edit";
            this.butEditLocatorDefinition.UseVisualStyleBackColor = true;
            this.butEditLocatorDefinition.Click += new System.EventHandler(this.butEditLocatorDefinition_Click);
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(384, 239);
            this.butOK.Margin = new System.Windows.Forms.Padding(2);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(63, 23);
            this.butOK.TabIndex = 10;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(451, 239);
            this.butCancel.Margin = new System.Windows.Forms.Padding(2);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(67, 23);
            this.butCancel.TabIndex = 11;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
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
            this.panel3.Size = new System.Drawing.Size(529, 58);
            this.panel3.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(263, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Defines a number of locators and the preferred Target.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Configure Locator List";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DataHubServicesAddin.Properties.Resources.Edit_Locator_48;
            this.pictureBox1.Location = new System.Drawing.Point(480, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 56);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(529, 2);
            this.panel4.TabIndex = 0;
            // 
            // butMoveLocatorDown
            // 
            this.butMoveLocatorDown.Image = global::DataHubServicesAddin.Properties.Resources.Down_16_n_p;
            this.butMoveLocatorDown.Location = new System.Drawing.Point(451, 100);
            this.butMoveLocatorDown.Margin = new System.Windows.Forms.Padding(2);
            this.butMoveLocatorDown.Name = "butMoveLocatorDown";
            this.butMoveLocatorDown.Size = new System.Drawing.Size(26, 28);
            this.butMoveLocatorDown.TabIndex = 2;
            this.butMoveLocatorDown.UseVisualStyleBackColor = true;
            this.butMoveLocatorDown.Click += new System.EventHandler(this.butMoveLocatorDown_Click);
            // 
            // cboTarget
            // 
            this.cboTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarget.FormattingEnabled = true;
            this.cboTarget.Location = new System.Drawing.Point(58, 213);
            this.cboTarget.Margin = new System.Windows.Forms.Padding(2);
            this.cboTarget.Name = "cboTarget";
            this.cboTarget.Size = new System.Drawing.Size(246, 21);
            this.cboTarget.TabIndex = 7;
            this.cboTarget.SelectedIndexChanged += new System.EventHandler(this.cboTarget_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 216);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Target:";
            // 
            // butMoveLocatorUp
            // 
            this.butMoveLocatorUp.Image = global::DataHubServicesAddin.Properties.Resources.Up_16_n_p;
            this.butMoveLocatorUp.Location = new System.Drawing.Point(451, 68);
            this.butMoveLocatorUp.Margin = new System.Windows.Forms.Padding(2);
            this.butMoveLocatorUp.Name = "butMoveLocatorUp";
            this.butMoveLocatorUp.Size = new System.Drawing.Size(26, 28);
            this.butMoveLocatorUp.TabIndex = 1;
            this.butMoveLocatorUp.UseVisualStyleBackColor = true;
            this.butMoveLocatorUp.Click += new System.EventHandler(this.butMoveLocatorUp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Zoom scale:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 240);
            this.textBox1.Name = "textBox1";
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // ConfigureLocatorListForm
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(529, 273);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butEditLocatorDefinition);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.butMoveLocatorDown);
            this.Controls.Add(this.butMoveLocatorUp);
            this.Controls.Add(this.butRemoveLocator);
            this.Controls.Add(this.butAddLocator);
            this.Controls.Add(this.lstLocators);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConfigureLocatorListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configure Locators";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstLocators;
        private System.Windows.Forms.Button butAddLocator;
        private System.Windows.Forms.Button butRemoveLocator;
        private System.Windows.Forms.Button butMoveLocatorUp;
        private System.Windows.Forms.Button butMoveLocatorDown;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butEditLocatorDefinition;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}