namespace Jornadas.Domain
{
    public class RegisterInEvent
    {
        private readonly IAssistantRepository assistantRepository;

        public RegisterInEvent(IAssistantRepository assistantRepository)
        {
            this.assistantRepository = assistantRepository;
        }

        public void RegisterAssistant(Event myEvent, User user)
        {
            var partaker = myEvent.RegisterAssistant(user);
            assistantRepository.Register(partaker);
        }

        public void RegisterOrganizer(Event myEvent, User user, Institution usersInstitution)
        {
            var partaker = myEvent.RegisterOrganizer(user, usersInstitution);
            assistantRepository.Register(partaker);
        }
    }
}
