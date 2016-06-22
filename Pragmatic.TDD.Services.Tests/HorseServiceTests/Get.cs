using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pragmatic.TDD.Services.Interfaces;
using Pragmatic.TDD.Services.Tests.Factories;

namespace Pragmatic.TDD.Services.Tests.HorseServiceTests
{
    [TestClass]
    public class Get : TestBase
    {
        private IHorseService _horseService;

        [TestInitialize]
        public void TestSetup()
        {
            HorseFactory.Create(Context).WithColor();

            _horseService = Container.Resolve<IHorseService>();
        }

        [TestMethod]
        public void ItExists()
        {
            // Arrange
            // Act
            // Assert
            Assert.IsNotNull(_horseService.Get(1));
        }

        [TestMethod]
        public void ItReturnsNullForUserThatDoesNotExist()
        {
            // Arrange
            // Act 
            var horse = _horseService.Get(-1);

            // Assert
            Assert.IsNull(horse);
        }

        [TestMethod]
        public void ItReturnsId()
        {
            // Arrange
            // Act
            var horse = _horseService.Get(1);

            // Assert
            Assert.AreEqual(1, horse.Id);
        }

        [TestMethod]
        public void ItReturnsName()
        {
            // Arrange
            // Act
            var horse = _horseService.Get(1);

            // Assert
            Assert.AreEqual("Man o' War", horse.Name);
        }

        [TestMethod]
        public void ItReturnsColor()
        {
            // Arrange
            // Act
            var horse = _horseService.Get(1);

            // Assert
            Assert.AreEqual("Chestnut", horse.Color);
        }
    }
}
