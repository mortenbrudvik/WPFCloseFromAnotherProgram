using System.Windows;
using System.Windows.Input;
using Hardcodet.Wpf.TaskbarNotification;

namespace WPFApp
{
    public partial class NotificationView
    {
        public NotificationView() => InitializeComponent();

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof (string), typeof (NotificationView), new FrameworkPropertyMetadata(string.Empty));

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(nameof(Message), typeof (string), typeof (NotificationView), new FrameworkPropertyMetadata(string.Empty));

        public string Message
        {
            get => (string) GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        private void grid_MouseEnter(object sender, MouseEventArgs e)
        {
            var taskbarIcon = TaskbarIcon.GetParentTaskbarIcon(this);
            taskbarIcon.ResetBalloonCloseTimer();
        }
    }
}