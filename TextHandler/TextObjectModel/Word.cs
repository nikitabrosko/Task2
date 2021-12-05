using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TextHandler.TextObjectModel.Characters.Letters;

namespace TextHandler.TextObjectModel
{
    public class Word : ISentenceElement
    {
        private readonly IList<Letter> _word;

        public IEnumerable<Letter> Value => new ReadOnlyCollection<Letter>(_word);

        public Word(IEnumerable<Letter> letters)
        {
            _word = letters.ToList();

            try
            {
                Verify(this);
            }
            catch
            {
                _word = default;

                throw;
            }
        }

        public static void Verify(Word word)
        {
            if (word is null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (word.Value is null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            var wordList = word.Value.ToList();

            if (wordList.Count == 0)
            {
                throw new ArgumentException("letters count can not be 0", nameof(word));
            }
        }
    }
}