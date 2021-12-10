using System.Collections.Generic;
using TextHandler.TextObjectModel.Sentences;

namespace TextHandler.TextObjectModel.Texts
{
    public interface IText : ITextModelElement<IEnumerable<ITextElement>>
    {
        void Append(ITextElement sentence);
    }
}
