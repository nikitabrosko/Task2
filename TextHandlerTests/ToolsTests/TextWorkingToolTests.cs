using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;
using TextHandler.Tools;

namespace TextHandlerTests.ToolsTests
{
    [TestClass]
    public class TextWorkingToolTests
    {
        [TestMethod]
        public void DebugTextWorkingToolTest()
        {
            string path = @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\file1.txt";

            Parser parser = new Parser();

            Text text = parser.ReadFile(path);

            var result = TextWorkingTool.RemoveWordsWithGivenLengthThatStartsWithConsonantLetter(text, 5);

            string str = "1";
        }
    }
}
