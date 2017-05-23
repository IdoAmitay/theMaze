using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// a class that determines if the input to the list command is legal
    /// </summary>
    class ListInputChecker : IInputChecker
    {
        /// <summary>
        /// determines if the input is legal
        /// </summary>
        /// <param name="args">the parameters to check</param>
        /// <returns>if the input is legal</returns>
        public bool IsInputLegal(string[] args)
        {
            //we know that in a legal command there are no arguments at all
            if (args.Length != 0)
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
