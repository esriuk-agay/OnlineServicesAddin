using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Runtime.InteropServices;

namespace DataHubServicesAddin.Dialogs
{


    /// <summary>
    /// Form for showing a list of map services available for the current user.
    /// </summary>
    public partial class AddOnlineMapForm : Form
    {
        /// <summary>
        /// Sets the window theme.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="pszSubAppName">Name of the PSZ sub app.</param>
        /// <param name="pszSubIdList">The PSZ sub id list.</param>
        /// <returns></returns>
        [DllImport("uxtheme.dll")] 
        public extern static int SetWindowTheme(IntPtr hWnd, 
                                                [MarshalAs(UnmanagedType.LPWStr)] string pszSubAppName, 
                                                [MarshalAs(UnmanagedType.LPWStr)] string pszSubIdList
                                                );


        /// <summary>
        /// Initializes a new instance of the <see cref="frmAddOnlineMap"/> class.
        /// </summary>
        public AddOnlineMapForm()
        {
            InitializeComponent();
            // Begin to get the 
            _BaseData = new DataTable();
            _BaseData.Columns.Add("ID", typeof(string));
            _BaseData.Columns.Add("NAME", typeof(string));
            _BaseData.Columns.Add("THUMBNAIL", typeof(Bitmap));
            _BaseData.Columns.Add("MAP_URL", typeof(string));
            lblLoading.Visible = true;
            lstMaps.Clear();
            imlMaps.Images.Clear();
            try
            {

                SetWindowTheme(lstMaps.Handle, "explorer", null);
            }
            catch (Exception)
            {
            }
            backGetOnlineList.RunWorkerAsync();
            try
            {
                ConfigureUI();
            }
            catch (Exception) { }
        }


        /// <summary>
        /// Handles the ProgressChanged event of the backGetOnlineList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void backGetOnlineList_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
              
                lock (mylock)
                {
                    if (lstMaps.Items.Count <  _BaseData.Rows.Count)
                    {
                        lblLoading.Visible = false;
                        for (int z = lstMaps.Items.Count; z <  _BaseData.Rows.Count; z++)
                        {
                            imlMaps.Images.Add((Bitmap)_BaseData.Rows[z]["THUMBNAIL"]);
                            ListViewItem item0 = new ListViewItem(new string[] 
                            {_BaseData.Rows[z]["NAME"].ToString()}, z);
                            lstMaps.Items.Add(item0);
                        }

                    }
                }

            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the backGetOnlineList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void backGetOnlineList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                lblLoading.Visible = false;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Handles the DoWork event of the backGetOnlineList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void backGetOnlineList_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataTable dt = OnlineManager.ListDataHubDatasetsWithSubscriptions();

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["IS_SUBSCRIBED"].ToString() == "Y")
                    {
                        if (dr["SERVICETYPE"].ToString().Equals("MAP", StringComparison.InvariantCultureIgnoreCase))
                        {
                            Bitmap b = null;
                            try
                            {
                                System.Net.WebRequest request = System.Net.WebRequest.Create(dr["THUMBNAIL_URL"].ToString());
                                System.Net.WebResponse response = request.GetResponse();
                                System.IO.Stream responseStream =
                                    response.GetResponseStream();
                                b = new Bitmap(responseStream);
                                int w = 165; int h = 130;
                                int borderx = 10; int bordery=10;
                                Bitmap newImage = new Bitmap(w, h);
                                using (Graphics graphics = Graphics.FromImage(newImage))
                                {
                                    graphics.Clear( Color.White);
                                    int x = (newImage.Width - b.Width) / 2;
                                    int y = (newImage.Height - b.Height) / 2;
                                    graphics.DrawImage(b, new Rectangle(borderx, bordery, newImage.Width - 2 * borderx, newImage.Height- 2 * bordery), 0, 0, b.Width, b.Height, GraphicsUnit.Pixel);

                                }
                                b = newImage;

                            }
                            catch (Exception)
                            {
                            }

                            string id = dr["ID"].ToString();
                            string name = dr["NAME"].ToString();
                            string mapurl = dr["URL"].ToString();
                            lock (mylock)
                            {
                                DataRow dn = _BaseData.NewRow();
                                dn["ID"] = id;
                                dn["NAME"] = name;
                                dn["THUMBNAIL"] = b;
                                dn["MAP_URL"] = mapurl;
                                _BaseData.Rows.Add(dn);
                            }
                            backGetOnlineList.ReportProgress(1);

                        }
                    }
                }


            }
            catch (Exception)
            {
            }

        }


        DataTable _BaseData = null;
        object mylock = new object();



        /// <summary>
        /// Handles the Click event of the butClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void butClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Hide();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the lstMaps control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lstMaps_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ConfigureUI();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Configures the UI.
        /// </summary>
        private void ConfigureUI()
        {
            if (lstMaps.SelectedIndices.Count > 0)
            {
                butOK.Enabled = true;
            }
            else butOK.Enabled = false;
        }


        /// <summary>
        /// Handles the Click event of the butOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in lstMaps.SelectedIndices)
                {
                    DataHubExtension.Current.AddAGSLayer(DataHubConfiguration.Current.UserName,
                        DataHubConfiguration.Current.Password,
                        _BaseData.Rows[i]["NAME"].ToString(),
                        _BaseData.Rows[i]["MAP_URL"].ToString());

                }
            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the lstMaps control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lstMaps_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                butOK_Click(null, null);
            }
            catch (Exception)
            {
            }
        }

    }


}
