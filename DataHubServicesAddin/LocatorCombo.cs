using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Desktop.AddIns;

namespace DataHubServicesAddin
{
    public class LocatorCombo : ComboBox
    {
        private List<string> _Items = new List<string>();
        private Dictionary<string, string> _Ids = new Dictionary<string, string>();

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LocatorCombo"/> class.
        /// </summary>
        public LocatorCombo()
        {
            LocatorCombo.Current = this;
            this.Populate();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        /// <remarks>Singleton instance</remarks>
        public static LocatorCombo Current { get; private set; }

        

        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        /// <value>
        /// The index of the selected.
        /// </value>
        public int SelectedIndex
        {
            get
            {
                if (string.IsNullOrEmpty(this.Value)) return -1;
                return _Items.IndexOf(this.Value);
            }
        }

        /// <summary>
        /// Gets the text value.
        /// </summary>
        /// <value>
        /// The text value.
        /// </value>
        public string TextValue
        {
            get
            {
                return this.Value;
            }
        }

        /// <summary>
        /// Populates this instance.
        /// </summary>
        public void Populate()
        {
            int mycookie = -1;

            _Items = new List<string>();
            _Ids = new Dictionary<string, string>();
            List<OnlineLocator> items = DataHubConfiguration.Current.Locators;
            string cur = DataHubConfiguration.Current.LastLocatorId;
            this.Clear();

            int found = -1;
            int i = 0;
            int firstcookie = -1;
            foreach (OnlineLocator c in items)
            {

                _Items.Add(c.Name);
                _Ids.Add(c.Name, c.GazId);
                mycookie = this.Add(c.Name);
                if (i == 0) firstcookie = mycookie;
                if (cur == c.GazId) found = mycookie;
                i++;
            }
            if (found != -1)
            {
                this.Select(found);
            }
            else if (items.Count > 0) { this.Select(firstcookie); }
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        private OnlineLocator Items { get; set; }

        #endregion
    }
}
