namespace StorageInstruments.MSTest
{
    using AutoFixture;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using StorageInstruments.DataContract;
    using StorageInstruments.DataContract.Utils;
    using StorageInstruments.Model;
    using StorageInstruments.Service;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class InstrumentServiceTests
    {
        private readonly IInstrumentRepository instrumentRepository;
        private readonly ISeriLog logger;
        private readonly InstrumentService instrumentService;
        private readonly static Fixture fixture = new Fixture();

        public InstrumentServiceTests()
        {
            this.instrumentRepository = Substitute.For<IInstrumentRepository>();
            this.logger = Substitute.For<ISeriLog>();
            this.instrumentService = new InstrumentService(instrumentRepository, logger);
        }

        [TestMethod]
        public void Delete_ValidId_ReturnsResult()
        {
            // Arrange
            var result = fixture.Create<Instrument>();
            instrumentRepository.Delete(Arg.Any<int>()).Returns(result);

            // Act
            var serviceResult = instrumentService.Delete(1);

            // Assert
            Assert.IsNotNull(serviceResult);
            Assert.AreEqual(serviceResult.Id, result.Id);
        }

        [TestMethod]
        public void Delete_InvalidId_ReturnsResult()
        {
            // Act
            var serviceResult = instrumentService.Delete(0);

            // Assert
            Assert.IsNull(serviceResult);
        }

        [TestMethod]
        public void GetInstrumentById_ValidId_ReturnsResult()
        {
            // Arrange
            var result = fixture.Create<Instrument>();
            instrumentRepository.GetById(Arg.Any<int>()).Returns(result);

            // Act
            var serviceResult = instrumentService.GetInstrumentById(1);

            // Assert
            Assert.IsNotNull(serviceResult);
            Assert.AreEqual(serviceResult.Id, result.Id);
        }

        [TestMethod]
        public void GetInstrumentById_InvalidId_ReturnsResult()
        {
            // Act
            var serviceResult = instrumentService.GetInstrumentById(0);

            // Assert
            Assert.IsNull(serviceResult);
        }

        [TestMethod]
        public void GetInstrumentsByName_ValidId_ReturnsResult()
        {
            // Arrange
            var result = fixture.Create<IEnumerable<Instrument>>();
            instrumentRepository.GetInstrumentsByName(Arg.Any<string>()).Returns(result);

            // Act
            var serviceResult = instrumentService.GetInstrumentsByName("test");

            // Assert
            Assert.IsNotNull(serviceResult);
            Assert.AreEqual(serviceResult.Count(), result.Count());
        }
    }
}
