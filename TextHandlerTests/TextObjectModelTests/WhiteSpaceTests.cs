using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel.WhiteSpaces;

namespace TextHandlerTests.TextObjectModelTests
{
    [TestClass]
    public class WhiteSpaceTests
    {
        [TestMethod]
        public void TestCreatingWithValidParameters()
        {
            var character = ' ';

            var whiteSpaceObject = new WhiteSpace(character);

            Assert.AreEqual(whiteSpaceObject.Value, character);
        }

        [TestMethod]
        [DataRow('.')]
        [DataRow('1')]
        [DataRow('a')]
        [DataRow('\t')]
        public void TestCreatingWithInvalidParameters(char character)
        {
            Assert.ThrowsException<ArgumentException>(() => new WhiteSpace(character));
        }
    }
}
