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
        private MultiPlayerVM vm;
       // public List<string> Games { get; set; }
        public MultiPlayerMenu()
        {

            InitializeComponent();
            this.vm = MultiPlayerVM.Instance;
            this.vm.VM_IsOppConnected = false;
            this.vm.List();
            this.DataContext = this;
            this. Visible= "Hidden";
           // this.Games = this.vm.Games;
            this. Rows = Properties.Settings.Default.MazeRows;
            this.Cols = Properties.Settings.Default.MazeCols;
            

        }


        public string Visible
        {
            get { return (string)GetValue(VisibleProperty); }
            set { SetValue(VisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Visible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibleProperty =
            DependencyProperty.Register("Visible", typeof(string), typeof(MultiPlayerMenu), new PropertyMetadata(default(string)));


        public int Rows { get; set; }
        public int Cols { get; set; }
        public List<string> Games
        {
            get
            {
                return this.vm.Games;
            }
        }
      /*  public List<string> Games
        {
            get { return (List<string>)GetValue(GamesProperty); }
            set { SetValue(GamesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Games.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GamesProperty =
            DependencyProperty.Register("Games", typeof(List<string>), typeof(MultiPlayerMenu), new PropertyMetadata(default(List<string>)));*/



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
            this.vm.JoinGame(this.cboListOfGames.SelectedItem.ToString());
            this.vm.VM_IsOppConnected = true;
            MultiPlayerWindow mp = new MultiPlayerWindow();
            this.Close();
            mp.Show();
        //    mp.func();
            
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            this.Visible = "Visible";
            //this.Show();

            this.vm.StartGame(MazeName, Rows, Cols);
            MultiPlayerWindow mp = new MultiPlayerWindow();
            this.Close();
            this.vm.VM_IsOppConnected = true;
            mp.Show();
           // mp.func();
            


        }
    }
}
