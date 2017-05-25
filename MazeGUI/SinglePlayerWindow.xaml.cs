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
using System.Threading;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window
    {
        
        private SinglePlayerVM vm;
        //private TheMazeBoard board;
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
            set
            {
                this.vm.VM_MazeName = value;
            }
        }
        public SinglePlayerWindow(string name, int rows, int cols)
        {
            InitializeComponent();
            vm = new SinglePlayerVM();
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
            this.vm.SolveMaze();
            this.Hide();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }


        private void singleGame_Loaded(object sender, RoutedEventArgs e)
        {

            //Thread.Sleep(1);
            //this.board = new TheMazeBoard(this.vm.VM_MazeName, this.vm.VM_MazeRows, this.vm.VM_MazeCols, this.vm.VM_CurPos, this.vm.VM_GoalPos);
            mySingleGame.Draw(vm.VM_MazeString, vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_CurPos, vm.VM_GoalPos);

        }

       
    }
}
