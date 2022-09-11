using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace PS2
{
    public partial class AddEditForm : Form
    {
        public List<Account> editAccounts = new List<Account>();
        InputLanguage original;
        public AddEditForm()
        {

            InitializeComponent();
            occupationComboBox.SelectedIndex = 0;
        }

        public AddEditForm(Account toEdit)
        {
            InitializeComponent();
            GameLoginTextBox.Text = toEdit.GameAccount;
            GamePasswordTextBox.Text = toEdit.GamePassword;
            DisplayNameTextBox.Text = toEdit.Name;

            if (!string.IsNullOrEmpty(toEdit.Description))
                DescriptionTextBox.Text = toEdit.Description;
            else
            {
                DescriptionTextBox.Text = "";
            }

            int occupIndex = occupationComboBox.Items.IndexOf(toEdit.Occupation);
            if (occupIndex != -1)
                occupationComboBox.SelectedIndex = occupIndex;
            else
                occupationComboBox.SelectedIndex = 0;

            usealtClientCheckBox.Checked = toEdit.useAlternativeClientPath;
            saveAndAddMore.Enabled = false;
        }


        private void saveAndAddMore_Click(object sender, EventArgs e)
        {
            Account acc = new Account(
                GameLoginTextBox.Text,
                GamePasswordTextBox.Text,
                DisplayNameTextBox.Text,
                DescriptionTextBox.Text,
                occupationComboBox.SelectedItem.ToString(),
                usealtClientCheckBox.Checked
                );

            editAccounts.Add(acc);

            GameLoginTextBox.Clear();
            GamePasswordTextBox.Clear();
            DisplayNameTextBox.Clear();
            DescriptionTextBox.Clear();
            occupationComboBox.SelectedIndex = 0;
            usealtClientCheckBox.Checked = false;

            MessageBox.Show(acc.ToString() + Strings.saveAndMore, "Info");
        }

        private void saveAndclose_Click(object sender, EventArgs e)
        {
            Account acc = new Account(
                GameLoginTextBox.Text,
                GamePasswordTextBox.Text,
                DisplayNameTextBox.Text,
                DescriptionTextBox.Text,
                occupationComboBox.SelectedItem.ToString(),
                usealtClientCheckBox.Checked
                );

            editAccounts.Add(acc);
            
            this.Close();
        }

        private void GameLoginTextBox_Enter(object sender, EventArgs e)
        {
            setEUForInput();
        }

        private void GameLoginTextBox_Leave(object sender, EventArgs e)
        {
            rollbackInputToOrigin();
        }

        private void GamePasswordTextBox_Enter(object sender, EventArgs e)
        {
            setEUForInput();
        }

        private void GamePasswordTextBox_Leave(object sender, EventArgs e)
        {
            rollbackInputToOrigin();
        }

        private void occupationComboBox_Enter(object sender, EventArgs e)
        {
            setEUForInput();
        }

        private void occupationComboBox_Leave(object sender, EventArgs e)
        {
            rollbackInputToOrigin();
        }

        private void setEUForInput()
        {
            original = InputLanguage.CurrentInputLanguage;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
        }
        private void rollbackInputToOrigin()
        {
            InputLanguage.CurrentInputLanguage = original;
        }

        private void DisplayNameTextBox_Enter(object sender, EventArgs e)
        {
            setEUForInput();
        }

        private void DisplayNameTextBox_Leave(object sender, EventArgs e)
        {
            rollbackInputToOrigin();
        }
    }
}
