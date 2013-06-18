using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Desktop.AddIns;
using DataHubServicesAddin.Dialogs;

namespace DataHubServicesAddin
{
    /// <summary>
    /// Add map button implementation
    /// </summary>
    class AddMapButton : Button
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AddMapButton"/> class.
        /// </summary>
        public AddMapButton()
        {
        }

        /// <summary>
        /// Called when Button is clicked.
        /// </summary>
        protected override void OnClick()
        {
            try
            {
                // Show the Add Map Dialog
                AddOnlineMapForm addOnlineMapForm = new AddOnlineMapForm();
                addOnlineMapForm.ShowDialog();

            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }
        }
    }
}
