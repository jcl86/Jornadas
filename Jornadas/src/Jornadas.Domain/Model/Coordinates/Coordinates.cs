using System;

namespace Jornadas.Domain
{
    public class Coordinates : ValueObject
    {
        const float EarthRadiusInKilometers = 6378.0F;

        public Latitude Latitude { get; }
        public Longitude Longitude { get; }

        public Coordinates(Latitude latitude, Longitude longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public float DistanceInKilometersTo(Coordinates position)
        {
            var latitude = ToRadian(position.Latitude - Latitude);
            var longitude = ToRadian(position.Longitude - Longitude);
            var a = Math.Pow(Math.Sin(latitude / 2), 2) +
                    Math.Cos(ToRadian(Latitude)) *
                    Math.Cos(ToRadian(position.Latitude)) *
                    Math.Pow(Math.Sin(longitude / 2), 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusInKilometers * Convert.ToSingle(c);
        }

        private float ToRadian(float value) => Convert.ToSingle(Math.PI / 180) * value;
        public override string ToString() => $"Lat: {Latitude.ToString()}, Long: {Longitude.ToString()}";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Coordinates)obj;
            return Latitude == other.Latitude && Longitude == other.Longitude;
        }
        public override int GetHashCode() => Latitude.GetHashCode() ^ Longitude.GetHashCode();
    }
}
