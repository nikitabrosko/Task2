﻿using System;

namespace TextHandler.TextObjectModel.Characters.Punctuation
{
    public class PunctuationMark : IWordElement
    {
        public char Value { get; }

        public PunctuationMark(char punctuationMark)
        {
            Value = punctuationMark;

            try
            {
                Verify(this);
            }
            catch
            {
                Value = default;

                throw;
            }
        }

        public static void Verify(PunctuationMark punctuationMark)
        {
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
    }
}
