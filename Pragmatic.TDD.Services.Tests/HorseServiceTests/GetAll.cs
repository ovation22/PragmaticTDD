using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pragmatic.TDD.Services.Interfaces;
using Pragmatic.TDD.Services.Tests.Factories;

namespace Pragmatic.TDD.Services.Tests.HorseServiceTests
{
    [TestClass]
    public class GetAll : TestBase
    {
        private IHorseService _horseService;

        [TestInitialize]
        public void TestSetup()
        {
            HorseFactory.Create(Context).WithColor().WithDam().WithSire();

            _horseService = Container.Resolve<IHorseService>();
        }

        [TestMethod]
        public void ItExists()
        {
            // Arrange
            // Act
            // Assert
            Assert.IsNotNull(_horseService.GetAll());
        }

        [TestMethod]
        public void ItReturnsCollectionOfHorses()
        {
            // Arrange
            // Act
            var horses = _horseService.GetAll();

            // Assert
            Assert.IsInstanceOfType(horses, typeof(IEnumerable<Dto.Horse>));
        }

        [TestMethod]
        public void ItReturnsId()
        {
            // Arrange
            // Act
            var horses = _horseService.GetAll();

            // Assert
            var horse = horses.First(x => x.Id == 1);
            Assert.AreEqual(1, horse.Id);
        }

        [TestMethod]
        public void ItReturnsName()
        {
            // Arrange
            // Act
            var horses = _horseService.GetAll();

            // Assert
            var horse = horses.First(x => x.Id == 1);
            Assert.AreEqual("Man o' War", horse.Name);
        }

        [TestMethod]
        public void ItReturnsColor()
        {
            // Arrange
            // Act
            var horses = _horseService.GetAll();

            // Assert
            var horse = horses.First(x => x.Id == 1);
            Assert.AreEqual("Chestnut", horse.Color);
        }

        [TestMethod]
        public void ItReturnsDamId()
        {
            // Arrange
            // Act
            var horses = _horseService.GetAll();

            // Assert
            var horse = horses.First(x => x.Id == 1);
            Assert.AreEqual(2, horse.DamId);
        }

        [TestMethod]
        public void ItReturnsDamName()
        {
            // Arrange
            // Act
            var horses = _horseService.GetAll();

            // Assert
            var horse = horses.First(x => x.Id == 1);
            Assert.AreEqual("Dam", horse.Dam);
        }

        [TestMethod]
        public void ItReturnsSireId()
        {
            // Arrange
            // Act
            var horses = _horseService.GetAll();

            // Assert
            var horse = horses.First(x => x.Id == 1);
            Assert.AreEqual(3, horse.SireId);
        }

        [TestMethod]
        public void ItReturnsSireName()
        {
            // Arrange
            // Act
            var horses = _horseService.GetAll();

            // Assert
            var horse = horses.First(x => x.Id == 1);
            Assert.AreEqual("Sire", horse.Sire);
        }
    }
}
