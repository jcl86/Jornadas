namespace Jornadas.Domain
{
    public class Longitude : ValueObject
    {
        private readonly float value;

        public Longitude(float value)
        {
            Ensure.Argument.Is(value >= -180 && value <= 180, CoreStrings.InvalidLongitude);
            this.value = value;
        }

        public static Longitude FromScalar(float value) => new Longitude(value);
        public static implicit operator float(Longitude longitude) => longitude.value;
        public static explicit operator Longitude(float value) => new Longitude(value);

        public override string ToString() => value.ToString();

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Longitude)obj;
            return value == (double)other;
        }
        public override int GetHashCode() => value.GetHashCode();

        public static bool operator ==(Longitude longitude1, Longitude longitude2) => EqualOperator(longitude1, longitude2);
        public static bool operator !=(Longitude longitude1, Longitude longitude2) => NotEqualOperator(longitude1, longitude2);
    }
}
