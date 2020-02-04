namespace Jornadas.Domain
{
    public class Organizer : User, IPartaker
    {
        public Institution Institution { get; }

        public int Number { get; }
        public bool IsOrganizer => true;

        public Organizer(string name, string email, Institution institution, int number) : base(name, email)
        {
            Institution = institution;
            Number = number;
        }
    }
}
