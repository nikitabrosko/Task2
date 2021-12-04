using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandler.Parsers
{
    public class Parser
    {
        private delegate void Action(char character);

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

             Action action;

             if (char.IsLetter(currentCharacter))
             {
                 action = CharacterIsLetter;
             }
             else if (char.IsWhiteSpace(currentCharacter))
             {
                 action = CharacterIsWhiteSpace;
             }
             else if (currentCharacter == '.')
             {
                 action = CharacterIsDot;
             }
             else if (currentCharacter == '?')
             {
                 action = CharacterIsQuestionMark;
             }
             else if (char.IsPunctuation(currentCharacter))
             {
                 action = CharacterIsOtherPunctuation;
             }
             else
             {
                 action = EndOfFile;
             }

             action.Invoke(currentCharacter);
        }
    }
}
