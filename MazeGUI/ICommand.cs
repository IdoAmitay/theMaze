using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// ICommand interface
    /// defines the functions the any command should have
    /// </summary>
    
   public interface ICommand
    {
        /// <summary>
        /// executeds the command
        /// </summary>
        /// <param name="args">the parameters to work with</param>
        /// <param name="client">the client who sent the command</param>
        /// <returns></returns>
        bool ExecuteCommand(string [] args, TcpClient client = null);
    }
}
