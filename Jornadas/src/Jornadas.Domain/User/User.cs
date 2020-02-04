namespace Jornadas.Domain
{
    public class User
    {
        private readonly string name;
        public string Email { get; }

        public User(string name, string email)
        {
            this.name = name;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return ((User)obj).Email.Trim().ToUpper().Equals(Email.Trim().ToUpper());
        }

        public override int GetHashCode() => Email.GetHashCode();
        public override string ToString() => name;
    }
}
