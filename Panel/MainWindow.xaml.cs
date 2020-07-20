using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
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

        TcpClient[] clientSockets;
        Client[] clients;

        string clientIPAddress;
        int clientIndex = 0;


        public MainWindow()
        {

            InitializeComponent();

            clientSockets = new TcpClient[100];
            clients = new Client[100];

            BackgroundWorker serverWorker = new BackgroundWorker();
            serverWorker.WorkerReportsProgress = true;
            serverWorker.DoWork += worker_ExecuteServer;
            serverWorker.ProgressChanged += worker_NewClient;
            //serverWorker.RunWorkerCompleted += worker_RunWorkerCompleted;
            serverWorker.RunWorkerAsync(10000);

            

        }


        public void listHosts(object sender, RoutedEventArgs e){

            

        }

        void worker_ExecuteServer(object sender, DoWorkEventArgs e)
        {

            IPAddress ipAddress = IPAddress.Parse("192.168.101.193");
            TcpListener serverSocket = new TcpListener(ipAddress, 10000);
            clientSockets[clientIndex] = default(TcpClient);
            serverSocket.Start();
            

            while (true) {

                clientSockets[clientIndex] = serverSocket.AcceptTcpClient();
                (sender as BackgroundWorker).ReportProgress(0);

            }
            

        }

        void worker_NewClient(object sender, ProgressChangedEventArgs e) {

            clientIPAddress = "" + IPAddress.Parse(((IPEndPoint)clientSockets[clientIndex].Client.RemoteEndPoint).Address.ToString());

            Client client = new Client();
            client.clientIndex = clientIndex;
            client.clientIPAddress = clientIPAddress;

            clients[clientIndex] = client;
            

            TextBlock newHost = new TextBlock();
            
            newHost.Text = clientIPAddress;
            //newHost.Name = "client_" + clientIPAddress.Replace(".", "");

            newHost.Name = "client_" + clientIndex.ToString();
            newHost.Text = client.clientIPAddress;
            Hosts.Children.Add(newHost);
            Hosts.RegisterName(newHost.Name, newHost);

            clientIndex++;

        }
        

    }

    
}
