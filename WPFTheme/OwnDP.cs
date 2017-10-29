using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace WPFTheme
{

    public class MyIntConverter : IValueConverter
    {
       

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var d = (double)value;
           
            return (int)d;
          //  return value.ToString() ;
           // return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { 
             var str =  (string)value;
              int result = 0;
              Int32.TryParse(str, out result);
            return result;
        }
    }

   public  class  SampleDP : FrameworkElement
    {
  

        static SampleDP()
        {
            FrameworkPropertyMetadata pm = new FrameworkPropertyMetadata();


            HighDependencyProperty = DependencyProperty.Register(
                        name: "High",
                        propertyType: typeof(int),
                        ownerType: typeof(SampleDP));


            WidthDependencyProperty = DependencyProperty.Register(
       name: "Width",
       propertyType: typeof(string),
       ownerType: typeof(SampleDP),
       typeMetadata: new PropertyMetadata("default", (o, e) =>
       {
           MessageBox.Show(e.ToString());
       })
       , validateValueCallback: new ValidateValueCallback(o =>
       {
           return true; /*!((string)o).Contains("daw");*/
       }));

        }

        public static readonly DependencyProperty HighDependencyProperty;
        public int High
        {
            get { return (int)base.GetValue(HighDependencyProperty); }
            set { SetValue(HighDependencyProperty, value); }
        }



        public static readonly DependencyProperty WidthDependencyProperty;
        public string Width
        {
            get { return (string)base.GetValue(WidthDependencyProperty); }
            set { SetValue(WidthDependencyProperty, value); }
        }


        private string hello;

        public string Hello
        {

            get { return hello; }
            set { hello = value; }
        }
    }

    public class PlaneDP: FrameworkElement, ICommandSource
    {
        public ICommand Command { get; set; }// => throw new NotImplementedException();

        public object CommandParameter { get; set; }

        public IInputElement CommandTarget { get; set; }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
         
        }

        static   void ChangedCB(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
           // (o as PlaneDP).Altitude = (int)e.NewValue;

            if ((int)e.OldValue == 6)
            {
              (o as PlaneDP).Altitude = 1;
            }
            if ((int)e.OldValue == 8)
            {
                
                

            }

        }
        static PlaneDP()
        {
            FrameworkPropertyMetadata fpm = new FrameworkPropertyMetadata();
            fpm.PropertyChangedCallback = ChangedCB;
            fpm.BindsTwoWayByDefault = true;
            fpm.DefaultValue = 0;


            PropertyChangedCallback pcc = ChangedCB;
            PropertyMetadata pm = new PropertyMetadata(0,
                (o, d) => { MessageBox.Show("Changed 1"); },
                (o, d) => {/* MessageBox.Show("Changed 2");*/ return 0; }
                );
            // FrameworkPropertyMetadata fpm = new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.None, (o, d) => { }, (o,d)=>{ return false; });

            ValidateValueCallback validate = new ValidateValueCallback(value => { return (int)value >= 0; });




            AltitudeProperty = DependencyProperty.Register(
                name: "Altitude",
                propertyType: typeof(int),
                ownerType: typeof(PlaneDP)
               ,
               typeMetadata: fpm,
               validateValueCallback: validate);
            //MaxDistanceProperty = DependencyProperty.Register("Distance", typeof(int), typeof(PlaneDP), fpm, validate);
            //FuelLevelProperty   = DependencyProperty.Register("FuelLevel",typeof(int), typeof(PlaneDP), fpm, validate);
            //  CurrentLoadProperty = DependencyProperty.Register("Load", typeof(int), typeof(PlaneDP), fpm, validate);


            PlaneDP.ExceedEvent = EventManager.RegisterRoutedEvent(
                "Exceed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SampleDP));
        }

            public event RoutedEventHandler Exceed
            {
            add   { base.AddHandler(PlaneDP.ExceedEvent, value); }
            remove { base.RemoveHandler(PlaneDP.ExceedEvent, value); }
            }

        public override void BeginInit()
        {
            base.BeginInit();
            RaiseEvent(new RoutedEventArgs(PlaneDP.ExceedEvent, this));
        }


        public static readonly DependencyProperty AltitudeProperty;
        public static readonly RoutedEvent ExceedEvent;


        public int Altitude
        {
            get { return (int)base.GetValue(AltitudeProperty); }
            set {  /*Do not validate here  - before SetValue ! */SetValue(AltitudeProperty, value); }
        }
#if false
        public readonly static DependencyProperty MaxDistanceProperty;
        public int Distance
        {
            get { return (int)base.GetValue(MaxDistanceProperty); }
            set { base.SetValue(MaxDistanceProperty, value); }
        }

        public readonly static DependencyProperty FuelLevelProperty;
        public int FuelLevel
        {
            get { return (int)base.GetValue(FuelLevelProperty); }
            set { base.SetValue(FuelLevelProperty, value); }
        }

        public readonly static DependencyProperty CurrentLoadProperty;
         public int Load
        {
            get { return (int)base.GetValue(CurrentLoadProperty); }
            set { base.SetValue(CurrentLoadProperty, value); }
        }

#endif
    }
}
