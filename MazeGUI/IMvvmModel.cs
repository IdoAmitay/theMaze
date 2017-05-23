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
         bool IsConnected();
        void CommunicateWithServer();
        void Close();
        void sendCommand(string s);
        void ConnectToserver();



    }
}
