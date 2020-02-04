namespace Jornadas.Domain
{
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (left is null && right is null) return true;

            if (left is null && !(right is null)) return false;
            if (right is null && !(left is null)) return false;

            return left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }
    }
}
