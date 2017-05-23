using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// JoinCommand class
    /// sending to the model the parameters to the join function
    /// </summary>
    class JoinCommand : ICommand
    {
        private IModel model;
        /// <summary>
        /// class constructor.
        /// defines the model to work with
        /// </summary>
        /// <param name="model"></param>
        public JoinCommand(IModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// executes the commannd
        /// </summary>
        /// <param name="args">the parameters</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns></returns>
        public bool ExecuteCommand(string[] args, TcpClient client = null)
        {
            string name = args[0];
           return  this.model.Join(name,client);
        }
    }
}
