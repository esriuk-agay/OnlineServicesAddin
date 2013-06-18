using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Desktop.AddIns;

namespace DataHubServicesAddin
{
    public class LocatorSearchButton : Button
    {

        /// <summary>
        /// Called when [click].
        /// </summary>
        protected override void OnClick()
        {
            try
            {
                DataHubExtension.Current.RunSearch();

            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }
        }
    }
}
