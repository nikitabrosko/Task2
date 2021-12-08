using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandlerTests.ParsersTests
{
    [TestClass]
    public class ParserFromObjectModelTests
    {
        [TestMethod]
        public void TestWithValidParametersTwoWordsAndTwoPunctuationMarks()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForParserFromObjectModelTestClass.txt";

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

            var parserFromObjectModel = new ParserFromObjectModel();
            parserFromObjectModel.WriteInFile(path, expectedTextObject);

            var parserToObjectModel = new ParserToObjectModel();
            var actualTextObject = parserToObjectModel.ReadFile(path);
            File.Delete(path);

            Assert.IsTrue(CompareTwoTextsForEqual(expectedTextObject, actualTextObject));
        }

        [TestMethod]
        public void TestWithValidParametersThreeWordsAndOnePunctuationSymbol()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForParserFromObjectModelTestClass.txt";

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
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('l'),
                    new Letter('d')
                }),
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('l'),
                    new Letter('d')
                }),
                new PunctuationSymbol(new PunctuationMark[]
                {
                    new PunctuationMark('.'),
                    new PunctuationMark('.'),
                    new PunctuationMark('.')
                })
            });

            var expectedTextObject = new Text();
            expectedTextObject.Append(sentenceFirst);

            var parserFromObjectModel = new ParserFromObjectModel();
            parserFromObjectModel.WriteInFile(path, expectedTextObject);

            var parserToObjectModel = new ParserToObjectModel();
            var actualTextObject = parserToObjectModel.ReadFile(path);
            File.Delete(path);

            Assert.IsTrue(CompareTwoTextsForEqual(expectedTextObject, actualTextObject));
        }

        [TestMethod]
        public void TestWithValidParametersPunctuationSymbolNewLine()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForParserFromObjectModelTestClass.txt";

            var sentenceFirst = new Sentence(new ISentenceElement[]
            {
                new PunctuationSymbol(new PunctuationMark[]
                {
                    new PunctuationMark('\r'),
                    new PunctuationMark('\n')
                }),
                new Word(new IWordElement[]
                {
                    new Letter('H'),
                    new Letter('e'),
                    new Letter('l'),
                    new Letter('l'),
                    new Letter('o')
                }),
                new PunctuationMark(','),
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

            var parserFromObjectModel = new ParserFromObjectModel();
            parserFromObjectModel.WriteInFile(path, expectedTextObject);

            var parserToObjectModel = new ParserToObjectModel();
            var actualTextObject = parserToObjectModel.ReadFile(path);
            File.Delete(path);

            Assert.IsTrue(CompareTwoTextsForEqual(expectedTextObject, actualTextObject));
        }

        [TestMethod]
        public void TestWithValidParametersTwoWordsAndOnePunctuationSymbol()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForParserFromObjectModelTestClass.txt";

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
                new Word(new IWordElement[]
                {
                    new Letter('w'),
                    new Letter('o'),
                    new Letter('r'),
                    new Letter('l'),
                    new Letter('d')
                }),
                new PunctuationSymbol(new PunctuationMark[]
                {
                    new PunctuationMark('?'),
                    new PunctuationMark('!')
                })
            });

            var expectedTextObject = new Text();
            expectedTextObject.Append(sentenceFirst);

            var parserFromObjectModel = new ParserFromObjectModel();
            parserFromObjectModel.WriteInFile(path, expectedTextObject);

            var parserToObjectModel = new ParserToObjectModel();
            var actualTextObject = parserToObjectModel.ReadFile(path);
            File.Delete(path);

            Assert.IsTrue(CompareTwoTextsForEqual(expectedTextObject, actualTextObject));
        }

        [TestMethod]
        public void TestWithInvalidParametersTextIsNull()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForParserFromObjectModelTestClass.txt";
            Text textObject = null;
            var parserFromObjectModel = new ParserFromObjectModel();
            File.Delete(path);

            Assert.ThrowsException<ArgumentNullException>(() => parserFromObjectModel.WriteInFile(path, textObject), nameof(textObject));
        }

        private static bool CompareTwoTextsForEqual(Text firstTextObject, Text secondTextObject)
        {
            var wordsFirstTextObject = firstTextObject.Value
                .Select(s => s.Value
                    .Select(e => e))
                .Aggregate((currentElement, nextElement) => currentElement.Union(nextElement))
                .ToList();

            var wordsSecondTextObject = secondTextObject.Value
                .Select(s => s.Value
                    .Select(e => e))
                .Aggregate((currentElement, nextElement) => currentElement.Union(nextElement))
                .ToList();

            if (wordsFirstTextObject.Count == wordsSecondTextObject.Count)
            {
                return !wordsFirstTextObject
                    .Where((t, i) => 
                        !CheckTwoISentenceElementsForEqual(t, wordsSecondTextObject[i]))
                    .Any();
            }

            return false;
        }

        private static bool CheckTwoISentenceElementsForEqual(ISentenceElement sentenceElementFirst, ISentenceElement sentenceElementSecond)
        {
            switch (sentenceElementFirst)
            {
                case Word wordFirst when sentenceElementSecond is Word wordSecond:
                {
                    var sentenceElementFirstList = wordFirst.Value.ToList();
                    var sentenceElementSecondList = wordSecond.Value.ToList();

                    if (sentenceElementFirstList.Count != sentenceElementSecondList.Count)
                    {
                        return false;
                    }

                    return !sentenceElementFirstList
                        .Where((t, i) => t.Value != sentenceElementSecondList[i].Value)
                        .Any();
                }
                case PunctuationSymbol punctuationSymbolFirst when sentenceElementSecond is PunctuationSymbol punctuationSymbolSecond:
                    var punctuationSymbolFirstList = punctuationSymbolFirst.Value.ToList();
                    var punctuationSymbolSecondList = punctuationSymbolSecond.Value.ToList();

                    if (punctuationSymbolFirstList.Count != punctuationSymbolSecondList.Count)
                    {
                        return false;
                    }

                    return !punctuationSymbolFirstList
                        .Where((t, i) => t.Value != punctuationSymbolSecondList[i].Value)
                        .Any();
                case PunctuationMark punctuationMarkFirst when sentenceElementSecond is PunctuationMark punctuationMarkSecond:
                    return punctuationMarkFirst.Value == punctuationMarkSecond.Value;
                default:
                    return false;
            }
        }
    }
}
