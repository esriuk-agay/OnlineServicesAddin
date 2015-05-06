using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ServiceModel;
using System.Net;
using System.ComponentModel;

namespace DataHubServicesAddin
{

    /// <summary>
    /// Online Manager. Utility methods to do with accessing Datahub.esriuk.com
    /// </summary>
    internal class OnlineManager
    {
        /// <summary>
        /// Static Variables concerning the DataHub Url
        /// </summary>
        public static readonly string _DataHubHttp = "http://datahub.esriuk.com/DhMetaData/MetaData.asmx";
        public static readonly string _DataHubHttps = "https://datahub.esriuk.com/DhMetaData/MetaData.asmx";

        #region Data Hub Meta Data



        /// <summary>
        /// List the Maps with an indication of subscription
        /// </summary>
        /// <returns></returns>
        internal static string TestLoginDetails(string inUserName, string inPassword)
        {
          
            MetaData.MetaDataSoapClient client = null;

            string url = DataHubConfiguration.Current.DataHubHttps;
            if (string.IsNullOrEmpty(url)) url = _DataHubHttps;
            if (url.StartsWith("https", StringComparison.InvariantCultureIgnoreCase))
            {
                client = new MetaData.MetaDataSoapClient(new BasicHttpBinding(BasicHttpSecurityMode.Transport), new EndpointAddress(url));
            }
            else
            {
                client = new MetaData.MetaDataSoapClient(new BasicHttpBinding(), new EndpointAddress(url));
            }


            try
            {
                MetaData.DataSetMetaData[] items = client.ListDataSets();
                    
            }
            catch (Exception)
            {
                return "COULDNOTCONNECT";
            }


            try
            {
                MetaData.ArrayOfString subscribed = client.ListSubscribedDataSets(inUserName, inPassword);
            }
            catch (Exception)
            {
                return "COULDNOTCONNECTWITHCRED";
            }
                
                
            return "";
        }



        /// <summary>
        /// List the Maps with an indication of subscription
        /// </summary>
        /// <returns></returns>
        internal static DataTable ListDataHubDatasetsWithSubscriptions()
        {
            DataTable dt = null;

            MetaData.MetaDataSoapClient client = null;

            string url = DataHubConfiguration.Current.DataHubHttps;
            if (string.IsNullOrEmpty(url)) url = _DataHubHttps;
            if (url.StartsWith("https", StringComparison.InvariantCultureIgnoreCase))
            {
                client = new MetaData.MetaDataSoapClient(new BasicHttpBinding(BasicHttpSecurityMode.Transport), new EndpointAddress(url));
            }
            else
            {
                client = new MetaData.MetaDataSoapClient(new BasicHttpBinding(), new EndpointAddress(url));
            }
            MetaData.DataSetMetaData[] datasets = client.ListDataSets();
            MetaData.ArrayOfString subscribed = client.ListSubscribedDataSets(DataHubConfiguration.Current.UserName, DataHubConfiguration.Current.Password);
            List<string> subs = new List<string>();
            if (subscribed != null)
            {
                foreach (string s in subscribed)
                {
                    subs.Add(s.Trim().ToUpper());
                }
            }

            string path = DataHubConfiguration.Current.DataHubHttp;
            if (string.IsNullOrEmpty(path)) path = _DataHubHttp;

            
            //path = path.Substring(0, path.Length - @"/MetaData.asmx".Length);
            path = path.Substring(0, path.LastIndexOf("/"));


            dt = new DataTable();
            dt.Columns.Add("NAME");
            dt.Columns.Add("ID");
            dt.Columns.Add("ABSTRACT");
            dt.Columns.Add("SERVICETYPE");
            dt.Columns.Add("GAZURL");
            dt.Columns.Add("GAZID");

            dt.Columns.Add("IS_SUBSCRIBED");
            dt.Columns.Add("DETAIL");
            dt.Columns.Add("URL");
            dt.Columns.Add("TOKEN_SERVICE_URL");
            dt.Columns.Add("THUMBNAIL_URL");
            dt.Columns.Add("IS_PREMIUM");
            dt.Columns.Add("TERMS_AND_CONDITIONS");
            if (string.IsNullOrEmpty(path) == false)
            {
                foreach (MetaData.DataSetMetaData d in datasets)
                {
                    DataRow dr = dt.NewRow();
                    dr["URL"] = d.Url;
                    dr["TOKEN_SERVICE_URL"] = d.TokenUrl;
                    dr["NAME"] = d.Name;
                    dr["ABSTRACT"] = d.Abstract;
                    dr["ID"] = d.Id;
                    dr["GAZURL"] = d.GazUrl;
                    dr["GAZID"] = d.GazId;
                    dr["SERVICETYPE"] = d.ServiceType;
                    dr["DETAIL"] = path + "/" + d.Detail;
                    dr["THUMBNAIL_URL"] = path + "/" + d.Thumbnail;
                    dr["TERMS_AND_CONDITIONS"] = path + "/" + d.TermsAndConditions;
                    dr["IS_SUBSCRIBED"] = subs.Contains(d.Id.Trim().ToUpper()) == true ? "Y" : "N";
                    dr["IS_PREMIUM"] = d.IsPremium == true ? "Y" : "N";
                    dt.Rows.Add(dr);
                }
                dt.AcceptChanges();
            }

            return dt;
        }


        /// <summary>
        /// List the Locators with an indication of Subscription
        /// </summary>
        /// <returns></returns>
        internal static BindingList<OnlineLocator> ListLocatorsWithSubscriptions()
        {
            BindingList<OnlineLocator> blist = new BindingList<OnlineLocator>();
            foreach (DataRow datarow in ListDataHubDatasetsWithSubscriptions().Rows)
            {
                if ((datarow["IS_SUBSCRIBED"].ToString() == "Y") && (datarow["SERVICETYPE"].ToString().Equals("GAZ", StringComparison.InvariantCultureIgnoreCase)))
                {
                    OnlineLocator onlineLocator = new OnlineLocator();
                    onlineLocator.Name = datarow["NAME"].ToString();
                    onlineLocator.Url = datarow["GAZURL"].ToString();
                    onlineLocator.Id = datarow["ID"].ToString();
                    onlineLocator.GazId = datarow["GAZID"].ToString();
                    blist.Add(onlineLocator);
                }

            }
            return blist;
        }

        #endregion

    }

}
