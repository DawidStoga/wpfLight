using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTheme
{
   public  class DataCommands
    {
        private static RoutedUICommand requery;
        static DataCommands()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new MouseGesture(MouseAction.RightClick, ModifierKeys.Control));
            requery = new RoutedUICommand("Requery", "RequeryN", typeof(DataCommands), inputs);

        }

        public static RoutedUICommand Requery { get { return requery; } }
    }
}
