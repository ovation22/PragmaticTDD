using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pragmatic.TDD.Services.Interfaces;
using Pragmatic.TDD.Web.Controllers;
using Pragmatic.TDD.Web.Mappers;

namespace Pragmatic.TDD.Web.Tests.Controllers.HorsesControllerTests
{
    [TestClass]
    public class Horse
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
            _horseService.Setup(x => x.Get(It.IsAny<int>())).Returns(() => horse);
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
            var result = _controller.Horse(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ItCallsService()
        {
            // Arrange
            // Act
            var result = _controller.Horse(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            _horseService.Verify(mock => mock.Get(It.IsAny<int>()), Times.Once());
        }

        [TestMethod]
        public void ItReturnsHorseDetail()
        {
            // Arrange
            // Act
            var result = _controller.Horse(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(Models.HorseDetail));
        }

        [TestMethod]
        public void ItReturnsId()
        {
            // Arrange
            // Act
            var result = _controller.Horse(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((Models.HorseDetail)result.ViewData.Model);
            Assert.AreEqual(1, horse.Id);
        }

        [TestMethod]
        public void ItReturnsName()
        {
            // Arrange
            // Act
            var result = _controller.Horse(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((Models.HorseDetail)result.ViewData.Model);
            Assert.AreEqual("Man o' War", horse.Name);
        }

        [TestMethod]
        public void ItReturnsColor()
        {
            // Arrange
            // Act
            var result = _controller.Horse(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((Models.HorseDetail)result.ViewData.Model);
            Assert.AreEqual("Chestnut", horse.Color);
        }

        [TestMethod]
        public void ItReturnsDamId()
        {
            // Arrange
            // Act
            var result = _controller.Horse(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((Models.HorseDetail)result.ViewData.Model);
            Assert.AreEqual(2, horse.DamId);
        }

        [TestMethod]
        public void ItReturnsDamName()
        {
            // Arrange
            // Act
            var result = _controller.Horse(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((Models.HorseDetail)result.ViewData.Model);
            Assert.AreEqual("Dam", horse.Dam);
        }

        [TestMethod]
        public void ItReturnsSireId()
        {
            // Arrange
            // Act
            var result = _controller.Horse(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((Models.HorseDetail)result.ViewData.Model);
            Assert.AreEqual(3, horse.SireId);
        }

        [TestMethod]
        public void ItReturnsSireName()
        {
            // Arrange
            // Act
            var result = _controller.Horse(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((Models.HorseDetail)result.ViewData.Model);
            Assert.AreEqual("Sire", horse.Sire);
        }
    }
}
