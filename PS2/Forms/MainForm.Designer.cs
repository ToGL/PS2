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
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.altClientcolumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnGroup = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnOccupation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumndescription = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.langComBox = new System.Windows.Forms.ComboBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            resources.ApplyResources(this.objectListView1, "objectListView1");
            this.objectListView1.AllColumns.Add(this.olvColumnName);
            this.objectListView1.AllColumns.Add(this.altClientcolumn);
            this.objectListView1.AllColumns.Add(this.olvColumnGroup);
            this.objectListView1.AllColumns.Add(this.olvColumnOccupation);
            this.objectListView1.AllColumns.Add(this.olvColumndescription);
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.altClientcolumn,
            this.olvColumnGroup,
            this.olvColumnOccupation,
            this.olvColumndescription});
            this.objectListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.objectListView1.CopySelectionOnControlC = false;
            this.objectListView1.CopySelectionOnControlCUsesDragSource = false;
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.HideSelection = false;
            this.objectListView1.IsSearchOnSortColumn = false;
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.SelectAllOnControlA = false;
            this.objectListView1.SelectColumnsMenuStaysOpen = false;
            this.objectListView1.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.objectListView1.SelectedForeColor = System.Drawing.Color.Black;
            this.objectListView1.ShowCommandMenuOnRightClick = true;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.UseHotControls = false;
            this.objectListView1.UseNotifyPropertyChanged = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.objectListView1_CellRightClick);
            this.objectListView1.DoubleClick += new System.EventHandler(this.objectListView1_DoubleClick);
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
            this.altClientcolumn.Searchable = false;
            resources.ApplyResources(this.altClientcolumn, "altClientcolumn");
            this.altClientcolumn.WordWrap = true;
            // 
            // olvColumnGroup
            // 
            this.olvColumnGroup.AspectName = "Group";
            resources.ApplyResources(this.olvColumnGroup, "olvColumnGroup");
            // 
            // olvColumnOccupation
            // 
            this.olvColumnOccupation.AspectName = "Occupation";
            this.olvColumnOccupation.CellEditUseWholeCell = true;
            this.olvColumnOccupation.IsEditable = false;
            this.olvColumnOccupation.MaximumWidth = 140;
            this.olvColumnOccupation.MinimumWidth = 140;
            this.olvColumnOccupation.Searchable = false;
            resources.ApplyResources(this.olvColumnOccupation, "olvColumnOccupation");
            // 
            // olvColumndescription
            // 
            this.olvColumndescription.AspectName = "Description";
            this.olvColumndescription.CellEditUseWholeCell = true;
            this.olvColumndescription.FillsFreeSpace = true;
            this.olvColumndescription.IsEditable = false;
            resources.ApplyResources(this.olvColumndescription, "olvColumndescription");
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
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.addNewToolStripMenuItem_Click);
            // 
            // useAlternativeClientToolStripMenuItem
            // 
            this.useAlternativeClientToolStripMenuItem.CheckOnClick = true;
            this.useAlternativeClientToolStripMenuItem.Name = "useAlternativeClientToolStripMenuItem";
            resources.ApplyResources(this.useAlternativeClientToolStripMenuItem, "useAlternativeClientToolStripMenuItem");
            this.useAlternativeClientToolStripMenuItem.Click += new System.EventHandler(this.useAlternativeClientToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            resources.ApplyResources(this.editToolStripMenuItem1, "editToolStripMenuItem1");
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            resources.ApplyResources(this.removeToolStripMenuItem1, "removeToolStripMenuItem1");
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem1_Click);
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
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // loadFromClipboardToolStripMenuItem
            // 
            this.loadFromClipboardToolStripMenuItem.Name = "loadFromClipboardToolStripMenuItem";
            resources.ApplyResources(this.loadFromClipboardToolStripMenuItem, "loadFromClipboardToolStripMenuItem");
            this.loadFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.loadFromClipboardToolStripMenuItem_Click);
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
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // runBULKToolStripMenuItem
            // 
            resources.ApplyResources(this.runBULKToolStripMenuItem, "runBULKToolStripMenuItem");
            this.runBULKToolStripMenuItem.Name = "runBULKToolStripMenuItem";
            this.runBULKToolStripMenuItem.Click += new System.EventHandler(this.runBULKToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
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
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::PS2.Properties.Resources.sign_emergency_code_sos_14_icon_icons_com_57231;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::PS2.Properties.Resources.edit_icon_icons_com_52382;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::PS2.Properties.Resources.crossregular_106296;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
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
            this.importAccountsToolStripMenuItem.Click += new System.EventHandler(this.importAccountsToolStripMenuItem_Click);
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
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "creds";
            // 
            // langComBox
            // 
            this.langComBox.FormattingEnabled = true;
            resources.ApplyResources(this.langComBox, "langComBox");
            this.langComBox.Name = "langComBox";
            this.langComBox.SelectionChangeCommitted += new System.EventHandler(this.langComBox_SelectionChangeCommitted);
            // 
            // searchTextBox
            // 
            resources.ApplyResources(this.searchTextBox, "searchTextBox");
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // PsMMainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.langComBox);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PsMMainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PsMMainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PsMMainForm_FormClosed);
            this.Load += new System.EventHandler(this.PsMMainForm_Load);
            this.Resize += new System.EventHandler(this.PsMMainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ObjectListView objectListView1;
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox langComBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private OLVColumn olvColumnGroup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

