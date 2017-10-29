using System.Windows;
using AirBusWPF.ViewModel;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Controls;
using System;
using System.Windows.Input;

namespace AirBusWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<BitmapImage> _images = new List<BitmapImage>();
        

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            CommandBinding binding = new CommandBinding(ApplicationCommands.Open);
            binding.Executed += Binding_Executed;
            this.CommandBindings.Add(binding);
            InitializeComponent();
            label1.Content = "text 3";
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void Binding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show(e.Source.ToString());
        }

        private void clickElipse_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show(this.DataContext.ToString());

        }

        private void dataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dblAnim = new DoubleAnimation
            {
                From = 1.0,
                To = 0.4
            };
            dblAnim.AutoReverse = true;
            Btn.BeginAnimation(Button.OpacityProperty, dblAnim);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path = System.Environment.CurrentDirectory;
            string FullPath = path + @"\Images\20170125_185637.jpg";
            // "E:\\Projecty NET\\wpfLight\\AirBusWPF\\bin\\Debug\\Images\\20170125_185637.jpg"
            //   E:\Projecty NET\wpfLight\AirBusWPF\bin\Debug\Images\20170125_185637.jpg
            _images.Add(new BitmapImage(new System.Uri(FullPath)));
            imageHolder.Source = _images[0];

        }

        private bool _isSpinning = false;
        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!_isSpinning)
            {
                var dblAnim = new DoubleAnimation();
                dblAnim.Completed += (o, s) => { _isSpinning = false;  };
                dblAnim.Duration = new Duration(timeSpan: TimeSpan.FromSeconds(4));
                dblAnim.From = 0;
                dblAnim.To = 360;

                var rt = new RotateTransform();
                Btn.RenderTransform = rt;
                rt.BeginAnimation(RotateTransform.AngleProperty, dblAnim);


            }
        
        }
    }
}