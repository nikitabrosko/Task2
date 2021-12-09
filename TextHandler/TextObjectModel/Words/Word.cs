using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TextHandler.TextObjectModel.SpellingMarks;

namespace TextHandler.TextObjectModel.Words
{
    public class Word : IWord
    {
        private readonly IList<IWordElement> _word;

        public IEnumerable<IWordElement> Value => new ReadOnlyCollection<IWordElement>(_word);

        public Word(IEnumerable<IWordElement> wordElements)
        {
            _word = wordElements.ToList();

            try
            {
                Verify();
            }
            catch
            {
                _word = default;

                throw;
            }
        }

        public string GetStringRepresentation()
        {
            return Value.Aggregate(string.Empty, (current, wordElement) => current + wordElement.GetStringRepresentation());
        }

        private void Verify()
        {
            var wordList = Value.ToList();

            if (wordList.Count == 0)
            {
                throw new ArgumentException("letters count can not be 0");
            }

            if (Value.First() is ISpellingMark)
            {
                throw new ArgumentException("first element of word can not be a punctuation mark");
            }
        }
    }
}