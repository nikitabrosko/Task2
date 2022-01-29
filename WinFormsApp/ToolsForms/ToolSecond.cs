using System;
using System.IO;
using System.Windows.Forms;
using TextHandler.TextObjectModel.Texts;
using TextHandler.Tools;

namespace WinFormsApp.ToolsForms
{
    public partial class ToolSecond : Form
    {
        private readonly IText _text;
        private readonly string _fullPathToToolsFile;

        public ToolSecond(IText text, string fullPathToToolsFile)
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

                PrintFindWordsInQuestionSentencesInFile(_text, wordLength, writer);

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

        private static void PrintFindWordsInQuestionSentencesInFile(IText textObject, int wordLength, TextWriter textWriter)
        {
            var words = TextWorkingTool.FindWordsInQuestionSentences(textObject, wordLength);

            foreach (var word in words)
            {
                textWriter.Write(word.GetStringRepresentation() + " ");
            }
        }
    }
}
