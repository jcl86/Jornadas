using Jornadas.Domain;
using System;
using Xunit;

namespace Jornadas.Test
{
    public class OrganizingAnEvent
    {
        [Fact]
        public void User_should_create_an_event()
        {
            var eventRepository = new EventTestRepository();
            var assistantRepository = new AssistantTestRepository();
            var user = ObjectFactory.Francisco;
            var convention = ObjectFactory.UmbrasParadox;
            var registerDate = DateTime.Now.AddDays(1);
            var beginDate = DateTime.Now.AddDays(2);
            var endDate = DateTime.Now.AddDays(3);

            //var createEvent = new CreateEvent(eventRepository, assistantRepository, new DefaultDateTimeProvider());
            //createEvent.Create(user, ObjectFactory.AlterParadox, "Umbras", CoreStrings.InvalidPastDate);
            

        }
    }


}
