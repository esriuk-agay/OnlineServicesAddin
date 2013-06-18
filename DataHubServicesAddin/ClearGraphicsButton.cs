using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Desktop.AddIns;

namespace DataHubServicesAddin
{
    public class ClearGraphicsButton : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClearGraphicsButton"/> class.
        /// </summary>
        public ClearGraphicsButton()
        {
        }

        /// <summary>
        /// Called when [click].
        /// </summary>
        protected override void OnClick()
        {
            DataHubExtension.Current.ClearGraphics();
        }
    }
}
