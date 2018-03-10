using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;
//Copyright Asmcx15-2018
namespace HypercamPRANK
{
    class Program
    {
        //Dll Imports
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);
        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            while (true)
            {
                IntPtr desktopPtr = GetDC(IntPtr.Zero);
                Graphics g = Graphics.FromHdc(desktopPtr);
                //Draw "Unregistered HyperCam 2" on the screen
                g.DrawImage(LoadImage(), new Point(0, 0));
                g.Dispose();
                ReleaseDC(IntPtr.Zero, desktopPtr);
            }
        }
        public static Image LoadImage()
        {
            //Unregistered HyperCam 2 Logo in Base64
            byte[] bytes = Convert.FromBase64String("R0lGODlhqAAQAPABAAAAAP///yH5BAAAAAAAIf8LSW1hZ2VNYWdpY2sOZ2FtbWE9MC40NTQ1NDUALAAAAACoABAAAALpjI+py+0Po5y02ouz3rz7D4bi2AAAYo4pqazoebiiKXM0HMi1t7/frsOFVr0LERZkOYpGoSE5Ezozx6cUeYvRrMFtDpf9Hl3hMBd4/fpuV/K2aGabGVWt9S7G1/dYfT+vFlj3Ihd4x+f3l4AoOGWH5xd5xjj4WGh4WQnZKDnm5Vby+QeXZjkKNsUohroJidZqyCmriemoRulYA6X6Kuvj+xgr+evqNZvKGtN52pKryMt8vDyM20wcF11ZLb1oO6e6Sjj4jQWq1dW7id6WfM6ejTzHwqSEAVWPb0Gb39TN/z9BHsAK6QZOKAAAOw==");
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
