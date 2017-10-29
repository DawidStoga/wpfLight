using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirBusWPF
{
    /// <summary>
    /// Interaction logic for ShowNumberControl.xaml
    /// </summary>
    public partial class ShowNumberControl : UserControl
    {


        public int CurrentNumber
        {
            get { return (int)GetValue(CurrentNumberProperty); }
            set { SetValue(CurrentNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentNumberProperty =
            DependencyProperty.Register("CurrentNumber", typeof(int), typeof(ShowNumberControl), /* new PropertyMetadata(0)*/ new UIPropertyMetadata(0, new PropertyChangedCallback(CurrentNumberChanged)), (value)=>{ if (Convert.ToInt32(value) >= 0 && Convert.ToInt32(value) <= 500) return true; else return false; });

        private static void CurrentNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ShowNumberControl c = (ShowNumberControl)d;
            Label theLabel = c.numberDisplay;
            theLabel.Content = e.NewValue.ToString();
        }

        public ShowNumberControl()
        {
            InitializeComponent();
        }

        private void myRect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            myRect.Fill = Brushes.Red;
        }
        /*  // A normal, everyday .NET property.
 private int _currNumber = 0;
 public int CurrentNumber
 {
     get { return _currNumber; }
     set
     {
         _currNumber = value;
         numberDisplay.Content = CurrentNumber.ToString();
     }
 }*/
    }
}
