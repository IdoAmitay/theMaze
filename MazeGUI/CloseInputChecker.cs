using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// class that checks if the input to the close command is legel
    /// </summary>
    class CloseInputChecker : IInputChecker
    {
        /// <summary>
        /// checks if the input is legal
        /// </summary>
        /// <param name="args">the parameters to the command</param>
        /// <returns>if the parameters are legal or not</returns>
        public bool IsInputLegal(string[] args)
        {
            //we know that there is exactly 1 parameter in a legal input
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
