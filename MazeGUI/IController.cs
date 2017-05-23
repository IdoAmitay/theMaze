using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// IController interface
    /// defines the functions that any controller should have
    /// </summary>
   public interface IController
    {
        /// <summary>
        /// setting the model to work with
        /// </summary>
        /// <param name="m">the model</param>
         void SetModel(IModel m);
        /// <summary>
        /// setting the view to work with
        /// </summary>
        /// <param name="v">the view to work with</param>
         void SetView(IView v);
        /// <summary>
        /// executing a command
        /// </summary>
        /// <param name="command">the command</param>
        /// <param name="client">the client who sent the command</param>
        /// <returns></returns>
        bool ExecuteCommand(string command, TcpClient client);
        /// <summary>
        /// handles with a changed data
        /// </summary>
        /// <param name="data">the data that has changed</param>
        /// <param name="client">the client that should receive the new data</param>
        void DataHasChanged(string data, TcpClient client);
    }
}
