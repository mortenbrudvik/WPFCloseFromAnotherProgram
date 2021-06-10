using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using PInvoke;

namespace CloseConsole.Utils
{
    public static class WindowUtils
    {
        public static IEnumerable<Window> GetWindows(Predicate<Window> match, int timeoutInSeconds)
        {
            var windows = new List<Window>();
            WaitWhile(() =>
            {
                windows.AddRange(GetWindows(match));
                return windows.Count > 0;
            }, timeoutInSeconds);

            return windows;
        }
        
        public static List<Window> GetWindows(Predicate<Window> match)
        {
            var windows = new List<Window>();
            User32.EnumWindows((handle, _) =>
            {
                var window = new Window(handle);
                if(match(window))
                    windows.Add(window);

                return true;
            }, IntPtr.Zero);

            return windows;
        }
        
        private static void WaitWhile(Func<bool> waitWhile, int timeoutInSeconds = 5, int sleepIntervalInMs = 100)
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