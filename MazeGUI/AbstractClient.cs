using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
    public abstract class AbstractClient : INotifyPropertyChanged
    {

        protected TcpClient client;
        protected IPEndPoint endP;
        protected NetworkStream stream;
        protected BinaryReader breader;
        protected StreamWriter swriter;
        protected Maze myMaze;
        protected Position curPos;
        protected string command;
        protected Position goalPos;
        protected Position initialPos;
        protected int mazeRows;
        protected int mazeCols;
        protected string mazeName;

       public Dictionary<string, Action<string>> Commands { get; set; }
        public string CurCommand
        {
            get
            {
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }
        public Maze MyMaze
        {
            get
            {
                return this.myMaze;
            }
            set
            {
                this.myMaze = value;
                NotifyPropertyChanged("MyMaze");
            }
        }
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
        public string MazeName
        {
            get
            {
                return this.mazeName;
            }
            set
            {
                this.mazeName = value;
                NotifyPropertyChanged("MazeName");
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
       

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public bool IsConnected()
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
        public  void CommunicateWithServer()
        {
          
            StringBuilder result = new StringBuilder();

            do
            {
                //appending the server's answer to the last command sent
                
                result.Append(this.breader.ReadString());
            } while (this.stream.DataAvailable);
            //printing the message to the client
          
            Commands[this.command](result.ToString());

         


          
        }
        
        public void sendCommand(string s)
        {
            
            this.swriter.WriteLine(s);

        }
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
        public void Close()
        {

            this.stream.Close();
            this.client.Close();
        }
        public void UpdatePosition(ref Position pos, string direction)
        {
            if (direction.Equals("up") && pos.Row - 1 >= 0)
            {

                if (this.MyMaze[pos.Row - 1, pos.Col] == MazeLib.CellType.Free)
                {
                    pos = new MazeLib.Position(pos.Row - 1, pos.Col);

                }
            }
            if (direction.Equals("down") && pos.Row + 1 < this.MyMaze.Rows)
            {
                if (this.MyMaze[pos.Row + 1, pos.Col] == MazeLib.CellType.Free)
                {
                    pos = new MazeLib.Position(pos.Row + 1, pos.Col);

                }
            }
            if (direction.Equals("left") && pos.Col - 1 >= 0)
            {
                if (this.MyMaze[pos.Row, pos.Col - 1] == MazeLib.CellType.Free)
                {
                    pos = new MazeLib.Position(pos.Row, pos.Col - 1);

                }
            }
            if (direction.Equals("right") && pos.Col + 1 < this.MyMaze.Cols)
            {
                if (this.MyMaze[pos.Row, pos.Col + 1] == MazeLib.CellType.Free)
                {
                    pos = new MazeLib.Position(pos.Row, pos.Col + 1);

                }
            }

        }
        public abstract void UpdateMaze(string maze);
        
        
        public abstract void TalkWithServer(string myCommand);
    }
}
