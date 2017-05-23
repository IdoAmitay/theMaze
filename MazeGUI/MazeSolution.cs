using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ServerProgram
{
    /// <summary>
    /// MazeSolutionClass
    /// contains tha maze's name'the solution and he evaluated nodes
    /// </summary>
    class MazeSolution
    {
        private string solution { get; set; }
        private string mazeName { get; set; }
        private int evaluatedNodes { get; set; }
        /// <summary>
        /// calss constructor
        /// setting all the members
        /// </summary>
        /// <param name="solution">the solution</param>
        /// <param name="evaluatedNodes">the evaluated nodes</param>
        /// <param name="name">maze's name</param>
        public MazeSolution(string solution, int evaluatedNodes, string name)
        {
            this.solution = solution;
            this.evaluatedNodes = evaluatedNodes;
            this.mazeName = name;
        }
        /// <summary>
        /// getting the number of nodes evaluated in while the solution
        /// </summary>
        /// <returns>the number of nodes evaluated</returns>
        public int  GetNodesEvaluated()
        {
            return this.evaluatedNodes;
        }
        /// <summary>
        /// getting the solution of the maze
        /// </summary>
        /// <returns>the solution of the maze</returns>
        public  string GetSolution()
        {
            return this.solution;
        }
        /// <summary>
        /// getting the name of the maze
        /// </summary>
        /// <returns>the name of the maze</returns>
        public  string GetName()
        {
            return this.mazeName;
        }
    }
}
