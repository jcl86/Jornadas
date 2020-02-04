using System;

namespace Jornadas.Domain
{
    public class CreateEvent
    {
        private readonly IEventRepository eventRepository;
        private readonly IAssistantRepository assistantRepository;
        private readonly IDateTimeProvider dateTimeProvider;

        public CreateEvent(IEventRepository eventRepository, IAssistantRepository assistantRepository, IDateTimeProvider dateTimeProvider)
        {
            this.eventRepository = eventRepository;
            this.assistantRepository = assistantRepository;
            this.dateTimeProvider = dateTimeProvider;
        }

        public void Create(User organizer, Institution institution, string name, DateTime beginDate, DateTime endDate, DateTime registrationAvaliable,
            string mainPlaceName, Coordinates coordinates, string placeDescription = null)
        {
            var newEvent = new Event(name, beginDate, endDate, registrationAvaliable, mainPlaceName, coordinates, placeDescription, dateTimeProvider);

            var organizeruser = newEvent.RegisterOrganizer(organizer, institution);

            eventRepository.Create(newEvent);
            assistantRepository.Register(organizeruser);
        }
    }
}
