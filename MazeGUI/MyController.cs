using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServerProgram
{
    /// <summary>
    /// MyController class
    /// </summary>
    public class MyController : IController
    {
        private IModel m;
        private IView v;
        private Dictionary<string, ICommand> commandList;
        private Dictionary<string, IInputChecker> checkersList;
        /// <summary>
        /// setting the model to work with and sets the commands and checkers
        /// </summary>
        /// <param name="m">the model</param>        
        public void SetModel(IModel m)
        {
            this.m = m;
            commandList = new Dictionary<string, ICommand>();
            checkersList = new Dictionary<string, IInputChecker>();
            commandList.Add("generate", new GenerateCommand(this.m));
            commandList.Add("solve", new SolveCommand(this.m));
            commandList.Add("start", new StartCommand(this.m));
            commandList.Add("list", new ListCommand(this.m));
            commandList.Add("join", new JoinCommand(this.m));
            commandList.Add("play", new PlayCommand(this.m));
            commandList.Add("close", new CloseCommand(this.m));
            checkersList.Add("generate", new GenerateInputChecker());
            checkersList.Add("solve", new SolveInputChecker());
            checkersList.Add("start", new StartInputChecker());
            checkersList.Add("list", new ListInputChecker());
            checkersList.Add("join", new JoinInputChecker());
            checkersList.Add("play", new PlayInputChecker());
            checkersList.Add("close", new CloseInputChecker());


        }
        /// <summary>
        /// setting the view to work with
        /// </summary>
        /// <param name="v">the view</param>
        public void SetView(IView v)
        {
            this.v = v;
        }
        /// <summary>
        /// executes a command received ferom the client
        /// </summary>
        /// <param name="command">the command string</param>
        /// <param name="client">the client who sent the command</param>
        /// <returns></returns>
        public bool ExecuteCommand(string command, TcpClient client)
        {
            string[] arr = command.Split(' ');
            //getting the command name
            string commandKey = arr[0];
            //checking if the cammand is in out dictionary
            if (!commandList.ContainsKey(commandKey))
            {
                //returns that the command was not found
                this.v.ShowResult("Command not Found",client);
                return false;
            }
            else
            {
                //setting an array of al the parameters to the command
                string[] args = arr.Skip(1).ToArray();
                //checking if all the parameters are legal
                IInputChecker checker = checkersList[commandKey];
                if (checker.IsInputLegal(args))
                {
                    ICommand com = commandList[commandKey];
                    //executing the command
                    return com.ExecuteCommand(args, client);
                }
                else
                {
                    this.v.ShowResult("illegal input", client);
                    return true;

                }
            }
        }
        /// <summary>
        /// function that delivers the view the data that has  changed after the last command
        /// </summary>
        /// <param name="data">the updated data</param>
        /// <param name="client">the client who should get the updated data</param>
        public void DataHasChanged(string data, TcpClient client)
        {
            this.v.ShowResult(data,client);
        }
    }
}
