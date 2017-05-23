using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// GenerateCommand class.
    /// delivering the mode the parameters to the generate command
    /// </summary>
   public class GenerateCommand : ICommand
    {
         private IModel model;
        /// <summary>
        /// class constructor.
        /// sets the model to work with
        /// </summary>
        /// <param name="model"></param>
        public GenerateCommand(IModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">the parameters received from the user</param>
        /// <param name="client">the client who sent the command</param>
        /// <returns>if we should close the connection or not</returns>
        public bool ExecuteCommand(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            return this.model.Generate(name, rows, cols, client);

        }
    }
}
