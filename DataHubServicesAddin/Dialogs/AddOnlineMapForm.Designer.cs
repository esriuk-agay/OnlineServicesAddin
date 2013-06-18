namespace DataHubServicesAddin.Dialogs
{
    partial class AddOnlineMapForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("sadsad sdsada", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("asdasd", 0);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("asdasd", 0);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("sadasdaasdas sddfs", 0);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(" sdfdsf dsf dsfds fdsf dsfdsfsdfd", 0);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOnlineMapForm));
            this.lstMaps = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imlMaps = new System.Windows.Forms.ImageList(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.backGetOnlineList = new System.ComponentModel.BackgroundWorker();
            this.lblLoading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstMaps
            // 
            this.lstMaps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName});
            this.lstMaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMaps.FullRowSelect = true;
            this.lstMaps.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.lstMaps.LargeImageList = this.imlMaps;
            this.lstMaps.Location = new System.Drawing.Point(12, 12);
            this.lstMaps.MultiSelect = false;
            this.lstMaps.Name = "lstMaps";
            this.lstMaps.Size = new System.Drawing.Size(630, 450);
            this.lstMaps.TabIndex = 0;
            this.lstMaps.TileSize = new System.Drawing.Size(200, 180);
            this.lstMaps.UseCompatibleStateImageBehavior = false;
            this.lstMaps.SelectedIndexChanged += new System.EventHandler(this.lstMaps_SelectedIndexChanged);
            this.lstMaps.DoubleClick += new System.EventHandler(this.lstMaps_DoubleClick);
            // 
            // imlMaps
            // 
            this.imlMaps.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMaps.ImageStream")));
            this.imlMaps.TransparentColor = System.Drawing.Color.White;
            this.imlMaps.Images.SetKeyName(0, "thumbnail.gif");
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(587, 476);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(527, 476);
            this.butOK.Margin = new System.Windows.Forms.Padding(2);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(56, 23);
            this.butOK.TabIndex = 13;
            this.butOK.Text = "Add";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // backGetOnlineList
            // 
            this.backGetOnlineList.WorkerReportsProgress = true;
            this.backGetOnlineList.WorkerSupportsCancellation = true;
            this.backGetOnlineList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backGetOnlineList_DoWork);
            this.backGetOnlineList.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backGetOnlineList_ProgressChanged);
            this.backGetOnlineList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backGetOnlineList_RunWorkerCompleted);
            // 
            // lblLoading
            // 
            this.lblLoading.BackColor = System.Drawing.Color.White;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblLoading.Location = new System.Drawing.Point(183, 170);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(315, 127);
            this.lblLoading.TabIndex = 15;
            this.lblLoading.Text = "Retrieving list of online maps... ";
            // 
            // frmAddOnlineMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 510);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.lstMaps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddOnlineMap";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Map";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstMaps;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button butOK;
        private System.ComponentModel.BackgroundWorker backGetOnlineList;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ImageList imlMaps;
        private System.Windows.Forms.Label lblLoading;
    }
}