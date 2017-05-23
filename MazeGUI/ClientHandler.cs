using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// client handler class
    /// handles the client's requests
    /// </summary>
    class ClientHandler : IClientHandler,IView
    {   
        private bool continueConnection;
        private IController c;
        /// <summary>
        /// class constructor
        /// </summary>
	public ClientHandler()
        {
            this.continueConnection = true;
        }
        /// <summary>
        /// setting the controller 
        /// </summary>
        /// <param name="c"> the controller </param>
	public void SetController(IController c)
        {
            this.c = c;

        }
        /// <summary>
        /// handking the clients request
        /// </summary>
        /// <param name="client"> the client who sent the request</param>
        public void HandleClient(TcpClient client)
        {
            //task that reads the client's command and executing the suitable task;
            new Task(() =>
            {
                NetworkStream stream = client.GetStream();
                StreamReader sreader = new StreamReader(stream);
                BinaryWriter bwriter = new BinaryWriter(stream);

                
                    do
                    {
                        try
                        {
                            string commandLine = sreader.ReadLine();
                            Console.WriteLine("Got command: {0}", commandLine);
                            continueConnection = this.c.ExecuteCommand(commandLine, client);
                        }
                        catch (SocketException)
                        {
                            break;
                        }



                    } while (continueConnection);
                    client.Close();
            }).Start();
        }
        /// <summary>
        /// getting the command fron the user
        /// </summary>
        /// <param name="s"> the command string</param>
        /// <param name="client">the client who set the command</param>
        /// <returns>if the connection should be closed or not</returns>
        public bool GetCommand(string s, TcpClient client)
        {
            return this.c.ExecuteCommand(s, client);
        }
        /// <summary>
        /// function that shows the result of the request to the client
        /// </summary>
        /// <param name="s">the result string</param>
        /// <param name="client"> the client who is going to receive the result</param>
        public void ShowResult(string s, TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            StreamReader sreader = new StreamReader(stream);
            BinaryWriter bwriter = new BinaryWriter(stream);
            bwriter.Write(s);
        }
    }
}
