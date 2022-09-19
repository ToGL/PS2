using BrightIdeasSoftware;
using System.Runtime.CompilerServices;

namespace PS2
{
    partial class PsMMainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PsMMainForm));
            this.accountsListView = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.altClientcolumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnGroup = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnOccupation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumndescription = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnSound = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useAlternativeClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitterToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitterToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runBULKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pM20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitterToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.importAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.langComBox = new System.Windows.Forms.ComboBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.accountsListView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountsListView
            // 
            resources.ApplyResources(this.accountsListView, "accountsListView");
            this.accountsListView.AllColumns.Add(this.olvColumnName);
            this.accountsListView.AllColumns.Add(this.altClientcolumn);
            this.accountsListView.AllColumns.Add(this.olvColumnGroup);
            this.accountsListView.AllColumns.Add(this.olvColumnOccupation);
            this.accountsListView.AllColumns.Add(this.olvColumndescription);
            this.accountsListView.AllColumns.Add(this.olvColumnSound);
            this.accountsListView.CellEditUseWholeCell = false;
            this.accountsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.altClientcolumn,
            this.olvColumnGroup,
            this.olvColumnOccupation,
            this.olvColumndescription,
            this.olvColumnSound});
            this.accountsListView.ContextMenuStrip = this.contextMenuStrip1;
            this.accountsListView.CopySelectionOnControlC = false;
            this.accountsListView.CopySelectionOnControlCUsesDragSource = false;
            this.accountsListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.accountsListView.FullRowSelect = true;
            this.accountsListView.HideSelection = false;
            this.accountsListView.IsSearchOnSortColumn = false;
            this.accountsListView.Name = "accountsListView";
            this.accountsListView.SelectAllOnControlA = false;
            this.accountsListView.SelectColumnsMenuStaysOpen = false;
            this.accountsListView.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.accountsListView.SelectedForeColor = System.Drawing.Color.Black;
            this.accountsListView.ShowCommandMenuOnRightClick = true;
            this.accountsListView.UseCompatibleStateImageBehavior = false;
            this.accountsListView.UseFiltering = true;
            this.accountsListView.UseHotControls = false;
            this.accountsListView.UseNotifyPropertyChanged = true;
            this.accountsListView.View = System.Windows.Forms.View.Details;
            this.accountsListView.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.AccountsListView_CellRightClick);
            this.accountsListView.DoubleClick += new System.EventHandler(this.AccountsListView_DoubleClick);
            this.accountsListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AccountsListView_KeyUp);
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "Name";
            this.olvColumnName.CellEditUseWholeCell = true;
            this.olvColumnName.HeaderCheckBoxUpdatesRowCheckBoxes = false;
            this.olvColumnName.Hideable = false;
            this.olvColumnName.IsEditable = false;
            this.olvColumnName.MaximumWidth = 200;
            this.olvColumnName.MinimumWidth = 140;
            resources.ApplyResources(this.olvColumnName, "olvColumnName");
            this.olvColumnName.UseFiltering = false;
            this.olvColumnName.UseInitialLetterForGroup = true;
            // 
            // altClientcolumn
            // 
            this.altClientcolumn.AspectName = "UseAltClientPath";
            this.altClientcolumn.AutoCompleteEditor = false;
            this.altClientcolumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.altClientcolumn.CheckBoxes = true;
            this.altClientcolumn.Groupable = false;
            this.altClientcolumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.altClientcolumn.MaximumWidth = 50;
            this.altClientcolumn.MinimumWidth = 50;
            this.altClientcolumn.Searchable = false;
            resources.ApplyResources(this.altClientcolumn, "altClientcolumn");
            this.altClientcolumn.WordWrap = true;
            // 
            // olvColumnGroup
            // 
            this.olvColumnGroup.AspectName = "Group";
            resources.ApplyResources(this.olvColumnGroup, "olvColumnGroup");
            this.olvColumnGroup.MinimumWidth = 80;
            // 
            // olvColumnOccupation
            // 
            this.olvColumnOccupation.AspectName = "Occupation";
            this.olvColumnOccupation.CellEditUseWholeCell = true;
            resources.ApplyResources(this.olvColumnOccupation, "olvColumnOccupation");
            this.olvColumnOccupation.IsEditable = false;
            this.olvColumnOccupation.MaximumWidth = 120;
            this.olvColumnOccupation.MinimumWidth = 120;
            this.olvColumnOccupation.Searchable = false;
            // 
            // olvColumndescription
            // 
            this.olvColumndescription.AspectName = "Description";
            this.olvColumndescription.CellEditUseWholeCell = true;
            resources.ApplyResources(this.olvColumndescription, "olvColumndescription");
            this.olvColumndescription.FillsFreeSpace = true;
            this.olvColumndescription.IsEditable = false;
            // 
            // olvColumnSound
            // 
            this.olvColumnSound.AspectName = "Sound";
            this.olvColumnSound.AutoCompleteEditor = false;
            this.olvColumnSound.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.olvColumnSound.CheckBoxes = true;
            resources.ApplyResources(this.olvColumnSound, "olvColumnSound");
            this.olvColumnSound.Groupable = false;
            this.olvColumnSound.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnSound.Searchable = false;
            this.olvColumnSound.WordWrap = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.useAlternativeClientToolStripMenuItem,
            this.editToolStripMenuItem1,
            this.removeToolStripMenuItem1,
            this.splitterToolStripMenuItem2,
            this.copyToClipboardToolStripMenuItem,
            this.loadFromClipboardToolStripMenuItem,
            this.splitterToolStripMenuItem1,
            this.runToolStripMenuItem,
            this.runBULKToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            resources.ApplyResources(this.addNewToolStripMenuItem, "addNewToolStripMenuItem");
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.AddNewToolStripMenuItem_Click);
            // 
            // useAlternativeClientToolStripMenuItem
            // 
            this.useAlternativeClientToolStripMenuItem.CheckOnClick = true;
            this.useAlternativeClientToolStripMenuItem.Name = "useAlternativeClientToolStripMenuItem";
            resources.ApplyResources(this.useAlternativeClientToolStripMenuItem, "useAlternativeClientToolStripMenuItem");
            this.useAlternativeClientToolStripMenuItem.Click += new System.EventHandler(this.UseAlternativeClientToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            resources.ApplyResources(this.editToolStripMenuItem1, "editToolStripMenuItem1");
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.EditToolStripMenuItem1_Click);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            resources.ApplyResources(this.removeToolStripMenuItem1, "removeToolStripMenuItem1");
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.RemoveToolStripMenuItem1_Click);
            // 
            // splitterToolStripMenuItem2
            // 
            this.splitterToolStripMenuItem2.Name = "splitterToolStripMenuItem2";
            resources.ApplyResources(this.splitterToolStripMenuItem2, "splitterToolStripMenuItem2");
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            resources.ApplyResources(this.copyToClipboardToolStripMenuItem, "copyToClipboardToolStripMenuItem");
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopyToClipboardToolStripMenuItem_Click);
            // 
            // loadFromClipboardToolStripMenuItem
            // 
            this.loadFromClipboardToolStripMenuItem.Name = "loadFromClipboardToolStripMenuItem";
            resources.ApplyResources(this.loadFromClipboardToolStripMenuItem, "loadFromClipboardToolStripMenuItem");
            this.loadFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.LoadFromClipboardToolStripMenuItem_Click);
            // 
            // splitterToolStripMenuItem1
            // 
            this.splitterToolStripMenuItem1.Name = "splitterToolStripMenuItem1";
            resources.ApplyResources(this.splitterToolStripMenuItem1, "splitterToolStripMenuItem1");
            // 
            // runToolStripMenuItem
            // 
            resources.ApplyResources(this.runToolStripMenuItem, "runToolStripMenuItem");
            this.runToolStripMenuItem.Image = global::PS2.Properties.Resources.passwords_keys_6032;
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItem_Click);
            // 
            // runBULKToolStripMenuItem
            // 
            resources.ApplyResources(this.runBULKToolStripMenuItem, "runBULKToolStripMenuItem");
            this.runBULKToolStripMenuItem.Name = "runBULKToolStripMenuItem";
            this.runBULKToolStripMenuItem.Click += new System.EventHandler(this.RunBULKToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pM20ToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // pM20ToolStripMenuItem
            // 
            this.pM20ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.pM20ToolStripMenuItem.Name = "pM20ToolStripMenuItem";
            resources.ApplyResources(this.pM20ToolStripMenuItem, "pM20ToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::PS2.Properties.Resources.sign_info_icon_34361;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::PS2.Properties.Resources.sign_emergency_code_sos_14_icon_icons_com_57231;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.splitterToolStripMenuItem,
            this.importAccountsToolStripMenuItem});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            resources.ApplyResources(this.accountsToolStripMenuItem, "accountsToolStripMenuItem");
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::PS2.Properties.Resources.plus_40632;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            resources.ApplyResources(this.addToolStripMenuItem, "addToolStripMenuItem");
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::PS2.Properties.Resources.edit_icon_icons_com_52382;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::PS2.Properties.Resources.crossregular_106296;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // splitterToolStripMenuItem
            // 
            this.splitterToolStripMenuItem.Name = "splitterToolStripMenuItem";
            resources.ApplyResources(this.splitterToolStripMenuItem, "splitterToolStripMenuItem");
            // 
            // importAccountsToolStripMenuItem
            // 
            this.importAccountsToolStripMenuItem.Image = global::PS2.Properties.Resources.import_download_icon_176152;
            this.importAccountsToolStripMenuItem.Name = "importAccountsToolStripMenuItem";
            resources.ApplyResources(this.importAccountsToolStripMenuItem, "importAccountsToolStripMenuItem");
            this.importAccountsToolStripMenuItem.Click += new System.EventHandler(this.ImportAccountsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Image = global::PS2.Properties.Resources.configuration_6036;
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            resources.ApplyResources(this.configurationToolStripMenuItem, "configurationToolStripMenuItem");
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.ConfigurationToolStripMenuItem_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "creds";
            // 
            // langComBox
            // 
            this.langComBox.FormattingEnabled = true;
            resources.ApplyResources(this.langComBox, "langComBox");
            this.langComBox.Name = "langComBox";
            this.langComBox.SelectionChangeCommitted += new System.EventHandler(this.LangComBox_SelectionChangeCommitted);
            // 
            // searchTextBox
            // 
            resources.ApplyResources(this.searchTextBox, "searchTextBox");
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // PsMMainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.langComBox);
            this.Controls.Add(this.accountsListView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PsMMainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PsMMainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PsMMainForm_FormClosed);
            this.Load += new System.EventHandler(this.PsMMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountsListView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ObjectListView accountsListView;
        private OLVColumn olvColumnName;
        private OLVColumn altClientcolumn;
        private OLVColumn olvColumnOccupation;
        private OLVColumn olvColumndescription;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pM20ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem runBULKToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator splitterToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useAlternativeClientToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.ComboBox langComBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private OLVColumn olvColumnGroup;
        private OLVColumn olvColumnSound;
    }
}

