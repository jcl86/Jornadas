namespace Jornadas.Domain
{
    public class Latitude : ValueObject
    {
        private readonly float value;

        public Latitude(float value)
        {
            Ensure.Argument.Is(value >= -90 && value <= 90, CoreStrings.InvalidLatitude);
            this.value = value;
        }

        public static Latitude FromScalar(float value) => new Latitude(value);
        public static implicit operator float(Latitude latitude) => latitude.value;
        public static explicit operator Latitude(float value) => new Latitude(value);
        
        public override string ToString() => value.ToString();

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Latitude)obj;
            return value == (double)other;
        }
        public override int GetHashCode() => value.GetHashCode();

        public static bool operator ==(Latitude latitude1, Latitude latitude2) => EqualOperator(latitude1, latitude2);
        public static bool operator !=(Latitude latitude1, Latitude latitude2) => NotEqualOperator(latitude1, latitude2);
    }
}
