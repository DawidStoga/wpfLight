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
using AirPlaneMVVM.Model;
using Domain;
using System.Collections.ObjectModel;

namespace AirPlaneMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        public ObservableCollection<Aircraft> AirCrafts;    
        public MainWindow()
        {
          
         
                AirCrafts = new ObservableCollection<Aircraft> {
                new Aircraft { AircraftID = 1, Name ="Test", Category = "dsd", Description = "dwsdw" },
                new Aircraft { AircraftID = 12, Name = "test2", Category = "dsd2", Description = "dwsdw2" } };//new EFconcrete().GetPlanes);

           

            InitializeComponent();


            cboPlanes.ItemsSource = AirCrafts;//EntityObservable.AirCrafts;
            //  cboPlanes.ItemsSource =  EntityObservable.AirCrafts;
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            var car = AirCrafts.FirstOrDefault(x => x.Name == ((Domain.Aircraft)cboPlanes.SelectedItem)?.Name);
            if (car != null)
            {
                car.Type += "Pink";
            }
        }
    }
}
