﻿using System;
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
                throw new ArgumentException("letter can not be a digit!", nameof(letter));
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

            var punctuationSymbolFirst = new PunctuationSymbol(new PunctuationMark[]
            {
                new PunctuationMark('?'), 
                new PunctuationMark('!')
            });

            var punctuationSymbolSecond = new PunctuationSymbol(new PunctuationMark[]
            {
                new PunctuationMark('.'),
                new PunctuationMark('.'),
                new PunctuationMark('.')
            });

            if (punctuationSymbol.Value.SequenceEqual(punctuationSymbolFirst.Value) 
                || punctuationSymbol.Value.SequenceEqual(punctuationSymbolSecond.Value))
            {
                throw new ArgumentException("punctuation symbol is wrong", nameof(punctuationSymbol));
            }
        }

        public static void Verify(Word word)
        {
            if (word is null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            var wordList = word.Value.ToList();

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

            var firstSentenceElement = sentence.Value.ToList().First();

            switch (firstSentenceElement)
            {
                case PunctuationMark or PunctuationSymbol:
                    throw new ArgumentException("first element of sentence can not be a punctuation mark or symbol");
                case Word word when char.IsLower(word.Value.ToList()[0].Value):
                    throw new ArgumentException("first element of sentence can not be in lowercase");
            }

            var lastSentenceElement = sentence.Value.ToList().Last();

            if (lastSentenceElement is not PunctuationMark or PunctuationSymbol)
            {
                throw new ArgumentException("last element of sentence should be a punctuation mark or symbol");
            }
        }
    }
}