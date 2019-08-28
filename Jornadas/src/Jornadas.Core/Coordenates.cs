namespace Jornadas.Core
{
    public class Coordenates
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public Coordenates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString() => $"Lat: {Latitude}, Long:{Longitude}";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return ((Coordenates)obj).Latitude == Latitude && ((Coordenates)obj).Longitude == Longitude;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
