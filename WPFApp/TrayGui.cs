using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace WPFApp
{
    public class TrayGui
    {
        private readonly MainWindow _window;
        private NotifyIcon _notifyIcon;
        private ContextMenuStrip _contextMenu;

        public TrayGui(MainWindow window)
        {
            _window = window;
        }

        public void Show()
        {
            if (_notifyIcon != null)
                return;

            _notifyIcon = new NotifyIcon();
            _notifyIcon.MouseDown += NotifyIconOnMouseDown;

            var uri = new Uri("pack://application:,,,/mb.ico", UriKind.Absolute);
            _notifyIcon.Icon = new Icon(Application.GetResourceStream(uri).Stream);
            _notifyIcon.Visible = true;
            _notifyIcon.Text = "WPFApp";
            

            _contextMenu = new ContextMenuStrip();
            _contextMenu.Items.Add(new ToolStripMenuItem("Quit", null, Quit_Click));
            _notifyIcon.ContextMenuStrip = _contextMenu;
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            _window.Shutdown();
        }

        public void Hide()
        {
            if (_notifyIcon == null) return;

            _notifyIcon.Visible = false;
            _notifyIcon = null;
        }

        private void NotifyIconOnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ShowWindow();
        }

        private void ShowWindow()
        {
            _window.Show();
            _window.WindowState = WindowState.Normal;
        }
    }
}