using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// STartCommnd class
    /// </summary>
    class StartCommand : ICommand
    {
        private IModel model;
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="model">the model</param>
        public StartCommand(IModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// executing the command
        /// </summary>
        /// <param name="args">the parqameters</param>
        /// <param name="client">the client who sent the command</param>
        /// <returns></returns>
        public bool ExecuteCommand(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            return   this.model.Start(name, rows, cols, client);
        }
    }
}
