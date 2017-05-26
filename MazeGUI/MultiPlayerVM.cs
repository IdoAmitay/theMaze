using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
    class MultiPlayerVM : ViewModel
    {
        IMvvmModel model;
        public MazeLib.Position OppPos
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
        public MultiPlayerVM()
        {
            // this.model = new ClientProgram.Client();
            this.model = ClientProgram.Client.Instance;
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
            c.Add("List", this.model.GetGamesList);
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
            this.model.sendCommand("start " + name + " " + rows.ToString() + " " + cols.ToString());
            NotifyPropertyChanged("MyMaze");//////
            NotifyPropertyChanged("PlayerPosition");//////
        }
        public void JoinGame(string game)
        {
            this.model.sendCommand("join " + game);
            NotifyPropertyChanged("MyMaze");//////
            NotifyPropertyChanged("PlayerPosition");//////
        }
        public void Play (string move)
        {
            this.model.sendCommand("play " + move);
            NotifyPropertyChanged("PlayerPosition");
        }
        public void Close ()
        {
            this.model.TalkWithServer("close " + this.model.MyMaze.Name);
            NotifyPropertyChanged("MyMaze");/////////////////////
        }
        public void List ()
        {
            this.model.TalkWithServer("List");
        }
        
    }
}
