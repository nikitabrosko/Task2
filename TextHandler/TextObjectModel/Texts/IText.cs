using System.Collections.Generic;

namespace TextHandler.TextObjectModel.Texts
{
    public interface IText : ITextModelElement<IEnumerable<ITextElement>>
    {
        void Append(ITextElement sentence);
    }
}
