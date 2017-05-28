using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
   abstract class AbstractMultiPlayerClient : AbstractClient
    {
        protected Position oppPos;
        private bool isOppConnected;
        private bool iLeft;
        public bool ILeft { get; set; }
        public Position OppPos
        {
            get
            {
                return this.oppPos;
            }
            set
            {
                this.oppPos = value;
                NotifyPropertyChanged("CurPos");
            }
        }
        public bool IsOppConnected
        {
            get
            {
                return this.isOppConnected;
            }
            set
            {
                this.isOppConnected = value;
                NotifyPropertyChanged("IsOppConnected");
            }
        }
        public List<string> Games { get;  set; }

        public void UpdatePositionFromJson(string json)
        {
            string[] arr = json.Split('\"');
            this.UpdatePosition(ref this.oppPos, arr[7]);
            NotifyPropertyChanged("OppPos");
        }
        public  void ContinueConnection()
        {
            
                while (this.IsConnected())
                {
                StringBuilder messageRecieved = new StringBuilder();
                 messageRecieved.Append(breader.ReadString());
                
                if (messageRecieved.ToString().Contains("is now closed"))
                {

                    this.Close();
                    this.IsOppConnected = false;
                    return;
                }
                this.UpdatePositionFromJson(messageRecieved.ToString());
                }
            
        }

        public override void TalkWithServer(string myCommand)
        {
           /* string[] arr = myCommand.Split(' ');
            this.command = arr[0];
            if (command.Equals("smove"))
            {
                this.UpdatePosition(ref this.curPos, arr[1]);
                return;
            }
            Task task = new Task(this.CommunicateWithServer);*/
            //checking if the client is connected
            if (!this.IsConnected())
            {
                //connecting the client
                this.ConnectToserver();

            }
            this.sendCommand(myCommand);
           /* task.Start();
            if (!this.command.Equals("play"))
            {
                 task.Wait();

            }
            if (this.command.Equals("start") || this.command.Equals("join"))
            {
                
               // task.Wait();
              //  task = new Task(ContinueConnection);
                this.command = "play";
               // task.Start();
            }*/
            
            
        }
        public override void UpdateMaze(string maze)
        {

            MyMaze = Maze.FromJSON(maze);
            MazeName = MyMaze.Name;
            MazeRows = MyMaze.Rows;
            mazeCols = MyMaze.Cols;
            InitialPos = MyMaze.InitialPos;
            CurPos = initialPos;
            GoalPos = MyMaze.GoalPos;
            OppPos = MyMaze.InitialPos;

        }
        public void GetGamesList(string json)
        {
            string[] arr = json.Split('\"');
            List<string> temp = new List<string>();
            for (int i = 1; i < arr.Length; i += 2)
            {
                temp.Add(arr[i]);
            }
            Games = temp;
        }
        public void UpdateCurPos (string move)
        {
            this.UpdatePosition(ref this.curPos, move);
        }
        public void UpdateOppPos(string move)
        {
            this.UpdatePosition(ref this.oppPos, move);
        }

    }

}
