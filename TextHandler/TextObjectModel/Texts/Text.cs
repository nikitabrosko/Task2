using System.Collections.Generic;
using System.Collections.ObjectModel;
using TextHandler.TextObjectModel.Sentences;

namespace TextHandler.TextObjectModel.Texts
{
    public class Text : IText
    {
        private readonly IList<ISentence> _text = new List<ISentence>();

        public IEnumerable<ISentence> Value => new ReadOnlyCollection<ISentence>(_text);

        public void Append(ISentence sentence)
        {
            _text.Add(sentence);
        }
    }
}
