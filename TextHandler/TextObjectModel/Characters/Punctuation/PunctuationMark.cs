﻿namespace TextHandler.TextObjectModel.Characters.Punctuation
{
    public class PunctuationMark : Character, ISentenceElement
    {
        public PunctuationMark(char punctuationMark)
        {
            Value = punctuationMark;

            try
            {
                Verifier.Verify(this);
            }
            finally
            {
                Value = default;
            }
        }
    }
}
