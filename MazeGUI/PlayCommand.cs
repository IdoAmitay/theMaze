using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// PlayCommand class
    /// </summary>
   public class PlayCommand:ICommand
    {
        private IModel model;
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="model">the model to work with</param>
        public PlayCommand(IModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// executing the command
        /// </summary>
        /// <param name="args">the parameters</param>
        /// <param name="client">the client who sent the command</param>
        /// <returns></returns>
        public bool ExecuteCommand(string[] args, TcpClient client = null)
        {
            string move =args[0];
            return this.model.play(move, client);
        }

        
    }
}
