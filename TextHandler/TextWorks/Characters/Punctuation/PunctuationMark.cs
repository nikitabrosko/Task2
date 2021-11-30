namespace TextHandler.TextWorks.Characters.Punctuation
{
    public class PunctuationMark : Character, ISentenceable
    {
        public PunctuationMark(char punctuationMark)
        {
            Value = punctuationMark;
        }
    }
}
