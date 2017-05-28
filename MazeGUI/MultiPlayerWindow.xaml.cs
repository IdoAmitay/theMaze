using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for MultiPlayerWindow.xaml
    /// </summary>
    public partial class MultiPlayerWindow : Window
    {
        MultiPlayerVM vm;
       
        public MultiPlayerWindow()
        {
            InitializeComponent();
            //vm = new MultiPlayerVM();
            this.vm = MultiPlayerVM.Instance;
            this.DataContext = this.vm;
            vm.PropertyChanged += MyPropertyChangedEventHandler;
           /* Task task = new Task(() =>
            {
                while (!vm.VM_CurPos.Equals(vm.VM_GoalPos) && !vm.VM_OppPos.Equals(vm.VM_GoalPos))
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
                    {

                        myGame.Draw(vm.VM_Maze.ToString(), vm.VM_MazeRows, vm.VM_MazeCols, 
                            vm.VM_CurPos, vm.VM_GoalPos, "resources/harry potter.jpg");
                        yourGame.Draw(vm.VM_Maze.ToString(), vm.VM_MazeRows, vm.VM_MazeCols,
                            vm.VM_OppPos, vm.VM_GoalPos, "resources/malfoy 2.jpg");
                        Thread.Sleep(100);
                    }

                          ));
                }
            });
            task.Start();*/


            //vm.StartGame(name, rows, cols);
           
        }
        
        private void MyPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() => {
                myGame.Draw(vm.VM_Maze.ToString(), vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_CurPos, vm.VM_GoalPos, "resources/harry potter.jpg");
                yourGame.Draw(vm.VM_Maze.ToString(), vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_OppPos, vm.VM_GoalPos, "resources/malfoy 2.jpg");

                if (vm.VM_CurPos.Equals(vm.VM_GoalPos) || vm.VM_OppPos.Equals(vm.VM_GoalPos) ||
                !this.vm.VM_IsOppConnected)
                {
                    if (vm.VM_CurPos.Equals(vm.VM_GoalPos))
                    {
                        MessageBoxResult result = MessageBox.Show("Harry Potter Won!", "Game Over");
                    }
                     if (vm.VM_OppPos.Equals(vm.VM_GoalPos))
                    {
                        MessageBoxResult result = MessageBox.Show("You Lost to Darco...", "Game Over");
                    }
                    if (!this.vm.VM_IsOppConnected && !this.vm.VM_ILeft)
                    {
                        MessageBoxResult result = MessageBox.Show("The opponent has left...", "Game Over");

                    }
                    MainWindow mainWin = new MainWindow();
                    mainWin.Show();
                    this.Close();
                }
                
                /*if (vm.VM_SecondClientClosed == true)
                {
                    MessageBoxResult result = MessageBox.Show("The other client has left the game.", "End of game");
                    MainWindow mainWin = new MainWindow();
                    this.Close();
                    mainWin.Show();

                }*/
            }

              ));
        }

        /*public void func ()
         {
             while (!vm.VM_CurPos.Equals(vm.VM_GoalPos) && !vm.VM_OppPos.Equals(vm.VM_GoalPos))
             {
                 Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
                 {

                     myGame.Draw(vm.VM_Maze.ToString(), vm.VM_MazeRows, vm.VM_MazeCols,
                         vm.VM_CurPos, vm.VM_GoalPos, "resources/harry potter.jpg");
                     yourGame.Draw(vm.VM_Maze.ToString(), vm.VM_MazeRows, vm.VM_MazeCols,
                         vm.VM_OppPos, vm.VM_GoalPos, "resources/malfoy 2.jpg");
                     Thread.Sleep(200);
                 }

                       ));
             }
         }*/
        private void btnBackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult result = MessageBox.Show("Are you sure you want to leave?", "Main menu", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                   // MainWindow mw = new MainWindow();
                    this.vm.Close();
                   // mw.Show();
                    // this.Hide();
                    this.Close();
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        private void myGame_Loaded(object sender, RoutedEventArgs e)
        {
            myGame.Draw(vm.VM_MazeString, vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_CurPos, vm.VM_GoalPos, "resources/harry potter.jpg");
        }

        private void yourGame_Loaded(object sender, RoutedEventArgs e)
        {
            yourGame.Draw(vm.VM_MazeString, vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_OppPos, vm.VM_GoalPos, "resources/malfoy 2.jpg");
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                vm.Play("up");
            }
            if (e.Key == Key.Down)
            {
                vm.Play("down");
            }
            if (e.Key == Key.Left)
            {
                vm.Play("left");
            }
            if (e.Key == Key.Right)
            {
                vm.Play("right");
            }
           // myGame.Draw(vm.VM_MazeString, vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_CurPos, vm.VM_GoalPos, "resources/harry potter.jpg");
           // yourGame.Draw(vm.VM_MazeString, vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_OppPos, vm.VM_GoalPos, "resources/malfoy 2.jpg");
           /* if (vm.VM_CurPos.Equals(vm.VM_GoalPos))
            {
                MessageBoxResult result = MessageBox.Show("Harry Potter Win!", "Darco Malfoy win!", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mw = new MainWindow();
                mw.Show();
                //this.Hide();
                this.Close();
            }*/
        }

    }
}
