using System;
using System.Diagnostics;
using System.Threading;
using PInvoke;
using static System.Console;

namespace CloseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Testing closing WPFApp from Console");

            var process = Process.Start("WPFApp.exe");
            WaitWhile(() => process.MainWindowHandle == IntPtr.Zero);
            var windowHandle = process.MainWindowHandle;
            WriteLine($"Press key to close WPF window (Handle: {windowHandle})");
            ReadKey();
            WriteLine("Closing WPF window");

            User32.PostMessage(windowHandle, User32.WindowMessage.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);


        }

        public static void WaitWhile(Func<bool> waitWhile, int timeoutInSeconds = 2, int sleepIntervalInMs = 100)
        {
            var watch = new Stopwatch();
            watch.Start();
            while ( waitWhile() && watch.ElapsedMilliseconds < timeoutInSeconds*1000)
            {
                Thread.Sleep(sleepIntervalInMs);
            }
        }
    }
}
