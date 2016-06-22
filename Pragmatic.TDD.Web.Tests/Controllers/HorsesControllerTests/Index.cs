using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pragmatic.TDD.Services.Interfaces;
using Pragmatic.TDD.Web.Controllers;
using Pragmatic.TDD.Web.Mappers;

namespace Pragmatic.TDD.Web.Tests.Controllers.HorsesControllerTests
{
    [TestClass]
    public class Index
    {
        private HorsesController _controller;
        private static Mock<IHorseService> _horseService;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            var horse = new Dto.Horse
            {
                Id = 1,
                Name = "Man o' War",
                Color = "Chestnut",
                Dam = "Dam",
                DamId = 2,
                Sire = "Sire",
                SireId = 3
            };

            _horseService = new Mock<IHorseService>();
            _horseService.Setup(x => x.GetAll()).Returns(() => new List<Dto.Horse> { horse });
        }

        [TestInitialize]
        public void TestSetup()
        {
            var horseToHorseDetailMapper = new HorseToHorseDetailMapper();
            var horseToHorseSummaryMapper = new HorseToHorseSummaryMapper();

            _controller = new HorsesController(_horseService.Object,
                horseToHorseDetailMapper,
                horseToHorseSummaryMapper);
        }

        [TestMethod]
        public void ItExists()
        {
            // Arrange
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ItCallsService()
        {
            // Arrange
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            _horseService.Verify(mock => mock.GetAll(), Times.Once());
        }

        [TestMethod]
        public void ItReturnsCollectionOfHorses()
        {
            // Arrange
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IEnumerable<Models.HorseSummary>));
        }

        [TestMethod]
        public void ItMapsId()
        {
            // Arrange
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((IEnumerable<Models.HorseSummary>)result.ViewData.Model).Single();
            Assert.AreEqual(1, horse.Id);
        }

        [TestMethod]
        public void ItMapsName()
        {
            // Arrange
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((IEnumerable<Models.HorseSummary>)result.ViewData.Model).Single();
            Assert.AreEqual("Man o' War", horse.Name);
        }

        [TestMethod]
        public void ItMapsColor()
        {
            // Arrange
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((IEnumerable<Models.HorseSummary>)result.ViewData.Model).Single();
            Assert.AreEqual("Chestnut", horse.Color);
        }

        [TestMethod]
        public void ItMapsDamId()
        {
            // Arrange
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((IEnumerable<Models.HorseSummary>)result.ViewData.Model).Single();
            Assert.AreEqual(2, horse.DamId);
        }

        [TestMethod]
        public void ItMapsDamName()
        {
            // Arrange
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((IEnumerable<Models.HorseSummary>)result.ViewData.Model).Single();
            Assert.AreEqual("Dam", horse.Dam);
        }

        [TestMethod]
        public void ItMapsSireId()
        {
            // Arrange
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((IEnumerable<Models.HorseSummary>)result.ViewData.Model).Single();
            Assert.AreEqual(3, horse.SireId);
        }

        [TestMethod]
        public void ItMapsSireName()
        {
            // Arrange
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((IEnumerable<Models.HorseSummary>)result.ViewData.Model).Single();
            Assert.AreEqual("Sire", horse.Sire);
        }
    }
}
