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
        public void Setup()
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
        public void ItMapsProperties()
        {
            // Arrange
            // Act
            var horses = _horseService.GetAll();
            var horse = horses.First();

            // Assert
            Assert.AreEqual(1, horse.Id);
            Assert.AreEqual("Man o' War", horse.Name);
            Assert.AreEqual("Chestnut", horse.Color);
            Assert.AreEqual(2, horse.DamId);
            Assert.AreEqual("Dam", horse.Dam);
            Assert.AreEqual(3, horse.SireId);
            Assert.AreEqual("Sire", horse.Sire);
        }
    }
}
