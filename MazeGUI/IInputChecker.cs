using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    /// <summary>
    /// IInputChecker interface
    /// defines the functions that any input checker should have
    /// </summary>
    public interface IInputChecker
    {
        /// <summary>
        /// determines if the input is legal
        /// </summary>
        /// <param name="args">the input values</param>
        /// <returns>wheather the input is legal or not</returns>
        bool IsInputLegal(string[] args);
    }
}
