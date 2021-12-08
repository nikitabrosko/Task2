using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;
using System.Linq;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandlerTests.ParsersTests
{
    [TestClass]
    public class ParserToObjectModelTests
    {
        [TestMethod]
        public void TestCharacterIsDotMethodWithValidParameters()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            ParserToObjectModel parser = new ParserToObjectModel();
            File.WriteAllText(path, "New file...");
            var expectedPunctuationSymbol = new PunctuationSymbol(new PunctuationMark[]
            {
                new PunctuationMark('.'),
                new PunctuationMark('.'),
                new PunctuationMark('.')
            });

            var textObject = parser.ReadFile(path);
            File.Delete(path);
            var actualPunctuationSymbol = textObject.Value.First().Value.ToList()[2];

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedPunctuationSymbol,
                actualPunctuationSymbol as PunctuationSymbol));
        }

        [TestMethod]
        [DataRow('-')]
        [DataRow('\'')]
        public void TestCharacterIsPunctuationInWordMethodWithValidParameters(char character)
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            ParserToObjectModel parser = new ParserToObjectModel();
            File.WriteAllText(path, $"Ain{character}t.");
            var expectedWord = new Word(new IWordElement[]
            {
                new Letter('A'),
                new Letter('i'),
                new Letter('n'),
                new PunctuationMark(character),
                new Letter('t')
            });

            var textObject = parser.ReadFile(path);
            File.Delete(path);
            var actualWord = textObject.Value.First().Value.First() as Word;

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedWord, actualWord));
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterComma()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            ParserToObjectModel parser = new ParserToObjectModel();
            File.WriteAllText(path, "New, file.");
            var expectedPunctuationMark = new PunctuationMark(',');

            var textObject = parser.ReadFile(path);
            File.Delete(path);
            var actualPunctuationMark = textObject.Value.First().Value.ToList()[1] as PunctuationMark;

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedPunctuationMark, actualPunctuationMark));
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterQuestionMark()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            ParserToObjectModel parser = new ParserToObjectModel();
            File.WriteAllText(path, "New file?");
            var expectedPunctuationMark = new PunctuationMark('?');

            var textObject = parser.ReadFile(path);
            File.Delete(path);
            var actualPunctuationMark = textObject.Value.First().Value.ToList()[2] as PunctuationMark;

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedPunctuationMark, actualPunctuationMark));
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterQuestionMarkAndExclamationMark()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            ParserToObjectModel parser = new ParserToObjectModel();
            File.WriteAllText(path, "New file?!");
            var expectedPunctuationSymbol = new PunctuationSymbol(new PunctuationMark[]
            {
                new PunctuationMark('?'),
                new PunctuationMark('!')
            });

            var textObject = parser.ReadFile(path);
            File.Delete(path);
            var actualPunctuationSymbol = textObject.Value.First().Value.ToList()[2] as PunctuationSymbol;

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedPunctuationSymbol, actualPunctuationSymbol));
        }

        [TestMethod]
        [DataRow('\n')]
        [DataRow('\r')]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterNewLinePunctuationMark(char character)
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            ParserToObjectModel parser = new ParserToObjectModel();
            File.WriteAllText(path, $"{character}New file.");
            var expectedPunctuationMark = new PunctuationMark(character);

            var textObject = parser.ReadFile(path);
            File.Delete(path);
            var actualPunctuationMark = textObject.Value.First().Value.ToList()[0] as PunctuationMark;

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedPunctuationMark, actualPunctuationMark));
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterNewLinePunctuationSymbol()
        {
            char characterFirst = '\r';
            char characterSecond = '\n';
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            ParserToObjectModel parser = new ParserToObjectModel();
            File.WriteAllText(path, $"{characterFirst}{characterSecond}New file.");
            var expectedPunctuationSymbol = new PunctuationSymbol(new PunctuationMark[]
            {
                new PunctuationMark(characterFirst),
                new PunctuationMark(characterSecond)
            });

            var textObject = parser.ReadFile(path);
            File.Delete(path);
            var actualPunctuationSymbol = textObject.Value.First().Value.ToList()[0] as PunctuationSymbol;

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedPunctuationSymbol, actualPunctuationSymbol));
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

                    return !sentenceElementFirstList.Where((t, i) => t.Value != sentenceElementSecondList[i].Value).Any();
                }
                case PunctuationSymbol punctuationSymbolFirst when sentenceElementSecond is PunctuationSymbol punctuationSymbolSecond:
                    var punctuationSymbolFirstList = punctuationSymbolFirst.Value.ToList();
                    var punctuationSymbolSecondList = punctuationSymbolSecond.Value.ToList();

                    if (punctuationSymbolFirstList.Count != punctuationSymbolSecondList.Count)
                    {
                        return false;
                    }

                    return !punctuationSymbolFirstList.Where((t, i) => t.Value != punctuationSymbolSecondList[i].Value).Any();
                case PunctuationMark punctuationMarkFirst when sentenceElementSecond is PunctuationMark punctuationMarkSecond:
                    return punctuationMarkFirst.Value == punctuationMarkSecond.Value;
                default:
                    return false;
            }
        }
    }
}
