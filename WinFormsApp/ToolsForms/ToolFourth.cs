using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Sentences;
using TextHandler.TextObjectModel.Texts;
using TextHandler.Tools;

namespace WinFormsApp.ToolsForms
{
    public partial class ToolFourth : Form
    {
        private readonly IText _text;
        private readonly string _fullPathToToolsFile;

        public ToolFourth(IText text, string fullPathToToolsFile)
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

                if (string.IsNullOrWhiteSpace(SentenceIndexTextBox.Text))
                {
                    MessageBox.Show("First write sentence number!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(SubstringTextBox.Text))
                {
                    MessageBox.Show("First write substring!");
                    return;
                }

                var wordLength = int.Parse(WordLegthTextBox.Text);
                var sentenceIndex = int.Parse(SentenceIndexTextBox.Text);
                var substring = GetSubstring("substring.txt", SubstringTextBox.Text);

                using var writer = new StreamWriter(_fullPathToToolsFile);

                PrintReplaceWordsWithSubstringInFile(_text, sentenceIndex, substring, wordLength, writer);

                MessageBox.Show("Print to tools file complete successfully");

                Hide();
            }
            catch (FormatException)
            {
                MessageBox.Show("Format error!");
            }
        }

        private static void PrintReplaceWordsWithSubstringInFile(IText textObject, int sentenceIndex,
            IEnumerable<ISentenceElement> substringText, int wordLength, TextWriter textWriter)
        {
            var newTextObject =
                TextWorkingTool.ReplaceWordsWithSubstring(textObject, sentenceIndex, substringText, wordLength);

            textWriter.WriteLine(newTextObject.GetStringRepresentation());
        }

        private static IEnumerable<ISentenceElement> GetSubstring(string path, string substring)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                var stream = File.Create(path);
                stream.Dispose();

                File.AppendAllText(path, substring);

                var reader = new StreamReader(path);

                var parserToObjectModel = new ParserToObjectModel(reader);
                var textObject = parserToObjectModel.ReadFile();

                if (textObject.Value.Count() != 1)
                {
                    MessageBox.Show("Incorrect substring, try enter a sentence again!");
                }

                reader.Dispose();
                File.Delete(path);

                return textObject.Value.OfType<ISentence>().Single().Value;
            }
            catch (IOException)
            {
                return GetSubstring(path, substring);
            }
        }
    }
}