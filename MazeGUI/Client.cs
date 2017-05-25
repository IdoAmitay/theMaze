using MazeGUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MazeLib;

namespace ClientProgram
{
    ///<summary>
    ///a client class
    ///holds the end point of communication, the tcp client, the stream and the binary writet
    ///</summary>
    class Client : IMvvmModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Maze maze;
        private static Client instance;
        private string command;
        private string mazeName;
        private int mazeRows;
        private int mazeCols;
        private Position curPos;
        private Position goalPos;
        private Position initialPos;
        public int MazeCols
        {
            get
            {
                return this.mazeCols;
            }
            set
            {
                this.mazeCols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }
        public int MazeRows
        {
            get
            {
                return this.mazeRows;
            }
            set
            {
                this.mazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }
        public Position InitialPos
        {
            get
            {
                return this.initialPos;
            }
            set
            {
                this.initialPos = value;
                NotifyPropertyChanged("InitialPos");
            }
        }
        public Position GoalPos
        {
            get
            {
                return this.goalPos;
            }
            set
            {
                this.goalPos = value;
                NotifyPropertyChanged("GoalPos");
            }
        }
        public Maze MyMaze
        {
            get
            {
                return this.maze;
            }
            set
            {
                this.maze = value;
                NotifyPropertyChanged("MyMaze");
            }
        }
        public string MazeName
        {
            get
            {
              return  this.mazeName;
            }
            set
            {
                this.mazeName = value;
                NotifyPropertyChanged("MazeName");
            }
        }
        public Position CurPos
        {
            get
            {
                return this.curPos;
            }
            set
            {
                this.curPos = value;
                NotifyPropertyChanged("CurPos");
            }
        }
    
        public Dictionary<string, Action<string>> Commands { get ; set ; }
        public string Solution { get ; set ; }

        public event Action<String> MessageReceived;
       // public event Action<string> MazeUpdate;
        //public event Action<string> PositionUpdate;
       // private Dictionary<string, Action<string>> commands;
            

        private IPEndPoint endP;
        private TcpClient client;
        private NetworkStream stream;
        private BinaryReader breader;
        private StreamWriter swriter;
        private Client() { }

        /// <summary>
        /// checks if the client is connected to the server
        /// </summary>
        /// <returns>true if connected, false otherwise </returns>
        public bool IsConnected ()
        {
            if (this.client != null)
            {
               // this.PositionUpdate += (str) => this.UpdatePosition(str);
                Socket clientSocket = this.client.Client;
                // checking if the socket is available
                bool isSocketAvailable = clientSocket.Poll(1000, SelectMode.SelectRead);
                //checking if there is data in the stream
                bool receivedDataIndicator = (clientSocket.Available == 0);
                return !(receivedDataIndicator && isSocketAvailable);
            }

            return false;
        }
        /// <summary>
        /// runs while the client is connected to the server
        /// reads the answers to the commands from the stream
        /// </summary>
        public void CommunicateWithServer()
        {
            while (IsConnected())
            {
                 //String result = "";
               StringBuilder result = new StringBuilder();

                do
                {
                    //appending the server's answer to the last command sent
                   // result += this.breader.ReadString();
                    result.Append(this.breader.ReadString());
                } while (this.stream.DataAvailable);
                //printing the message to the client
                //MessageReceived(result.ToString());
                if (Commands.ContainsKey(this.command))
                {
                    Commands[this.command](result.ToString());
                }
               
                
            }
        }

        /// <summary>
        /// closes the connection with the server and the current stream
        /// </summary>
        public void Close()
        {
            
            this.stream.Close();
            this.client.Close();
        }
        /// <summary>
        /// sending the command to the server
        /// </summary>
        /// <param name="s"> the command string</param>
        public void sendCommand(string s)
        {
            string[] arr = s.Split(' ');
            this.command = arr[0];
            if (command.Equals("smove"))
            {
                this.UpdatePosition(arr[1]);
            }
            else
            {
               // this.command = s;
                this.swriter.WriteLine(s);
            }

           
        }
        /// <summary>
        /// connecting to the server
        /// </summary>
        public void ConnectToserver()
        {
            //defining the port,ip and end point
            string s = ConfigurationManager.AppSettings["server"].ToString();
            int port = int.Parse(ConfigurationManager.AppSettings["port"].ToString());
            this.endP = new IPEndPoint(IPAddress.Parse(s), port);
            //closing the previous connection with the server
            if (this.client != null)
            {
                Close();
            }
            this.client = new TcpClient();
            this.client.Connect(endP);
            this.stream = client.GetStream();
            this.breader = new BinaryReader(stream);
            this.swriter = new StreamWriter(stream);
            this.swriter.AutoFlush = true;
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void UpdateMaze(string maze)
        {
            // MazeLib.Maze mazeTemp = new MazeLib.Maze();
            // MazeLib.Maze m = MazeLib.Maze.FromJSON(maze);
            // MyMaze = m;
            // MyMaze = new Maze(4,4);
            this.maze = Maze.FromJSON(maze);
           // MyMaze = Maze.FromJSON(maze);
           // this.NotifyPropertyChanged("MyMaze");
            mazeName = MyMaze.Name;
            MazeRows = MyMaze.Rows;
            mazeCols = MyMaze.Cols;
            InitialPos = MyMaze.InitialPos;
            CurPos = initialPos;
            GoalPos = MyMaze.GoalPos;

        }
        public void UpdatePosition (string direction)
        {
            if (direction.Equals("up") 
                && this.MyMaze[this.CurPos.Row + 1, this.CurPos.Col] == MazeLib.CellType.Free)
            {
                this.CurPos = new MazeLib.Position(this.CurPos.Row + 1, this.CurPos.Col);
                
            }
            if(direction.Equals("down")
                && this.MyMaze[this.CurPos.Row - 1, this.CurPos.Col] == MazeLib.CellType.Free)
            {
                this.CurPos = new MazeLib.Position(this.CurPos.Row - 1, this.CurPos.Col);
                
            }
            if (direction.Equals("left")
                && this.MyMaze[this.CurPos.Row, this.CurPos.Col - 1] == MazeLib.CellType.Free)
            {
                this.CurPos = new MazeLib.Position(this.CurPos.Row , this.CurPos.Col - 1);
                
            }
            if (direction.Equals("right")
                && this.MyMaze[this.CurPos.Row, this.CurPos.Col + 1] == MazeLib.CellType.Free)
            {
                this.CurPos = new MazeLib.Position(this.CurPos.Row, this.CurPos.Col + 1);
                
            }
            this.NotifyPropertyChanged("CurPos");

        }
        public void UpdatePositionFromJson(string json)
        {
            string[] arr = json.Split('\"');
            this.UpdatePosition(arr[7]);
        }
        public void UpdateSolution (string json)
        {
            string[] arr = json.Split('\"');
            Solution = arr[7];
            NotifyPropertyChanged("Solution");
        }
        public static Client Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Client();
                }
                return instance;
            }
        }
        public void TalkWithServer (string myCommand)
        {
            Task task = new Task(this.CommunicateWithServer);
            //checking if the client is connected
            if (!this.IsConnected())
            {
                //connecting the client
                this.ConnectToserver();
                // new Task(this.CommunicateWithServer).Start();
                task.Start();
            }
            this.sendCommand(myCommand);
            task.Wait();

        }
    }
}

            

    


