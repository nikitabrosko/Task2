using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandler.TextObjectModel
{
    public interface IWordElement : ISentenceElement
    {
        char Value { get; }
    }
}
