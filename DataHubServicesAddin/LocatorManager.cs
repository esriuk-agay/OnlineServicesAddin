using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace DataHubServicesAddin
{
    internal static class LocatorManager
    {

        private static Dictionary<String, TokenCache> CachedTokens
        {
            get
            {
                if (_CachedTokens == null)
                {
                    _CachedTokens = new Dictionary<string, TokenCache>();
                }
                return _CachedTokens;

            }

            set
            {
                _CachedTokens = value;
            }
        }
        private static Dictionary<String, TokenCache> _CachedTokens;


        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <param name="onlineLocator">The online locator.</param>
        /// <returns></returns>
        public static LocatorHub.LocatorHub CreateClient(OnlineLocator onlineLocator)
        {
            return LocatorManager.CreateClient(onlineLocator.Url, onlineLocator.Username, onlineLocator.Password, onlineLocator.Authentication, onlineLocator.TokenUrl);

        }

        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static LocatorHub.LocatorHub CreateClient(string url)
        {
            return LocatorManager.CreateClient(url, null, null, AuthenticationMode.None, null);
        }

        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="authenticationMode">The authentication mode.</param>
        /// <returns></returns>
        public static LocatorHub.LocatorHub CreateClient(string url, string username, string password, AuthenticationMode authenticationMode, string tokenUrl)
        {
            LocatorHub.LocatorHub client = new LocatorHub.LocatorHub();
            string locatorUrl  = url;

            if (locatorUrl.StartsWith("DATAHUB:"))
            {
                locatorUrl = locatorUrl.Replace("DATAHUB:", "");
                string token = LocatorManager.GetToken(LocatorManager.GetTokenUrlFromLocatorUrl(locatorUrl), DataHubConfiguration.Current.UserName, DataHubConfiguration.Current.Password);
                locatorUrl = String.Format("{0}?Token={1}", locatorUrl, token);
            }
            else
            {
                switch (authenticationMode)
                {

                    case AuthenticationMode.Token:
                        string locatorTokenURl = tokenUrl;
                        if (String.IsNullOrEmpty(locatorTokenURl))
                        {
                            locatorTokenURl = LocatorManager.GetTokenUrlFromLocatorUrl(url);
                        }
                        string token = LocatorManager.GetToken(locatorTokenURl, username, password);
                        locatorUrl = String.Format("{0}?Token={1}", url, token);
                        break;
                    case AuthenticationMode.Windows:
                        client.Credentials = new NetworkCredential(username, password);
                        break;
                    case AuthenticationMode.CurrentWindows:
                        client.Credentials = CredentialCache.DefaultNetworkCredentials;
                        break;
                }
            }
            

            client.Url = locatorUrl;

            return client;
        }

        private static string GetTokenUrlFromLocatorUrl(string url)
        {

            int lastSlashIndex = url.LastIndexOf('/');
            string baseUrl = url.Substring(0, lastSlashIndex);
            //fall back to non http rewritten url to ensure back compatibility
            string tokenUrl = String.Format("{0}/Rest.svc/GetToken", baseUrl);
            tokenUrl= tokenUrl.Trim();

            // Force the token URL to be HTTPS if not explicitly set otherwise.
            if (tokenUrl.StartsWith("http:", StringComparison.InvariantCultureIgnoreCase))
            {
                tokenUrl = "https:" + tokenUrl.Substring("http:".Length);
            }

            return tokenUrl;
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        private static string GetToken(string url, string username, string password)
        {
            string token = String.Empty;
            try
            {

                string tokenUrl = String.Format("{0}?username={1}&password={2}&format=pox", url, username, password);


                //Try and get token from the cache
                if (LocatorManager.CachedTokens != null && LocatorManager.CachedTokens.ContainsKey(tokenUrl))
                {
                    if (LocatorManager.CachedTokens[tokenUrl].IsValid())
                    {
                        token = LocatorManager.CachedTokens[tokenUrl].Token;
                    }
                    else
                    {
                        LocatorManager.CachedTokens.Remove(tokenUrl);
                    }
                }


                if (String.IsNullOrEmpty(token))
                {
                    WebRequest webRequest = WebRequest.Create(tokenUrl);
                    using (WebResponse webResponse = webRequest.GetResponse())
                    {
                        using (Stream byteStream = webResponse.GetResponseStream())
                        {
                            using (XmlTextReader xmlReader = new XmlTextReader(byteStream))
                            {
                                xmlReader.Read();
                                xmlReader.Read();
                                token = xmlReader.Value;
                                int duration = 0;
                                int.TryParse(token.Substring(0, 3), out duration);
                                TokenCache tokenCache = new TokenCache(token, DateTime.Now.AddMinutes(duration - 1).ToUniversalTime());
                                LocatorManager.CachedTokens.Add(tokenUrl, tokenCache);

                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return token;
        }

        #region Token Cache Class

        /// <summary>
        /// Represents a cached Token
        /// </summary>
        private class TokenCache
        {
            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="TokenCache"/> class.
            /// </summary>
            /// <param name="token">The token.</param>
            /// <param name="timeout">The timeout.</param>
            public TokenCache(string token, DateTime timeout)
            {
                this.Timeout = timeout;
                this.Token = token;
                this.Creation = DateTime.Now.ToUniversalTime();
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets or sets the timeout.
            /// </summary>
            /// <value>The timeout.</value>
            public DateTime Timeout { get; set; }

            /// <summary>
            /// Gets or sets the token.
            /// </summary>
            /// <value>The token.</value>
            public string Token { get; set; }


            /// <summary>
            /// Gets or sets the creation.
            /// </summary>
            /// <value>The creation.</value>
            public DateTime Creation { get; set; }

            #endregion

            #region Methods

            /// <summary>
            /// Determines whether this instance is valid.
            /// </summary>
            /// <returns>
            /// 	<c>true</c> if this instance is valid; otherwise, <c>false</c>.
            /// </returns>
            public bool IsValid()
            {
                //Check date hasnt been changed
                bool timeBeforeCreation = DateTime.Now.ToUniversalTime() >= this.Creation;
                return this.Timeout > DateTime.Now.ToUniversalTime() && timeBeforeCreation;
            }

            #endregion
        }

        #endregion
    }
}
