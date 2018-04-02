using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASPModule.Infrastructure.Configuration
{
    public class FeatureCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
           return  new Feature();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Feature) element).Code;
        }

        public new Feature this[string key]
        {
            get { return (Feature) BaseGet(key); }
        }
    }
}