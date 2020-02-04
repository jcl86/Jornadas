using System.Threading.Tasks;

namespace Jornadas.Domain
{
    public interface IAssistantRepository
    {
        Task Register(IPartaker partaker);
    }
}
