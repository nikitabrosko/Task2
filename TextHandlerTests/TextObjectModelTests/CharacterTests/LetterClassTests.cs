using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextHandler.TextObjectModel.Characters.Letters;

namespace TextHandlerTests.TextObjectModelTests.CharacterTests
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
