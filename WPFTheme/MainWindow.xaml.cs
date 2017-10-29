using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WPFTheme
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _mouseActivity = string.Empty;
        List<BitmapImage> _images = new List<BitmapImage>();
        private int _currImage = 0;
        private const int MAX_IMAGES = 4;
        
     
        public MainWindow()
        {
            /* PlaneDP f35 = new PlaneDP()
             {
                 Altitude = 1500,
                 Distance = 28000,
                 Fuel = 85,
                 Load = 24

             };*/
            
            InitializeComponent();
          //  SetCommandBindings();
            SetBindings();
        }

        private void SetCommandBindings()
        {
            CommandBinding cmdBind = new CommandBinding(ApplicationCommands.Help);
            cmdBind.CanExecute += CmdBind_CanExecute;
            cmdBind.Executed += CmdBind_Executed;

            CommandBindings.Add(cmdBind);
           
        }

        private void CmdBind_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("CmdBind_Executed", "Help!");
        }

        private void CmdBind_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SetBindings()
        {
            Binding bind = new Binding();
         //   bind.Converter = new MyIntConverter();
            bind.Source = this.slider;
            bind.Path = new PropertyPath("Value");

            this.BindLabel.SetBinding(Label.ContentProperty, bind);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object res = this.Resources["plane"];
            PlaneDP plane = res as PlaneDP;
            if(plane!=null)
            {
                MessageBox.Show(plane.Altitude.ToString());
            }
            else
            {
                MessageBox.Show(this.xmlPlane.Altitude.ToString());
            }
          //  plane.Altitude = 21;
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.xmlPlane.Altitude = 7;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.xmlPlane.ClearValue(PlaneDP.AltitudeProperty);
        }

        private void btnClickMe_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked the button");
            AddEventInfo(sender, e);
            AddEventInfo(sender, e);
            MessageBox.Show(_mouseActivity, "Your Event Info");
            // Clear string for next round.
            _mouseActivity = "";
        }

        private void outerEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Title = "You clicked the outer ellipse!";
            e.Handled = true ;
            AddEventInfo(sender, e);
          
            

        }
        private void AddEventInfo(object sender, RoutedEventArgs e)
        {
            _mouseActivity += string.Format(
            "{0} sent a {1} event named {2}.\n", sender,
            e.RoutedEvent.RoutingStrategy,
            e.RoutedEvent.Name);
        }

        private void outerEllipse_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddEventInfo(sender, e);
        }

        private void xmlPlane_Exceed(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(sender.ToString() + e.Source.ToString());
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Binding in XAML");
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Custom Command");
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            /* OpenFileDialog openFile = new OpenFileDialog();
             if (openFile.ShowDialog() == true)
                 {
                 XDocument doc = XDocument.Load(openFile.FileName);
                 }
                 */
 string pathXML = @"E:\Projecty NET\wpfLight\WPFTheme\Content\plant_catalog.xml";
          
           //  Stream xmlStream = Application.GetResourceStream(new Uri(pathXML, UriKind.Relative)).Stream;


            DataSet ds = new DataSet();
            ds.ReadXml(pathXML);
      //      xmlGrid.ItemsSource = ds.Tables[0].DefaultView;

            XDocument doc=   XDocument.Load(pathXML);
            var result = (from plant in doc.Descendants("PLANT")
                          where ((string)plant.Element("LIGHT").Value).Equals("Mostly Sunny")
                          select new
                          {
                              Name = plant.Element("COMMON").Value,
                              QNT = plant.Element("AVAILABILITY").Value
                          }).ToList();

            xmlGrid.ItemsSource= result;
            XMLLoader.Text = doc.ToString();

        }

        private void btnPreviousImage_Click(object sender, RoutedEventArgs e)
        {
            if (--_currImage < 0)
                _currImage = MAX_IMAGES-1;
            imageHolder.Source = _images[_currImage];
        }

        private void btnNextImage_Click(object sender, RoutedEventArgs e)
        {
            if (++_currImage >= MAX_IMAGES)
                _currImage = 0;
            imageHolder.Source = _images[_currImage];
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                string path = Environment.CurrentDirectory;
                // Load these images when the window loads.
               bool t =  Uri.IsHexDigit('a');
              
                
                _images.Add(new BitmapImage(new Uri($@"{path}\Content\Car1.jpg")));
                _images.Add(new BitmapImage(new Uri($@"{path}\Content\Car2.jpg")));

                Uri uriCar = new Uri(@"/ContentBin/Car3.jpg", UriKind.Relative);
                _images.Add(new BitmapImage(uriCar));
                uriCar = new Uri(@"/ContentBin/Car4.jpg", UriKind.Relative);
                _images.Add(new BitmapImage(uriCar));

                imageHolder.Source = _images[0];
            }
            catch(Exception ex)  {
                MessageBox.Show(ex.Message);
            }
        }

     

        private void ChangeResource_Click(object sender, RoutedEventArgs e)
        {
           
         /*   var rdb = (RadialGradientBrush)Resources["myBrush"];
            if (rdb.GradientStops[1].Color != Colors.GreenYellow)
            {
                rdb.GradientStops[1] = new GradientStop(Colors.GreenYellow, 0.1);
            }
            else
            {
                rdb.GradientStops[1] = new GradientStop(Colors.Gray, 0.2);
            }
            */
            Resources["myBrush"] = new SolidColorBrush(Colors.Red);

        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
          
           var  dblAnim = new DoubleAnimation();
            dblAnim.Completed += (o, s) => { };
            dblAnim.From = 60;
            dblAnim.To = 507;
            dblAnim.By = 60;
            dblAnim.Duration = new Duration(TimeSpan.FromMilliseconds(600));
            dblAnim.RepeatBehavior = new RepeatBehavior(3);

// Reverse when done.
            dblAnim.AutoReverse = true;
            animBtn.BeginAnimation(Button.WidthProperty, dblAnim);
        }

    
    }
}
