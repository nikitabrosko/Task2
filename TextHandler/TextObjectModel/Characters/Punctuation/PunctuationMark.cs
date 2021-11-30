namespace TextHandler.TextObjectModel.Characters.Punctuation
{
    public class PunctuationMark : Character, ISentenceable
    {
        public PunctuationMark(char punctuationMark)
        {
            Value = punctuationMark;
        }
    }
}
