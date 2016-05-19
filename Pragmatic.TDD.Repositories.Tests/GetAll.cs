using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pragmatic.TDD.Repositories.Tests
{
    [TestClass]
    public class GetAll : TestBase
    {
        [TestMethod]
        public void ItExists()
        {
            // Arrange

            // Act
            var things = Repository.GetAll();

            // Assert
            Assert.IsInstanceOfType(things, typeof(IQueryable<Thing>));
        }
    }
}
