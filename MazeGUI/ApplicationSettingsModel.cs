using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;

namespace MazeGUI
{
    class ApplicationSettingsModel : ISettingsModel
    {
        public string ServerIP
        {
            get { return Properties.Settings.Default.ServerIP; }
            set { Properties.Settings.Default.ServerIP = value;
                NotifyPropertyChanged("ServerIP");

            }
        }
        public int ServerPort
        {
            get { return Properties.Settings.Default.ServerPort; }
            set
            {
                Properties.Settings.Default.ServerPort = value;
                NotifyPropertyChanged("ServerPort");
            }
        }

        public int MazeRows
        {
            get
            {
               return Properties.Settings.Default.MazeRows;
            }
            set
            {
                Properties.Settings.Default.MazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }
        public int MazeCols
        {
            get
            {
                return Properties.Settings.Default.MazeCols;
            }
            set
            {
                Properties.Settings.Default.MazeCols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }
        public int SearchAlgorithm
        {
            get
            {
                return Properties.Settings.Default.SearchAlgorithm;
            }
            set
            {
                Properties.Settings.Default.SearchAlgorithm = value;
                NotifyPropertyChanged("SearchAlgorithm");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
