using System.Windows;
using GalaSoft.MvvmLight.Threading;
using System;

namespace AirBusWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
        static App()
        {
           
            Environment.ExitCode = 0x214;

            DispatcherHelper.Initialize();
        }
    }
}
