using System.Windows;

namespace WPFApp
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel(Show, Close, Hide);
        }
    }
}
