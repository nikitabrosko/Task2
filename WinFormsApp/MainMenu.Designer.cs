
namespace WinFormsApp
{
    partial class MainMenu
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
            this.FullPathToInputFileLabel = new System.Windows.Forms.Label();
            this.InputFileNameLabel = new System.Windows.Forms.Label();
            this.InputFileDirectoryNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChangeInputFilePathButton = new System.Windows.Forms.Button();
            this.InputFileInfoGroup = new System.Windows.Forms.GroupBox();
            this.OutputFileInfoGroup = new System.Windows.Forms.GroupBox();
            this.FullPathToOutputFileLabel = new System.Windows.Forms.Label();
            this.OutputFileDirectoryNameLabel = new System.Windows.Forms.Label();
            this.OutputFileNameLabel = new System.Windows.Forms.Label();
            this.ToolsFileInfoGroup = new System.Windows.Forms.GroupBox();
            this.FullPathToToolsFileLabel = new System.Windows.Forms.Label();
            this.ToolsFileDirectoryNameLabel = new System.Windows.Forms.Label();
            this.ToolsFileNameLabel = new System.Windows.Forms.Label();
            this.ChangeOutputFilePathButton = new System.Windows.Forms.Button();
            this.ChangeToolsFilePathButton = new System.Windows.Forms.Button();
            this.ReadInputFileButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.InputFileInfoGroup.SuspendLayout();
            this.OutputFileInfoGroup.SuspendLayout();
            this.ToolsFileInfoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // FullPathToInputFileLabel
            // 
            this.FullPathToInputFileLabel.AutoSize = true;
            this.FullPathToInputFileLabel.Location = new System.Drawing.Point(6, 24);
            this.FullPathToInputFileLabel.Name = "FullPathToInputFileLabel";
            this.FullPathToInputFileLabel.Size = new System.Drawing.Size(92, 15);
            this.FullPathToInputFileLabel.TabIndex = 0;
            this.FullPathToInputFileLabel.Text = "Full path to file: ";
            // 
            // InputFileNameLabel
            // 
            this.InputFileNameLabel.AutoSize = true;
            this.InputFileNameLabel.Location = new System.Drawing.Point(6, 61);
            this.InputFileNameLabel.Name = "InputFileNameLabel";
            this.InputFileNameLabel.Size = new System.Drawing.Size(64, 15);
            this.InputFileNameLabel.TabIndex = 1;
            this.InputFileNameLabel.Text = "File name: ";
            // 
            // InputFileDirectoryNameLabel
            // 
            this.InputFileDirectoryNameLabel.AutoSize = true;
            this.InputFileDirectoryNameLabel.Location = new System.Drawing.Point(6, 99);
            this.InputFileDirectoryNameLabel.Name = "InputFileDirectoryNameLabel";
            this.InputFileDirectoryNameLabel.Size = new System.Drawing.Size(94, 15);
            this.InputFileDirectoryNameLabel.TabIndex = 2;
            this.InputFileDirectoryNameLabel.Text = "Directory name: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Working with files paths";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(505, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tools";
            // 
            // ChangeInputFilePathButton
            // 
            this.ChangeInputFilePathButton.Location = new System.Drawing.Point(18, 465);
            this.ChangeInputFilePathButton.Name = "ChangeInputFilePathButton";
            this.ChangeInputFilePathButton.Size = new System.Drawing.Size(184, 23);
            this.ChangeInputFilePathButton.TabIndex = 5;
            this.ChangeInputFilePathButton.Text = "Write path to input file";
            this.ChangeInputFilePathButton.UseVisualStyleBackColor = true;
            this.ChangeInputFilePathButton.Click += new System.EventHandler(this.ChangeInputFilePathButton_Click);
            // 
            // InputFileInfoGroup
            // 
            this.InputFileInfoGroup.Controls.Add(this.FullPathToInputFileLabel);
            this.InputFileInfoGroup.Controls.Add(this.InputFileNameLabel);
            this.InputFileInfoGroup.Controls.Add(this.InputFileDirectoryNameLabel);
            this.InputFileInfoGroup.Location = new System.Drawing.Point(12, 12);
            this.InputFileInfoGroup.Name = "InputFileInfoGroup";
            this.InputFileInfoGroup.Size = new System.Drawing.Size(776, 131);
            this.InputFileInfoGroup.TabIndex = 7;
            this.InputFileInfoGroup.TabStop = false;
            this.InputFileInfoGroup.Text = "Input file info";
            // 
            // OutputFileInfoGroup
            // 
            this.OutputFileInfoGroup.Controls.Add(this.FullPathToOutputFileLabel);
            this.OutputFileInfoGroup.Controls.Add(this.OutputFileDirectoryNameLabel);
            this.OutputFileInfoGroup.Controls.Add(this.OutputFileNameLabel);
            this.OutputFileInfoGroup.Location = new System.Drawing.Point(12, 149);
            this.OutputFileInfoGroup.Name = "OutputFileInfoGroup";
            this.OutputFileInfoGroup.Size = new System.Drawing.Size(770, 133);
            this.OutputFileInfoGroup.TabIndex = 8;
            this.OutputFileInfoGroup.TabStop = false;
            this.OutputFileInfoGroup.Text = "Output file info";
            // 
            // FullPathToOutputFileLabel
            // 
            this.FullPathToOutputFileLabel.AutoSize = true;
            this.FullPathToOutputFileLabel.Location = new System.Drawing.Point(6, 22);
            this.FullPathToOutputFileLabel.Name = "FullPathToOutputFileLabel";
            this.FullPathToOutputFileLabel.Size = new System.Drawing.Size(92, 15);
            this.FullPathToOutputFileLabel.TabIndex = 3;
            this.FullPathToOutputFileLabel.Text = "Full path to file: ";
            // 
            // OutputFileDirectoryNameLabel
            // 
            this.OutputFileDirectoryNameLabel.AutoSize = true;
            this.OutputFileDirectoryNameLabel.Location = new System.Drawing.Point(6, 97);
            this.OutputFileDirectoryNameLabel.Name = "OutputFileDirectoryNameLabel";
            this.OutputFileDirectoryNameLabel.Size = new System.Drawing.Size(94, 15);
            this.OutputFileDirectoryNameLabel.TabIndex = 5;
            this.OutputFileDirectoryNameLabel.Text = "Directory name: ";
            // 
            // OutputFileNameLabel
            // 
            this.OutputFileNameLabel.AutoSize = true;
            this.OutputFileNameLabel.Location = new System.Drawing.Point(6, 59);
            this.OutputFileNameLabel.Name = "OutputFileNameLabel";
            this.OutputFileNameLabel.Size = new System.Drawing.Size(64, 15);
            this.OutputFileNameLabel.TabIndex = 4;
            this.OutputFileNameLabel.Text = "File name: ";
            // 
            // ToolsFileInfoGroup
            // 
            this.ToolsFileInfoGroup.Controls.Add(this.FullPathToToolsFileLabel);
            this.ToolsFileInfoGroup.Controls.Add(this.ToolsFileDirectoryNameLabel);
            this.ToolsFileInfoGroup.Controls.Add(this.ToolsFileNameLabel);
            this.ToolsFileInfoGroup.Location = new System.Drawing.Point(12, 288);
            this.ToolsFileInfoGroup.Name = "ToolsFileInfoGroup";
            this.ToolsFileInfoGroup.Size = new System.Drawing.Size(770, 133);
            this.ToolsFileInfoGroup.TabIndex = 9;
            this.ToolsFileInfoGroup.TabStop = false;
            this.ToolsFileInfoGroup.Text = "Tools file info";
            // 
            // FullPathToToolsFileLabel
            // 
            this.FullPathToToolsFileLabel.AutoSize = true;
            this.FullPathToToolsFileLabel.Location = new System.Drawing.Point(6, 22);
            this.FullPathToToolsFileLabel.Name = "FullPathToToolsFileLabel";
            this.FullPathToToolsFileLabel.Size = new System.Drawing.Size(92, 15);
            this.FullPathToToolsFileLabel.TabIndex = 3;
            this.FullPathToToolsFileLabel.Text = "Full path to file: ";
            // 
            // ToolsFileDirectoryNameLabel
            // 
            this.ToolsFileDirectoryNameLabel.AutoSize = true;
            this.ToolsFileDirectoryNameLabel.Location = new System.Drawing.Point(6, 97);
            this.ToolsFileDirectoryNameLabel.Name = "ToolsFileDirectoryNameLabel";
            this.ToolsFileDirectoryNameLabel.Size = new System.Drawing.Size(94, 15);
            this.ToolsFileDirectoryNameLabel.TabIndex = 5;
            this.ToolsFileDirectoryNameLabel.Text = "Directory name: ";
            // 
            // ToolsFileNameLabel
            // 
            this.ToolsFileNameLabel.AutoSize = true;
            this.ToolsFileNameLabel.Location = new System.Drawing.Point(6, 59);
            this.ToolsFileNameLabel.Name = "ToolsFileNameLabel";
            this.ToolsFileNameLabel.Size = new System.Drawing.Size(64, 15);
            this.ToolsFileNameLabel.TabIndex = 4;
            this.ToolsFileNameLabel.Text = "File name: ";
            // 
            // ChangeOutputFilePathButton
            // 
            this.ChangeOutputFilePathButton.Location = new System.Drawing.Point(18, 494);
            this.ChangeOutputFilePathButton.Name = "ChangeOutputFilePathButton";
            this.ChangeOutputFilePathButton.Size = new System.Drawing.Size(184, 23);
            this.ChangeOutputFilePathButton.TabIndex = 10;
            this.ChangeOutputFilePathButton.Text = "Write path to output file";
            this.ChangeOutputFilePathButton.UseVisualStyleBackColor = true;
            this.ChangeOutputFilePathButton.Click += new System.EventHandler(this.ChangeOutputFilePathButton_Click);
            // 
            // ChangeToolsFilePathButton
            // 
            this.ChangeToolsFilePathButton.Location = new System.Drawing.Point(18, 523);
            this.ChangeToolsFilePathButton.Name = "ChangeToolsFilePathButton";
            this.ChangeToolsFilePathButton.Size = new System.Drawing.Size(184, 23);
            this.ChangeToolsFilePathButton.TabIndex = 11;
            this.ChangeToolsFilePathButton.Text = "Write path to tools file";
            this.ChangeToolsFilePathButton.UseVisualStyleBackColor = true;
            this.ChangeToolsFilePathButton.Click += new System.EventHandler(this.ChangeToolsFilePathButton_Click);
            // 
            // ReadInputFileButton
            // 
            this.ReadInputFileButton.Location = new System.Drawing.Point(18, 592);
            this.ReadInputFileButton.Name = "ReadInputFileButton";
            this.ReadInputFileButton.Size = new System.Drawing.Size(184, 23);
            this.ReadInputFileButton.TabIndex = 12;
            this.ReadInputFileButton.Text = "Read input file";
            this.ReadInputFileButton.UseVisualStyleBackColor = true;
            this.ReadInputFileButton.Click += new System.EventHandler(this.ReadInputFileButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 621);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Write in output file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 465);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(387, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Print in tools file all sentences with ordering by number of words";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(327, 494);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(387, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Print in tools file words with input word length in question sentences";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(327, 581);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(387, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Print in tools file text replacing all words with input length to substring";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(327, 523);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(387, 52);
            this.button5.TabIndex = 16;
            this.button5.Text = "Print in tools file text with removing all words with input length that starts wi" +
    "th consonant letter";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 565);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Working with files content";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 661);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ReadInputFileButton);
            this.Controls.Add(this.ChangeToolsFilePathButton);
            this.Controls.Add(this.ChangeOutputFilePathButton);
            this.Controls.Add(this.ToolsFileInfoGroup);
            this.Controls.Add(this.OutputFileInfoGroup);
            this.Controls.Add(this.InputFileInfoGroup);
            this.Controls.Add(this.ChangeInputFilePathButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.InputFileInfoGroup.ResumeLayout(false);
            this.InputFileInfoGroup.PerformLayout();
            this.OutputFileInfoGroup.ResumeLayout(false);
            this.OutputFileInfoGroup.PerformLayout();
            this.ToolsFileInfoGroup.ResumeLayout(false);
            this.ToolsFileInfoGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FullPathToInputFileLabel;
        private System.Windows.Forms.Label InputFileNameLabel;
        private System.Windows.Forms.Label InputFileDirectoryNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ChangeInputFilePathButton;
        private System.Windows.Forms.GroupBox InputFileInfoGroup;
        private System.Windows.Forms.GroupBox OutputFileInfoGroup;
        private System.Windows.Forms.Label FullPathToOutputFileLabel;
        private System.Windows.Forms.Label OutputFileDirectoryNameLabel;
        private System.Windows.Forms.Label OutputFileNameLabel;
        private System.Windows.Forms.GroupBox ToolsFileInfoGroup;
        private System.Windows.Forms.Label FullPathToToolsFileLabel;
        private System.Windows.Forms.Label ToolsFileDirectoryNameLabel;
        private System.Windows.Forms.Label ToolsFileNameLabel;
        private System.Windows.Forms.Button ChangeOutputFilePathButton;
        private System.Windows.Forms.Button ChangeToolsFilePathButton;
        private System.Windows.Forms.Button ReadInputFileButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
    }
}