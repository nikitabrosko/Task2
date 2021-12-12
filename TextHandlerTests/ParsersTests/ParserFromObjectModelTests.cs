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
            string path = @"F:\GitHub\Task2\TextHandler\TextHandlerTests\FilesForTestsRepository\FileForParserFromObjectModelTestClass.txt";

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

            using (var streamWriter = new StreamWriter(path))
            {
                var parserFromObjectModel = new ParserFromObjectModel(streamWriter);
                parserFromObjectModel.WriteInFile(expectedTextObject);
            }

            IText actualTextObject;

            using (var streamReader = new StreamReader(path))
            {
                var parserToObjectModel = new ParserToObjectModel(streamReader);
                actualTextObject = parserToObjectModel.ReadFile();
            }

            Assert.IsTrue(CompareTwoTextsForEqual(expectedTextObject, actualTextObject));
            File.Delete(path);
        }

        [TestMethod]
        public void TestWithValidParametersThreeWordsAndOnePunctuationSymbol()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandlerTests\FilesForTestsRepository\FileForParserFromObjectModelTestClass.txt";

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

            using (var streamWriter = new StreamWriter(path))
            {
                var parserFromObjectModel = new ParserFromObjectModel(streamWriter);
                parserFromObjectModel.WriteInFile(expectedTextObject);
            }

            IText actualTextObject;

            using (var streamReader = new StreamReader(path))
            {
                var parserToObjectModel = new ParserToObjectModel(streamReader);
                actualTextObject = parserToObjectModel.ReadFile();
            }

            Assert.IsTrue(CompareTwoTextsForEqual(expectedTextObject, actualTextObject));
            File.Delete(path);
        }

        [TestMethod]
        public void TestWithValidParametersTwoWordsAndOnePunctuationSymbol()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandlerTests\FilesForTestsRepository\FileForParserFromObjectModelTestClass.txt";

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

            using (var streamWriter = new StreamWriter(path))
            {
                var parserFromObjectModel = new ParserFromObjectModel(streamWriter);
                parserFromObjectModel.WriteInFile(expectedTextObject);
            }

            IText actualTextObject;

            using (var streamReader = new StreamReader(path))
            {
                var parserToObjectModel = new ParserToObjectModel(streamReader);
                actualTextObject = parserToObjectModel.ReadFile();
            }

            Assert.IsTrue(CompareTwoTextsForEqual(expectedTextObject, actualTextObject));
            File.Delete(path);
        }

        [TestMethod]
        public void TestWithValidParametersNewLine()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandlerTests\FilesForTestsRepository\FileForParserFromObjectModelTestClass.txt";

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

            using (var streamWriter = new StreamWriter(path))
            {
                var parserFromObjectModel = new ParserFromObjectModel(streamWriter);
                parserFromObjectModel.WriteInFile(expectedTextObject);
            }

            IText actualTextObject;

            using (var streamReader = new StreamReader(path))
            {
                var parserToObjectModel = new ParserToObjectModel(streamReader);
                actualTextObject = parserToObjectModel.ReadFile();
            }

            Assert.IsTrue(CompareTwoTextsForEqual(expectedTextObject, actualTextObject));
            File.Delete(path);
        }

        [TestMethod]
        public void TestWithInvalidParametersTextIsNull()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandlerTests\FilesForTestsRepository\FileForParserFromObjectModelTestClass.txt";
            Text textObject = null;

            using (var streamWriter = new StreamWriter(path))
            {
                var parserFromObjectModel = new ParserFromObjectModel(streamWriter);

                Assert.ThrowsException<ArgumentNullException>(() => parserFromObjectModel.WriteInFile(textObject));
            }

            File.Delete(path);
        }

        private static bool CompareTwoTextsForEqual(IText firstTextObject, IText secondTextObject)
        {
            return firstTextObject.GetStringRepresentation()
                .Equals(secondTextObject.GetStringRepresentation());
        }
    }
}
