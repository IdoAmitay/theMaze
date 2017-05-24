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
using MazeLib;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window
    {
        
        private SinglePlayerVM vm;
        int MazeRows
        {
            get
            {
                return vm.VM_MazeRows;
            }
        }
        string MazeName {
            get
            {
                return vm.VM_MazeName;
            }
        }
        public SinglePlayerWindow(string name, int rows, int cols)
        {
            InitializeComponent();
            vm = new SinglePlayerVM(/*new SinglePlayerModel(name, rows, cols)*/);
            this.DataContext = vm;
            vm.CrerateMaze(name, rows, cols);
           
        }

        private void btnRestartGame_Click(object sender, RoutedEventArgs e)
        {
            SinglePlayerMenu sp = new SinglePlayerMenu();
            sp.Show();
            this.Hide();
        }

        private void btnSolveMaze_Click(object sender, RoutedEventArgs e)
        {
            SinglePlayerMenu sp = new SinglePlayerMenu();////////////////////
            sp.Show();
            this.Hide();
        }

        private void BbtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }


        private void myCanvasSingle_Loaded(object sender, RoutedEventArgs e)
        {
            //myCanvasSingle.Draw(vm.VM_MazeString);
            
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
