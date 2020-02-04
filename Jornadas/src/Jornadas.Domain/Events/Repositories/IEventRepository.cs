using System.Threading.Tasks;

namespace Jornadas.Domain
{
    public interface IEventRepository
    {
        Task Create(Event @event);
    }
}
