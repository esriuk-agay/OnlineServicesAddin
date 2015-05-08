using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace DataHubServicesAddin
{
    internal class DataHubConfiguration
    {
        #region Static Factory Reference

        /// <summary>
        /// Static Factory Reference
        /// </summary>
        public static DataHubConfiguration Current
        {
            get
            {
                if (_Config == null)
                {
                    _Config = new DataHubConfiguration();
                }
                return _Config;
            }
        }
        static DataHubConfiguration _Config = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Varables for Paths
        /// </summary>
        private const string CONFIG_SAVE_PATH = @"\ESRIUK\DataHub\OnlineServicesToolbar\";
        private const string CONFIG_FILE_NAME = "DataHubConfig.xml";

        private const int CONFIG_DEFAULT_ZOOM = 1250;


        /// <summary>
        /// Constructor
        /// </summary>
        public DataHubConfiguration()
        {
            Load();
        }


        #endregion

        #region Save and Load Operations

        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            try
            {
                System.Xml.XmlDocument dom = new XmlDocument();

                using (MemoryStream mem = new MemoryStream())
                {
                    using (XmlTextWriter wr = new XmlTextWriter(mem, Encoding.UTF8))
                    {

                        wr.WriteStartElement("DataHubConfiguration");

                        if (!string.IsNullOrEmpty(this.DataHubHttp))
                        {
                            wr.WriteStartElement("DataHubHttp");
                            wr.WriteAttributeString("url", this.DataHubHttp);
                            wr.WriteEndElement();
                        }
                        if (!string.IsNullOrEmpty(this.DataHubHttps))
                        {
                            wr.WriteStartElement("DataHubHttps");
                            wr.WriteAttributeString("url", this.DataHubHttps);
                            wr.WriteEndElement();
                        }
                        wr.WriteStartElement("DataHub");
                        wr.WriteAttributeString("user", this.UserName);
                        wr.WriteAttributeString("password", this.Password);
                        wr.WriteEndElement();

                        wr.WriteStartElement("LocatorHub");
                        wr.WriteAttributeString("usefuzzy", this.UseFuzzy.ToString());
                        wr.WriteAttributeString("usepan", this.UsePan.ToString());
                        wr.WriteAttributeString("lastlocatorid", this.LastLocatorId);
                        wr.WriteAttributeString("zoomscale", this.ZoomScale.ToString());
                        wr.WriteEndElement();

                        wr.WriteStartElement("Locators");
                        foreach (OnlineLocator locator in this.Locators)
                        {
                            wr.WriteStartElement("Locator");
                            wr.WriteAttributeString("Name", locator.Name);
                            wr.WriteAttributeString("Description", locator.Description);
                            wr.WriteAttributeString("LocatorId", locator.GazId);
                            wr.WriteAttributeString("Url", locator.Url);
                            wr.WriteAttributeString("Target", locator.Target);
                            wr.WriteAttributeString("Authentication", locator.Authentication.ToString());
                            wr.WriteAttributeString("Username", locator.Username);
                            wr.WriteAttributeString("Password", locator.Password);
                            wr.WriteAttributeString("TokenUrl", locator.TokenUrl);
                            wr.WriteAttributeString("FieldNames", locator.FieldNames);
                            wr.WriteEndElement();
                        }
                        wr.WriteEndElement();

                        wr.WriteEndElement();
                        wr.Flush();
                        mem.Seek(0, SeekOrigin.Begin);
                        dom.Load(mem);
                        if (!System.IO.Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + CONFIG_SAVE_PATH))
                        {
                            System.IO.Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + CONFIG_SAVE_PATH);
                        }
                        dom.Save(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + CONFIG_SAVE_PATH + CONFIG_FILE_NAME);
                    }

                }
            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }

        }

        /// <summary>
        /// Load
        /// </summary>
        internal void Load()
        {

            try
            {

                XmlDocument dom = new XmlDocument();
                string filename = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + CONFIG_SAVE_PATH + CONFIG_FILE_NAME;

                if (File.Exists(filename) == true)
                {
                    dom.Load(filename);
                    XmlNode dhubhttp = dom.SelectSingleNode("./DataHubConfiguration/DataHubHttp");
                    if (dhubhttp != null)
                    {
                        this.DataHubHttp = dhubhttp.Attributes.GetNamedItem("url").InnerText;
                    }
                    XmlNode dhubhttps = dom.SelectSingleNode("./DataHubConfiguration/DataHubHttps");
                    if (dhubhttps != null)
                    {
                        this.DataHubHttps = dhubhttps.Attributes.GetNamedItem("url").InnerText;
                    }
                    XmlNode dhub = dom.SelectSingleNode("./DataHubConfiguration/DataHub");
                    if (dhub != null)
                    {
                        this.UserName = dhub.Attributes.GetNamedItem("user").InnerText;
                        this.Password = dhub.Attributes.GetNamedItem("password").InnerText;
                    }

                    XmlNode lh = dom.SelectSingleNode("./DataHubConfiguration/LocatorHub");
                    if (lh != null)
                    {
                        this.UsePan = System.Convert.ToBoolean(lh.Attributes.GetNamedItem("usepan").InnerText);
                        this.UseFuzzy = System.Convert.ToBoolean(lh.Attributes.GetNamedItem("usefuzzy").InnerText);
                        LastLocatorId = FetchAttributeValue(lh, "lastlocatorid");
                        string zoomStr = FetchAttributeValue(lh, "zoomscale");
                        this.ZoomScale = String.IsNullOrEmpty(zoomStr) ? CONFIG_DEFAULT_ZOOM : int.Parse(zoomStr);
                    }


                    this.Locators = new List<OnlineLocator>();
                    XmlNode locator = dom.SelectSingleNode("./DataHubConfiguration/Locators");
                    if (locator != null)
                    {
                        foreach (XmlNode xmlNode in locator.SelectNodes("./Locator"))
                        {
                            OnlineLocator onlineLocator = new OnlineLocator();
                            onlineLocator.Name = FetchAttributeValue(xmlNode, "Name");
                            onlineLocator.Description = FetchAttributeValue(xmlNode, "Description");
                            onlineLocator.GazId = FetchAttributeValue(xmlNode, "LocatorId");
                            onlineLocator.Url = FetchAttributeValue(xmlNode, "Url");
                            onlineLocator.Target = FetchAttributeValue(xmlNode, "Target");
                            onlineLocator.Authentication = (AuthenticationMode)Enum.Parse(typeof(AuthenticationMode), FetchAttributeValue(xmlNode, "Authentication"));
                            onlineLocator.Username = FetchAttributeValue(xmlNode, "Username");
                            onlineLocator.Password = FetchAttributeValue(xmlNode, "Password");
                            onlineLocator.TokenUrl = FetchAttributeValue(xmlNode, "TokenUrl");
                            string fieldNames = FetchAttributeValue(xmlNode, "FieldNames");
                            if (string.IsNullOrEmpty(fieldNames)) fieldNames = "LOCATOR_DESCRIPTION";
                            onlineLocator.FieldNames = fieldNames;
                            this.Locators.Add(onlineLocator);
                        }
                    }
                }
                else
                {
                    //never run before. set things up to be empty
                    this.LastLocatorId = String.Empty;
                    this.Locators = new List<OnlineLocator>();
                    this.ZoomScale = CONFIG_DEFAULT_ZOOM;
                }

            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }

        }


        /// <summary>
        /// Utility Helper. To get Attribute Values from XML
        /// </summary>
        /// <param name="inNode"></param>
        /// <param name="inAttributeName"></param>
        /// <returns></returns>
        private string FetchAttributeValue(XmlNode inNode, string inAttributeName)
        {
            String attributeValue = null;
            try
            {
                if (inNode == null)
                {
                    attributeValue = "";
                }
                else if (inNode.Attributes.GetNamedItem(inAttributeName) == null)
                {
                    attributeValue = "";
                }
                else
                {
                    attributeValue = inNode.Attributes.GetNamedItem(inAttributeName).InnerText;
                }
            }
            catch (Exception ex)
            {
                DataHubExtension.ShowError(ex);
            }

            return attributeValue;
        }

        #endregion

        #region Configuration Values

        public List<OnlineLocator> Locators
        {
            get;
            set;
        }

        /// <summary>
        /// Whether to Use Pan
        /// </summary>
        public bool UsePan
        {
            get;
            set;
        }



        /// <summary>
        /// Gets or sets a value indicating whether to use fuzzy.
        /// </summary>
        /// <value>
        ///   <c>true</c> use fuzzy; otherwise, <c>false</c>.
        /// </value>
        public bool UseFuzzy
        {
            get;
            set;
        }




        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get;
            set;
        }


        /// <summary>
        /// Password
        /// </summary>
        public string Password
        {
            get;
            set;
        }



        /// <summary>
        /// Gets or sets the last locator id.
        /// </summary>
        /// <value>
        /// The last locator id.
        /// </value>
        public string LastLocatorId
        {
            get;
            set;
        }

        // Zoom scale when no extent is returned
        public int ZoomScale
        {
            get;
            set;
        }

        public string DataHubHttp
        {
            get;
            set;
        }

        public string DataHubHttps
        {
            get;
            set;
        }
        #endregion
    }
}
