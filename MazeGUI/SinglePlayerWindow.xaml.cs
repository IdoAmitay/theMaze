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
        public SinglePlayerWindow(string name, int rows, int cols)
        {
            InitializeComponent();
            vm = new SinglePlayerVM(new SinglePlayerModel(name, rows, cols));
            this.DataContext = vm;
        }


        private void myCanvasSingle_Loaded(object sender, RoutedEventArgs e)
        {
            myCanvasSingle.Draw("*0100110001#");
        }
    }
}
