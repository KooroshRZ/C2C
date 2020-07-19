using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Panel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application{

        public App(){
            this.Server();
            Window mainWindows = new MainWindow();
            MainWindow.Show();
        }

        public int Server()
        {

            // server socket here
            MessageBox.Show("I'm server");
            return 0;
        }

    }

    
}
