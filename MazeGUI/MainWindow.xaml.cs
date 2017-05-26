using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Single(object sender, RoutedEventArgs e)
        {
            SinglePlayerMenu sp = new SinglePlayerMenu();
            this.Close();

            sp.Show();
        }

        private void Button_Click_Settings(object sender, RoutedEventArgs e)
        {

            // vm.SaveSettings();
            Window win = new GameSettingswindow();
            win.Show();
            this.Hide();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MultiPlayerMenu mp = new MultiPlayerMenu();
            mp.Show();
            this.Hide();
        }

        
    }
}
