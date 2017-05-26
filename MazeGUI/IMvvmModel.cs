using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
    interface IMvvmModel : INotifyPropertyChanged
    {
        Dictionary<string, Action<string>> Commands { get; set; }
        MazeLib.Maze MyMaze { get; set; }
        MazeLib.Position CurPos { get; set; }
        string Solution { get; set; }
        List<string> Games { get; set; }
        MazeLib.Position OppPos { get; set; }

        bool IsConnected();
        void CommunicateWithServer();
        void Close();
        void sendCommand(string s);
        void ConnectToserver();
        void UpdatePositionFromJson(string json);
        void UpdatePosition(ref MazeLib.Position pos, string direction);
        void UpdateMaze(string maze);
        void UpdateSolution(string json);
        void TalkWithServer(string myCommand);
        void GetGamesList(string json);




    }
}
