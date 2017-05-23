using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using SearchAlgorithmsLib;

namespace ServerProgram
{
    /// <summary>
    /// MAzeAdapterClass
    /// adapts between ISearchable interface and Maze class
    /// </summary>
    public class MazeAdapter : SearchAlgorithmsLib.ISearchable<MazeLib.Position>
    {
        private Maze maze;
        /// <summary>
        /// class constructor
        /// defining the maze
        /// </summary>
        /// <param name="maze">the maze</param>
        public MazeAdapter(Maze maze)
        {
            this.maze = maze;
        }
        /// <summary>
        /// returns all the possible states available
        /// </summary>
        /// <param name="s">the current position</param>
        /// <returns>a list of all the available states</returns>
        public  List<State<MazeLib.Position>> getAllPossibleStates(State<MazeLib.Position> s)
        {
            List<State<MazeLib.Position>> statesList = new List<State<Position>>();
            //checking if we are not out of bounds and if the cell above is egal
            if(maze.Rows - 1 > s.state.Row && maze[s.state.Row +1,s.state.Col] == CellType.Free )
            {
                Position p = new Position(s.state.Row + 1, s.state.Col);
                statesList.Add(State<MazeLib.Position>.statePool<MazeLib.Position>.getState((p)));

            }
            //checking if we are not out of bounds and if the cell below is legal
            if (s.state.Row > 0 && maze[s.state.Row - 1, s.state.Col] == CellType.Free)
            {
                Position p = new Position(s.state.Row - 1, s.state.Col);

                statesList.Add(State<MazeLib.Position>.statePool<MazeLib.Position>.getState(p));
            
            }
            //checking if we are not out of bound and if the cell from the left is legal
            if (maze.Cols - 1 > s.state.Col && maze[s.state.Row, s.state.Col + 1] == CellType.Free )
            {
                Position p = new Position(s.state.Row, s.state.Col + 1);
                statesList.Add(State<MazeLib.Position>.statePool<MazeLib.Position>.getState(p));
             
            }
            //checking if we are not out of bound and if the cell from the right is legal

            if (s.state.Col > 0 && maze[s.state.Row, s.state.Col - 1] == CellType.Free )
            {
                Position p = new Position(s.state.Row, s.state.Col - 1);
                statesList.Add(State<MazeLib.Position>.statePool<MazeLib.Position>.getState(p));
              
            }


            return statesList;



        }
        /// <summary>
        /// getting the goal state of the maze
        /// </summary>
        /// <returns>the goal state of the maze</returns>
        public State<MazeLib.Position> getGoalState()
        {
            return new State<MazeLib.Position>(maze.GoalPos);
        }
        /// <summary>
        /// getting the initial state of the maze
        /// </summary>
        /// <returns>the initial state of the maze</returns>
        public State<MazeLib.Position> getInitialState()
        {
            return new State<Position>(maze.InitialPos);
        }
        /// <summary>
        /// setting the maze's name
        /// </summary>
        /// <param name="name">the name</param>
        public void SetMazeName(string name)
        {
            this.maze.Name = name;
        }
        /// <summary>
        /// getting the mazes name
        /// </summary>
        /// <returns>the maze's name</returns>
        public string getMazeName()
        {
            return this.maze.Name;
        }
        /// <summary>
        /// json object that defines the maze
        /// </summary>
        /// <returns>string that defines the maze</returns>
        public override string ToString()
        {
            return this.maze.ToJSON();
        }
        
    }
}
