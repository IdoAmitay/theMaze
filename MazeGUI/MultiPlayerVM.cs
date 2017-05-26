using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
    class MultiPlayerVM : ViewModel
    {
        IMvvmModel model;
        public MultiPlayerVM()
        {
            // this.model = new ClientProgram.Client();
            this.model = ClientProgram.Client.Instance;
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
            Dictionary<string, Action<string>> c = new Dictionary<string, Action<string>>();
           // c.Add("generate", this.model.UpdateMaze);
            c.Add("start", this.model.UpdateMaze);
            c.Add("join", this.model.UpdateMaze);
            //c.Add("start", this.model.UpdateMaze);
            c.Add("play", this.model.UpdatePositionFromJson);
            c.Add("close", this.model.UpdateMaze);
           // c.Add("solve", this.model.UpdateSolution);
            this.model.Commands = c;
            
        }
        public void StartGame (string name, int rows, int cols)
        {
            this.model.sendCommand("start " + name + " " + rows.ToString() + " " + cols.ToString());
            NotifyPropertyChanged("MyMaze");//////
            NotifyPropertyChanged("PlayerPosirtion");//////
        }
        public void JoinGame(string game)
        {
            this.model.sendCommand("join " + game);
            NotifyPropertyChanged("MyMaze");//////
            NotifyPropertyChanged("PlayerPosirtion");//////
        }
        public void Play (string move)
        {
            this.model.sendCommand("play " + move);
            NotifyPropertyChanged("PlayerPosition");
        }
        public void Close ()
        {
            this.model.TalkWithServer("close " + this.model.MyMaze.Name);
            NotifyPropertyChanged("MyMaze");/////////////////////
        }
    }
}
