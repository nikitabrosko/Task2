using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TextHandler.TextObjectModel.Letters;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.Punctuations.PunctuationSymbols;
using TextHandler.TextObjectModel.Words;

namespace TextHandler.TextObjectModel.Sentences
{
    public class Sentence : ISentence
    {
        private readonly IList<ISentenceElement> _sentence;

        public IEnumerable<ISentenceElement> Value => new ReadOnlyCollection<ISentenceElement>(_sentence);

        public Sentence(IEnumerable<ISentenceElement> sentenceElements)
        {
            _sentence = sentenceElements.ToList();

            try
            {
                Verify();
            }
            catch
            {
                _sentence = default;

                throw;
            }
        }

        private void Verify()
        {
            var firstSentenceElement = Value.ToList().First();

            switch (firstSentenceElement)
            {
                case IPunctuationMark punctuationMark:
                    switch (punctuationMark.Value)
                    {
                        case '\n':
                        case '\r':
                            break;
                        default:
                            throw new ArgumentException("first element of sentence can not be a punctuation mark");
                    }

                    break;
                case IPunctuationSymbol punctuationSymbol:
                    var punctuationSymbolFirst = new PunctuationSymbol(new IPunctuationMark[]
                    {
                        new PunctuationMark('\r'),
                        new PunctuationMark('\n')
                    });

                    if (punctuationSymbol.Value.Count() != punctuationSymbolFirst.Value.Count())
                    {
                        throw new ArgumentException("first element of sentence can not be a punctuation symbol");
                    }

                    for (int i = 0; i < punctuationSymbol.Value.Count(); i++)
                    {
                        if (punctuationSymbol.Value.ToList()[i].Value != punctuationSymbolFirst.Value.ToList()[i].Value)
                        {
                            throw new ArgumentException("first element of sentence can not be a punctuation symbol");
                        }
                    }

                    break;
                case IWord word:
                    switch (word.Value.First())
                    {
                        case ILetter when char.IsLower(((ILetter)word.Value.First()).Value):
                            throw new ArgumentException("first element of sentence can not be in lowercase");
                    }
                    break;
            }

            var lastSentenceElement = Value.ToList().Last();

            if (lastSentenceElement is not IPunctuationMark or IPunctuationSymbol)
            {
                throw new ArgumentException("last element of sentence should be a punctuation mark or symbol");
            }
        }
    }
}
