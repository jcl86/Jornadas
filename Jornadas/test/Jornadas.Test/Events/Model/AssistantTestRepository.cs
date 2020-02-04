using Jornadas.Domain;
using System.Threading.Tasks;

namespace Jornadas.Test
{
    public class AssistantTestRepository : IAssistantRepository
    {
        public IPartaker RegisteredPartaker { get; private set; }
        public async Task Register(IPartaker partaker)
        {
            RegisteredPartaker = partaker;
            await Task.CompletedTask;
        }
    }
}
