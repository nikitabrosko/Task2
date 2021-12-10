using System.Collections.Generic;
using System.Collections.ObjectModel;
using TextHandler.TextObjectModel.NewLines;
using TextHandler.TextObjectModel.Sentences;

namespace TextHandler.TextObjectModel.Texts
{
    public class Text : IText
    {
        private readonly IList<ITextElement> _text = new List<ITextElement>();

        public IEnumerable<ITextElement> Value => new ReadOnlyCollection<ITextElement>(_text);

        public void Append(ITextElement sentence)
        {
            _text.Add(sentence);
        }

        public string GetStringRepresentation()
        {
            var stringRepresentation = string.Empty;

            foreach (var textElement in Value)
            {
                switch (textElement)
                {
                    case ISentence sentence:
                        stringRepresentation += sentence.GetStringRepresentation();
                        break;
                    case INewLine newLine:
                        stringRepresentation += newLine.GetStringRepresentation();
                        break;
                }
            }

            return stringRepresentation;
        }
    }
}
