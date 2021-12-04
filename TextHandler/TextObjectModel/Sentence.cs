using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandler.TextObjectModel
{
    public class Sentence
    {
        private readonly IList<ISentenceElement> _sentence;

        public IEnumerable<ISentenceElement> Value => new ReadOnlyCollection<ISentenceElement>(_sentence);

        public Sentence(IEnumerable<ISentenceElement> sentenceElements)
        {
            _sentence = sentenceElements.ToList();

            try
            {
                Verify(this);
            }
            catch
            {
                _sentence = default;

                throw;
            }
        }

        public static void Verify(Sentence sentence)
        {
            if (sentence is null)
            {
                throw new ArgumentNullException(nameof(sentence));
            }

            if (sentence.Value is null)
            {
                throw new ArgumentNullException(nameof(sentence));
            }

            var firstSentenceElement = sentence.Value.ToList().First();

            switch (firstSentenceElement)
            {
                case PunctuationMark or PunctuationSymbol:
                    throw new ArgumentException("first element of sentence can not be a punctuation mark or symbol");
                case Word word when char.IsLower(word.Value.ToList()[0].Value):
                    throw new ArgumentException("first element of sentence can not be in lowercase");
            }

            var lastSentenceElement = sentence.Value.ToList().Last();

            if (lastSentenceElement is not PunctuationMark)
            {
                if (lastSentenceElement is not PunctuationSymbol)
                {
                    throw new ArgumentException("last element of sentence should be a punctuation mark or symbol");
                }
            }
        }
    }
}
