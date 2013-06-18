using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Desktop.AddIns;

namespace DataHubServicesAddin
{
    /// <summary>
    /// Combobox used to enter the locator search query
    /// </summary>
    public class LocatorSearchQuery : ComboBox
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LocatorSearchQuery"/> class.
        /// </summary>
        public LocatorSearchQuery()
        {
            LocatorSearchQuery.Current = this;
        }

        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public static LocatorSearchQuery Current { get; private set; }

        /// <summary>
        /// The Current Text Value
        /// </summary>
        public string TextValue
        {
            get { return this.Value; }
        }


        /// <summary>
        /// Called when the enter key is pressed.
        /// </summary>
        protected override void OnEnter()
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
