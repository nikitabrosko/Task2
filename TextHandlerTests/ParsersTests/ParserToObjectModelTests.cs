using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;
using System.Linq;
using TextHandler.TextObjectModel.Letters;
using TextHandler.TextObjectModel.NewLines;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.Punctuations.PunctuationSymbols;
using TextHandler.TextObjectModel.Sentences;
using TextHandler.TextObjectModel.SpellingMarks;
using TextHandler.TextObjectModel.Texts;
using TextHandler.TextObjectModel.WhiteSpaces;
using TextHandler.TextObjectModel.Words;

namespace TextHandlerTests.ParsersTests
{
    [TestClass]
    public class ParserToObjectModelTests
    {
        [TestMethod]
        public void TestCharacterIsDotMethodWithValidParameters()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandlerTests\FilesForTestsRepository\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, "New file...");

            IText textObject;

            using (var streamReader = new StreamReader(path))
            {
                var parser = new ParserToObjectModel(streamReader);
                textObject = parser.ReadFile();
            }
            
            File.Delete(path);

            var expectedPunctuationSymbol = new PunctuationSymbol(new IPunctuationMark[]
            {
                new PunctuationMark('.'),
                new PunctuationMark('.'),
                new PunctuationMark('.')
            });

            var actualPunctuationSymbol = (textObject.Value.First() as ISentence)?.Value.ToList()
                .Find(el => el is IPunctuationSymbol) as IPunctuationSymbol;

            Assert.AreEqual(expectedPunctuationSymbol.GetStringRepresentation(),
                actualPunctuationSymbol.GetStringRepresentation());
        }

        [TestMethod]
        [DataRow('-')]
        [DataRow('\'')]
        public void TestCharacterIsPunctuationInWordMethodWithValidParameters(char character)
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandlerTests\FilesForTestsRepository\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, $"Ain{character}t.");

            IText textObject;

            using (var streamReader = new StreamReader(path))
            {
                var parser = new ParserToObjectModel(streamReader);
                textObject = parser.ReadFile();
            }

            File.Delete(path);

            var expectedWord = new Word(new IWordElement[]
            {
                new Letter('A'),
                new Letter('i'),
                new Letter('n'),
                new SpellingMark(character),
                new Letter('t')
            });

            var actualWord = (textObject.Value.First() as ISentence)?.Value.First() as IWord;

            Assert.AreEqual(expectedWord.GetStringRepresentation(),
                actualWord.GetStringRepresentation());
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterComma()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandlerTests\FilesForTestsRepository\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, "New, file.");

            IText textObject;

            using (var streamReader = new StreamReader(path))
            {
                var parser = new ParserToObjectModel(streamReader);
                textObject = parser.ReadFile();
            }

            File.Delete(path);
            var expectedPunctuationMark = new PunctuationMark(',');
            var actualPunctuationMark = (textObject.Value.First() as ISentence)?.Value.ToList()[1] as IPunctuationMark;

            Assert.AreEqual(expectedPunctuationMark.GetStringRepresentation(),
                actualPunctuationMark.GetStringRepresentation());
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterQuestionMark()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandlerTests\FilesForTestsRepository\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, "New file?");

            IText textObject;

            using (var streamReader = new StreamReader(path))
            {
                var parser = new ParserToObjectModel(streamReader);
                textObject = parser.ReadFile();
            }

            File.Delete(path);
            var expectedPunctuationMark = new PunctuationMark('?');
            var actualPunctuationMark = (textObject.Value.First() as ISentence)?.Value.ToList()
                .Find(el => el is IPunctuationMark) as IPunctuationMark;

            Assert.AreEqual(expectedPunctuationMark.GetStringRepresentation(),
                actualPunctuationMark.GetStringRepresentation());
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterQuestionMarkAndExclamationMark()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandlerTests\FilesForTestsRepository\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, "New file?!");

            IText textObject;

            using (var streamReader = new StreamReader(path))
            {
                var parser = new ParserToObjectModel(streamReader);
                textObject = parser.ReadFile();
            }

            File.Delete(path);

            var expectedPunctuationSymbol = new PunctuationSymbol(new IPunctuationMark[]
            {
                new PunctuationMark('?'),
                new PunctuationMark('!')
            });

            var actualPunctuationSymbol = (textObject.Value.First() as ISentence)?.Value.ToList()
                .Find(el => el is IPunctuationSymbol) as IPunctuationSymbol;

            Assert.AreEqual(expectedPunctuationSymbol.GetStringRepresentation(), 
                actualPunctuationSymbol.GetStringRepresentation());
        }

        [TestMethod]
        [DataRow('\n')]
        [DataRow('\r')]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterNewLine(char character)
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandlerTests\FilesForTestsRepository\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, $"{character}New file.");

            IText textObject;

            using (var streamReader = new StreamReader(path))
            {
                var parser = new ParserToObjectModel(streamReader);
                textObject = parser.ReadFile();
            }

            File.Delete(path);
            var expectedNewLineObject = new NewLine(character);
            var actualNewLineObject = textObject.Value.First() as INewLine;

            Assert.AreEqual(expectedNewLineObject.GetStringRepresentation(), actualNewLineObject?.GetStringRepresentation());
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterWhiteSpace()
        {
            var character = ' ';
            string path = @"F:\GitHub\Task2\TextHandler\TextHandlerTests\FilesForTestsRepository\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, $"New{character}file.");

            IText textObject;

            using (var streamReader = new StreamReader(path))
            {
                var parser = new ParserToObjectModel(streamReader);
                textObject = parser.ReadFile();
            }

            File.Delete(path);
            var expectedWhiteSpaceObject = new WhiteSpace(character);
            var actualWhiteSpaceObject = (textObject.Value.First() as ISentence).Value.ToList()
                .Find(se => se is IWhiteSpace) as IWhiteSpace;

            Assert.AreEqual(expectedWhiteSpaceObject.GetStringRepresentation(),
                actualWhiteSpaceObject.GetStringRepresentation());
        }
    }
}
