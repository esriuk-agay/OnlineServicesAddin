using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Desktop.AddIns;

namespace DataHubServicesAddin
{
    /// <summary>
    /// Uze fuzzy button implementation
    /// </summary>
    public class UseFuzzyButton : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UseFuzzyButton"/> class.
        /// </summary>
        public UseFuzzyButton()
        {
            this.Checked = DataHubConfiguration.Current.UseFuzzy;
        }

        /// <summary>
        /// Called when [click].
        /// </summary>
        protected override void OnClick()
        {
            this.Checked = true;
            DataHubConfiguration.Current.UseFuzzy = true;
            DataHubConfiguration.Current.Save();
        }

        /// <summary>
        /// Called when [update].
        /// </summary>
        protected override void OnUpdate()
        {
            this.Checked = DataHubConfiguration.Current.UseFuzzy;
        }
    }
}
