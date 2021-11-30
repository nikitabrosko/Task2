using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.TextWorks.Characters.Letters;

namespace TextHandler.TextWorks
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