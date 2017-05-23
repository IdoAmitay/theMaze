using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace ServerProgram
{
    /// <summary>
    /// MyModel class
    /// </summary>
    /// <typeparam name="T">the type of information that the model will work with</typeparam>
    public class MyModel<T> : IModel
    {
        private IController c;
        private ISearcher<T> searcher;
        private MazeGeneratorLib.IMazeGenerator generator;
        private Dictionary<ISearchable<T>, MazeSolution> singleGameMaze;
        private Dictionary<ISearchable<T>, List<TcpClient>> multiPlayerGame;
        private Dictionary<ISearchable<T>, string> gamesNames;
        /// <summary>
        /// class constructor
        /// </summary>
        public MyModel()
        {
          
            this.singleGameMaze = new Dictionary<ISearchable<T>, MazeSolution>();
            this.multiPlayerGame = new Dictionary<ISearchable<T>, List<TcpClient>>();
            this.gamesNames = new Dictionary<ISearchable<T>, string>();
        }
        /// <summary>
        /// setting the controller to work with
        /// </summary>
        /// <param name="c">the controller</param>
        public void SetController (IController c)
        {
            this.c = c;
        }
        /// <summary>
        /// setting the searcher to solve a maze with
        /// </summary>
        /// <param name="searcher">the searcher</param>
        public void setSeasrcher(ISearcher<T> searcher) 
        {
            this.searcher = searcher;
        }
        /// <summary>
        /// joining to an available multiplayer game
        /// </summary>
        /// <param name="name">the name of the game to join</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        public bool Join(string nameOfGame, TcpClient client)
        {
            //checking if the palyer is already in a multiplayer game
            foreach (KeyValuePair<ISearchable<T>, List<TcpClient>> kvp in multiPlayerGame)
            {
                if (kvp.Value.Contains(client))
                {
                    this.c.DataHasChanged("player can play in one multiplayer game at a time", client);
                    return true;

                }
            }
            //the maze that the client wants to join
            ISearchable<T> searchale = getMazeByName(nameOfGame);
            //checking if the maze exists and if it is a multiplayer game maze
            if ( searchale != null && multiPlayerGame.ContainsKey(searchale) )
            {
                //adding the current client to the clients list
                multiPlayerGame[searchale].Add(client);
                List<TcpClient> clients = multiPlayerGame[searchale];
                //checking if there are 2 or more players
                if (clients.Count() > 1)
                {
                    //sending all the players that the game has begun
                    foreach (TcpClient cli in clients)
                    {
                        this.c.DataHasChanged(searchale.ToString(), cli);
                    }
                }
                return true;

            }
            else
            {
                this.c.DataHasChanged("game does not exist", client);
                return false;

            }
           

        }
       /// <summary>
       /// setting the maze generator
       /// </summary>
       /// <param name="generator"> the generator</param>
        public void SetGenerator(MazeGeneratorLib.IMazeGenerator generator)
        {
            this.generator = generator;
        }
        /// <summary>
        /// Generating new maze and adding it to the list of mazes
        /// </summary>
        /// <param name="name">maze name</param>
        /// <param name="rows">number of rows</param>
        /// <param name="cols">nuber of cols</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        public bool Generate(string name,int rows, int cols, TcpClient client)
        {
            if(getMazeByName(name) != null)
            {
               
                this.c.DataHasChanged("Name exist", client);
                return false;



            }
            //creating the maze
            ISearchable<T> searchable = CreateMaze(name, rows, cols);
            //adding the maze to the single player list and saving the name of the maze in the games names list
            this.singleGameMaze.Add(searchable, null);
            this.gamesNames.Add(searchable, name);
            //showing the client the maze
            this.c.DataHasChanged(searchable.ToString(), client);
            return false;
        }
        /// <summary>
        /// creates a new maze
        /// </summary>
        /// <param name="name"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public ISearchable<T> CreateMaze(string name, int rows, int cols)
        {
            MazeLib.Maze maze = this.generator.Generate(rows, cols);
            maze.Name = name;
            return (ISearchable<T>)new MazeAdapter(maze);

        }
        /// <summary>
        /// starting a multiplayer game
        /// </summary>
        /// <param name="name">the name of the game</param>
        /// <param name="rows">the number of rows</param>
        /// <param name="cols">the number of cols</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        public bool Start(string name,int rows,int cols, TcpClient client)
        {
           //checking if the name is already eists
            if (gamesNames.ContainsValue(name))
            {
               
                this.c.DataHasChanged("Name exist", client);
                return false;

            }
            else
            {
                //checking if the player is already playing in a multiplayer game
                foreach (KeyValuePair<ISearchable<T>,List<TcpClient>> kvp in multiPlayerGame )
                {
                    if (kvp.Value.Contains(client))
                    {
                        this.c.DataHasChanged("player can play in one multiplayer game at a time", client);
                        return false;

                    }
                }
                //creating the new maze
                ISearchable<T> searchable = CreateMaze(name, rows, cols);
                //creating players list
                List<TcpClient> clients = new List<TcpClient>();
                clients.Add(client);
                this.multiPlayerGame.Add(searchable, clients);
                this.gamesNames.Add(searchable, name);
                //waiting for a new player to join
                while(multiPlayerGame[searchable].Count == 1)
                {
                    Thread.Sleep(1000);
                }
                return true;

            }

        }
        /// <summary>
        /// returning a list of all the available multiplayer games
        /// </summary>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        public bool  List(TcpClient client)
        {
            JArray games = new JArray();
            //creating a list of all the multiplayer games
            foreach (KeyValuePair<ISearchable<T>, List<TcpClient>> key in multiPlayerGame)
            {
                games.Add(gamesNames[key.Key]);  
            }

            this.c.DataHasChanged(games.ToString(), client);
            return false;
        }
        /// <summary>
        /// returns a maze by it's name
        /// </summary>
        /// <param name="name">the name of the maze</param>
        /// <returns>the suitable maze</returns>
        public ISearchable<T> getMazeByName(string name)
        {
            //searching for the maze in the list
            foreach (KeyValuePair<ISearchable<T>,string> key in gamesNames)
            {
                if(key.Value.Equals(name))
                {
                    return key.Key;
                }
            }
            return null;
        }

        /// <summary>
        /// playing a move in a multiplayer game
        /// </summary>
        /// <param name="move">the move to play</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        public bool play(string move, TcpClient client)
        {
            //iterating all the mutiplayer games
            foreach (KeyValuePair<ISearchable<T>, List<TcpClient>> kvp in multiPlayerGame)
            {
                //checking if the current client is in the current game
                if (kvp.Value.Contains(client))
                {
                    //playing the move
                    JObject solutionObject = new JObject();
                    solutionObject["Name"] = gamesNames[kvp.Key];
                    solutionObject["Direction"] = move;
                    //sending the client's move to all the players in the game
                    foreach (TcpClient tcpClient in kvp.Value)
                    {
                        if(tcpClient !=client)
                        {
                            this.c.DataHasChanged(solutionObject.ToString(), tcpClient);
                        }

                    }
                        return true;
                    
                }
            }
            this.c.DataHasChanged("you are not in multiplater game", client);
            return true;
        }
        /// <summary>
        /// Solvding a mmaze
        /// </summary>
        /// <param name="name">the mazes name</param>
        /// <param name="algorithm">the algorithm to use to solve the maze: 0-BFS, 1-DFS</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        public bool Solve(string name, int algorithm, TcpClient client)
        {
            ISearchable<T> searchable = getMazeByName(name);
            //checking if the maze exists
            if (!gamesNames.ContainsValue(name))
            {
                this.c.DataHasChanged("name doesn't exist", client);

            }
            //checking if the maze have been solved already
            else if (singleGameMaze[searchable] == null)
            {
                //defining the searcher to solve the maze
                switch (algorithm)
                {
                    case 0:
                        {
                            setSeasrcher(new SearchAlgorithmsLib.BFS<T>());
                            break;
                        }
                    case 1:
                        {
                            setSeasrcher(new SearchAlgorithmsLib.DFS<T>());
                            break;
                        }
                    default:
                        break;
                }
                Solution<T> sol = this.searcher.search(searchable);
                //starting to set the siolution string
                string solutionStr = "";
                List<State<T>> solutionList = sol.getStateList();
                string state = solutionList.Last().state.ToString();
              
                solutionList.Remove(solutionList.Last());

                string[] arr = state.Split(',');
                int x1, x2, y1, y2;
                x1 = int.Parse(arr[0].Split('(')[1]);
                y1 = int.Parse(arr[1].Split(')')[0]);

                //checking that the list of states of the solution is not empty
                while (solutionList.Count > 0)
                {
                    state = solutionList.Last().state.ToString();
                    solutionList.Remove(solutionList.Last());
                    arr = state.Split(',');
                    x2 = int.Parse(arr[0].Split('(')[1]);
                    y2 = int.Parse(arr[1].Split(')')[0]);
                    //checking if the move was down
                    if (x1 > x2)
                    {
                        solutionStr += "3";

                    }
                    //checking if the move was up

                    if (x1 < x2)
                    {
                        solutionStr += "2";

                    }
                    //checking if the move was lef

                    if (y1 > y2)
                    {
                        solutionStr += "0";
                    }
                    //checking if the move was right

                    if (y1 < y2)
                    {
                        solutionStr += "1";
                    }
                    x1 = x2;
                    y1 = y2;
                }
                //setting the solution
                singleGameMaze[searchable] = new MazeSolution(solutionStr, searcher.getNumberOfNodesEvaluated(), name);
            }

                JObject solutionObject = new JObject();
                solutionObject["Name"] = singleGameMaze[searchable].GetName();
                solutionObject["Solution"] = singleGameMaze[searchable].GetSolution(); ;
                solutionObject["NodesEvaluated"] = singleGameMaze[searchable].GetNodesEvaluated();
            //showing the solution to the client
                this.c.DataHasChanged(solutionObject.ToString(), client);

            return false;
        }
        /// <summary>
        /// closes a multiplayer game
        /// </summary>
        /// <param name="name">the game's name</param>
        /// <param name="client">the client who sent the request</param>
        /// <returns>if the connection should be closed</returns>
        public bool close(string name, TcpClient client)
        {
            ISearchable<T> searchable = getMazeByName(name);
            //checking if the game to close exists
            if (searchable == null)
            {
                this.c.DataHasChanged("no such game", client);

                return true;
            }
            //checking if the player is trying to close someone elses game
            if (!multiPlayerGame[searchable].Contains(client))
            {
                this.c.DataHasChanged("you can close only your game!!", client);
                return true;

            }

           
            else
            {
                JArray m = new JArray();
                string msg = "the game " + name + " is now closed";
                m.Add(msg);
                //informing all the players that the game was closed
                foreach (TcpClient tcpClient in this.multiPlayerGame[searchable])
                {
                    this.c.DataHasChanged(m.ToString(), tcpClient);
                }
                this.multiPlayerGame.Remove(searchable);
                
            }
            return false;
        }


    }
}
