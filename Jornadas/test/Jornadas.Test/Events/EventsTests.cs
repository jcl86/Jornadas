using FluentAssertions;
using Jornadas.Domain;
using Jornadas.Test;
using System;
using Xunit;

namespace Jornadas.Test
{
    public class EventsTests
    {
        [Fact]
        public void Should_not_allow_to_create_event_before_current_date()
        {
            Action action = () => ObjectFactory.CreateEvent(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1), DateTime.Now.AddDays(-1));
            action.Should().Throw<DomainException>().WithMessage(CoreStrings.InvalidPastDate);
        }

        [Fact]
        public void Should_not_allow_to_create_event_when_end_date_is_before_begin_date()
        {
            Action action = () => ObjectFactory.CreateEvent(DateTime.Now.AddDays(2), DateTime.Now.AddDays(1), DateTime.Now);
            action.Should().Throw<DomainException>().WithMessage(CoreStrings.InvalidEventEndDate);
        }

        [Fact]
        public void Should_not_allow_to_create_event_when_registration_date_is_before_begin_or_end_date()
        {
            Action action = () => ObjectFactory.CreateEvent(DateTime.Now.AddDays(2), DateTime.Now.AddDays(1), DateTime.Now);
            action.Should().Throw<DomainException>().WithMessage(CoreStrings.InvalidEventRegistrationDate);
        }

        [Fact]
        public void Should_not_allow_to_change_dates_in_event_in_course()
        {
            var provider = new CustomDateTimeProvider(DateTime.Now);
            var myEvent = ObjectFactory.CreateEvent(DateTime.Now.AddDays(2), DateTime.Now.AddDays(4), DateTime.Now, provider);

            provider.Now = DateTime.Now.AddDays(3);

            Action action = () => myEvent.ChangeBeginDate(DateTime.Now.AddDays(3));
            action.Should().Throw<EventInCourseException>();

            action = () => myEvent.EndDate = DateTime.Now.AddDays(3);
            action.Should().Throw<EventInCourseException>();

            action = () => myEvent.RegistrationAvaliableSince = DateTime.Now.AddDays(1);
            action.Should().Throw<EventInCourseException>();
        }

        [Fact]
        public void Should_not_allow_to_change_begin_date_when_end_date_is_before_begin_date()
        {
            var myEvent = ObjectFactory.CreateEvent(DateTime.Now.AddDays(2), DateTime.Now.AddDays(4), DateTime.Now);

            Action action = () => myEvent.ChangeBeginDate(DateTime.Now);
            action.Should().Throw<DomainException>().WithMessage(CoreStrings.InvalidEventEndDate);

        }

        [Fact]
        public void Should_not_allow_to_change_registration_date_after_current_date()
        {

        }

        [Fact]
        public void Should_allow_to_change_begin_date_when_event_has_not_begin()
        {

        }

        [Fact]
        public void Should_allow_to_change_registration_data_when_event_has_not_begin_and_there_are_no_partakers()
        {

        }
    }
}
