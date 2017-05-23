using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{/// <summary>
/// a CloseCommand class
/// telling the model to close a multiplayer game
/// </summary>
    public class CloseCommand : ICommand
    {
        IModel model;
        /// <summary>
        /// class constructo
        /// sets the model to work with
        /// </summary>
        /// <param name="model"></param>
        public CloseCommand(IModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// executes the close command
        /// the function gets the name of the game to close and sends it to the model
        /// </summary>
        /// <param name="args">the parameters</param>
        /// <param name="client"> the client who requested to close the game</param>
        /// <returns>if we should close the connection between the client and the server</returns>
        public bool ExecuteCommand(string[] args, TcpClient client = null)
        {
            string name = args[0];
            return this.model.close(name,client);
        }
    }
}
