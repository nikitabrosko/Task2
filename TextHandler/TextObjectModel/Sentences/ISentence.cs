using System.Collections.Generic;

namespace TextHandler.TextObjectModel.Sentences
{
    public interface ISentence : ITextElement, ITextModelElement<IEnumerable<ISentenceElement>>
    {
    }
}
