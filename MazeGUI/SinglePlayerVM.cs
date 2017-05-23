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
        SinglePlayerModel model;
        private string name;
        private int rows;
        private int cols;

        public SinglePlayerVM(SinglePlayerModel model)
        {
            this.model = model;
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
        }

        public string VM_MazeName
        {
            get { return this.model.MazeName; }
            set { /*this.model.MazeName = value; */}
        }

        public int VM_MazeRows
        {
            get { return this.model.MazeRows; }
            set { /*this.rows = value;*/ }
        }

        public int VM_MazeCols
        {
            get { return this.model.MazeCols; }
            set { /*this.cols = value;*/ }
        }

        public int VM_SearchAlgorithm
        {
            get { return this.model.SearchAlgorithm; }
            set { }
        }

        public Position VM_InitialPos
        {
            get { return this.model.InitialPos; }
            set { }
        }

        public Position VM_GoalPos
        {
            get { return this.model.GoalPos; }
            set { }
        }

        public Position VM_CurPos
        {
            get { return this.model.CurPos; }
            set { }
        }

    }
}
