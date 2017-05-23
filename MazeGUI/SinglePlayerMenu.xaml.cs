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
    /// Interaction logic for SinglePlayerMenu.xaml
    /// </summary>
    public partial class SinglePlayerMenu : Window
    {
        SinglePlayerVM vm;
        public SinglePlayerMenu()
        {
            InitializeComponent();
            vm = new SinglePlayerVM(new SinglePlayerModel(vm.VM_MazeName, vm.VM_MazeRows, vm.VM_MazeCols));
            this.DataContext = vm;
        }
    }
}
