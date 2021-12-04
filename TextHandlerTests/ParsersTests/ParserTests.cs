using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;

namespace TextHandlerTests.ParsersTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void DebugTextTest()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\file1.txt";

            Parser parser = new Parser();

            Text text = parser.ReadFile(path);

            string str = "1";
        }
    }
}
