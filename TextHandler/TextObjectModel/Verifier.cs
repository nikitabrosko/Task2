using System;
using System.Linq;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandler.TextObjectModel
{
    public static class Verifier
    {
        public static void Verify(Letter letter)
        {
            if (letter is null)
            {
                throw new ArgumentNullException(nameof(letter));
            }

            if (char.IsDigit(letter.Value))
            {
                throw new ArgumentException("letter can not be a digit", nameof(letter));
            }

            if (char.IsWhiteSpace(letter.Value))
            {
                throw new ArgumentException("letter can not be a whitespace", nameof(letter));
            }

            if (char.IsPunctuation(letter.Value))
            {
                throw new ArgumentException("letter can not be a punctuation", nameof(letter));
            }
        }

        public static void Verify(PunctuationMark punctuationMark)
        {
            if (punctuationMark is null)
            {
                throw new ArgumentNullException(nameof(punctuationMark));
            }

            if (char.IsDigit(punctuationMark.Value))
            {
                throw new ArgumentException("punctuation mark can not be a digit!", nameof(punctuationMark));
            }

            if (char.IsWhiteSpace(punctuationMark.Value))
            {
                throw new ArgumentException("punctuation mark can not be a whitespace", nameof(punctuationMark));
            }

            if (char.IsLetter(punctuationMark.Value))
            {
                throw new ArgumentException("punctuation mark can not be a letter", nameof(punctuationMark));
            }
        }

        public static void Verify(PunctuationSymbol punctuationSymbol)
        {
            if (punctuationSymbol is null)
            {
                throw new ArgumentNullException(nameof(punctuationSymbol));
            }

            if (punctuationSymbol.Value is null)
            {
                throw new ArgumentNullException(nameof(punctuationSymbol.Value));
            }

            if (!CheckForPunctuationSymbol())
            {
                throw new ArgumentException("punctuation symbol is wrong", nameof(punctuationSymbol));
            }

            bool CheckForPunctuationSymbol()
            {
                var punctuationMarksFirst = new PunctuationMark[]
                {
                    new PunctuationMark('?'),
                    new PunctuationMark('!')
                };

                var punctuationMarksSecond = new PunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                };

                var punctuationSymbolList = punctuationSymbol.Value.ToList();

                if (punctuationSymbolList.Count == 2)
                {
                    for (int i = 0; i < punctuationSymbolList.Count; i++)
                    {
                        if (!punctuationSymbolList[i].Value.Equals(punctuationMarksSecond[i].Value))
                        {
                            return false;
                        }
                    }
                }
                else if (punctuationSymbolList.Count == 3)
                {
                    for (int i = 0; i < punctuationSymbolList.Count; i++)
                    {
                        if (!punctuationSymbolList[i].Value.Equals(punctuationMarksSecond[i].Value))
                        {
                            return false;
                        }
                    }
                }

                return true;
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
                throw new ArgumentNullException(nameof(word.Value));
            }

            var wordList = word.Value.ToList();

            if (wordList.Count == 0)
            {
                throw new ArgumentException("letters count can not be 0", nameof(word));
            }

            for (int index = 1; index < wordList.Count; index++)
            {
                if (char.IsUpper(wordList[index].Value))
                {
                    throw new ArgumentException($"letter in index {index} in uppercase", nameof(word));
                }
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
                throw new ArgumentNullException(nameof(sentence.Value));
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