using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASPModule.Infrastructure.Configuration
{
    public class FeatureSection:ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(FeatureCollection))]
        public FeatureCollection Features
        {
            get { return (FeatureCollection)base[""]; }
        }
        [ConfigurationProperty("default")]
        public string Default
        {
            get { return (string)base["default"]; }
            set { base["default"] = value; }
        }

    }
}