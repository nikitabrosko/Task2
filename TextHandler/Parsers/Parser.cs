using System.Collections.Generic;
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
        private readonly IList<PunctuationMark> _punctuationSymbolBuffer = new List<PunctuationMark>();
        private readonly IList<Letter> _wordBuffer = new List<Letter>();
        private readonly IList<ISentenceElement> _sentenceBuffer = new List<ISentenceElement>();
        private readonly Text _text = new Text();

        public Text ReadFile(string path)
        {
            _streamReader = File.OpenText(path);

            ReadNext();

            return _text;
        }

        private void CharacterIsLetter(char character)
        {
            _wordBuffer.Add(new Letter(character));

            ReadNext();
        }

        private void CharacterIsWhiteSpace(char character)
        {
            if (_wordBuffer.Count != 0)
            {
                _sentenceBuffer.Add(new Word(_wordBuffer));
                _wordBuffer.Clear();
            }

            ReadNext();
        }

        private void CharacterIsOtherPunctuation(char character)
        {
            _sentenceBuffer.Add(new Word(_wordBuffer));
            _sentenceBuffer.Add(new PunctuationMark(character));
            _wordBuffer.Clear();

            ReadNext();
        }

        private void CharacterIsDot(char character)
        {
            _sentenceBuffer.Add(new Word(_wordBuffer));
            _wordBuffer.Clear();

            char nextCharacter = (char) _streamReader.Peek();

            if (nextCharacter == '.')
            {
                _punctuationSymbolBuffer.Add(new PunctuationMark(character));
                _punctuationSymbolBuffer.Add(new PunctuationMark((char) _streamReader.Read()));
                _punctuationSymbolBuffer.Add(new PunctuationMark((char) _streamReader.Read()));
                _sentenceBuffer.Add(new PunctuationSymbol(_punctuationSymbolBuffer));
                _punctuationSymbolBuffer.Clear();
            }
            else
            {
                _sentenceBuffer.Add(new PunctuationMark(character));
            }

            _text.Append(new Sentence(_sentenceBuffer));
            _sentenceBuffer.Clear();

            ReadNext();
        }

        private void CharacterIsQuestionMark(char character)
        {
            _sentenceBuffer.Add(new Word(_wordBuffer));
            _wordBuffer.Clear();

            char nextCharacter = (char) _streamReader.Peek();

            if (nextCharacter == '!')
            {
                _punctuationSymbolBuffer.Add(new PunctuationMark(character));
                _punctuationSymbolBuffer.Add(new PunctuationMark((char) _streamReader.Read()));
                _sentenceBuffer.Add(new PunctuationSymbol(_punctuationSymbolBuffer));
                _punctuationSymbolBuffer.Clear();
            }
            else
            {
                _sentenceBuffer.Add(new PunctuationMark(character));
            }
            
            _text.Append(new Sentence(_sentenceBuffer));
            _sentenceBuffer.Clear();

            ReadNext();
        }

        private void EndOfFile(char character)
        {
            _streamReader.Dispose();
        }

        private void ReadNext()
        {
             char currentCharacter = (char)_streamReader.Read();

             CharacterCheck characterCheck;

             if (char.IsLetter(currentCharacter))
             {
                 characterCheck = CharacterIsLetter;
             }
             else if (char.IsWhiteSpace(currentCharacter))
             {
                 characterCheck = CharacterIsWhiteSpace;
             }
             else if (currentCharacter == '.')
             {
                 characterCheck = CharacterIsDot;
             }
             else if (currentCharacter == '?')
             {
                 characterCheck = CharacterIsQuestionMark;
             }
             else if (char.IsPunctuation(currentCharacter))
             {
                 characterCheck = CharacterIsOtherPunctuation;
             }
             else
             {
                 characterCheck = EndOfFile;
             }

             characterCheck.Invoke(currentCharacter);
        }
    }
}
