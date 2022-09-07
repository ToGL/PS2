using System;
using System.Windows.Forms;

namespace PS2
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(PsMMainForm._settings.MainLineageClientPath))
                this.mainClientTextBox.Text = PsMMainForm._settings.MainLineageClientPath;
            if (!string.IsNullOrEmpty(PsMMainForm._settings.AlternativeLineageClientPath))
                this.altClientTextBox.Text = PsMMainForm._settings.AlternativeLineageClientPath;

            this.loadToCharacter.Checked = PsMMainForm._settings.LoginUpToCharacter ? PsMMainForm._settings.LoginUpToCharacter : false;
            this.checkBoxSetTitleClient.Checked = PsMMainForm._settings.RenameClientWindow ? PsMMainForm._settings.RenameClientWindow : false;
        }

        private void mainClientPathButton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.mainClientTextBox.Text = this.openFileDialog1.FileName;
            PsMMainForm._settings.MainLineageClientPath = this.openFileDialog1.FileName;
            if (!string.IsNullOrEmpty(this.mainClientTextBox.Text))
                PsMMainForm.isClientSet = true;
        }

        private void altClientSet_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }


            if (string.IsNullOrEmpty(this.openFileDialog1.FileName)
                && !string.IsNullOrEmpty(PsMMainForm._settings.MainLineageClientPath))
            {
                PsMMainForm._settings.AlternativeLineageClientPath = PsMMainForm._settings.MainLineageClientPath;
            }
            else
            {
                PsMMainForm._settings.AlternativeLineageClientPath = this.openFileDialog1.FileName;
            }
            this.altClientTextBox.Text = PsMMainForm._settings.AlternativeLineageClientPath;

            if (!string.IsNullOrEmpty(this.altClientTextBox.Text))
                PsMMainForm.isClientSet = true;
        }

        private void CancelOption_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveOptions_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.mainClientTextBox.Text)
                && string.IsNullOrEmpty(this.altClientTextBox.Text))
            {
                MessageBox.Show(Strings.EmptyClientsPath);
                return;
            }

            if (!string.IsNullOrEmpty(this.mainClientTextBox.Text))
                PsMMainForm._settings.MainLineageClientPath = this.mainClientTextBox.Text;
            if (!string.IsNullOrEmpty(this.altClientTextBox.Text))
                PsMMainForm._settings.AlternativeLineageClientPath = this.altClientTextBox.Text;

            PsMMainForm._settings.RenameClientWindow = this.checkBoxSetTitleClient.Checked;
            PsMMainForm._settings.LoginUpToCharacter = this.loadToCharacter.Checked;

            PsMMainForm._jsonFileUtility.SaveFile(PsMMainForm._settingsPath, PsMMainForm._settings);
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxSetTitleClient.Checked)
                MessageBox.Show(Strings.WindowTitleInfo, "Info");

            PsMMainForm._settings.RenameClientWindow = this.checkBoxSetTitleClient.Checked;
        }

        private void loadToCharacter_CheckedChanged(object sender, EventArgs e)
        {
            PsMMainForm._settings.LoginUpToCharacter = loadToCharacter.Checked;
        }
    }
}
