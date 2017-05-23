using System.Net.Sockets;

namespace ServerProgram
{
    /// <summary>
    /// IClientHandler interface.
    /// defines the fnctions that any client handler should have
    /// </summary>
    public interface IClientHandler
    {
        /// <summary>
        /// handles the clients requests
        /// </summary>
        /// <param name="client">te client who sends the requests</param>
        void HandleClient(TcpClient client);
    }
}