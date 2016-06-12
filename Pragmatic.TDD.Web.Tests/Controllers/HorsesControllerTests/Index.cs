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
        private Mock<IHorseService> _horseService;
        private HorsesController _controller;

        [TestInitialize]
        public void Setup()
        {
            var horseToHorseDetailMapper = new HorseToHorseDetailMapper();
            var horseToHorseSummaryMapper = new HorseToHorseSummaryMapper();
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
        public void ItMaps()
        {
            // Arrange
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var horse = ((IEnumerable<Models.HorseSummary>)result.ViewData.Model).Single();
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
