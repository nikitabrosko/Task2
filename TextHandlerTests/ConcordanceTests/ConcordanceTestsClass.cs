using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.Concordance;

namespace TextHandlerTests.ConcordanceTests
{
    [TestClass]
    public class ConcordanceTestsClass
    {
        [TestMethod]
        public void DebugTest()
        {
            Concordance concordance = new Concordance();
            concordance.GetConcordance(@"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\file1.txt", @"F:\GitHub\Task2\TextHandler\TextHandler\FilesForDebug\file2.txt");
        }
    }
}
