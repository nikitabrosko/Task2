using System;

namespace TextHandler.TextObjectModel.WhiteSpaces
{
    public class WhiteSpace : IWhiteSpace
    {
        public char Value { get; }

        public WhiteSpace(char whiteSpace)
        {
            Value = whiteSpace;

            Verify();
        }

        public string GetStringRepresentation()
        {
            return Value.ToString();
        }

        private void Verify()
        {
            if (Value != ' ')
            {
                throw new ArgumentException("white space object should be only a white space!");
            }
        }
    }
}
