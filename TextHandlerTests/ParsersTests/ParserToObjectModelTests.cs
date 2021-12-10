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
using TextHandler.TextObjectModel.Tabulations;
using TextHandler.TextObjectModel.WhiteSpaces;
using TextHandler.TextObjectModel.Words;

namespace TextHandlerTests.ParsersTests
{
    [TestClass]
    public class ParserToObjectModelTests
    {
        [TestMethod]
        public void Debug()
        {
            var pathFrom = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\file1.txt";
            var pathTo = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\file2.txt";
            var parserToObjectModel = new ParserToObjectModel(new StreamReader(pathFrom));
            var textObject = parserToObjectModel.ReadFile();

            var parserFromObjectModel = new ParserFromObjectModel(new StreamWriter(pathTo));
            parserFromObjectModel.WriteInFile(textObject);

            string str = "1";
        }

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
            var actualWord = (textObject.Value.First() as ISentence)?.Value.First() as IWord;

            Assert.AreEqual(expectedWord.GetStringRepresentation(),
                actualWord.GetStringRepresentation());
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
            var actualPunctuationMark = (textObject.Value.First() as ISentence)?.Value.ToList()[1] as IPunctuationMark;

            Assert.AreEqual(expectedPunctuationMark.GetStringRepresentation(),
                actualPunctuationMark.GetStringRepresentation());
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
            var actualPunctuationMark = (textObject.Value.First() as ISentence)?.Value.ToList()
                .Find(el => el is IPunctuationMark) as IPunctuationMark;

            Assert.AreEqual(expectedPunctuationMark.GetStringRepresentation(),
                actualPunctuationMark.GetStringRepresentation());
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
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, $"{character}New file.");
            var parser = new ParserToObjectModel(new StreamReader(path));
            var expectedNewLineObject = new NewLine(character);

            var textObject = parser.ReadFile();
            File.Delete(path);
            var actualNewLineObject = textObject.Value.First() as INewLine;

            Assert.AreEqual(expectedNewLineObject.GetStringRepresentation(), actualNewLineObject?.GetStringRepresentation());
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterTabulation()
        {
            var character = '\t';
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, $"{character}New file.");
            var parser = new ParserToObjectModel(new StreamReader(path));
            var expectedTabulationObject = new Tabulation(character);

            var textObject = parser.ReadFile();
            File.Delete(path);
            var actualTabulationObject = (textObject.Value.First() as ISentence).Value.First() as ITabulation;

            Assert.AreEqual(expectedTabulationObject.GetStringRepresentation(),
                actualTabulationObject.GetStringRepresentation());
        }

        [TestMethod]
        public void TestCharacterIsPunctuationMethodWithValidParametersParameterWhiteSpace()
        {
            var character = ' ';
            var path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\FileForTestingParserIsDotTest.txt";
            File.WriteAllText(path, $"New{character}file.");
            var parser = new ParserToObjectModel(new StreamReader(path));
            var expectedWhiteSpaceObject = new WhiteSpace(character);

            var textObject = parser.ReadFile();
            File.Delete(path);
            var actualWhiteSpaceObject = (textObject.Value.First() as ISentence).Value.ToList()
                .Find(se => se is IWhiteSpace) as IWhiteSpace;

            Assert.AreEqual(expectedWhiteSpaceObject.GetStringRepresentation(),
                actualWhiteSpaceObject.GetStringRepresentation());
        }
    }
}
