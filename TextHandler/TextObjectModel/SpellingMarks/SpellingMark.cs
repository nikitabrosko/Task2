using System;

namespace TextHandler.TextObjectModel.SpellingMarks
{
    public class SpellingMark : ISpellingMark
    {
        public char Value { get; }

        public SpellingMark(char punctuationMark)
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

        public string GetStringRepresentation()
        {
            return Value.ToString();
        }

        private void Verify()
        {
            if (Value is not ('\'' or '-'))
            {
                throw new ArgumentException("spelling mark can be a \' or -");
            }
        }
    }
}
