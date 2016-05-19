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
            Assert.AreEqual(horse.Id, 1);
            Assert.AreEqual(horse.Name, "Man o' War");
            Assert.AreEqual(horse.Color, "Chestnut");
            Assert.AreEqual(horse.DamId, 2);
            Assert.AreEqual(horse.Dam, "Dam");
            Assert.AreEqual(horse.SireId, 3);
            Assert.AreEqual(horse.Sire, "Sire");
        }
    }
}
