using System.Collections.Generic;

namespace TextHandler.TextObjectModel.Words
{
    public interface IWord : ISentenceElement, ITextModelElement<IEnumerable<IWordElement>>
    {
    }
}
