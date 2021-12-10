using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;
using System.Linq;
using TextHandler.TextObjectModel.Letters;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.Punctuations.PunctuationSymbols;
using TextHandler.TextObjectModel.SpellingMarks;
using TextHandler.TextObjectModel.Words;

namespace TextHandlerTests.ParsersTests
{
    [TestClass]
    public class ParserToObjectModelTests
    {
        [TestMethod]
        public void TestCharacterIsDotMethodWithValidParameters()
        {
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, "New file...");
            var parser = new ParserToObjectModel(new StreamReader(path));
            var expectedPunctuationSymbol = new PunctuationSymbol(new IPunctuationMark[]
            {
                new PunctuationMark('.'),
                new PunctuationMark('.'),
                new PunctuationMark('.')
            });

            var textObject = parser.ReadFile();
            File.Delete(path);
            var actualPunctuationSymbol = textObject.Value.First().Value.ToList()[2];

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedPunctuationSymbol,
                actualPunctuationSymbol as IPunctuationSymbol));
        }

        [TestMethod]
        [DataRow('-')]
        [DataRow('\'')]
        public void TestCharacterIsPunctuationInWordMethodWithValidParameters(char character)
        {
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, $"Ain{character}t.");
            var parser = new ParserToObjectModel(new StreamReader(path));
            var expectedWord = new Word(new IWordElement[]
            {
                new Letter('A'),
                new Letter('i'),
                new Letter('n'),
                new SpellingMark(character),
                new Letter('t')
            });

            var textObject = parser.ReadFile();
            File.Delete(path);
            var actualWord = textObject.Value.First().Value.First() as IWord;

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedWord, actualWord));
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterComma()
        {
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, "New, file.");
            var parser = new ParserToObjectModel(new StreamReader(path));
            var expectedPunctuationMark = new PunctuationMark(',');

            var textObject = parser.ReadFile();
            File.Delete(path);
            var actualPunctuationMark = textObject.Value.First().Value.ToList()[1] as IPunctuationMark;

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedPunctuationMark, actualPunctuationMark));
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterQuestionMark()
        {
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, "New file?");
            var parser = new ParserToObjectModel(new StreamReader(path));
            var expectedPunctuationMark = new PunctuationMark('?');

            var textObject = parser.ReadFile();
            File.Delete(path);
            var actualPunctuationMark = textObject.Value.First().Value.ToList()[2] as IPunctuationMark;

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedPunctuationMark, actualPunctuationMark));
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterQuestionMarkAndExclamationMark()
        {
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, "New file?!");
            var parser = new ParserToObjectModel(new StreamReader(path));
            var expectedPunctuationSymbol = new PunctuationSymbol(new IPunctuationMark[]
            {
                new PunctuationMark('?'),
                new PunctuationMark('!')
            });

            var textObject = parser.ReadFile();
            File.Delete(path);
            var actualPunctuationSymbol = textObject.Value.First().Value.ToList()[2] as IPunctuationSymbol;

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedPunctuationSymbol, actualPunctuationSymbol));
        }

        [TestMethod]
        [DataRow('\n')]
        [DataRow('\r')]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterNewLinePunctuationMark(char character)
        {
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, $"{character}New file.");
            var parser = new ParserToObjectModel(new StreamReader(path));
            var expectedPunctuationMark = new PunctuationMark(character);

            var textObject = parser.ReadFile();
            File.Delete(path);
            var actualPunctuationMark = textObject.Value.First().Value.ToList()[0] as IPunctuationMark;

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedPunctuationMark, actualPunctuationMark));
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterNewLinePunctuationSymbol()
        {
            var characterFirst = '\r';
            var characterSecond = '\n';
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, $"{characterFirst}{characterSecond}New file.");
            var parser = new ParserToObjectModel(new StreamReader(path));
            var expectedPunctuationSymbol = new PunctuationSymbol(new IPunctuationMark[]
            {
                new PunctuationMark(characterFirst),
                new PunctuationMark(characterSecond)
            });

            var textObject = parser.ReadFile();
            File.Delete(path);
            var actualPunctuationSymbol = textObject.Value.First().Value.ToList()[0] as IPunctuationSymbol;

            Assert.IsTrue(CheckTwoISentenceElementsForEqual(expectedPunctuationSymbol, actualPunctuationSymbol));
        }

        private static bool CheckTwoISentenceElementsForEqual(ISentenceElement sentenceElementFirst, ISentenceElement sentenceElementSecond)
        {
            switch (sentenceElementFirst)
            {
                case IWord wordFirst 
                    when sentenceElementSecond is IWord wordSecond:
                {
                    return wordFirst.GetStringRepresentation()
                        .Equals(wordSecond.GetStringRepresentation());
                }
                case IPunctuationSymbol punctuationSymbolFirst 
                    when sentenceElementSecond is IPunctuationSymbol punctuationSymbolSecond:
                {
                    return punctuationSymbolFirst.GetStringRepresentation()
                        .Equals(punctuationSymbolSecond.GetStringRepresentation());
                }
                case IPunctuationMark punctuationMarkFirst
                    when sentenceElementSecond is IPunctuationMark punctuationMarkSecond:
                {
                    return punctuationMarkFirst.GetStringRepresentation()
                        .Equals(punctuationMarkSecond.GetStringRepresentation());
                }
                default:
                    return false;
            }
        }
    }
}
