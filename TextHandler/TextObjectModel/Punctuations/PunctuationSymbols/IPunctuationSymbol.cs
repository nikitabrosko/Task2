using System.Collections.Generic;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;

namespace TextHandler.TextObjectModel.Punctuations.PunctuationSymbols
{
    public interface IPunctuationSymbol : ISentenceElement, ITextModelElement<IEnumerable<IPunctuationMark>>
    {
    }
}
