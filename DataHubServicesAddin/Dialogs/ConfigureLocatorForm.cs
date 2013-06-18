using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using DataHubServicesAddin.LocatorHub;


namespace DataHubServicesAddin.Dialogs
{
    /// <summary>
    /// Form used to configure locators
    /// </summary>
    internal partial class ConfigureLocatorForm : Form
    {

        BindingList<RemoteLocator> _Locators = null;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="frmConfigureLocator"/> class.
        /// </summary>
        /// <param name="inSettings">The in settings.</param>
        public ConfigureLocatorForm()
        {
            try
            {
                InitializeComponent();

                pnlDataHub.Location = new System.Drawing.Point(pnlHub.Location.X, pnlHub.Location.Y);
                pnlDataHub.Size = new Size(pnlHub.Size.Width, pnlHub.Size.Height);

                this.LocatorNamesAlreadyInUse = new List<string>();
                //Setup Local Locators
                this.InvalidateWebService();
                cboUrl.Items.Clear();
                cboLocator.DisplayMember = "LocatorName";
                cboLocator.ValueMember = "LocatorId";

                //Setup DataHub Locators
                _DHubLocators = new BindingList<OnlineLocator>();
                try
                {
                    _DHubLocators = OnlineManager.ListLocatorsWithSubscriptions();
                }
                catch (Exception)
                {

                }

                cboDhubLocator.DataSource = _DHubLocators;
                cboDhubLocator.DisplayMember = "Name";
                cboDhubLocator.ValueMember = "Id";

                 // Configure the Default State of the Locator
                 radAuthNone.Checked = true;

                ConfigureUI();
            }
            catch (Exception exv)
            {
                Cursor.Current = Cursors.Default;
                DataHubExtension.ShowError(exv);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureLocatorForm"/> class.
        /// </summary>
        /// <param name="onlineLocator">The online locator.</param>
        public ConfigureLocatorForm(OnlineLocator onlineLocator)
            : this()
        {
            // Now, if re-bining to an existing. Select the appropriate one
            if (onlineLocator != null)
            {
                _ID = onlineLocator.GazId;
                txtName.Text = onlineLocator.Name;
                if (onlineLocator.Url.StartsWith("DATAHUB:", StringComparison.CurrentCultureIgnoreCase))
                {
                    radOnline.Checked = true;
                    ReConnectToOnlineService(onlineLocator);
                }
                else
                {
                    ReConnectToRemoteService(onlineLocator);
                    radHubConnection.Checked = true;
                }
                ConfigureUI();
           }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the configured locator.
        /// </summary>
        /// <value>
        /// The configured locator.
        /// </value>
        public OnlineLocator ConfiguredLocator { get; private set; }

        /// <summary>
        /// Gets or sets the locator names already in use.
        /// </summary>
        /// <value>
        /// The locator names already in use.
        /// </value>
        public List<String> LocatorNamesAlreadyInUse { get; set; }

        BindingList<OnlineLocator> _DHubLocators = null;
        private string _ID="";

        #endregion

        /// <summary>
        /// Re-connects to remote service.
        /// </summary>
        /// <param name="inLocatorDefinition">The in locator definition.</param>
        private void ReConnectToRemoteService(OnlineLocator inLocatorDefinition)
        {
            cboUrl.Text = inLocatorDefinition.Url;
            txtUsername.Text = inLocatorDefinition.Username;
            txtPassword.Text = inLocatorDefinition.Password;
            switch (inLocatorDefinition.Authentication)
            {
                case AuthenticationMode.CurrentWindows:
                    radAuthWindows.Checked = true;
                    chkUseCurrentCredntials.Checked = true;
                    break;
                case AuthenticationMode.Token:
                    radAuthToken.Checked = true;
                    break;
                case AuthenticationMode.Windows:
                    radAuthWindows.Checked = true;
                    chkUseCurrentCredntials.Checked = false;
                    break;
                default:
                    radAuthNone.Checked = true;
                    break;
            }
            ConnectToHub();
            cboLocator.SelectedValue = inLocatorDefinition.GazId;
            if (cboLocator.SelectedItem != null)
            {
                lblDesc.Text = ((RemoteLocator)cboLocator.SelectedItem).LocatorDescription;
            }

        }


        /// <summary>
        /// Re-connects to online service.
        /// </summary>
        /// <param name="inLocatorDefinition">The in locator definition.</param>
        private void ReConnectToOnlineService(OnlineLocator inLocatorDefinition)
        {
            foreach (OnlineLocator l in _DHubLocators)
            {
                if (l.GazId == inLocatorDefinition.GazId)
                {
                    if (("DATAHUB:" + l.Url).Equals(inLocatorDefinition.Url, StringComparison.InvariantCultureIgnoreCase))
                    {
                        cboDhubLocator.SelectedValue = l.Id;
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// Configures the UI.
        /// </summary>
        private void ConfigureUI()
        {
            try
            {
                butConnect.Enabled = ((_Locators == null) && (string.IsNullOrEmpty(cboUrl.Text) == false));
                pnlHub.Visible = radHubConnection.Checked;
                pnlDataHub.Visible = radOnline.Checked;
            }
            catch (Exception exv)
            {
                DataHubExtension.ShowError(exv);
            }
        
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
                if (string.IsNullOrEmpty(txtName.Text) == true)
                {
                    MessageBox.Show("Please provide a valid name for the Locator", "Invalid Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.LocatorNamesAlreadyInUse.Contains(txtName.Text))
                {
                    MessageBox.Show("The name provided for the Locator is already in use. Please specify a new name." ,"Invalid Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
               }

                if (txtName.Text.Length > 100)
                {
                    MessageBox.Show("Locator Name must be less than 100 characters.", "Invalid Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }




                if (radOnline.Checked == true)
                {
                    if (this.cboDhubLocator.SelectedItem == null)
                    {
                        MessageBox.Show("Please specify a Locator to use.", "Invalid Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    this.ConfiguredLocator = this.cboDhubLocator.SelectedItem as OnlineLocator;
                    this.ConfiguredLocator.Url = "DATAHUB:" + this.ConfiguredLocator.Url;
                }
                else
                {
                    if (this._Locators == null)
                    {
                        MessageBox.Show("Please connect to a Locator Hub and choose a Locator.", "Invalid Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (cboLocator.SelectedItem == null)
                    {
                        MessageBox.Show("Please specify a Locator to use.", "Invalid Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (!cboUrl.Text.ToUpper().Contains("HTTPS://"))
                    {
                        if (MessageBox.Show("This Edit Connection does not use a Secure Web Connection. Details will be sent in clear text and is therefore un-secure. It is recommended that the Web Server is changed to use HTTPS. \n Do you wish to continue?", "Security Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    this.ConfiguredLocator = new OnlineLocator();
                    this.ConfiguredLocator.GazId = cboLocator.SelectedValue.ToString();
                    this.ConfiguredLocator.Url = cboUrl.Text;

                    if (radAuthToken.Checked)
                    {
                        this.ConfiguredLocator.Authentication = AuthenticationMode.Token;
                        this.ConfiguredLocator.Username = txtUsername.Text;
                        this.ConfiguredLocator.Password = txtPassword.Text;

                    }
                    else if (radAuthWindows.Checked)
                    {
                        if (chkUseCurrentCredntials.Checked)
                        {
                            this.ConfiguredLocator.Authentication = AuthenticationMode.CurrentWindows;
                        }
                        else
                        {
                            this.ConfiguredLocator.Authentication = AuthenticationMode.Windows;
                            this.ConfiguredLocator.Username = txtUsername.Text;
                            this.ConfiguredLocator.Password = txtPassword.Text;
                        }
                    }
                }

                this.ConfiguredLocator.Name = txtName.Text;
              
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {

            }
        }


        


        /// <summary>
        /// Handles the TextChanged event of the connectionSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void connectionSettings_TextChanged(object sender, EventArgs e)
        {
            try
            {
                InvalidateWebService();
                ConfigureUI();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Invalidates the web service.
        /// </summary>
        private void InvalidateWebService()
        {
            _Locators = null;
            cboLocator.DataSource = null;
            cboLocator.Refresh();
            lblDesc.Text = "";
       
        }

        /// <summary>
        /// Handles the Click event of the butConnect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void butConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _Locators = this.GetListOfLocatorsFromHub();
                cboLocator.DataSource = _Locators;
                cboLocator.DisplayMember = "LocatorName";
                if (cboLocator.SelectedItem != null)
                {
                    lblDesc.Text = ((RemoteLocator)cboLocator.SelectedItem).LocatorDescription;
                }
                ConfigureUI();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Connects to hub.
        /// </summary>
        private void ConnectToHub()
        {
            BindingList<RemoteLocator> locators =  this.GetListOfLocatorsFromHub();
            cboLocator.DataSource = locators;
        }

        /// <summary>
        /// Gets the list of locators from hub.
        /// </summary>
        /// <returns></returns>
        private BindingList<RemoteLocator> GetListOfLocatorsFromHub()
        {
            string url = cboUrl.Text;
            string username = null;
            string password = null;
            AuthenticationMode authentication = AuthenticationMode.None;
            
            if (radAuthWindows.Checked) 
            {
                if (chkUseCurrentCredntials.Checked) 
                {
                    authentication = AuthenticationMode.CurrentWindows;
                }
                else
                {
                    authentication = AuthenticationMode.Windows;
                    username = txtUsername.Text;
                    password = txtPassword.Text;
                }
            }
            else if (radAuthToken.Checked)
            {
                authentication =  AuthenticationMode.Token;
                username = txtUsername.Text;
                password = txtPassword.Text;
                
            }


            LocatorHub.LocatorHub locatorHubClient = LocatorManager.CreateClient(url, username, password, authentication, null);

            return new BindingList<RemoteLocator>(locatorHubClient.ListLocators());
        }

        /// <summary>
        /// Handles the SelectedValueChanged event of the cboLocator control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboLocator_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboLocator.SelectedItem != null)
                {
                    lblDesc.Text = ((RemoteLocator)cboLocator.SelectedItem).LocatorDescription;
                    ConfigureUI();
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radLocalDefinition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radLocalDefinition_CheckedChanged(object sender, EventArgs e)
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
        /// Handles the CheckedChanged event of the chkUseCurrentCredntials control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkUseCurrentCredntials_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool usernamePasswordNeeded = !chkUseCurrentCredntials.Checked;

                txtUsername.Enabled = usernamePasswordNeeded;
                txtPassword.Enabled = usernamePasswordNeeded;
                InvalidateWebService();
                ConfigureUI();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the securityOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void securityOption_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool tokenService = radAuthToken.Checked;
            
                bool usernamePasswordNeeded = !radAuthNone.Checked;
                txtPassword.Enabled = usernamePasswordNeeded;
                txtUsername.Enabled = usernamePasswordNeeded;

                chkUseCurrentCredntials.Enabled = radAuthWindows.Checked;

                InvalidateWebService();
                ConfigureUI();
            }
            catch (Exception)
            {

            }
        }
    }
}   