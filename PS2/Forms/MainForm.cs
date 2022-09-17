using BrightIdeasSoftware;
using NonInvasiveKeyboardHookLibrary;
using PS2.Model;
using PS2.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PS2
{
    public partial class PsMMainForm : Form
    {
        static public readonly JsonFileUtility _jsonFileUtility = new JsonFileUtility();
        static public readonly string _settingsPath = @"./settings.json";
        static public readonly string _credsPath = @"./creds_v2.json";

        static public bool isClientSet = false;

        static public Settings _settings = new Settings();
        static public List<Account> _accounts = Account.GetAccounts();
        static public Dictionary<String, int> loginProc = new Dictionary<string, int>();

        static private Guid hotkey;
        bool setUnsetForce = false;
        KeyboardHookManager keyboardHookManager = new KeyboardHookManager();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        public PsMMainForm()
        {
            //Load last selected language based on application propertie Language (English is default)
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                    System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                System.Threading.Thread.CurrentThread.CurrentCulture =
                    System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }

            InitializeComponent();
        }

        private void PsMMainForm_Load(object sender, EventArgs e)
        {
            langComBox.DataSource = new System.Globalization.CultureInfo[] {
                System.Globalization.CultureInfo.GetCultureInfo("ru-RU"),
                System.Globalization.CultureInfo.GetCultureInfo("en-US"),
            };
            langComBox.SelectedIndex = 0;
            langComBox.DisplayMember = "NativeName";
            langComBox.ValueMember = "Name";

            if (!string.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                langComBox.SelectedValue = Properties.Settings.Default.Language;
            }

            LoadOptions();
            LoadAccounts();

            this.objectListView1.SetObjects(_accounts);
            this.objectListView1.ShowGroups = false;
            this.objectListView1.RefreshObjects(_accounts);


            this.objectListView1.RebuildColumns();
            this.objectListView1.Unsort();
            if (_settings.listState != null)
                this.objectListView1.RestoreState(_settings.listState);

            this.button1.Text = "OFF";
            this.button1.ForeColor = Color.Red;
        }

        private void addNewAccountViaForm()
        {
            AddEditForm addEdit = new AddEditForm();
            addEdit.ShowDialog();

            foreach (Account acc in addEdit.editAccounts)
            {
                if (!_accounts.Contains(acc))
                {
                    _accounts.Add(acc);
                    objectListView1.AddObject(acc);
                }
                else
                {
                    _accounts[_accounts.IndexOf(acc)] = acc;
                    objectListView1.UpdateObject(acc);
                }
            }

            this.objectListView1.RefreshObjects(_accounts);
            this.objectListView1.SelectObjects(addEdit.editAccounts);
            addEdit.editAccounts.Clear();
        }
        private void editAccountViaForm()
        {
            Account tmpAcc = (Account)objectListView1.SelectedObject;
            if (tmpAcc != null)
            {
                AddEditForm addEdit = new AddEditForm(tmpAcc);
                addEdit.ShowDialog();


                foreach (Account acc in addEdit.editAccounts)
                {
                    if (_accounts.Contains(tmpAcc))
                    {
                        _accounts[_accounts.IndexOf(tmpAcc)] = acc;
                    }
                }
                this.objectListView1.SetObjects(_accounts);
                this.objectListView1.RefreshObjects(_accounts);
                addEdit.editAccounts.Clear();
            }
            else
            {
                MessageBox.Show(Strings.EditOnceAtTime, "Information");
            }
        }
        private void deleteSelectedAccounts()
        {
            string nameTodelete = "";
            if (objectListView1.SelectedObjects.Count > 1)
            {
                foreach (Account acc in objectListView1.SelectedObjects)
                {

                    nameTodelete += "\n" + acc.Name;
                }
            }

            if (objectListView1.SelectedObject != null && objectListView1.SelectedObjects.Count == 1)
            {
                nameTodelete = ((Account)objectListView1.SelectedObject).Name;
            }
            var confirmResult = MessageBox.Show(nameTodelete,
                                  "Are you sure to delete: ",
                                  MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                foreach (Account acc in objectListView1.SelectedObjects)
                {
                    objectListView1.RemoveObject(acc);
                    _accounts.Remove(acc);
                }
            }


            objectListView1.RefreshObjects(_accounts);

        }


        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objectListView1.SelectedObjects.Count > 0)
                Clipboard.SetText(_jsonFileUtility.GetJsonString(objectListView1.SelectedObjects));
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("...that's all I can say about Vietnam.", "Forest Gump");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _jsonFileUtility.SaveFile(_credsPath, _accounts);

            this.Close();
        }



        private void importAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Accounts Files (CSV JSON)|*.CSV;*.JSON";
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (Path.GetExtension(openFileDialog1.FileName) == ".csv")
            {
                readFromCSV(openFileDialog1.FileName);
            }
            else if (Path.GetExtension(openFileDialog1.FileName) == ".json")
            {
                List<Account> toAdd = _jsonFileUtility.ReadFile<List<Account>>(openFileDialog1.FileName);

                foreach (Account acc in toAdd)
                {
                    if (_accounts.Contains(acc))
                    {
                        _accounts[_accounts.IndexOf(acc)] = acc;
                    }
                    else
                    {
                        _accounts.Add(acc);
                    }
                }
                objectListView1.SetObjects(_accounts);
                objectListView1.RefreshObjects(_accounts);
                objectListView1.SelectObjects(toAdd);
            }
        }

        private void readFromCSV(string fileName)
        {

            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            String line;
            List<Account> toAdd = new List<Account>();
            while ((line = file.ReadLine()) != null)
            {
                int firstComma = line.IndexOf(',');
                int secondComma = line.IndexOf(',', firstComma + 1);
                Account acc = new Account();
                acc.GameAccount = line.Substring(0, firstComma);
                acc.GamePassword = line.Substring(firstComma + 1, secondComma - firstComma - 1);
                acc.Name = line.Substring(secondComma + 1);
                acc.Description = "";
                acc.Occupation = "not set";
                acc.Group = "";
                acc.UseAltClientPath = false;

                toAdd.Add(acc);


            }
            foreach (Account acc in toAdd)
            {
                if (_accounts.Contains(acc))
                {
                    _accounts[_accounts.IndexOf(acc)] = acc;
                }
                else
                {
                    _accounts.Add(acc);
                }
            }

            objectListView1.SetObjects(_accounts);
            objectListView1.RefreshObjects(_accounts);
            objectListView1.SelectObjects(toAdd);

            file.Close();
        }


        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form opt = new OptionsForm();
            opt.ShowDialog();
        }

        private void objectListView1_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (objectListView1.SelectedItems.Count >= 2
                && isClientSet)
            {
                runBULKToolStripMenuItem.Enabled = true;
            }
            if (objectListView1.Items.Count > 0
                && isClientSet)
            {
                runToolStripMenuItem.Enabled = true;
            }
            if (objectListView1.SelectedObjects.Count >= 2)
            {
                useAlternativeClientToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                editToolStripMenuItem1.Enabled = false;
            }
            else
            {
                useAlternativeClientToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;
                editToolStripMenuItem1.Enabled = true;

            }
            if (objectListView1.SelectedObjects.Count == 1)
            {
                useAlternativeClientToolStripMenuItem.Checked = ((Account)objectListView1.SelectedObject).UseAltClientPath;
            }
        }

        private void loadFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Account> tmp = _jsonFileUtility.GetObjectFromJsonString<List<Account>>(Clipboard.GetText());

            if (tmp != null)
            {
                foreach (Account acc in tmp)
                {
                    if (_accounts.Contains(acc))
                    {
                        _accounts.Remove(acc);
                        objectListView1.UpdateObject(acc);
                    }
                    _accounts.Add(acc);
                    objectListView1.AddObject(acc);
                }

                objectListView1.RefreshObjects(_accounts);
                objectListView1.SelectObjects(tmp);
            }
        }

        private void useAlternativeClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objectListView1.SelectedObjects.Count == 1)
            {
                ((Account)objectListView1.SelectedObject).UseAltClientPath = useAlternativeClientToolStripMenuItem.Checked;
                objectListView1.RefreshObjects(objectListView1.SelectedObjects);
            }
        }

        private void LoadOptions()
        {
            if (!File.Exists(_settingsPath))
            {
                string lineageWindowTitle = "Lineage";
                string mainClientPath = "";

                if (System.IO.File.Exists(@"./settings.ini"))
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(@"./settings.ini");

                    try
                    {
                        String line;
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line.StartsWith("lineageWindowTitle="))
                            {
                                lineageWindowTitle = line.Substring("lineageWindowTitle=".Length);
                            }
                            if (line.StartsWith("lineagePath="))
                            {
                                mainClientPath = line.Substring("lineagePath=".Length);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show(Strings.ErrorLoadOldSettings, "Error");
                        Environment.Exit(1);
                    }
                    finally
                    {
                        file.Close();
                    }
                }
                _settings.LineageWindowTitle = lineageWindowTitle;
                _settings.MainLineageClientPath = mainClientPath;
                _settings.AlternativeLineageClientPath = mainClientPath;
                _settings.RenameClientWindow = true;
                _settings.LoginUpToCharacter = false;
                _settings.listState = new byte[0];

                if (!string.IsNullOrEmpty(mainClientPath))
                    isClientSet = true;

                _jsonFileUtility.SaveFile(_settingsPath, _settings);
            }
            else
            {
                _settings = _jsonFileUtility.ReadFile<Settings>(_settingsPath);

                if (!string.IsNullOrEmpty(_settings.MainLineageClientPath)
                    || !string.IsNullOrEmpty(_settings.AlternativeLineageClientPath))
                {
                    isClientSet = true;
                }
            }
        }

        private void inputCreds(IntPtr handle, string LoginToEnter, string PasswordToEnter, string accName, bool force)
        {
            ShowWindow(handle, 4); // SW_SHOWNOACTIVATE
            

            //turn off capslock
            if (IsKeyLocked(Keys.CapsLock))
            {
                const int KEYEVENTF_EXTENDEDKEY = 0x1;
                const int KEYEVENTF_KEYUP = 0x2;
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
                (UIntPtr)0);
            }
            /*  if (SetForegroundWindow(handle))
              {
                  SendKeys.SendWait("{HOME}");
                  SendKeys.SendWait("+{END}");
                  SendKeys.SendWait("{BACKSPACE}");
                  Thread.Sleep(200);
              }

              */


            const Int32 WM_CHAR = 0x0102;
            const uint WM_KEYDOWN = 0x0100;
            const uint WM_KEYUP = 0x0101;
            const int VK_TAB = 0x09;
            const int VK_ENTER = 0x0D;

            foreach (char ch in LoginToEnter.ToCharArray()) {
                PostMessage(handle, WM_CHAR, ch, 0);
            }

        

            PostMessage(handle, WM_KEYDOWN, VK_TAB, 0);
            PostMessage(handle, WM_KEYUP, VK_TAB, 0);

            

            foreach (char ch in PasswordToEnter.ToCharArray())
            {
                PostMessage(handle, WM_CHAR, ch, 0);
            }

            if (force) {
                
                PostMessage(handle, WM_KEYDOWN, VK_ENTER, 0);
                PostMessage(handle, WM_CHAR, VK_ENTER, 0);
                PostMessage(handle, WM_KEYUP, VK_ENTER, 0);

                PostMessage(handle, WM_KEYDOWN, VK_ENTER, 0);
                PostMessage(handle, WM_CHAR, VK_ENTER, 0);
                PostMessage(handle, WM_KEYUP, VK_ENTER, 0);
                force = false;
            }

            if (_settings.LoginUpToCharacter)
            {
        
                PostMessage(handle, WM_KEYDOWN, VK_ENTER, 0);
                PostMessage(handle, WM_CHAR, VK_ENTER, 0);
                PostMessage(handle, WM_KEYUP, VK_ENTER, 0);
 
                PostMessage(handle, WM_KEYDOWN, VK_ENTER, 0);
                PostMessage(handle, WM_CHAR, VK_ENTER, 0);
                PostMessage(handle, WM_KEYUP, VK_ENTER, 0);
     
                PostMessage(handle, WM_KEYDOWN, VK_ENTER, 0);
                PostMessage(handle, WM_CHAR, VK_ENTER, 0);
                PostMessage(handle, WM_KEYUP, VK_ENTER, 0);
            }
        }



        private void changeProductNameInL2int(String newProductName, string clientPath)
        {

            string folder = System.IO.Path.GetDirectoryName(clientPath) + @"\";
            System.IO.StreamWriter file = new System.IO.StreamWriter(folder + @"l2b.int");
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

            System.IO.FileInfo fileInf = new System.IO.FileInfo(sourceFile);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(destinationFile, true);
            }

        }

        private void runClient()
        {

            if (objectListView1.SelectedObjects.Count == 0)
            {
                MessageBox.Show(Strings.selectToRun);
                return;
            }
            if (!isClientSet)
            {
                MessageBox.Show(Strings.NoClientSet);
                Form opt = new OptionsForm();
                opt.ShowDialog();
                return;
            }

            foreach (Account acc in objectListView1.SelectedObjects)
            {
                string clientToRun;
                if (string.IsNullOrEmpty(_settings.MainLineageClientPath))
                    clientToRun = _settings.AlternativeLineageClientPath;
                else
                    clientToRun = _settings.MainLineageClientPath;

                if (acc.UseAltClientPath && !string.IsNullOrEmpty(_settings.AlternativeLineageClientPath))
                    clientToRun = _settings.AlternativeLineageClientPath;


                if (_settings.RenameClientWindow)
                    changeProductNameInL2int(acc.Name, clientToRun);

                IntPtr hWnd = FindWindow("L2UnrealWWindowsViewportWindow", acc.Name + " Lineage II");
                if (hWnd != IntPtr.Zero)
                {
                    MessageBox.Show(Strings.ClientForAccIsRunning, "Info");
                    return;
                }

                Process proc = Process.Start(clientToRun);

                if (loginProc.ContainsKey(acc.Name))
                {
                    loginProc[acc.Name] = proc.Id;
                }
                else
                {
                    loginProc.Add(acc.Name, proc.Id);
                }
              
                proc.WaitForInputIdle();
                if (proc.MainWindowTitle.Equals("Warning")) //skip warning
                {
                    proc.CloseMainWindow();
                }

                hWnd = FindWindow("L2UnrealWWindowsViewportWindow", acc.Name + " Lineage II");
                while (hWnd == IntPtr.Zero)
                {
                    Thread.Sleep(1000);
                    hWnd = FindWindow("L2UnrealWWindowsViewportWindow", acc.Name + " Lineage II");
                }

                if (hWnd != IntPtr.Zero)
                    new Thread(delegate () { inputCreds(hWnd, acc.GameAccount, acc.GamePassword, acc.Name, false); }).Start();

                if (_settings.RenameClientWindow)
                    changeProductNameInL2int("Lineage II", clientToRun);
                //delay to set lineage 2 product back
                Thread.Sleep(1000);
            }
        }
        private void runClient(Account acc)
        {
                string clientToRun;
                if (string.IsNullOrEmpty(_settings.MainLineageClientPath))
                    clientToRun = _settings.AlternativeLineageClientPath;
                else
                    clientToRun = _settings.MainLineageClientPath;

                if (acc.UseAltClientPath && !string.IsNullOrEmpty(_settings.AlternativeLineageClientPath))
                    clientToRun = _settings.AlternativeLineageClientPath;


                if (_settings.RenameClientWindow)
                    changeProductNameInL2int(acc.Name, clientToRun);
                
                IntPtr hWnd = FindWindow("L2UnrealWWindowsViewportWindow", acc.Name + " Lineage II");
                if (hWnd != IntPtr.Zero) {
                    MessageBox.Show(Strings.ClientForAccIsRunning, "Info");
                    return;
                }

                Process proc = Process.Start(clientToRun);

                loginProc.Add(acc.Name, proc.Id);

                proc.WaitForInputIdle();
                if (proc.MainWindowTitle.Equals("Warning")) //skip warning
                {
                    proc.CloseMainWindow();
                }

                hWnd = FindWindow("L2UnrealWWindowsViewportWindow", acc.Name + " Lineage II");
                while (hWnd == IntPtr.Zero)
                {
                    Thread.Sleep(1000);
                    hWnd = FindWindow("L2UnrealWWindowsViewportWindow", acc.Name + " Lineage II");
                }

                if (hWnd != IntPtr.Zero)
                    new Thread(delegate () { inputCreds(hWnd, acc.GameAccount, acc.GamePassword, acc.Name, true); }).Start();

                if (_settings.RenameClientWindow)
                    changeProductNameInL2int("Lineage II", clientToRun);
                //delay to set lineage 2 product back
                Thread.Sleep(1000);
            
        }


        private void LoadAccounts()
        {

            if (!File.Exists(_credsPath))
            {

                var confirmResult = MessageBox.Show(
                                      Strings.LoadFromCSVRequest,
                                      "Question",
                                      MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    openFileDialog1.Filter = "Accounts Files (CSV)|*.CSV";
                    if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    readFromCSV(openFileDialog1.FileName);

                }

                return;
            }
            List<Account> toAdd = _jsonFileUtility.ReadFile<List<Account>>(_credsPath);

            foreach (Account acc in toAdd)
            {
                if (_accounts.Contains(acc))
                {
                    _accounts.Remove(acc);
                }
                _accounts.Add(acc);
                objectListView1.UpdateObject(acc);
            }

            objectListView1.RefreshObjects(_accounts);
            objectListView1.SelectObjects(toAdd);
        }

        private void PsMMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _settings.listState = objectListView1.SaveState();
            _jsonFileUtility.SaveFile(_settingsPath, _settings);

            if (_accounts.Count > 0)
                _jsonFileUtility.SaveFile(_credsPath, _accounts);
        }

        private void PsMMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = langComBox.SelectedValue.ToString();

            Properties.Settings.Default.Save();
            if(this.setUnsetForce)
                keyboardHookManager.UnregisterHotkey(hotkey);
        }

        private void langComBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = langComBox.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            Application.Restart();
            Environment.Exit(0);
        }


        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            this.objectListView1.ModelFilter = TextMatchFilter.Contains(this.objectListView1, searchTextBox.Text);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewAccountViaForm();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editAccountViaForm();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteSelectedAccounts();
        }

        private void objectListView1_DoubleClick(object sender, EventArgs e)
        {
            runClient();
        }
        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewAccountViaForm();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editAccountViaForm();
        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteSelectedAccounts();
        }
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runClient();
        }

        private void runBULKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            if (!setUnsetForce) {
                keyboardHookManager.Start();
                setUnsetForce = true;
                this.button1.Text = "ON";
                this.button1.ForeColor = Color.Green;
                String accname = "";

                hotkey = keyboardHookManager.RegisterHotkey(NonInvasiveKeyboardHookLibrary.ModifierKeys.Control, (int) Keys.Z, () =>
                {
                    int toKill = 0;
                
                    accname = GetActiveWindowTitle().Split(' ')[0];
                    if (loginProc.TryGetValue(accname, out toKill))
                    {
                        if (toKill != 0)
                        {
                            KillProcess(toKill);
                            loginProc.Remove(accname);

                            foreach (Account acc in PsMMainForm._accounts) {
                                if (acc.Name.Equals(accname))
                                {
                                    runClient(acc);
                                }
                            }

                        }
                    }
                });
            }else{
                setUnsetForce=false;
                this.button1.Text = "OFF";
                this.button1.ForeColor = Color.Red;
                keyboardHookManager.Stop();
                keyboardHookManager.UnregisterHotkey(hotkey);
            }
        }

        public void KillProcess(int pid)
        {
            Process[] process = Process.GetProcesses();

            foreach (Process prs in process)
            {
                if (prs.Id == pid)
                {
                    prs.Kill();
                    break;
                }
            }
        }

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        private void PsMMainForm_Resize(object sender, EventArgs e)
        {

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(100);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
