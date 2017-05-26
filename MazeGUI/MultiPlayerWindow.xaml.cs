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
    /// Interaction logic for MultiPlayerWindow.xaml
    /// </summary>
    public partial class MultiPlayerWindow : Window
    {
        MultiPlayerVM vm;
        public MultiPlayerWindow()
        {
            InitializeComponent();
            vm = new MultiPlayerVM();
            this.DataContext = vm;
        }

        private void btnBackToMainMenu_Click(object sender, RoutedEventArgs e)
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

        private void myGame_Loaded(object sender, RoutedEventArgs e)
        {
            myGame.Draw(vm.VM_MazeString, vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_CurPos, vm.VM_GoalPos, "resources/harry potter.jpg");
        }

        private void yourGame_Loaded(object sender, RoutedEventArgs e)
        {
            yourGame.Draw(vm.VM_MazeString, vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_CurPos, vm.VM_GoalPos, "resources/malfoy 2.jpg");
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
            myGame.Draw(vm.VM_MazeString, vm.VM_MazeRows, vm.VM_MazeCols, vm.VM_CurPos, vm.VM_GoalPos, "resources/harry potter.jpg");
            if (vm.VM_CurPos.Equals(vm.VM_GoalPos))
            {
                MessageBoxResult result = MessageBox.Show("Harry Potter Win!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mw = new MainWindow();
                mw.Show();
                //this.Hide();
                this.Close();
            }
        }

    }
}
