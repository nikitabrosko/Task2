using System.Collections.Generic;
using System.IO;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandler.Parsers
{
    public class ParserToObjectModel
    {
        private delegate void CharacterCheck(char character);

        private StreamReader _streamReader;
        private readonly IList<IWordElement> _wordBuffer = new List<IWordElement>();
        private readonly IList<ISentenceElement> _sentenceBuffer = new List<ISentenceElement>();
        private Text _text = new Text();

        public Text ReadFile(string path)
        {
            try
            {
                _streamReader = File.OpenText(path);

                ReadNext();

                return _text;
            }
            finally
            {
                _streamReader.Dispose();
                _wordBuffer.Clear();
                _sentenceBuffer.Clear();
                _text = new Text();
            }
        }

        private void CharacterIsLetter(char character)
        {
            _wordBuffer.Add(new Letter(character));
        }

        private void CharacterIsWhiteSpace(char character)
        {
            if (_wordBuffer.Count != 0)
            {
                AddWordToSentenceBufferAndClearWordBuffer();
            }
        }

        private void CharacterIsPunctuation(char character)
        {
            switch (character)
            {
                case '.':
                    CharacterIsDot(character);
                    break;
                case '?':
                    CharacterIsQuestionMark(character);
                    break;
                case '-':
                case '\'':
                    _wordBuffer.Add(new PunctuationMark(character));
                    break;
                case '\n':
                case '\r':
                    CharacterIsNewLine(character);
                    break;
                default:
                    AddWordToSentenceBufferAndClearWordBuffer();
                    _sentenceBuffer.Add(new PunctuationMark(character));
                    break;
            }
        }

        private void CharacterIsDot(char character)
        {
            AddWordToSentenceBufferAndClearWordBuffer();

            char nextCharacter = (char) _streamReader.Peek();

            if (nextCharacter == '.')
            {
                _sentenceBuffer.Add(new PunctuationSymbol(
                    new PunctuationMark[]
                    {
                        new PunctuationMark(character),
                        new PunctuationMark((char)_streamReader.Read()),
                        new PunctuationMark((char)_streamReader.Read())
                    }));
            }
            else
            {
                _sentenceBuffer.Add(new PunctuationMark(character));
            }

            AppendToTextAndClearSentenceBuffer();
        }

        private void CharacterIsQuestionMark(char character)
        {
            AddWordToSentenceBufferAndClearWordBuffer();

            char nextCharacter = (char) _streamReader.Peek();

            if (nextCharacter == '!')
            {
                _sentenceBuffer.Add(new PunctuationSymbol(
                    new PunctuationMark[]
                    {
                        new PunctuationMark(character), 
                        new PunctuationMark((char)_streamReader.Read())
                    }));
            }
            else
            {
                _sentenceBuffer.Add(new PunctuationMark(character));
            }

            AppendToTextAndClearSentenceBuffer();
        }

        private void CharacterIsNewLine(char character)
        {
            char nextCharacter = (char)_streamReader.Peek();

            if (nextCharacter is '\n' or '\r')
            {
                _sentenceBuffer.Add(new PunctuationSymbol(
                    new PunctuationMark[]
                    {
                        new PunctuationMark(character),
                        new PunctuationMark((char)_streamReader.Read())
                    }));
            }
            else
            {
                _sentenceBuffer.Add(new PunctuationMark(character));
            }
        }

        private void ReadNext()
        {
            if (_streamReader.Peek() == -1)
            {
                return;
            }

            char currentCharacter = (char)_streamReader.Read();

            CharacterCheck characterCheck = null;

            if (char.IsLetter(currentCharacter))
            {
                characterCheck = CharacterIsLetter;
            }
            else if (currentCharacter.Equals('\n'))
            {
                characterCheck = CharacterIsPunctuation;
            }
            else if (currentCharacter == ' ')
            {
                characterCheck = CharacterIsWhiteSpace;
            }
            else if (char.IsPunctuation(currentCharacter))
            {
                characterCheck = CharacterIsPunctuation;
            }

            characterCheck?.Invoke(currentCharacter);

            ReadNext();
        }

        private void AddWordToSentenceBufferAndClearWordBuffer()
        {
            _sentenceBuffer.Add(new Word(_wordBuffer));
            _wordBuffer.Clear();
        }

        private void AppendToTextAndClearSentenceBuffer()
        {
            _text.Append(new Sentence(_sentenceBuffer));
            _sentenceBuffer.Clear();
        }
    }
}