using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Letters;
using TextHandler.TextObjectModel.NewLines;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.Punctuations.PunctuationSymbols;
using TextHandler.TextObjectModel.Sentences;
using TextHandler.TextObjectModel.Texts;
using TextHandler.TextObjectModel.WhiteSpaces;
using TextHandler.TextObjectModel.Words;

namespace TextHandlerTests.ParsersTests
{
    [TestClass]
    public class ParserFromObjectModelTests
    {
        [TestMethod]
        public void TestWithValidParametersTwoWordsAndTwoPunctuationMarks()
        {
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForParserFromObjectModelTestClass.txt";

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

            var expectedTextObject = new Text();
            expectedTextObject.Append(sentenceFirst);

            var parserFromObjectModel = new ParserFromObjectModel(new StreamWriter(path));
            parserFromObjectModel.WriteInFile(expectedTextObject);

            var parserToObjectModel = new ParserToObjectModel(new StreamReader(path));
            var actualTextObject = parserToObjectModel.ReadFile();

            Assert.IsTrue(CompareTwoTextsForEqual(expectedTextObject, actualTextObject));
            File.Delete(path);
        }

        [TestMethod]
        public void TestWithValidParametersThreeWordsAndOnePunctuationSymbol()
        {
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForParserFromObjectModelTestClass.txt";

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
                new WhiteSpace(' '),
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('l'),
                    new Letter('d')
                }),
                new PunctuationSymbol(new IPunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                })
            });

            var expectedTextObject = new Text();
            expectedTextObject.Append(sentenceFirst);

            var parserFromObjectModel = new ParserFromObjectModel(new StreamWriter(path));
            parserFromObjectModel.WriteInFile(expectedTextObject);

            var parserToObjectModel = new ParserToObjectModel(new StreamReader(path));
            var actualTextObject = parserToObjectModel.ReadFile();

            Assert.IsTrue(CompareTwoTextsForEqual(expectedTextObject, actualTextObject));
            File.Delete(path);
        }

        [TestMethod]
        public void TestWithValidParametersTwoWordsAndOnePunctuationSymbol()
        {
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForParserFromObjectModelTestClass.txt";

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
                new PunctuationSymbol(new IPunctuationMark[]
                {
                    new PunctuationMark('?'),
                    new PunctuationMark('!')
                })
            });

            var expectedTextObject = new Text();
            expectedTextObject.Append(sentenceFirst);

            var parserFromObjectModel = new ParserFromObjectModel(new StreamWriter(path));
            parserFromObjectModel.WriteInFile(expectedTextObject);

            var parserToObjectModel = new ParserToObjectModel(new StreamReader(path));
            var actualTextObject = parserToObjectModel.ReadFile();

            Assert.IsTrue(CompareTwoTextsForEqual(expectedTextObject, actualTextObject));
            File.Delete(path);
        }

        [TestMethod]
        public void TestWithValidParametersNewLine()
        {
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForParserFromObjectModelTestClass.txt";

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
                new WhiteSpace(' '),
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('l'),
                    new Letter('d')
                }),
                new PunctuationSymbol(new IPunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                })
            });
            var newLine = new NewLine(new char[]
            {
                '\r',
                '\n'
            });
            var sentenceSecond = new Sentence(new ISentenceElement[]
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
                new WhiteSpace(' '),
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('l'),
                    new Letter('d')
                }),
                new PunctuationMark('.')
            });

            var expectedTextObject = new Text();
            expectedTextObject.Append(sentenceFirst);
            expectedTextObject.Append(newLine);
            expectedTextObject.Append(sentenceSecond);

            var parserFromObjectModel = new ParserFromObjectModel(new StreamWriter(path));
            parserFromObjectModel.WriteInFile(expectedTextObject);

            var parserToObjectModel = new ParserToObjectModel(new StreamReader(path));
            var actualTextObject = parserToObjectModel.ReadFile();

            Assert.IsTrue(CompareTwoTextsForEqual(expectedTextObject, actualTextObject));
            File.Delete(path);
        }

        [TestMethod]
        public void TestWithInvalidParametersTextIsNull()
        {
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForParserFromObjectModelTestClass.txt";
            Text textObject = null;
            var parserFromObjectModel = new ParserFromObjectModel(new StreamWriter(path));

            Assert.ThrowsException<ArgumentNullException>(() => parserFromObjectModel.WriteInFile(textObject));
            File.Delete(path);
        }

        private static bool CompareTwoTextsForEqual(IText firstTextObject, IText secondTextObject)
        {
            return firstTextObject.GetStringRepresentation()
                .Equals(secondTextObject.GetStringRepresentation());
        }
    }
}
