using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TextHandler.TextObjectModel
{
    public class Sentence
    {
        private readonly IList<ISentenceElement> _sentence = new List<ISentenceElement>();

        public IEnumerable<ISentenceElement> Value => new ReadOnlyCollection<ISentenceElement>(_sentence);

        public Sentence(IEnumerable<ISentenceElement> sentenceElements)
        {
            _sentence = sentenceElements.ToList();
        }
    }
}
