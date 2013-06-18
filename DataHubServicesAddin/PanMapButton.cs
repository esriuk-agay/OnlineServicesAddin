using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Desktop.AddIns;

namespace DataHubServicesAddin
{
    public class PanMapButton : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanMapButton"/> class.
        /// </summary>
        public PanMapButton()
        {
            this.Checked = DataHubConfiguration.Current.UsePan;
        }

        /// <summary>
        /// Called when button is clicked.
        /// </summary>
        protected override void OnClick()
        {
            this.Checked = true;
            DataHubConfiguration.Current.UsePan = true;
            DataHubConfiguration.Current.Save();
        }

        /// <summary>
        /// Called when state is updated.
        /// </summary>
        protected override void OnUpdate()
        {
            this.Checked = DataHubConfiguration.Current.UsePan;
        }
        
    }
}
