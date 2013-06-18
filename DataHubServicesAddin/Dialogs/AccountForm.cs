using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataHubServicesAddin.Dialogs
{
    /// <summary>
    /// Form for entering datahub credentials
    /// </summary>
    public partial class AccountForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountForm"/> class.
        /// </summary>
        public AccountForm()
        {
            InitializeComponent();
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
                try
                {
                    string connecttest = OnlineManager.TestLoginDetails(txtName.Text, txtPassword.Text);
                    if (string.IsNullOrEmpty(connecttest) == false)
                    {
                        switch(connecttest)
                        {
                            case "COULDNOTCONNECT":
                                 lblWarning.Text="Could not connect. Please check network.";
                                break;
                            case "COULDNOTCONNECTWITHCRED":
                                lblWarning.Text="Invalid. Please check account credentials.";
                                break;
                            default:
                                lblWarning.Text= "Unable to connect.";
                                break;
                        }
                        lblWarning.Visible = true;
                        return;
                    }
                }
                catch (Exception)
                {

                }

                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Hide();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Handles the Load event of the frmAccount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmAccount_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
             get {
                return txtPassword.Text;
            }
            set
            {
               txtPassword.Text = value;
            }

        }
    }
}
