using PS2.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PS2.Utilities
{
    public class ProcessUtility
    {
        const Int32 WM_CHAR = 0x0102;
        const uint WM_KEYDOWN = 0x0100;
        const uint WM_KEYUP = 0x0101;
        const int VK_TAB = 0x09;
        const int VK_ENTER = 0x0D;
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;

        #region import WinAPI
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        #endregion
        public void RunProcess(Account acc, Settings settings)
        {
            var clientToRun = GetClientPath(acc, settings);

            if (settings.RenameClientWindow)
            {
                ChangeProductNameInL2int(acc.Name, clientToRun);
            }

            Process proc = Process.Start(clientToRun);

            proc.WaitForInputIdle();
            if (proc.MainWindowTitle.Equals("Warning")) //skip warning
            {
                proc.CloseMainWindow();
            }

            IntPtr hWnd = FindWindow("L2UnrealWWindowsViewportWindow", acc.Name + " Lineage II");
            while (hWnd == IntPtr.Zero)
            {
                //TODO infinity loop in case client closed before inputCreds (
                Thread.Sleep(1000);
                hWnd = FindWindow("L2UnrealWWindowsViewportWindow", acc.Name + " Lineage II");
            }

            if (hWnd != IntPtr.Zero)
            {
                new Thread(delegate () { InputCreds(hWnd, acc, settings); }).Start();
            }

            VolumeMixer.SetApplicationMute(proc.Id, !acc.Sound);

            if (settings.RenameClientWindow)
            {
                ChangeProductNameInL2int("Lineage II", clientToRun);
            }
            //delay to set lineage 2 product back
            Thread.Sleep(1000);
        }

        public void InputCreds(IntPtr handle, Account acc, Settings settings)
        {
            ShowWindow(handle, 4); // SW_SHOWNOACTIVATE
            Thread.Sleep(750);

            //turn off capslock
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }

            foreach (char ch in acc.GameAccount.ToCharArray())
            {
                PostMessage(handle, WM_CHAR, ch, 0);
            }

            Thread.Sleep(100);

            PostMessage(handle, WM_KEYDOWN, VK_TAB, 0);
            PostMessage(handle, WM_KEYUP, VK_TAB, 0);

            Thread.Sleep(100);

            foreach (char ch in acc.GamePassword.ToCharArray())
            {
                PostMessage(handle, WM_CHAR, ch, 0);
            }

            if (settings.LoginUpToCharacter)
            {
                Thread.Sleep(500);
                PostMessage(handle, WM_KEYDOWN, VK_ENTER, 0);
                PostMessage(handle, WM_CHAR, VK_ENTER, 0);
                PostMessage(handle, WM_KEYUP, VK_ENTER, 0);
                Thread.Sleep(500);
                PostMessage(handle, WM_KEYDOWN, VK_ENTER, 0);
                PostMessage(handle, WM_CHAR, VK_ENTER, 0);
                PostMessage(handle, WM_KEYUP, VK_ENTER, 0);
                Thread.Sleep(500);
                PostMessage(handle, WM_KEYDOWN, VK_ENTER, 0);
                PostMessage(handle, WM_CHAR, VK_ENTER, 0);
                PostMessage(handle, WM_KEYUP, VK_ENTER, 0);
            }
        }

        private void ChangeProductNameInL2int(string newProductName, string clientPath)
        {
            string folder = Path.GetDirectoryName(clientPath) + @"\";
            StreamWriter file = new StreamWriter(folder + @"l2b.int");
            file.WriteLine("[General]");
            file.WriteLine("Start=Lineage II (Starting)");
            file.WriteLine("Exit=Lineage II (Exiting)");
            file.WriteLine("Run=Lineage II (Running)");
            file.WriteLine("Product=" + newProductName + " Lineage II");
            file.Close();

            var l2encdec = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = folder,
                FileName = "cmd.exe",
                Arguments = "/c l2encdec.exe -h 111 l2b.int",
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(l2encdec).WaitForExit();
            string sourceFile = folder + "enc-l2b.int";
            string destinationFile = folder + "l2.int";

            FileInfo fileInf = new FileInfo(sourceFile);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(destinationFile, true);
            }
        }

        private string GetClientPath(Account acc, Settings settings)
        {
            var clientToRun = settings.MainLineageClientPath;
            if (string.IsNullOrEmpty(clientToRun))
            {
                clientToRun = settings.AlternativeLineageClientPath;
            }

            if (acc.UseAltClientPath && !string.IsNullOrEmpty(settings.AlternativeLineageClientPath))
            {
                clientToRun = settings.AlternativeLineageClientPath;
            }

            return clientToRun;
        }
    }
}
