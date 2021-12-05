﻿using System.Collections.Generic;
using System.IO;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandler.Parsers
{
    public class Parser
    {
        private delegate void CharacterCheck(char character);

        private StreamReader _streamReader;
        private readonly IList<Letter> _wordBuffer = new List<Letter>();
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
                    _wordBuffer.Add(new Letter(character));
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

            _text.Append(new Sentence(_sentenceBuffer));
            _sentenceBuffer.Clear();
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
            
            _text.Append(new Sentence(_sentenceBuffer));
            _sentenceBuffer.Clear();
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
            else if (char.IsWhiteSpace(currentCharacter))
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
    }
}