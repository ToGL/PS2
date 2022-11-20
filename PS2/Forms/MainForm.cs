using BrightIdeasSoftware;
using PS2.Model;
using PS2.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PS2
{
    public partial class PsMMainForm : Form
    {
        private readonly JsonFileUtility _jsonFileUtility = new JsonFileUtility();
        private readonly ProcessUtility _processUtility = new ProcessUtility();
        private readonly CsvReaderUtility _csvReaderUtility = new CsvReaderUtility();

        private readonly List<Account> _accounts = new List<Account>();
        private Settings _settings = new Settings();

        public bool IsClientSet
        {
            get => !string.IsNullOrEmpty(_settings.MainLineageClientPath) || !string.IsNullOrEmpty(_settings.AlternativeLineageClientPath);
        }

        public PsMMainForm()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }

            InitializeComponent();
        }

        private void PsMMainForm_Load(object sender, EventArgs e)
        {
            langComBox.DataSource = new CultureInfo[] {
                CultureInfo.GetCultureInfo("ru-RU"),
                CultureInfo.GetCultureInfo("en-US"),
            };
            langComBox.SelectedIndex = 0;
            langComBox.DisplayMember = "NativeName";
            langComBox.ValueMember = "Name";

            if (!string.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                langComBox.SelectedValue = Properties.Settings.Default.Language;
            }

            LoadSettings();
            LoadAccounts();

            accountsListView.SetObjects(_accounts);
            accountsListView.ShowGroups = false;
            accountsListView.RefreshObjects(_accounts);

            accountsListView.RebuildColumns();
            accountsListView.Unsort();
            if (_settings.ListState != null)
            {
                accountsListView.RestoreState(_settings.ListState);
            }
        }

        private void AddNewAccountViaForm()
        {
            var addEdit = new AddEditForm(_accounts);
            addEdit.ShowDialog();

            UpdateView(addEdit.EditAccounts);
            addEdit.EditAccounts.Clear();
        }

        private void EditAccountViaForm()
        {
            var tmpAcc = (Account)accountsListView.SelectedObject;
            if (tmpAcc == null)
            {
                MessageBox.Show(Strings.EditOnceAtTime, "Information");
                return;
            }

            var addEdit = new AddEditForm(_accounts, tmpAcc);
            addEdit.ShowDialog();

            UpdateView(addEdit.EditAccounts);
            addEdit.EditAccounts.Clear();
        }

        private void DeleteSelectedAccounts()
        {
            string nameTodelete = "";
            if (accountsListView.SelectedObjects.Count > 1)
            {
                foreach (Account acc in accountsListView.SelectedObjects)
                {
                    nameTodelete += "\n" + acc.Name;
                }
            }

            if (accountsListView.SelectedObject != null && accountsListView.SelectedObjects.Count == 1)
            {
                nameTodelete = ((Account)accountsListView.SelectedObject).Name;
            }
            var confirmResult = MessageBox.Show(nameTodelete, "Are you sure to delete: ", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                foreach (Account acc in accountsListView.SelectedObjects)
                {
                    accountsListView.RemoveObject(acc);
                    _accounts.Remove(acc);
                }
            }

            accountsListView.RefreshObjects(_accounts);
        }

        private void CopyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (accountsListView.SelectedObjects.Count > 0)
            {
                Clipboard.SetText(_jsonFileUtility.GetJsonString(accountsListView.SelectedObjects));
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("...that's all I can say about Vietnam.", "Forest Gump");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _jsonFileUtility.SaveFile(Consts.CredsPath, _accounts);

            Close();
        }

        private void ImportAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileDialog.Filter = "Accounts Files (CSV JSON)|*.CSV;*.JSON";
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (Path.GetExtension(fileDialog.FileName) == ".csv")
            {
                ReadFromCSV(fileDialog.FileName);
            }
            else if (Path.GetExtension(fileDialog.FileName) == ".json")
            {
                var toAdd = _jsonFileUtility.ReadFile<List<Account>>(fileDialog.FileName);
                UpdateView(toAdd);
            }
        }

        private void ReadFromCSV(string fileName)
        {
            var toAdd = _csvReaderUtility.ReadAccounts(fileName);
            UpdateView(toAdd);
        }

        private void UpdateView(List<Account> newAccounts)
        {
            foreach (var acc in newAccounts)
            {
                var index = _accounts.FindIndex(x => x.GameAccount == acc.GameAccount);
                if (index > -1)
                {
                    _accounts[index] = acc;
                }
                else
                {
                    _accounts.Add(acc);
                }
            }
            accountsListView.SetObjects(_accounts);
            accountsListView.RefreshObjects(_accounts);
            accountsListView.SelectObjects(newAccounts);
        }

        private void ConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var opt = new OptionsForm(_settings);
            opt.ShowDialog();
        }

        private void AccountsListView_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            runToolStripMenuItem.Enabled = accountsListView.Items.Count > 0 && IsClientSet;

            useAlternativeClientToolStripMenuItem.Enabled = accountsListView.SelectedObjects.Count < 2;
            editToolStripMenuItem.Enabled = accountsListView.SelectedObjects.Count < 2;
            editToolStripMenuItem1.Enabled = accountsListView.SelectedObjects.Count < 2;

            if (accountsListView.SelectedObjects.Count == 1)
            {
                useAlternativeClientToolStripMenuItem.Checked = ((Account)accountsListView.SelectedObject).UseAltClientPath;
            }
        }

        private void LoadFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var accounts = _jsonFileUtility.GetObjectFromJsonString<List<Account>>(Clipboard.GetText());

            if (accounts == null)
            {
                return;
            }

            foreach (var acc in accounts)
            {
                if (_accounts.Contains(acc))
                {
                    _accounts.Remove(acc);
                    accountsListView.UpdateObject(acc);
                }
                _accounts.Add(acc);
                accountsListView.AddObject(acc);
            }

            accountsListView.RefreshObjects(_accounts);
            accountsListView.SelectObjects(accounts);
        }

        private void UseAlternativeClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (accountsListView.SelectedObjects.Count == 1)
            {
                ((Account)accountsListView.SelectedObject).UseAltClientPath = useAlternativeClientToolStripMenuItem.Checked;
                accountsListView.RefreshObjects(accountsListView.SelectedObjects);
            }
        }

        private void LoadSettings()
        {
            if (File.Exists(Consts.SettingsPath))
            {
                _settings = _jsonFileUtility.ReadFile<Settings>(Consts.SettingsPath);
                return;
            }

            string lineageWindowTitle = "Lineage";
            string mainClientPath = "";

            if (File.Exists(Consts.SettingsIniPath))
            {
                StreamReader file = new StreamReader(Consts.SettingsIniPath);

                try
                {
                    string line;
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
            _settings.ListState = new byte[0];

            _jsonFileUtility.SaveFile(Consts.SettingsPath, _settings);
        }

        private void RunClient()
        {
            if (accountsListView.SelectedObjects.Count == 0)
            {
                MessageBox.Show(Strings.selectToRun);
                return;
            }
            if (!IsClientSet)
            {
                MessageBox.Show(Strings.NoClientSet);
                Form opt = new OptionsForm(_settings);
                opt.ShowDialog();
                return;
            }

            foreach (Account acc in accountsListView.SelectedObjects)
            {
                _processUtility.RunProcess(acc, _settings);
            }
        }

        private void LoadAccounts()
        {
            if (!File.Exists(Consts.CredsPath))
            {
                var confirmResult = MessageBox.Show(Strings.LoadFromCSVRequest, "Question", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    fileDialog.Filter = "Accounts Files (CSV)|*.CSV";
                    if (fileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    ReadFromCSV(fileDialog.FileName);
                }
                return;
            }
            var toAdd = _jsonFileUtility.ReadFile<List<Account>>(Consts.CredsPath);

            UpdateView(toAdd);
        }

        private void PsMMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _settings.ListState = accountsListView.SaveState();
            _jsonFileUtility.SaveFile(Consts.SettingsPath, _settings);

            if (_accounts.Count > 0)
            {
                _jsonFileUtility.SaveFile(Consts.CredsPath, _accounts);
            }
        }

        private void PsMMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = langComBox.SelectedValue.ToString();

            Properties.Settings.Default.Save();
        }

        private void LangComBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = langComBox.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            Application.Restart();
            Environment.Exit(0);
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            accountsListView.ModelFilter = TextMatchFilter.Contains(accountsListView, searchTextBox.Text);
        }

        #region ONeCall functions
        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewAccountViaForm();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAccountViaForm();
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedAccounts();
        }

        private void AccountsListView_DoubleClick(object sender, EventArgs e)
        {
            RunClient();
        }

        private void AddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewAccountViaForm();
        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditAccountViaForm();
        }

        private void RemoveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteSelectedAccounts();
        }
        private void RunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunClient();
        }
        #endregion

        private void AccountsListView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RunClient();
            }
        }
    }
}
