using System;
using System.IO;
using TextHandler.TextObjectModel.NewLines;
using TextHandler.TextObjectModel.Sentences;
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
            try
            {
                WriteNext(text);
            }
            finally
            {
                _textWriter.Dispose();
            }
        }

        private void WriteNext(IText text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            foreach (var textElement in text.Value)
            {
                switch (textElement)
                {
                    case ISentence sentence:
                        _textWriter.Write(sentence.GetStringRepresentation());
                        break;
                    case INewLine newLine:
                        _textWriter.Write(newLine.GetStringRepresentation());
                        break;
                }
            }
        }
    }
}
