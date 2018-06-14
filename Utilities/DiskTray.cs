// CODE FROM GITHUB
// MADE BY BLACHNIET
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AlexejheroYTB.Utilities.AttackoftheTray
{
    internal class Program
    {
        /*static void Main(string[] args)
        {
            ConsoleKey key;
            while (true)
            {
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.O:
                        open();
                        break;
                    case ConsoleKey.C:
                        close();
                        break;
                    default:
                        return;
                }
            }
        }*/

        internal static void Open()
        {
            int ret = MciSendString("set cdaudio door open", null, 0, IntPtr.Zero);
        }

        internal static void Close()
        {
            int ret = MciSendString("set cdaudio door closed", null, 0, IntPtr.Zero);
        }

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi)]
        protected static extern int MciSendString(string lpstrCommand,
                                                   StringBuilder lpstrReturnString,
                                                   int uReturnLength,
                                                   IntPtr hwndCallback);
    }
}