using System;
using System.Collections.Generic;
using PInvoke;

namespace CloseConsole.Utils
{
    public static class WindowUtils
    {
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
    }
}