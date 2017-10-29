using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace AirBusWPF.Design
{

    class WPFObj:DispatcherObject
    {
        public WPFObj():base()
        {
           
        }
     


    }

    class WPFTech
    {
        WPFObj myWPFobj = new WPFObj();
        DependencyObject obj = new DependencyObject();

        Visual vis;


        void Test()
        {
            vis = new UIElement();
             
           
        }
    }
}
