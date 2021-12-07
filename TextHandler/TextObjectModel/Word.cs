using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandler.TextObjectModel
{
    public class Word : ISentenceElement
    {
        private readonly IList<IWordElement> _word;

        public IEnumerable<IWordElement> Value => new ReadOnlyCollection<IWordElement>(_word);

        public Word(IEnumerable<IWordElement> wordElements)
        {
            _word = wordElements.ToList();

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
            var wordList = word.Value.ToList();

            if (wordList.Count == 0)
            {
                throw new ArgumentException("letters count can not be 0", nameof(word));
            }

            if (word.Value.First() is PunctuationMark)
            {
                throw new ArgumentException("first element of word can not be a punctuation mark", nameof(word));
            }
        }
    }
}