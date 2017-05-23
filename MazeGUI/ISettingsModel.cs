using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
    interface ISettingsModel : INotifyPropertyChanged
    {
        string ServerIP { get; set; }
        int ServerPort { get; set; }
        int MazeRows { get; set; }
        int MazeCols { get; set; }
        int SearchAlgorithm { get; set; }
        void SaveSettings();
    }
}
