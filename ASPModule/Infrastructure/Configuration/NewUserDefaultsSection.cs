using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASPModule.Infrastructure.Configuration
{
    public class NewUserDefaultsSection:ConfigurationSection
    {

        [ConfigurationProperty("city",IsRequired = true)]
        [CallbackValidator(CallbackMethodName = "ValidateCity",Type = typeof(NewUserDefaultsSection))]
        public string City
        {
            get { return (string) this["city"]; }
            set { this["city"] = value; }
        }
        [ConfigurationProperty("country", DefaultValue = "POL")]
        public string Country
        {
            get { return (string)this["country"]; }
            set { this["country"] = value; }
        }
        [ConfigurationProperty("language")]
        public string Language
        {
            get { return (string)this["language"]; }
            set { this["language"] = value; }
        }
        [ConfigurationProperty("regionCode")]
        [IntegerValidator(MaxValue = 5, MinValue = 0)]
        public int Region
        {
            get { return (int)this["regionCode"]; }
            set { this["regionCode"] = value; }
        }

        public static void ValidateCity(object candidateValue)  //must be static, returm void and take one parameter of object type
        {
            if ((string) candidateValue == "Warszawa")
            {
                throw new Exception("Unsoported City Value");
            }
        }

    }
}