using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PS2
{
    public partial class AddEditForm : Form
    {
        public List<Account> editAccounts = new List<Account>();
        private List<String> groupsList = new List<String>();

        InputLanguage original;
        public AddEditForm()
        {
            InitializeComponent();
            occupationComboBox.SelectedIndex = 0;
            
        }

        private List<String> getGroupsList() { 
            List<String> groups = new List<String>();

            foreach (Account account in PsMMainForm._accounts) { 
                if(!groups.Contains(account.Group) && !string.IsNullOrEmpty(account.Group))
                    groups.Add(account.Group);
            }
            return groups;
        }

        public AddEditForm(Account toEdit)
        {
            InitializeComponent();

            textBoxGroup.Text = toEdit.Group;
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

            usealtClientCheckBox.Checked = toEdit.UseAltClientPath;
            saveAndAddMore.Enabled = false;
        }


        private void saveAndAddMore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GameLoginTextBox.Text)
                || string.IsNullOrEmpty(GamePasswordTextBox.Text)
                || string.IsNullOrEmpty(DisplayNameTextBox.Text))
            {

                MessageBox.Show(Strings.EmptyEntry, "Error");
                return;
            }

            Account acc = new Account(
                GameLoginTextBox.Text,
                GamePasswordTextBox.Text,
                DisplayNameTextBox.Text,
                DescriptionTextBox.Text,
                occupationComboBox.SelectedItem.ToString(),
                textBoxGroup.Text,
                usealtClientCheckBox.Checked
                );

            if (!editAccounts.Contains(acc))
                editAccounts.Add(acc);
            else {
                editAccounts[editAccounts.IndexOf(acc)] = acc;
            }

            GameLoginTextBox.Clear();
            GamePasswordTextBox.Clear();
            DisplayNameTextBox.Clear();
            DescriptionTextBox.Clear();
            occupationComboBox.SelectedIndex = 0;
            textBoxGroup.Clear();
            usealtClientCheckBox.Checked = false;

            MessageBox.Show(acc.ToString() + Strings.saveAndMore, "Info");
        }

        private void saveAndclose_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GameLoginTextBox.Text)
                || string.IsNullOrEmpty(GamePasswordTextBox.Text)
                || string.IsNullOrEmpty(DisplayNameTextBox.Text)) {

                MessageBox.Show(Strings.EmptyEntry, "Error");
                return;
            }
            
            Account acc = new Account(
                GameLoginTextBox.Text,
                GamePasswordTextBox.Text,
                DisplayNameTextBox.Text,
                DescriptionTextBox.Text,
                occupationComboBox.SelectedItem.ToString(),
                textBoxGroup.Text,
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
            if (!Regex.IsMatch(this.GameLoginTextBox.Text, "^[a-zA-Z0-9!@#$&()_-]*$"))
            {
                MessageBox.Show(Strings.engInputOnly, "info");
                this.GameLoginTextBox.Text = "";
                this.GameLoginTextBox.Focus();
            }
            rollbackInputToOrigin();
        }

        private void GamePasswordTextBox_Enter(object sender, EventArgs e)
        {
            setEUForInput();
        }

        private void GamePasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.GamePasswordTextBox.Text, "^[a-zA-Z0-9!@#$&()_-]*$"))
            {
                MessageBox.Show(Strings.engInputOnly, "info");
                this.GamePasswordTextBox.Text = "";
                this.GamePasswordTextBox.Focus();
            }

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

            if (!Regex.IsMatch(this.DisplayNameTextBox.Text, "^[a-zA-Z0-9!@#$&()_-]*$"))
            {
                MessageBox.Show(Strings.engInputOnly, "info");
                this.DisplayNameTextBox.Text = "";
                this.DisplayNameTextBox.Focus();
            }
            rollbackInputToOrigin();
        }

        
        private void AddEditForm_Load(object sender, EventArgs e)
        {
            this.groupsList = getGroupsList();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            foreach (string group in groupsList)
            {
               col.Add(group);
            }

            textBoxGroup.AutoCompleteCustomSource = col;
        }

        private void textBoxGroup_TextChanged(object sender, EventArgs e)
        {
            if (!groupsList.Contains(textBoxGroup.Text))
            {
                groupsList.Add(textBoxGroup.Text);
            }
        }
    }
}
