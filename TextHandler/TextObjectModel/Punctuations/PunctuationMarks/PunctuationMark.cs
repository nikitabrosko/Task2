using System;

namespace TextHandler.TextObjectModel.Punctuations.PunctuationMarks
{
    public class PunctuationMark : IPunctuationMark
    {
        public char Value { get; }

        public PunctuationMark(char punctuationMark)
        {
            Value = punctuationMark;

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

        private void Verify()
        {
            if (char.IsDigit(Value))
            {
                throw new ArgumentException("punctuation mark can not be a digit!");
            }

            if (Value is ' ')
            {
                throw new ArgumentException("punctuation mark can not be a whitespace");
            }

            if (char.IsLetter(Value))
            {
                throw new ArgumentException("punctuation mark can not be a letter");
            }
        }
    }
}
