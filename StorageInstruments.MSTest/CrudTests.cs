using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StorageInstruments.Data;
using StorageInstruments.DataContract;
using StorageInstruments.Model;
using System.Security.Cryptography.X509Certificates;

namespace StorageInstruments.MSTest
{
    [TestClass]
    public class CrudTests
    {
        Fixture fixture;
        Instrument instrument;
        Mock<IInstrumentRepository> mapMock;

        [TestInitialize]
        public void Starter()
        {
            // Fixture setup
            fixture = new Fixture();

            instrument = fixture.Freeze<Instrument>();

            mapMock = new Mock<IInstrumentRepository>();

            fixture.Register(() => mapMock.Object);
        }
        [TestMethod]
        public void TestGetById()
        {
            var aux = mapMock.Setup(x => x.GetById(instrument.Id)).Returns<Instrument>(x => x);

            Assert.IsNotNull(aux);
        }

        [TestMethod]
        public void TestCreateInstrument()
        {
            Instrument fakeInstrument = new Instrument()
            {
                Location = LocationType.Home,
                Name = "Test",
                owner = "Test",
                Type = InstrumentType.Percurssion
            };

            var aux = mapMock.Setup(x => x.Add(fakeInstrument));
            
            //Assert.AreEqual(aux, mapMock.Setup(x => x.GetById(aux.ob)
        }
    }
}
