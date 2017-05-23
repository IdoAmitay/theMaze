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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for TheMazeBoard.xaml
    /// </summary>
    public partial class TheMazeBoard : UserControl
    {
        public  TheMazeBoard()
        {
            InitializeComponent();
        }

        public string MazeName
        {
            get { return (string)GetValue(MazeNameProperty); }
            set { SetValue(MazeNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeNameProperty =
            DependencyProperty.Register("MazeName", typeof(string), typeof(TheMazeBoard));


        public int MazeRows
        {
            get { return (int)GetValue(MazeRowsProperty); }
            set { SetValue(MazeRowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeRows.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeRowsProperty =
            DependencyProperty.Register("MazeRows", typeof(int), typeof(TheMazeBoard));



        public int MazeCols
        {
            get { return (int)GetValue(MazeColsProperty); }
            set { SetValue(MazeColsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeCols.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeColsProperty =
            DependencyProperty.Register("MazeCols", typeof(int), typeof(TheMazeBoard));


        public string InitialPos
        {
            get { return (string)GetValue(InitialPosProperty); }
            set { SetValue(InitialPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InitialPos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InitialPosProperty =
            DependencyProperty.Register("InitialPos", typeof(string), typeof(TheMazeBoard));


        public string GoalPos
        {
            get { return (string)GetValue(GoalPosProperty); }
            set { SetValue(GoalPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoalPos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GoalPosProperty =
            DependencyProperty.Register("GoalPos", typeof(string), typeof(TheMazeBoard));



        public void Draw(string recsStr)
        {
            int rectindex = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Rectangle rect = new Rectangle()
                    {
                        Height = 100,
                        Width = 100,
                        Fill = Brushes.White,
                        Stroke = Brushes.Black,
                        StrokeThickness = 2
                    };
                    //rec.Height = 150;
                    //rec.Width = 150;

                    if (recsStr[rectindex] == '1')
                        rect.Fill = Brushes.Black;
                    else if (recsStr[rectindex] == '0')
                        rect.Fill = Brushes.White;
                    else if (recsStr[rectindex] == '*')
                        rect.Fill = Brushes.Red;
                    else
                        rect.Fill = Brushes.Blue;

                    //rec.Stroke = new SolidColorBrush(Colors.Black);

                    Canvas.SetTop(rect, i * rect.Height);
                    Canvas.SetLeft(rect, j * rect.Width);
                    myCanvas.Children.Add(rect);


                    rectindex++;
                }
            }
            Rectangle r = new Rectangle()
            {
                Height = 100,
                Width = 100,
                Fill = Brushes.White,
                Stroke = Brushes.Black,
                StrokeThickness = 3
            };
            Canvas.SetBottom(r, 100);
            myCanvas.Children.Add(r);
        }
    }
}
