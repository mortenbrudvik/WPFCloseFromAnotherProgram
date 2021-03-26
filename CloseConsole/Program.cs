using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using PInvoke;
using static System.Console;
using static CloseConsole.Utils.WindowUtils;

namespace CloseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Testing closing WPFApp from Console");

            WaitWhile(() => GetWindows(win => win.Title.Contains("WPFCloseBonanza")).Count == 0);
            var windowHandle = GetWindows(win => win.Title.Contains("WPFCloseBonanza")).First().Handle;

            WriteLine($"Press key to close WPF window (Handle: {windowHandle})");
            ReadKey();
            
            WriteLine("Closing WPF window");
            User32.PostMessage(windowHandle, User32.WindowMessage.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        public static void WaitWhile(Func<bool> waitWhile, int timeoutInSeconds = 5, int sleepIntervalInMs = 100)
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
