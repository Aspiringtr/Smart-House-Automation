using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cctv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new Dashboard();

        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (this.WindowState == WindowState.Maximized)
                {

                    var screenPos = PointToScreen(e.GetPosition(this));

                    // Calculate ratio of mouse position across window width
                    double xRatio = e.GetPosition(this).X / this.ActualWidth;

                    // Restore to normal size
                    this.WindowState = WindowState.Normal;

                    // Set new window position so cursor stays at same spot on restored window
                    this.Left = screenPos.X - (this.ActualWidth * xRatio);
                    this.Top = screenPos.Y - e.GetPosition(this).Y;
                }

                this.DragMove();
            }
        }

        private void dashBoardClick(object sender, RoutedEventArgs e) 
        {
            MainContent.Content = new Dashboard();
        }
        private void liveViewClick(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new LiveView();
        }
    }
}