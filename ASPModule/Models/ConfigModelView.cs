using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASPModule.Models
{
    public class ConfigModelView
    {
        public NameValueCollection AppSettings { get; set; }
        public ConnectionStringSettingsCollection ConnectionStrings { get; set; }

    }
}