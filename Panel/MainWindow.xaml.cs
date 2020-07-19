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

namespace Panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            //Execute.MouseUp += new MouseButtonEventHandler(handleExecute);
        }

        public void handleExecute(object sender, RoutedEventArgs e) {

            //MessageBox.Show("You clicked");



        }

        public void Find(object sender, RoutedEvent e)
        {
            //object command = StackPanel.FindName("cmd");
        }
    }

    
}
