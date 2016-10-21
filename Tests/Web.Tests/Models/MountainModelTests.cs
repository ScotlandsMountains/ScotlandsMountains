﻿using NUnit.Framework;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Server.Models;

namespace Web.Tests.Models
{
    [TestFixture]
    public class MountainModelTests
    {
        private Mountain _mountain;
        private MountainModel _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mountain = new Mountain
            {
                Id = MockDomainRoot.EntityId,
                Name = "Name",
                Height = new Height {Metres = 1},
                Location = new Location {GridRef = new GridRef("NM123456"), Latitude = 2, Longitude = 3},
                Prominence = new Prominence {Metres = 4, KeyCol = "KeyCol", KeyColHeight = new Height {Metres = 5}},
                Feature = "Feature",
                Observations = "Observations",
                ClassificationIds = MockDomainRoot.EntityIds,
                MapIds = MockDomainRoot.EntityIds,
                SectionId = MockDomainRoot.EntityId,
                CountryId = MockDomainRoot.EntityId
            };

            _sut = new MountainModel(_mountain, new MockDomainRoot());
        }

        [Test]
        public void ThenIdIsMappedCorrectly()
        {
            Assert.That(_sut.Id, Is.EqualTo(MockDomainRoot.EntityId));
        }

        [Test]
        public void ThenNameIsMappedCorrectly()
        {
            Assert.That(_sut.Name, Is.EqualTo(_mountain.Name));
        }

        [Test]
        public void ThenHeightIsMappedCorrectly()
        {
            Assert.That(_sut.Height, Is.SameAs(_mountain.Height));
        }

        [Test]
        public void ThenLocationIsMappedCorrectly()
        {
            Assert.That(_sut.Location, Is.SameAs(_mountain.Location));
        }

        [Test]
        public void ThenProminenceIsMappedCorrectly()
        {
            Assert.That(_sut.Prominence, Is.SameAs(_mountain.Prominence));
        }

        [Test]
        public void ThenFeatureIsMappedCorrectly()
        {
            Assert.That(_sut.Feature, Is.EqualTo(_mountain.Feature));
        }

        [Test]
        public void ThenObservationIsMappedCorrectly()
        {
            Assert.That(_sut.Observations, Is.EqualTo(_mountain.Observations));
        }

        [Test]
        public void ThenClassificationsAreMappedCorrectly()
        {
            Assert.That(_sut.Classifications[0].Id, Is.EqualTo(MockDomainRoot.EntityId));
            Assert.That(_sut.Classifications[0].Name, Is.EqualTo(MockDomainRoot.EntityName));
        }

        [Test]
        public void ThenMapsAreMappedCorrectly()
        {
            Assert.That(_sut.Maps[0].Id, Is.EqualTo(MockDomainRoot.EntityId));
            Assert.That(_sut.Maps[0].Name, Is.EqualTo(MockDomainRoot.EntityName));
        }

        [Test]
        public void ThenSectionIsMappedCorrectly()
        {
            Assert.That(_sut.Section.Id, Is.EqualTo(MockDomainRoot.EntityId));
            Assert.That(_sut.Section.Name, Is.EqualTo(MockDomainRoot.EntityName));
        }

        [Test]
        public void ThenCountryIsMappedCorrectly()
        {
            Assert.That(_sut.Country.Id, Is.EqualTo(MockDomainRoot.EntityId));
            Assert.That(_sut.Country.Name, Is.EqualTo(MockDomainRoot.EntityName));
        }
    }
}
