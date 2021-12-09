using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.TextObjectModel;

namespace TextHandler.Concordance
{
    public class WordEqualityComparer : IEqualityComparer<Word>
    {
        public bool Equals(Word x, Word y)
        {
            var sentenceElementFirstList = x.Value.ToList();
            var sentenceElementSecondList = y.Value.ToList();

            if (sentenceElementFirstList.Count != sentenceElementSecondList.Count)
            {
                return false;
            }

            return !sentenceElementFirstList.Where((t, i) => t.Value != sentenceElementSecondList[i].Value).Any();
        }

        public int GetHashCode(Word obj)
        {
            return obj.GetHashCode();
        }
    }
}
