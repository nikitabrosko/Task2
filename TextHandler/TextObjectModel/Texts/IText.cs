using System.Collections.Generic;
using TextHandler.TextObjectModel.Sentences;

namespace TextHandler.TextObjectModel.Texts
{
    public interface IText : ITextModelElement<IEnumerable<ISentence>>
    {
        void Append(ISentence sentence);
    }
}
