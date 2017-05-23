using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// SolveCommand class
    /// </summary>
    class SolveCommand: ICommand
    {
        private IModel model;
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="model">the model</param>
        public SolveCommand(IModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// executes the command
        /// </summary>
        /// <param name="args">the parameters</param>
        /// <param name="client">the client who sent the command</param>
        /// <returns></returns>
        public bool ExecuteCommand(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int algorithm = int.Parse(args[1]);
           return  this.model.Solve(name, algorithm,client);
        }
    }
}
