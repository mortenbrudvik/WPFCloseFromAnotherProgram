using System;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace WPFApp
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel(Show, Close, Hide);
        }

        protected override async void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            Hide();
            
            var notificationView = new NotificationView()
            {
                Title = "WPFApp",
                Message = "The application window has been minimized to tray."
            };

            TaskbarIcon.ShowCustomBalloon(notificationView, PopupAnimation.Slide, 4000);

            await Task.Delay(4000);
            TaskbarIcon.CloseBalloon();
        }
    }
}
