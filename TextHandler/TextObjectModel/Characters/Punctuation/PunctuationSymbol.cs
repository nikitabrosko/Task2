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
            if (punctuationSymbol is null)
            {
                throw new ArgumentNullException(nameof(punctuationSymbol));
            }

            if (punctuationSymbol.Value is null)
            {
                throw new ArgumentNullException(nameof(punctuationSymbol));
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

                switch (punctuationSymbolList.Count)
                {
                    case 1:
                        return false;
                    case 2:
                    {
                        for (int i = 0; i < punctuationSymbolList.Count; i++)
                        {
                            if (!punctuationSymbolList[i].Value.Equals(punctuationMarksFirst[i].Value))
                            {
                                return false;
                            }
                        }

                        break;
                    }
                    case 3:
                    {
                        for (int i = 0; i < punctuationSymbolList.Count; i++)
                        {
                            if (!punctuationSymbolList[i].Value.Equals(punctuationMarksSecond[i].Value))
                            {
                                return false;
                            }
                        }

                        break;
                    }
                }

                return true;
            }
        }
    }
}