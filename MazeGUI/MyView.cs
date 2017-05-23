using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// MyView class
    /// </summary>
    class MyView : IView
    {
        private IController c;
        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="c"></param>
        public MyView(IController c)
        {
            this.c = c;
        }
        /// <summary>
        /// gets the command from the user
        /// </summary>
        /// <param name="s">the command string</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        public bool GetCommand(string s, TcpClient client)
        {
            return this.c.ExecuteCommand(s, client);
        }
        /// <summary>
        /// shows the result of the command
        /// </summary>
        /// <param name="s">the result of the command</param>
        /// <param name="client">the client who sent the request</param>
        public void ShowResult(string s, TcpClient client)
        {
            ///
        }
    }
}
