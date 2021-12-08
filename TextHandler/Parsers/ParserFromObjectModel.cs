using System;
using System.IO;
using System.Linq;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandler.Parsers
{
    public class ParserFromObjectModel
    {
        private StreamWriter _streamWriter;

        public void WriteInFile(string path, Text text)
        {
            try
            {
                _streamWriter = new StreamWriter(path);

                WriteNext(text);
            }
            finally
            {
                _streamWriter.Dispose();
            }
        }

        private void WriteNext(Text text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            foreach (var sentence in text.Value)
            {
                SentenceHandler(sentence);
            }
        }

        private void SentenceHandler(Sentence sentence)
        {
            var sentenceList = sentence.Value.ToList();

            for (int i = 0; i < sentenceList.Count; i++)
            {
                bool isNextCharacterPunctuation = sentenceList.Count > i + 1
                                                  && sentenceList[i + 1] is PunctuationMark or PunctuationSymbol;

                SentenceElementTypeCheck(sentenceList[i], isNextCharacterPunctuation);
            }
        }

        private void SentenceElementTypeCheck(ISentenceElement sentenceElement, bool isNextCharacterPunctuation)
        {
            switch (sentenceElement)
            {
                case Word word:
                    WordHandler(word, isNextCharacterPunctuation);
                    break;
                case PunctuationMark punctuationMark:
                    PunctuationMarkHandler(punctuationMark);
                    break;
                case PunctuationSymbol punctuationSymbol:
                    PunctuationSymbolHandler(punctuationSymbol);
                    break;
                default:
                    throw new ArgumentException("wrong type of sentence element");
            }
        }

        private void WordHandler(Word word, bool isNextCharacterPunctuation)
        {
            foreach (var wordElement in word.Value)
            {
                _streamWriter.Write(wordElement.Value);
            }

            if (!isNextCharacterPunctuation)
            {
                SetWhiteSpace();
            }
        }

        private void PunctuationMarkHandler(PunctuationMark punctuationMark)
        {
            _streamWriter.Write(punctuationMark.Value);

            if (punctuationMark.Value is not '\n' or '\r')
            {
                SetWhiteSpace();
            }
        }

        private void PunctuationSymbolHandler(PunctuationSymbol punctuationSymbol)
        {
            foreach (var punctuationMark in punctuationSymbol.Value)
            {
                _streamWriter.Write(punctuationMark.Value);
            }

            var punctuationSymbolNewLine = new PunctuationSymbol(new PunctuationMark[]
            {
                new PunctuationMark('\r'),
                new PunctuationMark('\n')
            });

            if (punctuationSymbol.Value.Count() == punctuationSymbolNewLine.Value.Count())
            {
                for (int i = 0; i < punctuationSymbol.Value.Count(); i++)
                {
                    if (punctuationSymbol.Value.ToList()[i].Value != punctuationSymbolNewLine.Value.ToList()[i].Value)
                    {
                        SetWhiteSpace();
                        return;
                    }
                }

                return;
            }

            SetWhiteSpace();
        }

        private void SetWhiteSpace()
        {
            _streamWriter.Write(' ');
        }
    }
}
