using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServerProgram
{
    /// <summary>
    /// PlayerInputChecker calss.
    /// determineds if the input is legal
    /// </summary>
    class PlayInputChecker : IInputChecker
    {
        /// <summary>
        /// determines if the input is legal or not
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool IsInputLegal(string[] args)
        {
            // in a legal input there is exectly one value
            if (args.Length != 1)
            {
                return false;
            }
            //checking if the move is legal (case sensitive)
            if (!args[0].Equals("up") && !args[0].Equals("down") && !args[0].Equals("left") && !args[0].Equals("right"))
            {
                return false;
            }
            return true;
        }
    }
}
