using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Letters;
using TextHandler.TextObjectModel.NewLines;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.Punctuations.PunctuationSymbols;
using TextHandler.TextObjectModel.Sentences;
using TextHandler.TextObjectModel.Texts;
using TextHandler.TextObjectModel.WhiteSpaces;
using TextHandler.TextObjectModel.Words;

namespace TextHandlerTests.TextObjectModelTests
{
    [TestClass]
    public class TextTests
    {
        [TestMethod]
        public void TestTextClassCreating()
        {
            var sentenceFirst = new Sentence(new ISentenceElement[]
            {
                new Word(new IWordElement[]
                {
                    new Letter('H'),
                    new Letter('e'),
                    new Letter('l'),
                    new Letter('l'),
                    new Letter('o')
                }),
                new PunctuationMark(','),
                new WhiteSpace(' '),
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('l'),
                    new Letter('d')
                }),
                new PunctuationMark('!')
            });
            var sentenceSecond = new Sentence(new ISentenceElement[]
            {
                new Word(new IWordElement[]
                {
                    new Letter('S'),
                    new Letter('e'),
                    new Letter('n'),
                    new Letter('t'),
                    new Letter('e'),
                    new Letter('n'),
                    new Letter('c'),
                    new Letter('e')
                }),
                new WhiteSpace(' '),
                new Word(new IWordElement[]
                {
                    new Letter('h'),
                    new Letter('a'),
                    new Letter('v'),
                    new Letter('e')
                }),
                new WhiteSpace(' '),
                new Word(new IWordElement[]
                {
                    new Letter('f'),
                    new Letter('o'),
                    new Letter('u'),
                    new Letter('r')
                }),
                new WhiteSpace(' '),
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('d'),
                    new Letter('s')
                }),
                new PunctuationSymbol(new IPunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                })
            });

            var textObject = new Text();
            textObject.Append(sentenceFirst);
            textObject.Append(sentenceSecond);

            Assert.IsTrue(sentenceFirst.GetStringRepresentation()
                              .Equals((textObject.Value.First() as ISentence)?.GetStringRepresentation()) 
                          && sentenceSecond.GetStringRepresentation()
                              .Equals((textObject.Value.Last() as ISentence)?.GetStringRepresentation()));
        }

        [TestMethod]
        public void TestTextClassCreatingWithNewLine()
        {
            var sentenceFirst = new Sentence(new ISentenceElement[]
            {
                new Word(new IWordElement[]
                {
                    new Letter('H'),
                    new Letter('e'),
                    new Letter('l'),
                    new Letter('l'),
                    new Letter('o')
                }),
                new PunctuationMark(','),
                new WhiteSpace(' '),
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('l'),
                    new Letter('d')
                }),
                new PunctuationMark('!')
            });
            var newLine = new NewLine('\n');
            var sentenceSecond = new Sentence(new ISentenceElement[]
            {
                new Word(new IWordElement[]
                {
                    new Letter('S'),
                    new Letter('e'),
                    new Letter('n'),
                    new Letter('t'),
                    new Letter('e'),
                    new Letter('n'),
                    new Letter('c'),
                    new Letter('e')
                }),
                new PunctuationSymbol(new IPunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                })
            });

            var textObject = new Text();
            textObject.Append(sentenceFirst);
            textObject.Append(newLine);
            textObject.Append(sentenceSecond);

            Assert.AreEqual(
                string.Concat(sentenceFirst.GetStringRepresentation(), newLine.GetStringRepresentation(),
                    sentenceSecond.GetStringRepresentation()), textObject.GetStringRepresentation());
        }
    }
}