using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// SolveInputChecker class
    /// determines if the input is legal
    /// </summary>
    class SolveInputChecker : IInputChecker
    {
        /// <summary>
        /// determinesd if the input is legal or not
        /// </summary>
        /// <param name="args">the parameters to check</param>
        /// <returns>if the input is legal</returns>
        public bool IsInputLegal(string[] args)
        {
            int algorithm;
            //in a legal input there are exactly two values
            if (args.Length != 2)
            {
                return false;
            }
            // checking if the algorithm index is legal (1 or 0)
            try
            {
                algorithm = int.Parse(args[1]);
            }
            catch (Exception e)
            {
                return false;
            }
            if (algorithm !=1 && algorithm != 0)
            {
                return false;
            }
            return true;


        }
    }
}
