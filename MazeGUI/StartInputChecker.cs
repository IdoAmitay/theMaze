using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// StartInputChecker calss.
    /// determines if the input is legal
    /// </summary>
    class StartInputChecker : IInputChecker
    {
        /// <summary>
        /// determineds i the input is legal
        /// </summary>
        /// <param name="args">the parameters to check</param>
        /// <returns>if the input is legal</returns>
        public bool IsInputLegal(string[] args)
        {
            int col;
            int row;
            // in a legal input there are exactly 3 values
            if (args.Length != 3)
            {
                return false;
            }
            //checking if the rows are integers that greater than zero
            try
            {
                row = int.Parse(args[1]);
                col = int.Parse(args[2]);
            }
            catch (Exception e)
            {
                return false;
            }
            if (row <= 0 || col <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
