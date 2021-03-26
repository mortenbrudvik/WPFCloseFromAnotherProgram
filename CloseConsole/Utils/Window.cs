using System;
using System.Diagnostics;
using PInvoke;

namespace CloseConsole.Utils
{
    public class Window 
    {
        public Window(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle { get; }
        public string Title => User32.GetWindowText(Handle);
        public bool IsVisible => User32.IsWindowVisible(Handle);
        public string ClassName => User32.GetClassName(Handle);

        public string ProcessName => Process.GetProcessById(ProcessId).ProcessName.Trim();
        public int ProcessId
        {
            get
            {
                User32.GetWindowThreadProcessId(Handle, out var processId);
                return processId;
            }
        }
    }
}