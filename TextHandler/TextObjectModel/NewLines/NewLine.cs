using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandler.TextObjectModel.NewLines
{
    public class NewLine : INewLine
    {
        public IEnumerable<char> Value { get; }

        public NewLine(IEnumerable<char> newLine)
        {
            Value = newLine;

            Verify();
        }

        public NewLine(char newLine)
        {
            Value = new char[] {newLine};

            Verify();
        }

        public string GetStringRepresentation()
        {
            return string.Join(string.Empty, Value);
        }

        private void Verify()
        {
            if (Value.Count() is not (1 or 2))
            {
                throw new ArgumentException("new line object length should be 1 or 2");
            }

            if (Value.Any(character => character is not ('\n' or '\r')))
            {
                throw new ArgumentException("new line object should be a new line!");
            }
        }
    }
}
