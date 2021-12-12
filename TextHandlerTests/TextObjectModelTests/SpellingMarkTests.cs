using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel.SpellingMarks;

namespace TextHandlerTests.TextObjectModelTests
{
    [TestClass]
    public class SpellingMarkTests
    {
        [TestMethod]
        [DataRow('-')]
        [DataRow('\'')]
        public void TestCreatingWithValidParameters(char spellingMark)
        {
            var spellingMarkObject = new SpellingMark(spellingMark);

            Assert.AreEqual(spellingMark, spellingMarkObject.Value);
        }

        [TestMethod]
        [DataRow('1')]
        [DataRow('!')]
        public void TestCreatingWithInvalidParameters(char spellingMark)
        {
            Assert.ThrowsException<ArgumentException>(() => new SpellingMark(spellingMark));
        }
    }
}
