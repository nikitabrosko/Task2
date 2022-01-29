using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class WritePathToOutputFile : Form
    {
        private readonly MainMenu _mainMenu;

        public WritePathToOutputFile(MainMenu mainMenu)
        {
            InitializeComponent();

            _mainMenu = mainMenu;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PathToFileTextBox.Text))
            {
                MessageBox.Show("Write a path!");
            }
            else
            {
                _mainMenu.FullPathToOutputFile = PathToFileTextBox.Text.Trim('\"');
                Hide();
            }
        }
    }
}
