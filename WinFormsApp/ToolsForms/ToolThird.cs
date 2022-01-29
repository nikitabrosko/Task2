using System;
using System.IO;
using System.Windows.Forms;
using TextHandler.TextObjectModel.Texts;
using TextHandler.Tools;

namespace WinFormsApp.ToolsForms
{
    public partial class ToolThird : Form
    {
        private readonly IText _text;
        private readonly string _fullPathToToolsFile;

        public ToolThird(IText text, string fullPathToToolsFile)
        {
            InitializeComponent();

            _text = text;
            _fullPathToToolsFile = fullPathToToolsFile;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(WordLegthTextBox.Text))
                {
                    MessageBox.Show("First write word length!");
                    return;
                }

                var wordLength = int.Parse(WordLegthTextBox.Text);

                using var writer = new StreamWriter(_fullPathToToolsFile);

                PrintRemoveWordsThatStartsWithConsonantLetterInFile(_text, wordLength, writer);

                MessageBox.Show("Print to tools directory complete successfully");

                Hide();
            }
            catch (FormatException)
            {
                MessageBox.Show("First write word length!");
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private static void PrintRemoveWordsThatStartsWithConsonantLetterInFile(IText textObject, int wordLength, TextWriter textWriter)
        {
            var newTextObject = TextWorkingTool.RemoveWordsThatStartsWithConsonantLetter(textObject, wordLength);

            textWriter.WriteLine(newTextObject.GetStringRepresentation());
        }
    }
}
