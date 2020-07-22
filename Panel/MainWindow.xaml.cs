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
using System.Threading;

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
        public int clientIndex = 0;
        

        public MainWindow(){

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
        
        void worker_ExecuteServer(object sender, DoWorkEventArgs e)
        {

            IPAddress ipAddress = IPAddress.Parse("192.168.1.102");

            TcpListener serverSocket = null;

            try
            {
                
                serverSocket = new TcpListener(ipAddress, 20000);
                //clientSockets[clientIndex] = default(TcpClient);
                serverSocket.Start();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            
            
            while (true) {

                
                clientSockets[clientIndex] = serverSocket.AcceptTcpClient();
                (sender as BackgroundWorker).ReportProgress(0);
                Thread.Sleep(10);
            }
            

        }

        void worker_NewClient(object sender, ProgressChangedEventArgs e) {
            
            clientIPAddress = "" + IPAddress.Parse(((IPEndPoint)clientSockets[clientIndex].Client.RemoteEndPoint).Address.ToString());

            Client client = new Client();
            client.clientIndex = clientIndex;
            client.clientIPAddress = clientIPAddress;
            client.clientSocket = clientSockets[clientIndex];
            client.mainWindow = this;

            clients[clientIndex] = client;
            

            TextBlock newHost = new TextBlock();
            
            newHost.Text = clientIPAddress;
            //newHost.Name = "client_" + clientIPAddress.Replace(".", "");

            newHost.Name = "client_" + clientIndex.ToString();
            newHost.Text = client.clientIPAddress;
            Hosts.Children.Add(newHost);
            Hosts.RegisterName(newHost.Name, newHost);
            

            newHost.MouseUp += client.handleClient;

            clientIndex++;

        }
        

    }

    
}
