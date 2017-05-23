using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// ListCommand class
    /// sending the parameters to the list command in the model
    /// </summary>
   public class ListCommand:ICommand
    {
        private IModel model;
        /// <summary>
        /// class constructor
        /// setting the model to work with
        /// </summary>
        /// <param name="m"></param>
        public ListCommand(IModel m)
        {
            this.model = m;
        }
        /// <summary>
        /// executes the command
        /// </summary>
        /// <param name="args">the parameters</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        public bool ExecuteCommand(string[] args, TcpClient client = null)
        {
           return this.model.List(client);
        }
    }
}
