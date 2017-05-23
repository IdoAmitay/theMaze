using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for GameSettingswindow.xaml
    /// </summary>
    public partial class GameSettingswindow : Window
    {
        private SettingsViewModel vm;
        public GameSettingswindow()
        {
            ISettingsModel model = new ApplicationSettingsModel();
            InitializeComponent();
            vm = new SettingsViewModel(model);
            this.DataContext = vm;
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
} 
