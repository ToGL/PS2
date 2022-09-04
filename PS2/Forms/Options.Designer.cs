namespace PS2
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.mainClienPathLable = new System.Windows.Forms.Label();
            this.mainClientTextBox = new System.Windows.Forms.TextBox();
            this.mainClientPathButton = new System.Windows.Forms.Button();
            this.AlternativeClientPAthL = new System.Windows.Forms.Label();
            this.altClientTextBox = new System.Windows.Forms.TextBox();
            this.altClientSet = new System.Windows.Forms.Button();
            this.saveOptions = new System.Windows.Forms.Button();
            this.CancelOption = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkBoxSetTitleClient = new System.Windows.Forms.CheckBox();
            this.loadToCharacter = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mainClienPathLable
            // 
            resources.ApplyResources(this.mainClienPathLable, "mainClienPathLable");
            this.mainClienPathLable.Name = "mainClienPathLable";
            // 
            // mainClientTextBox
            // 
            resources.ApplyResources(this.mainClientTextBox, "mainClientTextBox");
            this.mainClientTextBox.Name = "mainClientTextBox";
            // 
            // mainClientPathButton
            // 
            resources.ApplyResources(this.mainClientPathButton, "mainClientPathButton");
            this.mainClientPathButton.Name = "mainClientPathButton";
            this.mainClientPathButton.UseVisualStyleBackColor = true;
            this.mainClientPathButton.Click += new System.EventHandler(this.mainClientPathButton_Click);
            // 
            // AlternativeClientPAthL
            // 
            resources.ApplyResources(this.AlternativeClientPAthL, "AlternativeClientPAthL");
            this.AlternativeClientPAthL.Name = "AlternativeClientPAthL";
            // 
            // altClientTextBox
            // 
            resources.ApplyResources(this.altClientTextBox, "altClientTextBox");
            this.altClientTextBox.Name = "altClientTextBox";
            // 
            // altClientSet
            // 
            resources.ApplyResources(this.altClientSet, "altClientSet");
            this.altClientSet.Name = "altClientSet";
            this.altClientSet.UseVisualStyleBackColor = true;
            this.altClientSet.Click += new System.EventHandler(this.altClientSet_Click);
            // 
            // saveOptions
            // 
            resources.ApplyResources(this.saveOptions, "saveOptions");
            this.saveOptions.Name = "saveOptions";
            this.saveOptions.UseVisualStyleBackColor = true;
            this.saveOptions.Click += new System.EventHandler(this.saveOptions_Click);
            // 
            // CancelOption
            // 
            resources.ApplyResources(this.CancelOption, "CancelOption");
            this.CancelOption.Name = "CancelOption";
            this.CancelOption.UseVisualStyleBackColor = true;
            this.CancelOption.Click += new System.EventHandler(this.CancelOption_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "L2.exe";
            // 
            // checkBoxSetTitleClient
            // 
            resources.ApplyResources(this.checkBoxSetTitleClient, "checkBoxSetTitleClient");
            this.checkBoxSetTitleClient.Checked = true;
            this.checkBoxSetTitleClient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSetTitleClient.Name = "checkBoxSetTitleClient";
            this.checkBoxSetTitleClient.UseVisualStyleBackColor = true;
            this.checkBoxSetTitleClient.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // loadToCharacter
            // 
            resources.ApplyResources(this.loadToCharacter, "loadToCharacter");
            this.loadToCharacter.Name = "loadToCharacter";
            this.loadToCharacter.UseVisualStyleBackColor = true;
            this.loadToCharacter.CheckedChanged += new System.EventHandler(this.loadToCharacter_CheckedChanged);
            // 
            // OptionsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadToCharacter);
            this.Controls.Add(this.checkBoxSetTitleClient);
            this.Controls.Add(this.CancelOption);
            this.Controls.Add(this.saveOptions);
            this.Controls.Add(this.altClientSet);
            this.Controls.Add(this.altClientTextBox);
            this.Controls.Add(this.AlternativeClientPAthL);
            this.Controls.Add(this.mainClientPathButton);
            this.Controls.Add(this.mainClientTextBox);
            this.Controls.Add(this.mainClienPathLable);
            this.Name = "OptionsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainClienPathLable;
        private System.Windows.Forms.TextBox mainClientTextBox;
        private System.Windows.Forms.Button mainClientPathButton;
        private System.Windows.Forms.Label AlternativeClientPAthL;
        private System.Windows.Forms.TextBox altClientTextBox;
        private System.Windows.Forms.Button altClientSet;
        private System.Windows.Forms.Button saveOptions;
        private System.Windows.Forms.Button CancelOption;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBoxSetTitleClient;
        private System.Windows.Forms.CheckBox loadToCharacter;
    }
}