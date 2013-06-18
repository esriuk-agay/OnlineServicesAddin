using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Desktop.AddIns;
using DataHubServicesAddin.Dialogs;

namespace DataHubServicesAddin
{
    public class DataHubCredentialsButton : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataHubCredentialsButton"/> class.
        /// </summary>
        public DataHubCredentialsButton()
        {
        }

        /// <summary>
        /// Called when Button is clicked.
        /// </summary>
        protected override void OnClick()
        {
            try
            {
                // Show the Account Form
                AccountForm frm = new AccountForm();
                frm.Username = DataHubConfiguration.Current.UserName;
                frm.Password = DataHubConfiguration.Current.Password;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Set the Username and Password
                    DataHubConfiguration.Current.UserName = frm.Username;
                    DataHubConfiguration.Current.Password = frm.Password;
                    DataHubConfiguration.Current.Save();
                }
            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }
        }
    }
}
