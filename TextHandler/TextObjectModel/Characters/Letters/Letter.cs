using System;

namespace TextHandler.TextObjectModel.Characters.Letters
{
    public class Letter : Character
    {
        public Letter(char letter)
        {
            Value = letter;

            try
            {
                Verify(this);
            }
            catch
            {
                Value = default;

                throw;
            }
        }

        public static void Verify(Letter letter)
        {
            if (letter is null)
            {
                throw new ArgumentNullException(nameof(letter));
            }

            if (char.IsDigit(letter.Value))
            {
                throw new ArgumentException("letter can not be a digit", nameof(letter));
            }

            if (char.IsWhiteSpace(letter.Value))
            {
                throw new ArgumentException("letter can not be a whitespace", nameof(letter));
            }

            if (char.IsPunctuation(letter.Value))
            {
                throw new ArgumentException("letter can not be a punctuation", nameof(letter));
            }
        }
    }
}
