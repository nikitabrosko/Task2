using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TextHandler.TextObjectModel
{
    public class Text
    {
        private readonly IList<Sentence> _text = new List<Sentence>();

        public IEnumerable<Sentence> Value => new ReadOnlyCollection<Sentence>(_text);

        public void Append(Sentence sentence)
        {
            _text.Add(sentence);
        }
    }
}
