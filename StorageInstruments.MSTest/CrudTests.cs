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
        [TestMethod]
        public void TestGetById()
        {
            // Fixture setup
            var fixture = new Fixture();

            var instrument = fixture.Freeze<Instrument>();

            var mapMock = new Mock<IInstrumentRepository>();
            fixture.Register(() => mapMock.Object);

            var aux = mapMock.Object.GetById(instrument.Id);

            Assert.IsNotNull(aux);

        }
    }
}
