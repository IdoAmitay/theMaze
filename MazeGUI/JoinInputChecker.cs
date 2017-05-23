using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// a class that determines if the input to the join command is legal
    /// </summary>
    class JoinInputChecker : IInputChecker
    {
        /// <summary>
        /// determines if the input to the command is legal
        /// </summary>
        /// <param name="args">the parameters</param>
        /// <returns>if the connection should be closed</returns>
        public bool IsInputLegal(string[] args)
        {
            //we know that in a legal input there is exactly one parameter
            if (args.Length != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
