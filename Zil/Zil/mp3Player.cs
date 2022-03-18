using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Zil
{
    class mp3Player : IDisposable
    {
        public mp3Player(string fileName)
        {
            const string FORMAT = @"open ""{0}"" type mpegvideo alias MediaFile";
            string command = String.Format(FORMAT, fileName);
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void Play()
        {
            string command = "play MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallBack);
        public void Dispose()
        {
            string command = "stop MediaFile";
        }
    }
}
