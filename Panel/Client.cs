using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Panel
{
    public class Client {
        

        public string clientIPAddress;
        public int clientIndex;
        public string clientCommand;
        public TcpClient clientSocket;

        public string command;
        public string arg0;
        public string arg1;
        public string password;

        public MainWindow mainWindow;

        public void handleClient(object sender, System.EventArgs e) {
            
            
            this.command = mainWindow.commandTextBox.Text;
            this.arg0 = mainWindow.arg0TextBox.Text;
            this.arg1 = mainWindow.arg1TextBox.Text;
            this.password = mainWindow.passwordTextBox.Text;

            MessageBox.Show(this.command);

            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(this.command + "\n" + this.arg0 + "\n" + this.arg1 + "\n" + this.password + "\n");

            string dataBase64 = System.Convert.ToBase64String(data);
            string messageSize = dataBase64.Length.ToString();

            NetworkStream stream = this.clientSocket.GetStream();

            stream.Write(System.Text.Encoding.ASCII.GetBytes(messageSize), 0, messageSize.Length);
            stream.Write(System.Text.Encoding.ASCII.GetBytes(dataBase64), 0, dataBase64.Length);

        }

    }

}
