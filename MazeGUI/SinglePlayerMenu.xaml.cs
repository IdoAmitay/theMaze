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

        // string Name { get; set; }
        public int DefaultRows { get; set; }
        public int DefaultCols { get; set; }

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(SinglePlayerMenu), new PropertyMetadata(default(string)));


        // int Rows { get; set; }
/*

        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Rows.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.Register("Rows", typeof(int), typeof(SinglePlayerMenu), new PropertyMetadata(0));


        // int Cols { get; set; }


        public int Cols
        {
            get { return (int)GetValue(ColsProperty); }
            set { SetValue(ColsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cols.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColsProperty =
            DependencyProperty.Register("Cols", typeof(int), typeof(SinglePlayerMenu), new PropertyMetadata(0));

        */
        SinglePlayerVM vm;
        public SinglePlayerMenu()
        {
            this.DefaultRows = Properties.Settings.Default.MazeRows;
            this.DefaultCols = Properties.Settings.Default.MazeCols;
            InitializeComponent();
            vm = new SinglePlayerVM(/*new SinglePlayerModel(vm.VM_MazeName, vm.VM_MazeRows, vm.VM_MazeCols)*/);
            this.DataContext = this;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            // Window singlePlayerGame = new SinglePlayerWindow(Name, Rows,Cols);
             Window singlePlayerGame = new SinglePlayerWindow(Name, DefaultRows,DefaultCols);

            this.Close();
            singlePlayerGame.Show();



        }

        private void txtCols_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
