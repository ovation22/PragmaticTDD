using System.Data.Entity;
using Moq;

namespace Pragmatic.TDD.Repositories.Tests
{
    public class TestBase
    {
        protected Repository<Thing> Repository;
        protected Mock<DbSet<Thing>> MockSet { get; }
        protected Mock<DbContext> MockContext { get; }

        public TestBase()
        {
            MockSet = new Mock<DbSet<Thing>>();
            MockContext = new Mock<DbContext>();
            MockContext.Setup(c => c.Set<Thing>()).Returns(MockSet.Object);

            Repository = new Repository<Thing>(MockContext.Object);
        }

        public class Thing : DbSet
        {
        }
    }
}
