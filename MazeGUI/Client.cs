﻿using MazeGUI;
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

namespace ClientProgram
{
    ///<summary>
    ///a client class
    ///holds the end point of communication, the tcp client, the stream and the binary writet
    ///</summary>
    class Client : IMvvmModel
    {
        private static Client instance;
        private string command;
        public MazeLib.Maze MyMaze { get; set; }
        public MazeLib.Position PlayerPosition { get; set; }
        public Dictionary<string, Action<string>> Commands { get ; set ; }
        public string Solution { get ; set ; }

        public event Action<String> MessageReceived;
       // public event Action<string> MazeUpdate;
        //public event Action<string> PositionUpdate;
       // private Dictionary<string, Action<string>> commands;
            
        public event PropertyChangedEventHandler PropertyChanged;

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
                StringBuilder result = new StringBuilder();

                do
                {
                    //appending the server's answer to the last command sent
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

        public void UpdateMaze (string maze)
        {
            // MazeLib.Maze mazeTemp = new MazeLib.Maze();
            // MazeLib.Maze m = MazeLib.Maze.FromJSON(maze);
            // MyMaze = m;
            MyMaze = new MazeLib.Maze(3, 3);
            this.NotifyPropertyChanged("MyMaze");
        }
        public void UpdatePosition (string direction)
        {
            if (direction.Equals("up") 
                && this.MyMaze[this.PlayerPosition.Row + 1, this.PlayerPosition.Col] == MazeLib.CellType.Free)
            {
                this.PlayerPosition = new MazeLib.Position(this.PlayerPosition.Row + 1, this.PlayerPosition.Col);
                
            }
            if(direction.Equals("down")
                && this.MyMaze[this.PlayerPosition.Row - 1, this.PlayerPosition.Col] == MazeLib.CellType.Free)
            {
                this.PlayerPosition = new MazeLib.Position(this.PlayerPosition.Row - 1, this.PlayerPosition.Col);
                
            }
            if (direction.Equals("left")
                && this.MyMaze[this.PlayerPosition.Row, this.PlayerPosition.Col - 1] == MazeLib.CellType.Free)
            {
                this.PlayerPosition = new MazeLib.Position(this.PlayerPosition.Row , this.PlayerPosition.Col - 1);
                
            }
            if (direction.Equals("right")
                && this.MyMaze[this.PlayerPosition.Row, this.PlayerPosition.Col + 1] == MazeLib.CellType.Free)
            {
                this.PlayerPosition = new MazeLib.Position(this.PlayerPosition.Row, this.PlayerPosition.Col + 1);
                
            }
            this.NotifyPropertyChanged("PlayerPosition");

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
            //checking if the client is connected
            if (!this.IsConnected())
            {
                //connecting the client
                this.ConnectToserver();
                new Task(this.CommunicateWithServer).Start();
            }
            this.sendCommand(myCommand);
        }
    }
}

            

    


