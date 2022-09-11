namespace PS2
{
    partial class AddEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.GameLoginTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GamePasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DisplayNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.occupationComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.usealtClientCheckBox = new System.Windows.Forms.CheckBox();
            this.saveAndclose = new System.Windows.Forms.Button();
            this.saveAndAddMore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // GameLoginTextBox
            // 
            resources.ApplyResources(this.GameLoginTextBox, "GameLoginTextBox");
            this.GameLoginTextBox.Name = "GameLoginTextBox";
            this.GameLoginTextBox.Enter += new System.EventHandler(this.GameLoginTextBox_Enter);
            this.GameLoginTextBox.Leave += new System.EventHandler(this.GameLoginTextBox_Leave);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // GamePasswordTextBox
            // 
            resources.ApplyResources(this.GamePasswordTextBox, "GamePasswordTextBox");
            this.GamePasswordTextBox.Name = "GamePasswordTextBox";
            this.GamePasswordTextBox.Enter += new System.EventHandler(this.GamePasswordTextBox_Enter);
            this.GamePasswordTextBox.Leave += new System.EventHandler(this.GamePasswordTextBox_Leave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // DisplayNameTextBox
            // 
            resources.ApplyResources(this.DisplayNameTextBox, "DisplayNameTextBox");
            this.DisplayNameTextBox.Name = "DisplayNameTextBox";
            this.DisplayNameTextBox.Enter += new System.EventHandler(this.DisplayNameTextBox_Enter);
            this.DisplayNameTextBox.Leave += new System.EventHandler(this.DisplayNameTextBox_Leave);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // DescriptionTextBox
            // 
            resources.ApplyResources(this.DescriptionTextBox, "DescriptionTextBox");
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            // 
            // occupationComboBox
            // 
            resources.ApplyResources(this.occupationComboBox, "occupationComboBox");
            this.occupationComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.occupationComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.occupationComboBox.FormattingEnabled = true;
            this.occupationComboBox.Items.AddRange(new object[] {
            resources.GetString("occupationComboBox.Items"),
            resources.GetString("occupationComboBox.Items1"),
            resources.GetString("occupationComboBox.Items2"),
            resources.GetString("occupationComboBox.Items3"),
            resources.GetString("occupationComboBox.Items4"),
            resources.GetString("occupationComboBox.Items5"),
            resources.GetString("occupationComboBox.Items6"),
            resources.GetString("occupationComboBox.Items7"),
            resources.GetString("occupationComboBox.Items8"),
            resources.GetString("occupationComboBox.Items9"),
            resources.GetString("occupationComboBox.Items10"),
            resources.GetString("occupationComboBox.Items11"),
            resources.GetString("occupationComboBox.Items12"),
            resources.GetString("occupationComboBox.Items13"),
            resources.GetString("occupationComboBox.Items14"),
            resources.GetString("occupationComboBox.Items15"),
            resources.GetString("occupationComboBox.Items16"),
            resources.GetString("occupationComboBox.Items17"),
            resources.GetString("occupationComboBox.Items18"),
            resources.GetString("occupationComboBox.Items19"),
            resources.GetString("occupationComboBox.Items20"),
            resources.GetString("occupationComboBox.Items21"),
            resources.GetString("occupationComboBox.Items22"),
            resources.GetString("occupationComboBox.Items23"),
            resources.GetString("occupationComboBox.Items24"),
            resources.GetString("occupationComboBox.Items25"),
            resources.GetString("occupationComboBox.Items26"),
            resources.GetString("occupationComboBox.Items27"),
            resources.GetString("occupationComboBox.Items28"),
            resources.GetString("occupationComboBox.Items29"),
            resources.GetString("occupationComboBox.Items30"),
            resources.GetString("occupationComboBox.Items31")});
            this.occupationComboBox.Name = "occupationComboBox";
            this.occupationComboBox.Enter += new System.EventHandler(this.occupationComboBox_Enter);
            this.occupationComboBox.Leave += new System.EventHandler(this.occupationComboBox_Leave);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // usealtClientCheckBox
            // 
            resources.ApplyResources(this.usealtClientCheckBox, "usealtClientCheckBox");
            this.usealtClientCheckBox.Name = "usealtClientCheckBox";
            this.usealtClientCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveAndclose
            // 
            resources.ApplyResources(this.saveAndclose, "saveAndclose");
            this.saveAndclose.Name = "saveAndclose";
            this.saveAndclose.UseVisualStyleBackColor = true;
            this.saveAndclose.Click += new System.EventHandler(this.saveAndclose_Click);
            // 
            // saveAndAddMore
            // 
            resources.ApplyResources(this.saveAndAddMore, "saveAndAddMore");
            this.saveAndAddMore.Name = "saveAndAddMore";
            this.saveAndAddMore.UseVisualStyleBackColor = true;
            this.saveAndAddMore.Click += new System.EventHandler(this.saveAndAddMore_Click);
            // 
            // AddEditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveAndAddMore);
            this.Controls.Add(this.saveAndclose);
            this.Controls.Add(this.usealtClientCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.occupationComboBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DisplayNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GamePasswordTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GameLoginTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AddEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GameLoginTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GamePasswordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DisplayNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.ComboBox occupationComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox usealtClientCheckBox;
        private System.Windows.Forms.Button saveAndclose;
        private System.Windows.Forms.Button saveAndAddMore;
    }
}