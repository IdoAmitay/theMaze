using MazeLib;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
   abstract class AbstractSinglePlayerClient : AbstractClient
    {
        
       // private static AbstractSinglePlayerClient instance;
       // public AbstractSinglePlayerClient() { }
        public string Solution { get; set; }
        /*public static SinglePlayerClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SinglePlayerClient();
                }
                return instance;
            }
        }*/
        /*public override void CommunicateWithServer()
        {
            while (IsConnected())
            {
                //String result = "";
                StringBuilder result = new StringBuilder();

                do
                {
                    //appending the server's answer to the last command sent
                    // result += this.breader.ReadString();
                    result.Append(this.breader.ReadString());
                } while (this.stream.DataAvailable);
                //printing the message to the client
                //MessageReceived(result.ToString());
                if (Commands.ContainsKey(this.command))
                {
                    Commands[this.command](result.ToString());
                   
                }


            }
        }*/

        /*public override void TalkWithServer(string myCommand)
        {
            string[] arr = myCommand.Split(' ');
            this.command = arr[0];
            if (command.Equals("smove"))
            {
                this.UpdatePosition(ref this.curPos, arr[1]);
                return;
            }
            Task task = new Task(this.CommunicateWithServer);
            //checking if the client is connected
            if (!this.IsConnected())
            {
                //connecting the client
                this.ConnectToserver();
                // new Task(this.CommunicateWithServer).Start();

            }
            this.sendCommand(myCommand);
            task.Start();

            
            
                task.Wait();

            

        }*/
        public void UpdateSolution(string json)
        {
            string[] arr = json.Split('\"');
            Solution = arr[7];
            NotifyPropertyChanged("Solution");
        }
        public override void UpdateMaze(string maze)
        {
            {

                MyMaze = Maze.FromJSON(maze);
                MazeName = MyMaze.Name;
                MazeRows = MyMaze.Rows;
                MazeCols = MyMaze.Cols;
                this.initialPos = MyMaze.InitialPos;
                CurPos = initialPos;
                this.goalPos = MyMaze.GoalPos;

            }
        }
    }
}
