using System;
using System.ComponentModel;
using System.Windows;

namespace WPFApp
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel(Show, Close);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        // protected override void OnSourceInitialized(EventArgs e)
        // {
        //     base.OnSourceInitialized(e);
        //     var source = PresentationSource.FromVisual(this) as HwndSource;
        //     source.AddHook(WndProc);
        // }
        //
        // static uint WM_CLOSE = 0x10;
        // public const Int32 WM_SYSCOMMAND = 0x112;
        // private static uint SC_CLOSE = 0xF060;
        // private bool _wmCloseCalled;
        // private bool _scCloseCalled;
        //
        // /// <summary>
        // /// WM_CLOSE is sent as a window message whenever the window is requested to be closed, by any means.
        // /// SC_CLOSE is sent as a parameter of a WM_SYSCOMMAND message, when the user presses the Close button (or selects Close from the control menu of the window).
        // /// </summary>
        // private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        // {
        //     var isThisWindow = hwnd == Process.GetCurrentProcess().MainWindowHandle;
        //
        //     if (msg == WM_CLOSE && isThisWindow)
        //         _wmCloseCalled = true;
        //     
        //     if (msg == WM_SYSCOMMAND && wParam.ToInt32() == SC_CLOSE && isThisWindow)
        //         _scCloseCalled = true;
        //     
        //     return IntPtr.Zero;
        // }
    }
}
