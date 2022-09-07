using BrightIdeasSoftware;
using PS2.Model;
using PS2.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
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
        public List<Account> _accounts = Account.GetAccounts();

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

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
            
            this.altClientcolumn.IsVisible = Properties.Settings.Default.UseAltClientColumn;
            this.olvColumnOccupation.IsVisible = Properties.Settings.Default.OccupationColumn;
            this.olvColumndescription.IsVisible = Properties.Settings.Default.Description;
           
            this.objectListView1.RebuildColumns();

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
                }
                else {
                    _accounts[_accounts.IndexOf(acc)] = acc;
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

            Properties.Settings.Default.UseAltClientColumn = this.altClientcolumn.IsVisible;
            Properties.Settings.Default.OccupationColumn = this.olvColumnOccupation.IsVisible;
            Properties.Settings.Default.Description = this.olvColumndescription.IsVisible;
            Properties.Settings.Default.Save();

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
                useAlternativeClientToolStripMenuItem.Checked = ((Account)objectListView1.SelectedObject).useAlternativeClientPath;
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
                        
                    }
                    _accounts.Add(acc);
                    objectListView1.UpdateObject(acc);
                }

                objectListView1.RefreshObjects(_accounts);
                objectListView1.SelectObjects(tmp);
            }
        }

        private void useAlternativeClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objectListView1.SelectedObjects.Count == 1)
            {
                ((Account)objectListView1.SelectedObject).useAlternativeClientPath = useAlternativeClientToolStripMenuItem.Checked;
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

        private void inputCreds(IntPtr handle, string LoginToEnter, string PasswordToEnter, string accName)
        {
            SetForegroundWindow(handle);
            Thread.Sleep(200);
            ShowWindow(handle, 1);
            Thread.Sleep(1000);


            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                if (p.ProcessName == "L2" && p.MainWindowTitle.StartsWith(accName) &&
                    p.MainWindowHandle != IntPtr.Zero)
                {
                    SetForegroundWindow(p.MainWindowHandle);

                    //turn off capslock
                    if (IsKeyLocked(Keys.CapsLock))
                    {
                        const int KEYEVENTF_EXTENDEDKEY = 0x1;
                        const int KEYEVENTF_KEYUP = 0x2;
                        keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                        keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
                        (UIntPtr)0);
                    }

                    SendKeys.SendWait("{HOME}");
                    SendKeys.SendWait("+{END}");
                    SendKeys.SendWait("{BACKSPACE}");
                    Thread.Sleep(200);

                    SendKeys.SendWait(LoginToEnter);
                    Thread.Sleep(100);
                    SendKeys.SendWait("\t");
                    Thread.Sleep(100);
                    SendKeys.SendWait(PasswordToEnter);

                    if (_settings.LoginUpToCharacter)
                    {
                        Thread.Sleep(500);
                        SendKeys.SendWait("{ENTER}");
                        Thread.Sleep(500);
                        SendKeys.SendWait("{ENTER}");
                        Thread.Sleep(500);
                        SendKeys.SendWait("{ENTER}");
                    }

                }
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

                if (acc.useAlternativeClientPath && !string.IsNullOrEmpty(_settings.AlternativeLineageClientPath))
                    clientToRun = _settings.AlternativeLineageClientPath;


                if (_settings.RenameClientWindow)
                    changeProductNameInL2int(acc.Name, clientToRun);

                Process proc = Process.Start(clientToRun);
                proc.WaitForInputIdle();
                if (proc.MainWindowTitle.Equals("Warning")) //skip warning
                {
                    proc.CloseMainWindow();
                }
                proc.WaitForInputIdle();
                inputCreds(proc.MainWindowHandle, acc.GameAccount, acc.GamePassword, acc.Name);


                Thread.Sleep(1000);

                if (_settings.RenameClientWindow)
                    changeProductNameInL2int("Lineage II", clientToRun);
                //delay to set lineage 2 product back
                Thread.Sleep(1000);
            }
        }

        private void LoadAccounts()
        {
            //TODO proper update accounts on import

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
            if (_accounts.Count > 0)
                _jsonFileUtility.SaveFile(_credsPath, _accounts);
        }

        private void PsMMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = langComBox.SelectedValue.ToString();
            Properties.Settings.Default.UseAltClientColumn = this.altClientcolumn.IsVisible;
            Properties.Settings.Default.OccupationColumn = this.olvColumnOccupation.IsVisible;
            Properties.Settings.Default.Description = this.olvColumndescription.IsVisible;
           
            Properties.Settings.Default.Save();
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

    }
}
