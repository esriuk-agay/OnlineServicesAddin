using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Desktop.AddIns;

namespace DataHubServicesAddin
{
    /// <summary>
    /// Use Zoom Button implementation
    /// </summary>
    public class UseZoomButton : Button
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UseZoomButton"/> class.
        /// </summary>
        public UseZoomButton()
        {
            this.Checked = !DataHubConfiguration.Current.UsePan;
        }

        /// <summary>
        /// Called when Button is clicked.
        /// </summary>
        protected override void OnClick()
        {
            this.Checked = true;
            DataHubConfiguration.Current.UsePan = false;
            DataHubConfiguration.Current.Save();
        }

        /// <summary>
        /// Called when [update].
        /// </summary>
        protected override void OnUpdate()
        {
            this.Checked = !DataHubConfiguration.Current.UsePan;
        }
    }
}
