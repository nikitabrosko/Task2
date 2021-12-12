using System;
using System.IO;
using TextHandler.TextObjectModel.Texts;

namespace TextHandler.Parsers
{
    public class ParserFromObjectModel
    {
        private readonly TextWriter _textWriter;

        public ParserFromObjectModel(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void WriteInFile(IText text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            foreach (var textElement in text.Value)
            {
                WriteNext(textElement.GetStringRepresentation());
            }
        }

        private void WriteNext(string textToWrite)
        {
            _textWriter.Write(textToWrite);
        }
    }
}
