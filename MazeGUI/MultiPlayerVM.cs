﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
    class MultiPlayerVM : ViewModel
    {
        // IMvvmModel model;
        AbstractMultiPlayerClient model;
        private static MultiPlayerVM instance;
        public bool VM_ILeft
        {
            get
            {
                return this.model.ILeft;
            }
            set
            {
                this.model.ILeft = value;
            }
        }
        public bool VM_IsOppConnected
        {
            get
            {
                return this.model.IsOppConnected;
            }
            set
            {
                this.model.IsOppConnected = value;
                NotifyPropertyChanged("IsOppConnected");
            }
        }
        public MazeLib.Position VM_OppPos
        {
            get
            {
                return this.model.OppPos;
            }
            set
            {
                this.model.OppPos = value;
                NotifyPropertyChanged("OppPos");
            }
        }
        public List<string> Games
        {
            get
            {
                return this.model.Games;
            }
            set
            {
                this.model.Games = value;
                NotifyPropertyChanged("Games");
            }
        }
        private MultiPlayerVM()
        {
            // this.model = new ClientProgram.Client();
            //this.model = ClientProgram.Client.Instance;
            this.model = MyMultiPlayerClient.Instance;
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
            Dictionary<string, Action<string>> c = new Dictionary<string, Action<string>>();
           // c.Add("generate", this.model.UpdateMaze);
            c.Add("start", this.model.UpdateMaze);
            c.Add("join", this.model.UpdateMaze);
            //c.Add("start", this.model.UpdateMaze);
            c.Add("play", this.model.UpdatePositionFromJson);
            c.Add("close", this.model.UpdateMaze);
            // c.Add("solve", this.model.UpdateSolution);
            c.Add("list", this.model.GetGamesList);
            this.model.Commands = c;
            
        }


        public MazeLib.Maze VM_Maze
        {
            get
            {
                return this.model.MyMaze;
            }
            set
            {
                this.model.MyMaze = value;
                NotifyPropertyChanged("MyMaze");
            }
        }
        public string VM_MazeName
        {
            get { return this.model.MyMaze.Name; }
            set
            {
                this.model.MyMaze.Name = value;
                NotifyPropertyChanged("MazeName");
            }
        }

        public int VM_MazeRows
        {
            get { return this.model.MyMaze.Rows; }
            set { /*this.rows = value;*/ }
        }

        public int VM_MazeCols
        {
            get { return this.model.MyMaze.Cols; }
            set { /*this.cols = value;*/ }
        }

        /*public int VM_SearchAlgorithm
        {
            get { return this.model.SearchAlgorithm; }
            set { }
        }*/

        public MazeLib.Position VM_InitialPos
        {
            get { return this.model.MyMaze.InitialPos; }
            set { }
        }

        public MazeLib.Position VM_GoalPos
        {
            get { return this.model.MyMaze.GoalPos; }
            set { }
        }

        public MazeLib.Position VM_CurPos
        {
            get { return this.model.CurPos; }
            set { }
        }

        

        public string VM_MazeString
        {
            get { return this.model.MyMaze.ToString(); }
            set
            {

            }
        }
        public void StartGame (string name, int rows, int cols)
        {
            //this.model.TalkWithServer("start " + name + " " + rows.ToString() + " " + cols.ToString());
            if (!this.model.IsConnected())
            {
                //connecting the client
                this.model.ConnectToserver();

            }
            this.model.CurCommand = "start";
            this.model.sendCommand("start " + name + " " + rows.ToString() + " " + cols.ToString());
            this.model.CommunicateWithServer();
            NotifyPropertyChanged("MyMaze");//////
            NotifyPropertyChanged("CurPos");//////
            NotifyPropertyChanged("OppPos");//////

            Task task = new Task(this.model.ContinueConnection);
            task.Start();
        }
        public void JoinGame(string game)
        {
            //this.model.TalkWithServer("join " + game);
            if (!this.model.IsConnected())
            {
                //connecting the client
                this.model.ConnectToserver();

            }
            this.model.CurCommand = "join";

            this.model.sendCommand("join " + game);
            this.model.CommunicateWithServer();
            NotifyPropertyChanged("MyMaze");//////
            NotifyPropertyChanged("CurPos");//////
            NotifyPropertyChanged("OppPos");//////

            Task task = new Task(this.model.ContinueConnection);
            task.Start();
        }
        public void Play (string move)
        {
            if (!this.model.IsConnected())
            {
                //connecting the client
                this.model.ConnectToserver();

            }
            // this.model.TalkWithServer("smove " + move);
            this.model.CurCommand = "play";
            //this.model.UpdatePosition (this.model.CurPos, move);
            this.model.UpdateCurPos(move);
            NotifyPropertyChanged("CurPos");
            //this.model.TalkWithServer("play " + move);
            this.model.sendCommand("play " + move);
        }
        public void Close ()
        {
            //this.model.TalkWithServer("close " + this.model.MyMaze.Name);
            if (!this.model.IsConnected())
            {
                //connecting the client
                this.model.ConnectToserver();

            }
            this.model.CurCommand = "close";
            this.VM_ILeft = true;
            this.model.sendCommand("close " + this.model.MyMaze.Name);
            //this.model.CommunicateWithServer();
           // NotifyPropertyChanged("IsOppConnected");/////////////////////
        }
        public void List ()
        {
            //this.model.TalkWithServer("list");
            if (!this.model.IsConnected())
            {
                //connecting the client
                this.model.ConnectToserver();

            }
            this.model.CurCommand = "list";

            this.model.sendCommand("list");
            this.model.CommunicateWithServer();
        }
        public static MultiPlayerVM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MultiPlayerVM();
                }
                return instance;
            }
        }
        
    }
}
