using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;

namespace TextHandlerTests.ParsersTests
{
    [TestClass]
    public class ParserFromObjectModelTests
    {
        [TestMethod]
        public void TestForDebug()
        {
            string pathFrom = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\file1.txt";
            string pathTo = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\ParserFromObjectModelFile.txt";

            ParserFromObjectModel parserFromObjectModel = new ParserFromObjectModel();
            ParserToObjectModel parserToObjectModel = new ParserToObjectModel();

            var textObject = parserToObjectModel.ReadFile(pathFrom);
            parserFromObjectModel.WriteInFile(pathTo, textObject);

        }

        public void TestForDebug2()
        {
            string pathFrom = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\file1.txt";

            ParserToObjectModel parserToObjectModel = new ParserToObjectModel();

            var textObject = parserToObjectModel.ReadFile(pathFrom);

            string str = "1";
        }
    }
}
