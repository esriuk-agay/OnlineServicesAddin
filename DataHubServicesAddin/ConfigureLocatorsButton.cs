using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Addin = ESRI.ArcGIS.Desktop.AddIns;
using DataHubServicesAddin.Dialogs;
using System.Windows.Forms;

namespace DataHubServicesAddin
{
    public class ConfigureLocatorsButton : Addin.Button
    {
        /// <summary>
        /// Called when button is clicked.
        /// </summary>
        protected override void OnClick()
        {
            ConfigureLocatorListForm configureLocatorListDialog = new ConfigureLocatorListForm(DataHubConfiguration.Current.Locators,
                DataHubConfiguration.Current.ZoomScale);

            DialogResult dialogResult = configureLocatorListDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                DataHubConfiguration.Current.Locators = configureLocatorListDialog.ConfiguredLocators;
                DataHubConfiguration.Current.ZoomScale = configureLocatorListDialog.ConfiguredZoomScale;

                DataHubConfiguration.Current.Save();
                LocatorCombo.Current.Populate();
            }
        }

    }

}
