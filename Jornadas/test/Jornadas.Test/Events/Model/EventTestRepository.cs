using Jornadas.Domain;
using System.Threading.Tasks;

namespace Jornadas.Test
{
    public class EventTestRepository : IEventRepository
    {
        public Event CreatedEvent { get; private set; }

        public async Task Create(Event @event)
        {
            CreatedEvent = @event;
            await Task.CompletedTask;
        }

    }
}
