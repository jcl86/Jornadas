namespace Jornadas.Core
{
    public interface IPartaker
    {
        int EventId { get; }
        string Name { get; }
        string Email { get; }
    }
}
