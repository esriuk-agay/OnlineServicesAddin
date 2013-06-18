using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Desktop.AddIns;

namespace DataHubServicesAddin
{
    public class UseStandardButton : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UseStandardButton"/> class.
        /// </summary>
        public UseStandardButton()
        {
            this.Checked = !DataHubConfiguration.Current.UseFuzzy;
        }

        /// <summary>
        /// Called when [click].
        /// </summary>
        protected override void OnClick()
        {
            this.Checked = true;
            DataHubConfiguration.Current.UseFuzzy = false;
            DataHubConfiguration.Current.Save();
        }

        /// <summary>
        /// Called when [update].
        /// </summary>
        protected override void OnUpdate()
        {
            this.Checked = !DataHubConfiguration.Current.UseFuzzy;
        }
    }
}
