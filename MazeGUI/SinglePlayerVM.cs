using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
            this.model = new ClientProgram.Client();
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
            Dictionary<string, Action<string>> c = new Dictionary<string, Action<string>>();
            c.Add("generate", this.model.UpdateMaze);
            c.Add("start", this.model.UpdateMaze);
            c.Add("join", this.model.UpdateMaze);
            c.Add("start", this.model.UpdateMaze);
            c.Add("play", this.model.UpdatePositionFromJson);
            c.Add("close", this.model.UpdateMaze);
            this.model.Commands = c;





        }

        public string VM_MazeName
        {
            get { return this.model.MyMaze.Name; }
            set { /*this.model.MazeName = value; */}
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

        public int VM_SearchAlgorithm
        {
            get { return this.model.SearchAlgorithm; }
            set { }
        }

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
            get { return this.model.PlayerPosition; }
            set { }
        }

    }
}
