using FluentAssertions;
using Jornadas.Domain;
using System;
using Xunit;

namespace Jornadas.Test
{
    public class CoordinatesTests
    {
        [Fact]
        public void Not_allow_latitude_could_be_greater_than_180()
        {
            Action position = () => new Coordinates(Latitude.FromScalar(-190), Longitude.FromScalar(240));
            position.Should().Throw<ArgumentException>().WithMessage(CoreStrings.InvalidLatitude);
        }

        [Fact]
        public void Not_allow_longitude_could_be_greater_than_180()
        {
            Action position = () => new Coordinates(Latitude.FromScalar(-90), Longitude.FromScalar(240));
            position.Should().Throw<ArgumentException>().WithMessage(CoreStrings.InvalidLongitude);
        }

        [Fact]
        public void Be_equal_to_another_position_with_the_same_latitude_and_longitude()
        {
            var positionOne = new Coordinates((Latitude)37.1773f, (Longitude)(-3.5985f));
            var positionTwo = new Coordinates((Latitude)37.1773f, (Longitude)(-3.5985f));
            positionOne.Should().Be(positionTwo);
        }

        [Fact]
        public void Allow_to_calculate_the_distance_in_kilometers_from_granada_to_madrid()
        {
            var granada = new Coordinates((Latitude)37.1773f, (Longitude)(-3.5985f));
            var madrid = new Coordinates((Latitude)40.4168f, (Longitude)(-3.70379f));
            var distance = granada.DistanceInKilometersTo(madrid);
            distance.Should().Be(360.727539f);
        }

        [Fact]
        public void Latitude_should_be_equal_to_the_same_latitude()
        {
            var latitude = Latitude.FromScalar(37.1773f);
            var latitude2 = Latitude.FromScalar(37.1773f);
            latitude.Should().Be(latitude2);
            (latitude == latitude2).Should().BeTrue();
        }

        [Fact]
        public void Longitude_should_be_equal_to_the_same_longitude()
        {
            var longitude = Longitude.FromScalar(-3.5985f);
            var longitude2 = Longitude.FromScalar(-3.5985f);
            longitude.Should().Be(longitude2);
            (longitude == longitude2).Should().BeTrue();
        }

        [Fact]
        public void Longitude_should_not_be_equal_to_the_same_latitude()
        {
            var longitude = Longitude.FromScalar(-3.5985f);
            var latitude = Latitude.FromScalar(-3.5985f);
            longitude.Should().NotBe(latitude);
        }

        [Fact]
        public void Null_longitudes_should_be_compared_properly()
        {
            Longitude longitude = Longitude.FromScalar(-3.5985f);
            Longitude nullLongitude = null;

            nullLongitude.Should().BeNull();
            (nullLongitude == null).Should().BeTrue();

            nullLongitude.Should().NotBe(longitude);
            (nullLongitude == longitude).Should().BeFalse();

            longitude.Should().NotBe(nullLongitude);
            (longitude == nullLongitude).Should().BeFalse();
        }
    }
}
