using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TextHandler.TextObjectModel.Texts
{
    public class Text : IText
    {
        private readonly IList<ITextElement> _text = new List<ITextElement>();

        public IEnumerable<ITextElement> Value => new ReadOnlyCollection<ITextElement>(_text);

        public void Append(ITextElement sentence)
        {
            _text.Add(sentence);
        }

        public string GetStringRepresentation()
        {
            return Value.Aggregate(string.Empty, (current, textElement) => current + textElement.GetStringRepresentation());
        }
    }
}
