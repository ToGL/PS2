using PS2.Model;
using PS2.Utilities;
using System;
using System.Windows.Forms;

namespace PS2
{
    public partial class OptionsForm : Form
    {
        private readonly JsonFileUtility _jsonFileUtility = new JsonFileUtility();
        private readonly Settings _settings;

        public OptionsForm(Settings settings)
        {
            _settings = settings;

            InitializeComponent();
            if (!string.IsNullOrEmpty(_settings.MainLineageClientPath))
            {
                mainClientTextBox.Text = _settings.MainLineageClientPath;
            }

            if (!string.IsNullOrEmpty(_settings.AlternativeLineageClientPath))
            {
                altClientTextBox.Text = _settings.AlternativeLineageClientPath;
            }

            loadToCharacter.Checked = _settings.LoginUpToCharacter;
            checkBoxSetTitleClient.Checked = true;
        }

        private void MainClientPathButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            mainClientTextBox.Text = openFileDialog1.FileName;
            _settings.MainLineageClientPath = openFileDialog1.FileName;
        }

        private void AltClientSet_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (string.IsNullOrEmpty(openFileDialog1.FileName) && !string.IsNullOrEmpty(_settings.MainLineageClientPath))
            {
                _settings.AlternativeLineageClientPath = _settings.MainLineageClientPath;
            }
            else
            {
                _settings.AlternativeLineageClientPath = openFileDialog1.FileName;
            }
            altClientTextBox.Text = _settings.AlternativeLineageClientPath;
        }

        private void CancelOption_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveOptions_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mainClientTextBox.Text)
                && string.IsNullOrEmpty(altClientTextBox.Text))
            {
                MessageBox.Show(Strings.EmptyClientsPath);
                return;
            }

            if (!string.IsNullOrEmpty(mainClientTextBox.Text))
            {
                _settings.MainLineageClientPath = mainClientTextBox.Text;
            }

            if (!string.IsNullOrEmpty(altClientTextBox.Text))
            {
                _settings.AlternativeLineageClientPath = altClientTextBox.Text;
            }

            _settings.RenameClientWindow = true;
            _settings.LoginUpToCharacter = loadToCharacter.Checked;

            _jsonFileUtility.SaveFile(Consts.SettingsPath, _settings);
            Close();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSetTitleClient.Checked)
            {
                MessageBox.Show(Strings.WindowTitleInfo, "Info");
            }

            _settings.RenameClientWindow = checkBoxSetTitleClient.Checked;
        }

        private void LoadToCharacter_CheckedChanged(object sender, EventArgs e)
        {
            _settings.LoginUpToCharacter = loadToCharacter.Checked;
        }
    }
}
