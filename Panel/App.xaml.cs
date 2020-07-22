using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Panel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        public MainWindow mainWindow;

        /*protected override void OnStartup(StartupEventArgs e) {

            mainWindow = new MainWindow();
            mainWindow.Title = "C&C Panel";
            MainWindow.Show();
            
        }*/
    
        private void Panel_Startup(object sender, StartupEventArgs e) {

            mainWindow = new MainWindow();
            mainWindow.Title = "C&C Panel";
            MainWindow.Show();

        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e){

            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;

        }
        

    }

}
