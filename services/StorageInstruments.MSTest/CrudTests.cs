using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StorageInstruments.Data;
using StorageInstruments.DataContract;
using StorageInstruments.Model;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace StorageInstruments.MSTest
{
    [TestClass]
    public class CrudTests
    {
        Fixture fixture;
        Instrument instrument;
        IEnumerable<Instrument> instruments;
        Mock<IInstrumentRepository> mapMock;

        [TestInitialize]
        public void Starter()
        {
            // Fixture setup
            fixture = new Fixture();

            instrument = fixture.Freeze<Instrument>();

            instruments = fixture.Freeze<IEnumerable<Instrument>>();

            mapMock = new Mock<IInstrumentRepository>();

            fixture.Register(() => mapMock.Object);

            mapMock.Setup(x => x.GetById(instrument.Id)).Returns(instrument);
            mapMock.Setup(x => x.GetCountOfInstruments()).Returns(1);
            mapMock.Setup(x => x.GetInstrumentsByName(instrument.Name)).Returns(instruments);
            mapMock.Setup(x => x.Add(instrument)).Returns(instrument);
        }
        [TestMethod]
        public void TestGetById()
        {
            var expected = mapMock.Object.GetById(instrument.Id);

            Assert.IsNotNull(expected);
        }

        [TestMethod]
        public void TestCreateInstrument()
        {
            var sut = mapMock.Object.Add(instrument);

            Assert.AreEqual(sut, instrument);
        }
    }
}
