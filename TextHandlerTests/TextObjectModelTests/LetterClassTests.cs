using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel.Letters;

namespace TextHandlerTests.TextObjectModelTests
{
    [TestClass]
    public class LetterClassTests
    {
        [TestMethod]
        [DataRow('a')]
        [DataRow('b')]
        [DataRow('c')]
        public void TestCreatingWithValidParameters(char letter)
        {
            var letterObject = new Letter(letter);

            Assert.AreEqual(letter, letterObject.Value);
        }

        [TestMethod]
        [DataRow('.')]
        [DataRow(' ')]
        [DataRow('1')]
        public void TestCreatingWithInvalidParameters(char letter)
        {
            Assert.ThrowsException<ArgumentException>(() => new Letter(letter),
                nameof(letter));
        }
    }
}
