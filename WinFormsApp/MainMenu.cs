using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Texts;
using TextHandler.Tools;
using WinFormsApp.ToolsForms;

namespace WinFormsApp
{
    public partial class MainMenu : Form
    {
        private IText _text;
        private string _fullPathToInputFile;
        private string _fullPathToOutputFile;
        private string _fullPathToToolsFile;

        public string FullPathToInputFile
        {
            get => _fullPathToInputFile;
            set
            {
                _fullPathToInputFile = value;
                WritePathsInGroupBox(InputFileInfoGroup, value);
            }
        }

        public string FullPathToOutputFile
        {
            get => _fullPathToOutputFile;
            set
            {
                _fullPathToOutputFile = value;
                WritePathsInGroupBox(OutputFileInfoGroup, value);
            }
        }

        public string FullPathToToolsFile
        {
            get => _fullPathToToolsFile;
            set
            {
                _fullPathToToolsFile = value;
                WritePathsInGroupBox(ToolsFileInfoGroup, value);
            }
        }

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
        }

        private static void WritePathsInGroupBox(GroupBox groupBox, string fullPathToFile)
        {
            var collection = groupBox.Controls;

            if (collection.Count is 3)
            {
                collection[0].Text = "Full path to file: ";
                collection[0].Text += fullPathToFile;

                collection[1].Text = "File name: ";
                collection[1].Text += Path.GetFileName(fullPathToFile);

                collection[2].Text = "Directory name: ";
                collection[2].Text += Path.GetDirectoryName(fullPathToFile);
            }
        }

        private void ChangeInputFilePathButton_Click(object sender, EventArgs e)
        {
            var writePathToFileForm = new WritePathToInputFile(this);
            writePathToFileForm.Show();
        }

        private void ChangeOutputFilePathButton_Click(object sender, EventArgs e)
        {
            var writePathToFileForm = new WritePathToOutputFile(this);
            writePathToFileForm.Show();
        }

        private void ChangeToolsFilePathButton_Click(object sender, EventArgs e)
        {
            var writePathToFileForm = new WritePathToToolsFile(this);
            writePathToFileForm.Show();
        }

        private void ReadInputFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FullPathToInputFile))
                {
                    MessageBox.Show("First write path to input file!");

                    return;
                }

                using var reader = new StreamReader(FullPathToInputFile);

                var parserToObjectModel = new ParserToObjectModel(reader);

                _text = parserToObjectModel.ReadFile();

                MessageBox.Show("Parse to object model complete successfully");
            }
            catch (FormatException)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FullPathToOutputFile))
                {
                    MessageBox.Show("First write path to output file!");

                    return;
                }

                using var writer = new StreamWriter(FullPathToOutputFile);

                var parserFromObjectModel = new ParserFromObjectModel(writer);

                parserFromObjectModel.WriteInFile(_text);

                MessageBox.Show("Parse from object model complete successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (_text is null)
                {
                    MessageBox.Show("First parse input file to object model!");

                    return;
                }

                using var writer = new StreamWriter(FullPathToToolsFile);

                PrintSentencesWithOrderByNumberOfWordsInFile(_text, writer);

                MessageBox.Show("Print to tools directory complete successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_text is null)
            {
                MessageBox.Show("First parse input file to object model!");

                return;
            }

            if (FullPathToToolsFile is null)
            {
                MessageBox.Show("First write path to tools file!");

                return;
            }

            var toolSecondForm = new ToolSecond(_text, FullPathToToolsFile);
            toolSecondForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (_text is null)
            {
                MessageBox.Show("First parse input file to object model!");

                return;
            }

            if (FullPathToToolsFile is null)
            {
                MessageBox.Show("First write path to tools file!");

                return;
            }

            var toolThirdForm = new ToolThird(_text, FullPathToToolsFile);
            toolThirdForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_text is null)
            {
                MessageBox.Show("First parse input file to object model!");

                return;
            }

            if (FullPathToToolsFile is null)
            {
                MessageBox.Show("First write path to tools file!");

                return;
            }

            var toolFourthForm = new ToolFourth(_text, FullPathToToolsFile);
            toolFourthForm.Show();
        }

        private static void PrintSentencesWithOrderByNumberOfWordsInFile(IText textObject, TextWriter textWriter)
        {
            var sentences = TextWorkingTool.SentencesWithOrderByNumberOfWords(textObject);

            foreach (var sentence in sentences)
            {
                textWriter.WriteLine(sentence.GetStringRepresentation());
            }
        }
    }
}
