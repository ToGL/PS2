using PS2.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace PS2
{
    public partial class AddEditForm : Form
    {
        private readonly IStringValidator _stringValidator = new StringValidator();
        private readonly List<Account> _accounts;

        public List<Account> EditAccounts = new List<Account>();
        private List<string> _groupsList = new List<string>();
        private InputLanguage _original;

        public AddEditForm(List<Account> accounts)
        {
            _accounts = accounts;

            InitializeComponent();
            occupationComboBox.SelectedIndex = 0;
        }

        public AddEditForm(List<Account> accounts, Account toEdit)
        {
            _accounts = accounts;

            InitializeComponent();

            textBoxGroup.Text = toEdit.Group;
            GameLoginTextBox.Text = toEdit.GameAccount;
            GamePasswordTextBox.Text = toEdit.GamePassword;
            DisplayNameTextBox.Text = toEdit.Name;

            DescriptionTextBox.Text = !string.IsNullOrEmpty(toEdit.Description) ? toEdit.Description : "";

            var occupIndex = occupationComboBox.Items.IndexOf(toEdit.Occupation);
            occupationComboBox.SelectedIndex = occupIndex != -1 ? occupIndex : 0;

            usealtClientCheckBox.Checked = toEdit.UseAltClientPath;
            saveAndAddMore.Enabled = false;
        }

        private List<string> GetGroupsList()
        {
            var groups = new List<string>();

            foreach (Account account in _accounts)
            {
                if (!groups.Contains(account.Group) && !string.IsNullOrEmpty(account.Group))
                {
                    groups.Add(account.Group);
                }
            }
            return groups;
        }

        private void SaveAndAddMore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GameLoginTextBox.Text)
                || string.IsNullOrEmpty(GamePasswordTextBox.Text)
                || string.IsNullOrEmpty(DisplayNameTextBox.Text))
            {

                MessageBox.Show(Strings.EmptyEntry, "Error");
                return;
            }

            Account acc = GetAccountModel();

            if (!EditAccounts.Contains(acc))
            {
                EditAccounts.Add(acc);
            }
            else
            {
                EditAccounts[EditAccounts.IndexOf(acc)] = acc;
            }

            GameLoginTextBox.Clear();
            GamePasswordTextBox.Clear();
            DisplayNameTextBox.Clear();
            DescriptionTextBox.Clear();
            occupationComboBox.SelectedIndex = 0;
            textBoxGroup.Clear();
            usealtClientCheckBox.Checked = false;

            MessageBox.Show("Name:\t\t" + acc.Name + "\n" +
                   "Occupation:\t " + acc.Occupation + "\n" +
                   "Description: \t" + acc.Description +
                   Strings.saveAndMore, "Info");
        }

        private Account GetAccountModel()
        {
            return new Account()
            {
                GameAccount = GameLoginTextBox.Text,
                GamePassword = GamePasswordTextBox.Text,
                Name = DisplayNameTextBox.Text,
                Description = DescriptionTextBox.Text,
                Occupation = occupationComboBox.SelectedItem.ToString(),
                Group = textBoxGroup.Text,
                UseAltClientPath = usealtClientCheckBox.Checked
            };
        }

        private void SaveAndclose_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GameLoginTextBox.Text)
                || string.IsNullOrEmpty(GamePasswordTextBox.Text)
                || string.IsNullOrEmpty(DisplayNameTextBox.Text))
            {
                MessageBox.Show(Strings.EmptyEntry, "Error");
                return;
            }

            EditAccounts.Add(GetAccountModel());

            Close();
        }

        private void GameLoginTextBox_Enter(object sender, EventArgs e)
        {
            SetEUForInput();
        }

        private void GameLoginTextBox_Leave(object sender, EventArgs e)
        {
            TextBox_Leave(GameLoginTextBox);
        }

        private void GamePasswordTextBox_Enter(object sender, EventArgs e)
        {
            SetEUForInput();
        }

        private void GamePasswordTextBox_Leave(object sender, EventArgs e)
        {
            TextBox_Leave(GamePasswordTextBox);
        }

        private void TextBox_Leave(TextBox textBox)
        {
            if (!_stringValidator.Validate(textBox.Text))
            {
                MessageBox.Show(Strings.engInputOnly, "info");
                textBox.Text = "";
                textBox.Focus();
            }

            RollbackInputToOrigin();
        }

        private void OccupationComboBox_Enter(object sender, EventArgs e)
        {
            SetEUForInput();
        }

        private void OccupationComboBox_Leave(object sender, EventArgs e)
        {
            RollbackInputToOrigin();
        }

        private void SetEUForInput()
        {
            _original = InputLanguage.CurrentInputLanguage;
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
        }

        private void RollbackInputToOrigin()
        {
            InputLanguage.CurrentInputLanguage = _original;
        }

        private void DisplayNameTextBox_Enter(object sender, EventArgs e)
        {
            SetEUForInput();
        }

        private void DisplayNameTextBox_Leave(object sender, EventArgs e)
        {
            TextBox_Leave(DisplayNameTextBox);
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            _groupsList = GetGroupsList();
            var col = new AutoCompleteStringCollection();
            foreach (string group in _groupsList)
            {
                col.Add(group);
            }

            textBoxGroup.AutoCompleteCustomSource = col;
        }

        private void TextBoxGroup_TextChanged(object sender, EventArgs e)
        {
            if (!_groupsList.Contains(textBoxGroup.Text))
            {
                _groupsList.Add(textBoxGroup.Text);
            }
        }
    }
}
