using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// IModel interface
    /// defines the functions that any model should have
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Generating new maze
        /// </summary>
        /// <param name="name">maze name</param>
        /// <param name="rows">number of rows</param>
        /// <param name="cols">nuber of cols</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        bool Generate(string name, int rows, int cols, TcpClient client);
        /// <summary>
        /// Solvding a mmaze
        /// </summary>
        /// <param name="name">the mazes name</param>
        /// <param name="algorithm">the algorithm to use to solve the maze: 0-BFS, 1-DFS</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        
        bool Solve(string name, int algorithm, TcpClient client);
        /// <summary>
        /// starting a multiplayer game
        /// </summary>
        /// <param name="name">the name of the game</param>
        /// <param name="rows">the number of rows</param>
        /// <param name="cols">the number of cols</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        bool Start(string name, int rows, int cols,TcpClient client);
        /// <summary>
        /// returning a list of all the available multiplayer games
        /// </summary>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        bool List(TcpClient client);
        /// <summary>
        /// joining to an available multiplayer game
        /// </summary>
        /// <param name="name">the name of the game to join</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        bool Join(string name, TcpClient client);
        /// <summary>
        /// playing a move in a multiplayer game
        /// </summary>
        /// <param name="move">the move to play</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        bool play(string move,TcpClient client);
        /// <summary>
        /// closes a multiplayer game
        /// </summary>
        /// <param name="name">the game's name</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        bool close(string name, TcpClient client);
        /// <summary>
        /// setting the controller to work with
        /// </summary>
        /// <param name="c">the controller</param>
        void SetController(IController c);
        /// <summary>
        /// setting the generator to work with
        /// </summary>
        /// <param name="generator">the generator</param>
        void SetGenerator(MazeGeneratorLib.IMazeGenerator generator);

    }
}
