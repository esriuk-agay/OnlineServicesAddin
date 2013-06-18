namespace DataHubServicesAddin.Dialogs
{
    partial class LocatorPopupForm
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
            this.DGResults = new System.Windows.Forms.DataGridView();
            this.butCancel = new System.Windows.Forms.Button();
            this.butBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DGResults)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGResults
            // 
            this.DGResults.AllowUserToAddRows = false;
            this.DGResults.AllowUserToDeleteRows = false;
            this.DGResults.AllowUserToResizeColumns = false;
            this.DGResults.AllowUserToResizeRows = false;
            this.DGResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGResults.Location = new System.Drawing.Point(0, 0);
            this.DGResults.MultiSelect = false;
            this.DGResults.Name = "DGResults";
            this.DGResults.ReadOnly = true;
            this.DGResults.RowHeadersVisible = false;
            this.DGResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGResults.Size = new System.Drawing.Size(569, 217);
            this.DGResults.TabIndex = 3;
            this.DGResults.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGResults_CellMouseDoubleClick);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(484, 14);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(73, 23);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butBack
            // 
            this.butBack.Location = new System.Drawing.Point(12, 14);
            this.butBack.Name = "butBack";
            this.butBack.Size = new System.Drawing.Size(71, 23);
            this.butBack.TabIndex = 2;
            this.butBack.Text = "Back";
            this.butBack.UseVisualStyleBackColor = true;
            this.butBack.Click += new System.EventHandler(this.butBack_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butBack);
            this.panel1.Controls.Add(this.butCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 217);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 49);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGResults);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 217);
            this.panel2.TabIndex = 6;
            // 
            // LocatorPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 266);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LocatorPopupForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Address";
            this.Shown += new System.EventHandler(this.LocatorPopupForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DGResults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGResults;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}