namespace Jornadas.Domain
{
    public interface IPartaker
    {
        int Number { get; }
        string Email { get; }
        bool IsOrganizer { get; }
    }
}
