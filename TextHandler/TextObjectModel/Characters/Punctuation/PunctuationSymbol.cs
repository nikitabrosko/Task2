using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TextHandler.TextObjectModel.Characters.Punctuation
{
    public class PunctuationSymbol : ISentenceElement
    {
        private readonly IList<PunctuationMark> _punctuationSymbol;

        public IEnumerable<PunctuationMark> Value => new ReadOnlyCollection<PunctuationMark>(_punctuationSymbol);

        public PunctuationSymbol(IEnumerable<PunctuationMark> punctuationMarks)
        {
            _punctuationSymbol = punctuationMarks.ToList();

            try
            {
                Verify(this);
            }
            catch
            {
                _punctuationSymbol = default;

                throw;
            }
        }

        public static void Verify(PunctuationSymbol punctuationSymbol)
        {
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

                switch (punctuationSymbolList.Count)
                {
                    case 2:
                    {
                        if (punctuationSymbolList.Where((t, i) => !t.Value.Equals(punctuationMarksFirst[i].Value)).Any())
                        {
                            return false;
                        }

                        break;
                    }
                    case 3:
                    {
                        if (punctuationSymbolList.Where((t, i) => !t.Value.Equals(punctuationMarksSecond[i].Value)).Any())
                        {
                            return false;
                        }

                        break;
                    }
                    default:
                        throw new ArgumentException("punctuation symbol length can not be more than 3 and less than 2", nameof(punctuationSymbol));
                }

                return true;
            }
        }
    }
}