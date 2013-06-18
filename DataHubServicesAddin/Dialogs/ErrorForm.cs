using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataHubServicesAddin.Dialogs
{
    /// <summary>
    /// Form for displaying errors
    /// </summary>
    internal partial class ErrorForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="frmError"/> class.
        /// </summary>
        /// <param name="errorDialog">The error dialog.</param>
        public ErrorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="frmError"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public ErrorForm(Exception exception)
            : this()
        {
            this.txtError.Text = exception.Message + Environment.NewLine;
            this.txtError.Text += "Stack Trace:" + Environment.NewLine + exception.StackTrace;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="frmError"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ErrorForm(string message)
            : this()
        {
            this.txtError.Text = message;
        }

        #endregion

        #region Events

        /// <summary>
        /// Handles the Click event of the butOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void butOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion
    }
}