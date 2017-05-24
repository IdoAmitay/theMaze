using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;

namespace MazeGUI
{
    class SinglePlayerModel
    {
        public SinglePlayerModel(/*string name, int rows, int cols*/)
        {
            //string str = "generate " + name + " " + rows + " " + cols;
            // send to client
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private string mazeName;
        public string MazeName
        {
            get { return mazeName; }
            set
            {
                mazeName = value;
                NotifyPropertyChanged("MazeName");
            }
        }

        private int mazeRows;
        public int MazeRows
        {
            get { return mazeRows; }
            set
            {
                mazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }

        private int mazeCols;
        public int MazeCols
        {
            get { return mazeCols; }
            set
            {
                mazeRows = value;
                NotifyPropertyChanged("MazeCols");
            }
        }

        private int searchAlgorithm;
        public int SearchAlgorithm
        {
            get { return searchAlgorithm; }
            set
            {
                searchAlgorithm = value;
                NotifyPropertyChanged("searchAlgorithm");
            }
        }

        private Position initialPos;
        public Position InitialPos
        {
            get { return this.initialPos; }
            set
            {
                NotifyPropertyChanged("InitialPos");
            }
        }

        private Position goalPos;
        public Position GoalPos
        {
            get { return this.goalPos; }
            set
            {
                NotifyPropertyChanged("GoalPos");
            }
        }

        private Position curPos;
        public Position CurPos
        {
            get { return this.curPos; }
            set
            {
                NotifyPropertyChanged("CurPos");
            }
        }

        private Maze maze;
        public Maze Maze
        {
            get { return maze; }
            set
            {
                maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        public void SaveSettings()
        {
            //// 
        }
    }
}
