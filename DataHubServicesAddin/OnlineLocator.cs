using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataHubServicesAddin
{
    /// <summary>
    /// Utility Class, for an Online Locator
    /// </summary>
    public class OnlineLocator
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the gaz id.
        /// </summary>
        /// <value>
        /// The gaz id.
        /// </value>
        public string GazId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>
        /// The target.
        /// </value>
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the authentication.
        /// </summary>
        /// <value>
        /// The authentication.
        /// </value>
        public AuthenticationMode Authentication { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the token URL.
        /// </summary>
        /// <value>
        /// The token URL.
        /// </value>
        public string TokenUrl { get; set; }

        /// <summary>
        /// Gets or sets the comma-separated list of field names.
        /// </summary>
        /// <value>
        /// Comma-separated list of field names.
        /// </value>
        public string FieldNames { get; set; }

        public string[] FieldList()
        {
            return this.FieldNames.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Create a new OnlineLocator instance by cloning this one
        /// </summary>
        /// <returns>A clone of this OnlineLocator</returns>
        public OnlineLocator Clone()
        {
            OnlineLocator l = new OnlineLocator();
            l.Id = this.Id;
            l.Name = this.Name;
            l.Url = this.Url;
            l.GazId = this.GazId;
            l.Description = this.Description;
            l.Target = this.Target;
            l.Authentication = this.Authentication;
            l.Username = this.Username;
            l.Password = this.Password;
            l.TokenUrl = this.TokenUrl;
            l.FieldNames = this.FieldNames;
            return l;
        }
    }

    /// <summary>
    /// defines the types of authentication supported
    /// </summary>
    public enum AuthenticationMode
    {
        None,
        Token,
        Windows,
        CurrentWindows
    }
}
