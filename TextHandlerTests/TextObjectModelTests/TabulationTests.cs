using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel.Tabulations;

namespace TextHandlerTests.TextObjectModelTests
{
    [TestClass]
    public class TabulationTests
    {
        [TestMethod]
        public void TestCreatingParameterIsValid()
        {
            var character = '\t';

            var tabulationObject = new Tabulation(character);

            Assert.AreEqual(tabulationObject.Value, character);
        }

        [TestMethod]
        [DataRow('.')]
        [DataRow('a')]
        [DataRow('1')]
        [DataRow('\n')]
        public void TestCreatingParameterIsInvalid(char character)
        {
            Assert.ThrowsException<ArgumentException>(() => new Tabulation(character));
        }
    }
}
