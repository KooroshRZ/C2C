using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace Panel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application{

        public Window mainWindows;

        public App(){
            
            mainWindows = new MainWindow();
            MainWindow.Show();
            this.ExecuteServer();
        }

        public void ExecuteServer()
        {

            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndpoint = new IPEndPoint(ipAddr, 11111);

            Socket listener = new Socket(ipAddr.AddressFamily,
                 SocketType.Stream, ProtocolType.Tcp);

            try {

                listener.Bind(localEndpoint);
                listener.Listen(10);

                while (true)
                {

                    Console.WriteLine("Waiting connection ... ");
                    
                    Socket clientSocket = listener.Accept();

                    //mainWindows.
                    //mainWindows.

                    // Data buffer 
                    byte[] bytes = new Byte[1024];
                    string data = null;

                    while (true)
                    {

                        int numByte = clientSocket.Receive(bytes);

                        data += Encoding.ASCII.GetString(bytes,
                                                   0, numByte);

                        if (data.IndexOf("<EOF>") > -1)
                            break;
                    }

                    Console.WriteLine("Text received -> {0} ", data);
                    byte[] message = Encoding.ASCII.GetBytes("Test Server");
                    
                    clientSocket.Send(message);
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();

                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }

    
}
