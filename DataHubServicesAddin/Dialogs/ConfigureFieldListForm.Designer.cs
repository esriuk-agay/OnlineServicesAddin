namespace DataHubServicesAddin.Dialogs
{
    partial class ConfigureFieldListForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.availableFieldsListBox = new System.Windows.Forms.ListBox();
            this.chosenFieldsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.locatorNameLabel = new System.Windows.Forms.Label();
            this.butMoveRight = new System.Windows.Forms.Button();
            this.butMoveDown = new System.Windows.Forms.Button();
            this.butMoveUp = new System.Windows.Forms.Button();
            this.butMoveLeft = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 58);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Define which fields should appear in the callout label on the map.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Configure List of Fields";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::DataHubServicesAddin.Properties.Resources.Edit_Locator_48;
            this.pictureBox1.Location = new System.Drawing.Point(467, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // availableFieldsListBox
            // 
            this.availableFieldsListBox.FormattingEnabled = true;
            this.availableFieldsListBox.Location = new System.Drawing.Point(9, 104);
            this.availableFieldsListBox.Name = "availableFieldsListBox";
            this.availableFieldsListBox.Size = new System.Drawing.Size(218, 238);
            this.availableFieldsListBox.TabIndex = 1;
            this.availableFieldsListBox.SelectedIndexChanged += new System.EventHandler(this.availableFieldsListBox_SelectedIndexChanged);
            // 
            // chosenFieldsListBox
            // 
            this.chosenFieldsListBox.FormattingEnabled = true;
            this.chosenFieldsListBox.Location = new System.Drawing.Point(261, 104);
            this.chosenFieldsListBox.Name = "chosenFieldsListBox";
            this.chosenFieldsListBox.Size = new System.Drawing.Size(218, 238);
            this.chosenFieldsListBox.TabIndex = 2;
            this.chosenFieldsListBox.SelectedIndexChanged += new System.EventHandler(this.chosenFieldsListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Locator:";
            // 
            // locatorNameLabel
            // 
            this.locatorNameLabel.AutoSize = true;
            this.locatorNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locatorNameLabel.Location = new System.Drawing.Point(64, 65);
            this.locatorNameLabel.Name = "locatorNameLabel";
            this.locatorNameLabel.Size = new System.Drawing.Size(144, 13);
            this.locatorNameLabel.TabIndex = 4;
            this.locatorNameLabel.Text = "Locator name goes here";
            // 
            // butMoveRight
            // 
            this.butMoveRight.Image = global::DataHubServicesAddin.Properties.Resources.Right_16_n_p;
            this.butMoveRight.Location = new System.Drawing.Point(231, 117);
            this.butMoveRight.Name = "butMoveRight";
            this.butMoveRight.Size = new System.Drawing.Size(26, 28);
            this.butMoveRight.TabIndex = 8;
            this.butMoveRight.UseVisualStyleBackColor = true;
            this.butMoveRight.Click += new System.EventHandler(this.butMoveRight_Click);
            // 
            // butMoveDown
            // 
            this.butMoveDown.Image = global::DataHubServicesAddin.Properties.Resources.Down_16_n_p;
            this.butMoveDown.Location = new System.Drawing.Point(483, 149);
            this.butMoveDown.Name = "butMoveDown";
            this.butMoveDown.Size = new System.Drawing.Size(26, 28);
            this.butMoveDown.TabIndex = 6;
            this.butMoveDown.UseVisualStyleBackColor = true;
            this.butMoveDown.Click += new System.EventHandler(this.butMoveDown_Click);
            // 
            // butMoveUp
            // 
            this.butMoveUp.Image = global::DataHubServicesAddin.Properties.Resources.Up_16_n_p;
            this.butMoveUp.Location = new System.Drawing.Point(483, 117);
            this.butMoveUp.Name = "butMoveUp";
            this.butMoveUp.Size = new System.Drawing.Size(26, 28);
            this.butMoveUp.TabIndex = 5;
            this.butMoveUp.UseVisualStyleBackColor = true;
            this.butMoveUp.Click += new System.EventHandler(this.butMoveUp_Click);
            // 
            // butMoveLeft
            // 
            this.butMoveLeft.Image = global::DataHubServicesAddin.Properties.Resources.Left_16_n_p;
            this.butMoveLeft.Location = new System.Drawing.Point(231, 149);
            this.butMoveLeft.Name = "butMoveLeft";
            this.butMoveLeft.Size = new System.Drawing.Size(26, 28);
            this.butMoveLeft.TabIndex = 9;
            this.butMoveLeft.UseVisualStyleBackColor = true;
            this.butMoveLeft.Click += new System.EventHandler(this.butMoveLeft_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Available Fields:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Display Fields:";
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(440, 350);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(63, 23);
            this.butCancel.TabIndex = 12;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.Location = new System.Drawing.Point(371, 350);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(63, 23);
            this.butOK.TabIndex = 13;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // ConfigureFieldListForm
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(515, 385);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butMoveLeft);
            this.Controls.Add(this.butMoveRight);
            this.Controls.Add(this.butMoveDown);
            this.Controls.Add(this.butMoveUp);
            this.Controls.Add(this.locatorNameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chosenFieldsListBox);
            this.Controls.Add(this.availableFieldsListBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigureFieldListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Fields";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox availableFieldsListBox;
        private System.Windows.Forms.ListBox chosenFieldsListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label locatorNameLabel;
        private System.Windows.Forms.Button butMoveUp;
        private System.Windows.Forms.Button butMoveDown;
        private System.Windows.Forms.Button butMoveRight;
        private System.Windows.Forms.Button butMoveLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
    }
}