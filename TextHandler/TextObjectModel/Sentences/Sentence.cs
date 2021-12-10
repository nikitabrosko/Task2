using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TextHandler.TextObjectModel.Letters;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.Punctuations.PunctuationSymbols;
using TextHandler.TextObjectModel.WhiteSpaces;
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

        public string GetStringRepresentation()
        {
            string stringRepresentation = string.Empty;

            foreach (var sentenceElement in Value)
            {
                switch (sentenceElement)
                {
                    case IWord word:
                        stringRepresentation += word.GetStringRepresentation();
                        break;
                    case IPunctuationMark punctuationMark:
                        stringRepresentation += punctuationMark.GetStringRepresentation();
                        break;
                    case IPunctuationSymbol punctuationSymbol:
                        stringRepresentation += punctuationSymbol.GetStringRepresentation();
                        break;
                    case IWhiteSpace whiteSpace:
                        stringRepresentation += whiteSpace.GetStringRepresentation();
                        break;
                }
            }

            return stringRepresentation;
        }

        private void Verify()
        {
            var firstSentenceElement = Value.ToList().First();

            switch (firstSentenceElement)
            {
                case IPunctuationMark:
                    throw new ArgumentException("first element of sentence can not be a punctuation mark");
                case IPunctuationSymbol:
                    throw new ArgumentException("first element of sentence can not be a punctuation symbol");
                case IWord word:
                    switch (word.Value.First())
                    {
                        case ILetter when char.IsLower(((ILetter)word.Value.First()).Value):
                            throw new ArgumentException("first element of sentence can not be in lowercase");
                    }
                    break;
            }

            var lastSentenceElement = Value.ToList().Last();

            if (lastSentenceElement is not (IPunctuationMark or IPunctuationSymbol))
            {
                throw new ArgumentException("last element of sentence should be a punctuation mark or symbol");
            }
        }
    }
}
