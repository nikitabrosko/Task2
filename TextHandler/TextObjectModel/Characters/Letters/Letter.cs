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
                Verifier.Verify(this);
            }
            catch
            {
                Value = default;

                throw;
            }
        }
    }
}
