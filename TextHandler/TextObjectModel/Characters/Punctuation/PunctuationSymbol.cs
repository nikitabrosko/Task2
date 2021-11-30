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
                Verifier.Verify(this);
            }
            catch
            {
                _punctuationSymbol = default;

                throw;
            }
        }
    }
}