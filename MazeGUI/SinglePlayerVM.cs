using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazeGUI
{
    class SinglePlayerVM : ViewModel
    {
        /*private IMvvmModel model;
         public SinglePlayerVM(IMvvmModel model)
         {
             this.model = model;
         }
         public void Move(int direction)
         {
            // this.model.sendCommand("play " + direction);
             //this.model.sendCommand
         }*/
        // SinglePlayerModel model;
        IMvvmModel model;
        private string name;
        private int rows;
        private int cols;

        public SinglePlayerVM() 
        {
            // this.model = new ClientProgram.Client();
            this.model = ClientProgram.Client.Instance;
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
            Dictionary<string, Action<string>> c = new Dictionary<string, Action<string>>();
            c.Add("generate", this.model.UpdateMaze);
           // c.Add("start", this.model.UpdateMaze);
            c.Add("join", this.model.UpdateMaze);
            c.Add("start", this.model.UpdateMaze);
            c.Add("play", this.model.UpdatePositionFromJson);
            c.Add("close", this.model.UpdateMaze);
            c.Add("solve", this.model.UpdateSolution);
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
            set {
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

        public  MazeLib.Position VM_InitialPos
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
        public void CrerateMaze (string name, int rows , int cols) 
        {
            this.model.TalkWithServer("generate " + name + " " + rows.ToString() + " " + cols.ToString());
            
            this.name = name;
            this.rows = rows;
            this.cols = cols;
            
           // NotifyPropertyChanged("MyMaze"); /////////
        }
        public void SolveMaze()
        {
            this.model.TalkWithServer("solve " + name + " " + ConfigurationManager.AppSettings["Algorithm"].ToString());
            int i = 0;
            while (i < this.model.Solution.Length)
            {
                int direction = int.Parse(this.model.Solution[i].ToString());
                string dir;
                switch (direction)
                {
                    case 0:
                        dir = "left";
                        break;
                    case 1:
                        dir = "right";
                        break;
                    case 2:
                        dir = "up";
                        break;
                    default:
                        dir = "down";
                        break;
                }
                this.Move(dir);
            }
           // NotifyPropertyChanged("Solution");
        }
        public void Move (string direction)
        {
            this.model.TalkWithServer("smove " + direction);
          //  NotifyPropertyChanged("PlayerPosition");
        }

    }
}
