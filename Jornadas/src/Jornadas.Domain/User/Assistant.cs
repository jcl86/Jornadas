namespace Jornadas.Domain
{
    public class Assistant : User, IPartaker
    {
        public int Number { get; }
        public bool IsOrganizer => false;

        public Assistant(string name, string email, int number) : base(name, email)
        {
            Number = number;
        }
    }
}
