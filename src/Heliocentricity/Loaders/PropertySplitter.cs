using System;
using Heliocentricity.Common.Loaders;

namespace Heliocentricity.Loaders
{
    public class PropertySplitter : IPropertySplitter
    {
        public string GetKey(string keyValue)
        {
            return keyValue.Split(new[] {":"}, 2, StringSplitOptions.None)[0].Trim();
        }

        public string GetValue(string keyValue)
        {
            return keyValue.Split(new[] { ": " }, 2, StringSplitOptions.None)[1].Trim();
        }
    }
}