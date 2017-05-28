using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
    class MySinglePlayerClient : AbstractSinglePlayerClient
    {
        // private static AbstractSinglePlayerClient instance;
        // public AbstractSinglePlayerClient() { }
        private static MySinglePlayerClient instance;
        private MySinglePlayerClient () { }
        public static MySinglePlayerClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MySinglePlayerClient();
                }
                return instance;
            }
        }
       

        public override void TalkWithServer(string myCommand)
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

            

        }
    }
}
