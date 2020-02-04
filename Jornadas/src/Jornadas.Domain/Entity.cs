namespace Jornadas.Domain
{
    public class Entity<T>
    {
        public T Id { get; }

        public Entity(T id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Entity<T>)obj;
            return Id.Equals(other.Id);
        }
        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Entity<T> left, Entity<T> right) => EqualOperator(left, right);
        public static bool operator !=(Entity<T> left, Entity<T> right) => NotEqualOperator(left, right);

        protected static bool EqualOperator(Entity<T> left, Entity<T> right)
        {
            if (left is null && right is null) return true;
            if (left is null && !(right is null)) return false;
            if (right is null && !(left is null)) return false;

            return left.Equals(right);
        }

        protected static bool NotEqualOperator(Entity<T> left, Entity<T> right) => !EqualOperator(left, right);
        
    }
}
