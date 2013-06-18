using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataHubServicesAddin
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Extension method on String to convert to Double
        /// </summary>
        /// <param name="theDouble">The double.</param>
        /// <returns>a double</returns>
        /// <remarks>creates a ToDouble() method on string</remarks>
        public static Double ToDouble(this string theDouble)
        {
            return System.Convert.ToDouble(theDouble);
        }
    }
}
