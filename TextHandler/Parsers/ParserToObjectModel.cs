using System.Collections.Generic;
using System.IO;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Letters;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.Punctuations.PunctuationSymbols;
using TextHandler.TextObjectModel.Sentences;
using TextHandler.TextObjectModel.SpellingMarks;
using TextHandler.TextObjectModel.Texts;
using TextHandler.TextObjectModel.Words;

namespace TextHandler.Parsers
{
    public class ParserToObjectModel
    {
        private delegate void CharacterCheck(char character);

        private readonly TextReader _streamReader;
        private readonly IList<IWordElement> _wordBuffer = new List<IWordElement>();
        private readonly IList<ISentenceElement> _sentenceBuffer = new List<ISentenceElement>();
        private IText _text = new Text();

        public ParserToObjectModel(TextReader textReader)
        {
            _streamReader = textReader;
        }

        public IText ReadFile()
        {
            try
            {
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

        private void CharacterIsPunctuationOrSpelling(char character)
        {
            switch (character)
            {
                case '.':
                    CharacterIsDot(character);
                    break;
                case '?':
                    CharacterIsQuestionMark(character);
                    break;
                case '!':
                    AddWordToSentenceBufferAndClearWordBuffer();
                    _sentenceBuffer.Add(new PunctuationMark(character));
                    AppendToTextAndClearSentenceBuffer();
                    break;
                case '-':
                case '\'':
                    _wordBuffer.Add(new SpellingMark(character));
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
                    new IPunctuationMark[]
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
                    new IPunctuationMark[]
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

            if (nextCharacter is '\n')
            {
                _sentenceBuffer.Add(new PunctuationSymbol(
                    new IPunctuationMark[]
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
            else if (currentCharacter is '\n' or '\r')
            {
                characterCheck = CharacterIsPunctuationOrSpelling;
            }
            else if (currentCharacter == ' ')
            {
                characterCheck = CharacterIsWhiteSpace;
            }
            else if (char.IsPunctuation(currentCharacter))
            {
                characterCheck = CharacterIsPunctuationOrSpelling;
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