using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;

namespace TextHandler.TextObjectModel.Punctuations.PunctuationSymbols
{
    public class PunctuationSymbol : IPunctuationSymbol
    {
        private readonly IList<IPunctuationMark> _punctuationSymbol;

        public IEnumerable<IPunctuationMark> Value => new ReadOnlyCollection<IPunctuationMark>(_punctuationSymbol);

        public PunctuationSymbol(IEnumerable<IPunctuationMark> punctuationMarks)
        {
            _punctuationSymbol = punctuationMarks.ToList();

            try
            {
                Verify();
            }
            catch
            {
                _punctuationSymbol = default;

                throw;
            }
        }

        public string GetStringRepresentation()
        {
            return Value.Aggregate(string.Empty, (current, punctuationMark) => current + punctuationMark.GetStringRepresentation());
        }

        private void Verify()
        {
            if (!CheckForPunctuationSymbol())
            {
                throw new ArgumentException("punctuation symbol is wrong");
            }

            bool CheckForPunctuationSymbol()
            {
                var punctuationMarksFirst = new IPunctuationMark[]
                {
                    new PunctuationMark('?'),
                    new PunctuationMark('!')
                };

                var punctuationMarksSecond = new IPunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                };

                var punctuationSymbolThird = new IPunctuationMark[]
                {
                    new PunctuationMark('\r'),
                    new PunctuationMark('\n')
                };

                var punctuationSymbolList = Value.ToList();

                switch (punctuationSymbolList.Count)
                {
                    case 2:
                    {
                        if (punctuationSymbolList.Where((t, i) => !t.Value.Equals(punctuationSymbolThird[i].Value)).Any())
                        {
                            if (punctuationSymbolList.Where((t, i) => !t.Value.Equals(punctuationMarksFirst[i].Value)).Any())
                            {
                                return false;
                            }
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
                        throw new ArgumentException("punctuation symbol length can not be more than 3 and less than 2");
                }

                return true;
            }
        }
    }
}