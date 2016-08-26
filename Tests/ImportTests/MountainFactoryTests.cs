﻿using Moq;
using NUnit.Framework;
using ScotlandsMountains.Import;
using ScotlandsMountains.Import.Dobih;
using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.ImportTests
{
    [TestFixture]
    public class MountainFactoryTests
    {
        private const int Number = 1;
        private const string Id = "Id";
        private const string Name = "Name";
        private const double Metres = 2;
        private const double Latitude = 3;
        private const double Longitude = 4;
        private const string GridRef = "NM123456";
        private const double Drop = 5;
        private const string ColGridRef = "ColGridRef";
        private const double ColMetres = 6;
        private const string Feature = "Feature";
        private const string Observations = "Observations";

        private Mountain _actual;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var mockRecord = new Mock<IDobihRecord>();
            mockRecord.Setup(x => x.Number).Returns(Number);
            mockRecord.Setup(x => x.Name).Returns(Name);
            //mockRecord.Setup(x => x.SectionName).Returns();
            //mockRecord.Setup(x => x.Classifications).Returns();
            //mockRecord.Setup(x => x.Maps1To50000).Returns();
            //mockRecord.Setup(x => x.Maps1To25000).Returns();
            mockRecord.Setup(x => x.Metres).Returns(Metres);
            mockRecord.Setup(x => x.Latitude).Returns(Latitude);
            mockRecord.Setup(x => x.Longitude).Returns(Longitude);
            mockRecord.Setup(x => x.GridRef).Returns(GridRef);
            mockRecord.Setup(x => x.Drop).Returns(Drop);
            mockRecord.Setup(x => x.ColGridRef).Returns(ColGridRef);
            mockRecord.Setup(x => x.ColMetres).Returns(ColMetres);
            mockRecord.Setup(x => x.Feature).Returns(Feature);
            mockRecord.Setup(x => x.Observations).Returns(Observations);

            var mockIdGenerator = new Mock<IIdGenerator>();
            mockIdGenerator.Setup(x => x.Generate(Number)).Returns(Id);

            var mockDomainRoot = new Mock<IDomainRoot>(MockBehavior.Loose);

            var mockDobihFile = new Mock<IDobihFile>();
            mockDobihFile.Setup(x => x.Records).Returns(new List<IDobihRecord> { mockRecord.Object });

            _actual = new MountainsFactory(mockIdGenerator.Object, mockDomainRoot.Object).BuildFrom(mockDobihFile.Object).Single();
        }

        [Test]
        public void ThenIdIsMappedCorrectly()
        {
            Assert.That(_actual.Id, Is.EqualTo(Id));
        }
        
        [Test]
        public void ThenNameIsMappedCorrectly()
        {
            Assert.That(_actual.Name, Is.EqualTo(Name));
        }

        [Test]
        public void ThenHeightIsMappedCorrectly()
        {
            Assert.That(_actual.Height.Metres, Is.EqualTo(Metres));
        }

        [Test]
        public void ThenLocationIsMappedCorrectly()
        {
            Assert.That(_actual.Location.Latitude, Is.EqualTo(Latitude));
            Assert.That(_actual.Location.Longitude, Is.EqualTo(Longitude));
            Assert.That(_actual.Location.GridRef.SixFigure, Is.EqualTo(GridRef));
        }

        [Test]
        public void ThenProminenceIsMappedCorectly()
        {
            Assert.That(_actual.Prominence.Metres, Is.EqualTo(Drop));
            Assert.That(_actual.Prominence.KeyCol, Is.EqualTo(ColGridRef));
            Assert.That(_actual.Prominence.KeyColHeight.Metres, Is.EqualTo(ColMetres));
        }

        [Test]
        public void ThenFeatureIsMappedCorectly()
        {
            Assert.That(_actual.Feature, Is.EqualTo(Feature));
        }

        [Test]
        public void ThenObservationsIsMappedCorectly()
        {
            Assert.That(_actual.Observations, Is.EqualTo(Observations));
        }
    }
}
