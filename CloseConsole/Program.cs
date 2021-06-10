using System;
using System.Linq;
using PInvoke;
using static System.Console;
using static CloseConsole.Utils.WindowUtils;

namespace CloseConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WriteLine("Testing closing WPFApp from Console. To simulate close message from msi installer.");

            WriteLine("Press a key to start searching for WPF Window");
            ReadKey();
            var windowHandle = GetWindows(win => win.Title.Contains("WPFCloseBonanza"), 3).First().Handle;

            WriteLine($"Press key to close WPF window (Handle: {windowHandle})");
            ReadKey();
            
            WriteLine("Closing WPF window");
            User32.PostMessage(windowHandle, User32.WindowMessage.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
