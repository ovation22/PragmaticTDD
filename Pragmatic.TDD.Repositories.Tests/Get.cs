using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Pragmatic.TDD.Repositories.Tests
{
    [TestClass]
    public class Get : TestBase
    {
        [TestMethod]
        public void ItExists()
        {
            // Arrange

            // Act
            var thing = Repository.Get(It.IsAny<int>());

            // Assert
            Assert.IsNull(thing);
            MockSet.Verify(set => set.FindAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
