using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TextHandler.TextObjectModel.Characters.Letters;
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
            var firstSentenceElement = sentence.Value.ToList().First();

            switch (firstSentenceElement)
            {
                case PunctuationMark punctuationMark:
                    switch (punctuationMark.Value)
                    {
                        case '\n':
                        case '\r':
                            break;
                        default:
                            throw new ArgumentException("first element of sentence can not be a punctuation mark");
                    }

                    break;
                case PunctuationSymbol punctuationSymbol:
                    var punctuationSymbolFirst = new PunctuationSymbol(new PunctuationMark[]
                    {
                        new PunctuationMark('\r'), new PunctuationMark('\n')
                    });

                    if (!punctuationSymbol.Equals(punctuationSymbolFirst))
                    {
                        throw new ArgumentException("first element of sentence can not be a punctuation symbol");
                    }

                    break;
                case Word word:
                    switch (word.Value.First())
                    {
                        case Letter when char.IsLower(((Letter)word.Value.First()).Value):
                            throw new ArgumentException("first element of sentence can not be in lowercase");
                    }
                    break;
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
