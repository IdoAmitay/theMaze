using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MazeGUI
{
    class SettingsViewModel : ViewModel
    {
        private ISettingsModel model;
        public SettingsViewModel(ISettingsModel model)
        {
            this.model = model;
        }
        public string ServerIP
        {
            get { return model.ServerIP; }
            set
            {
                model.ServerIP = value;
                NotifyPropertyChanged("ServerIP");
            }
        }

        public static readonly DependencyProperty ServerIPProperty =
            DependencyProperty.Register("ServerIP", typeof(int), typeof(TheMazeBoard), new PropertyMetadata(0));


        public int ServerPort
        {
            get { return model.ServerPort; }
            set
            {
                model.ServerPort = value;
                NotifyPropertyChanged("ServerPort");
            }
        }

        public static readonly DependencyProperty ServerPortProperty =
            DependencyProperty.Register("ServerPort", typeof(int), typeof(TheMazeBoard), new PropertyMetadata(0));


        public int MazeRows
        {
            get { return model.MazeRows; }
            set
            {
                model.MazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }

        // Using a DependencyProperty as the backing store for MazeRows.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeRowsProperty =
            DependencyProperty.Register("MazeRows", typeof(int), typeof(TheMazeBoard), new PropertyMetadata(0));


        public int MazeCols
        {
            get { return model.MazeCols; }
            set
            {
                model.MazeCols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }

        // Using a DependencyProperty as the backing store for MazeCols.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeColsProperty =
            DependencyProperty.Register("MazeCols", typeof(int), typeof(TheMazeBoard), new PropertyMetadata(0));



        public int SearchAlgorithm
        {
            get { return model.SearchAlgorithm; }
            set
            {
                model.SearchAlgorithm = value;
                NotifyPropertyChanged("SearchAlgorithm");
            }
        }

        // Using a DependencyProperty as the backing store for SearchAlgorithm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchAlgorithmProperty =
            DependencyProperty.Register("SearchAlgorithm", typeof(int), typeof(TheMazeBoard), new PropertyMetadata(0));

        public void SaveSettings()
        {
            model.SaveSettings();
        }
    }
}
