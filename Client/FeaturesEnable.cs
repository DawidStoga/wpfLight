using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{

    public enum ImplementedFeatures
    {
        [Feature(Enabled = true)]
        None = 0,
        [Feature(Enabled = false)]
        Enviroment,
        [Feature(Enabled = true)]
        ConsoleClass,
        [Feature(Enabled = true)]
        SystemDataTypes,
        [Feature(Enabled = true)]
        StringData,
        [Feature(Enabled = true)]
        NarrowingConversion,
        [Feature(Enabled = true)]
        ImplicitlyTypes,
        [Feature(Enabled = true)]
        Decision_Constructs
    }

    public class FeatureAttribute:Attribute
    {
        public bool Enabled { get; set; } = false;
    }
    
}
