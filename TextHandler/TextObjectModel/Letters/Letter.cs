using System;

namespace TextHandler.TextObjectModel.Letters
{
    public class Letter : ILetter
    {
        public char Value { get; }

        public Letter(char letter)
        {
            Value = letter;

            try
            {
                Verify();
            }
            catch
            {
                Value = default;

                throw;
            }
        }

        public string GetStringRepresentation()
        {
            return Value.ToString();
        }

        private void Verify()
        {
            if (char.IsDigit(Value))
            {
                throw new ArgumentException("letter can not be a digit");
            }

            if (char.IsWhiteSpace(Value))
            {
                throw new ArgumentException("letter can not be a whitespace");
            }

            if (char.IsPunctuation(Value))
            {
                throw new ArgumentException("letter can not be a punctuation");
            }
        }
    }
}
