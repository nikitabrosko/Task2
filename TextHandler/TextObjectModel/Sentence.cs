using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TextHandler.TextObjectModel
{
    public class Sentence
    {
        private readonly IList<ISentenceable> _sentence = new List<ISentenceable>();

        public IEnumerable<ISentenceable> Value => new ReadOnlyCollection<ISentenceable>(_sentence);

        public Sentence(IEnumerable<ISentenceable> sentenceElements)
        {
            _sentence = sentenceElements.ToList();
        }
    }
}
