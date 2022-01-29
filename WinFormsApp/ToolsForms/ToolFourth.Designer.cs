
namespace WinFormsApp.ToolsForms
{
    partial class ToolFourth
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
            this.button1 = new System.Windows.Forms.Button();
            this.WordLegthTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SentenceIndexTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SubstringTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WordLegthTextBox
            // 
            this.WordLegthTextBox.Location = new System.Drawing.Point(29, 57);
            this.WordLegthTextBox.Name = "WordLegthTextBox";
            this.WordLegthTextBox.Size = new System.Drawing.Size(295, 23);
            this.WordLegthTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Write word length";
            // 
            // SentenceIndexTextBox
            // 
            this.SentenceIndexTextBox.Location = new System.Drawing.Point(29, 124);
            this.SentenceIndexTextBox.Name = "SentenceIndexTextBox";
            this.SentenceIndexTextBox.Size = new System.Drawing.Size(295, 23);
            this.SentenceIndexTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Write sentence number";
            // 
            // SubstringTextBox
            // 
            this.SubstringTextBox.Location = new System.Drawing.Point(29, 194);
            this.SubstringTextBox.Name = "SubstringTextBox";
            this.SubstringTextBox.Size = new System.Drawing.Size(295, 23);
            this.SubstringTextBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Write substring";
            // 
            // ToolFourth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 319);
            this.Controls.Add(this.SubstringTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SentenceIndexTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WordLegthTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ToolFourth";
            this.Text = "Tool 4 inputs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox WordLegthTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SentenceIndexTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SubstringTextBox;
        private System.Windows.Forms.Label label3;
    }
}