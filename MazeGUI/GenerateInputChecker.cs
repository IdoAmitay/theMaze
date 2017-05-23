using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// class that checks if the input to the generate command is legal
    /// </summary>
    class GenerateInputChecker : IInputChecker
    {
        /// <summary>
        /// Determines if the input is legal or not
        /// </summary>
        /// <param name="args">the parameters to check</param>
        /// <returns>if the input is lega or not</returns>
        public bool IsInputLegal(string[] args)
        {
            int row;
            int col;
            //we know that in a legal input there are exactly 3 values
            if (args.Length != 3)
            {
                return false;

            }
            //we are checking if the rows and colsare actualy numbers
            try
            {
                 row = int.Parse(args[1]);
                 col = int.Parse(args[2]);
            } 

            catch (Exception e)
            {
                return false;
            
            }
            //checking that the row's and cols are positive and not zero
            if (row <= 0 || col <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
