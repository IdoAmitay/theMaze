using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// Server calss
    /// </summary>
    class Server
    {
        private int port;
        string s = ConfigurationManager.AppSettings["ServerIP"].ToString();
        private TcpListener listener;
        private IClientHandler clientHandler;
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="port">the port</param>
        /// <param name="clientHandler">the client handler</param>
        public Server(int port, IClientHandler clientHandler)
        {
            this.port = port;
            this.clientHandler = clientHandler;
        }
        /// <summary>
        /// starts the work of the server
        /// </summary>
        public void Start()
        {
            IPEndPoint endP = new IPEndPoint(IPAddress.Parse(s), port);
            listener = new TcpListener(endP);
            listener.Start();
            //handles a client until the connection is off
            Task task = new Task(() => {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        //hsndling the client
                        this.clientHandler.HandleClient(client);
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
                Console.WriteLine("Server stopped");
            });
            task.Start();

        }
       
       
        /// <summary>
        /// stop the listening of the server
        /// </summary>
        public void Stop()
        {
            this.listener.Stop();
        }

    }
}
