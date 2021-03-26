using System;
using System.Windows;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        private TrayGui _trayGui;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _trayGui.Show();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            _trayGui = new TrayGui(this);
        }

        public void Shutdown()
        {
            _trayGui.Hide();
            Application.Current.Shutdown();
        }
    }
}
