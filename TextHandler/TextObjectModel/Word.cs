using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TextHandler.TextObjectModel.Characters.Letters;

namespace TextHandler.TextObjectModel
{
    public class Word : ISentenceable
    {
        private readonly IList<Letter> _word;

        public IEnumerable<Letter> Value => new ReadOnlyCollection<Letter>(_word);

        public Word(IEnumerable<Letter> letters)
        {
            _word = letters.ToList();
        }
    }
}