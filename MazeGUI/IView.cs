using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// IView interface
    /// defines the functions that any view should have
    /// </summary>
   public interface IView
    {
        /// <summary>
        /// gets the command from the user
        /// </summary>
        /// <param name="s">the command string</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        bool GetCommand(string s, TcpClient client);
        /// <summary>
        /// shows the result of the command
        /// </summary>
        /// <param name="s">the result of the command</param>
        /// <param name="client">the client who sent the request</param>
        void ShowResult(string s, TcpClient client);
    }
}
