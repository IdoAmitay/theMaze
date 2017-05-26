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
    /// Interaction logic for MultiPlayerMenu.xaml
    /// </summary>
    public partial class MultiPlayerMenu : Window
    {
        private MultiPlayerVM vm = new MultiPlayerVM();
        public MultiPlayerMenu()
        {
            InitializeComponent();
            this.DataContext = this;
            this.vm.List();
            this. Rows = Properties.Settings.Default.MazeRows;
            this.Cols = Properties.Settings.Default.MazeCols;

        }

        public int Rows { get; set; }
        public int Cols { get; set; }
        public List<string> Games
        {
            get { return (List<string>)GetValue(GamesProperty); }
            set { SetValue(GamesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Games.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GamesProperty =
            DependencyProperty.Register("Games", typeof(List<string>), typeof(MultiPlayerMenu), new PropertyMetadata(default(List<string>)));



        public string MazeName
        {
            get { return (string)GetValue(MazeNameProperty); }
            set { SetValue(MazeNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeNameProperty =
            DependencyProperty.Register("MazeName", typeof(string), typeof(MultiPlayerMenu), new PropertyMetadata(default(string)));


        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            MultiPlayerWindow mp = new MultiPlayerWindow(MazeName,Rows,Cols);
            this.Close();
            mp.Show();
        }
    }
}
