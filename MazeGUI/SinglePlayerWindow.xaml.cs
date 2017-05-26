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
using System.Windows.Threading;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window
    {
        
        private SinglePlayerVM vm;
        //private TheMazeBoard board;
       /* int MazeRows
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
        }*/
        public SinglePlayerWindow(string name, int rows, int cols)
        {
            InitializeComponent();
            vm = new SinglePlayerVM();
            this.DataContext = vm;
            vm.CrerateMaze(name, rows, cols);
          //  this.Show();


        }
      
        private void btnRestartGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to restart the game", "Restart Game", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    vm.Restart();
                    mySingleGame.Draw(vm.VM_MazeString, vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_CurPos, vm.VM_GoalPos, "resources/harry potter.jpg" );
                    break;

                case MessageBoxResult.No:
                    break;
            }
            
          //  this.Show();
        }

        private void btnSolveMaze_Click(object sender, RoutedEventArgs e)
        {
            this.vm.GetSolution();
            for (int i = 0; i < vm.Solution.Length; i++)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
                {
                    this.vm.Move(this.vm.ConvertStep(int.Parse(vm.Solution[i].ToString())));
                    Thread.Sleep(500);
                    mySingleGame.Draw(vm.VM_MazeString, vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_CurPos, vm.VM_GoalPos, "resources/harry potter.jpg");
                }
                ));
                if (vm.VM_CurPos.Equals(vm.VM_GoalPos))
                {
                    MessageBoxResult result = MessageBox.Show("You Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    //this.Hide();
                    this.Close();
                }
            }
          
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to leave?", "Main menu", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    // this.Hide();
                    this.Close();
                    break;

                case MessageBoxResult.No:
                    break;
            }
            
        }


        private void singleGame_Loaded(object sender, RoutedEventArgs e)
        {

           // Thread.Sleep(1);
            //this.board = new TheMazeBoard(this.vm.VM_MazeName, this.vm.VM_MazeRows, this.vm.VM_MazeCols, this.vm.VM_CurPos, this.vm.VM_GoalPos);
            mySingleGame.Draw(vm.VM_MazeString, vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_CurPos, vm.VM_GoalPos, "resources/harry potter.jpg");

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                vm.Move("up");
            }
            if (e.Key == Key.Down)
            {
                vm.Move("down");
            }
            if (e.Key == Key.Left)
            {
                vm.Move("left");
            }
            if (e.Key == Key.Right)
            {
                vm.Move("right");
            }
            mySingleGame.Draw(vm.VM_MazeString, vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_CurPos, vm.VM_GoalPos, "resources/harry potter.jpg");
            if (vm.VM_CurPos.Equals(vm.VM_GoalPos))
            {
                MessageBoxResult result = MessageBox.Show("You Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mw = new MainWindow();
                mw.Show();
                //this.Hide();
                this.Close();
            }
        }


    }
}
