using System;
using System.Collections.Generic;
using System.Linq;

namespace Jornadas.Domain
{
    public class Event
    {
        private readonly string name;
        private readonly IDateTimeProvider dateTimeProvider;

        public int Year => BeginDate.Year;

        public BeginDate BeginDate { get; }
        public void ChangeBeginDate(DateTime newBeginDate) => BeginDate.Change(newBeginDate);

        private DateTime endDate;
        public DateTime EndDate
        {
            get => endDate;
            set
            {
                Ensure.That<DomainException>(!BeginDate.IsFuture(value), CoreStrings.InvalidEventEndDate);

                if (IsHappeningNow())
                    throw new EventInCourseException(CoreStrings.EventInCourse);

                endDate = value;
            }
        }

        private DateTime registrationAvaliableSince;
        public DateTime RegistrationAvaliableSince
        {
            get => registrationAvaliableSince;
            set
            {
                if (value < dateTimeProvider.Now)
                    throw new DomainException(CoreStrings.InvalidPastDate);

                Ensure.That<DomainException>(!BeginDate.IsPast(value), CoreStrings.InvalidEventRegistrationDate);

                if (IsHappeningNow())
                    throw new EventInCourseException(CoreStrings.EventInCourse);

                if (audience.HasRegistrations())
                    throw new DomainException(CoreStrings.AlreadyRegistrations);

                registrationAvaliableSince = value;
            }
        }

        private readonly List<Place> places;
        public Place MainPlace => places.First(x => x.IsMainPlace);
        public void AddSecondaryPlace(string name, Coordinates coordinates = null, string description = null)
        {
            if (places.Any(x => x.ToString().ToUpper().Equals(name.ToUpper())))
                throw new DomainException(CoreStrings.PlaceWithSameName);

            places.Add(Place.CreateSecondaryPlace(name, coordinates ?? MainPlace.Coordinates, description));
        }

        private readonly Audience audience;
        public Assistant RegisterAssistant(User user) => audience.RegisterAssistant(user);
        public Organizer RegisterOrganizer(User user, Institution institution) => audience.RegisterOrganizer(user, institution);

        public Event(string name, DateTime beginDate, DateTime endDate, DateTime registrationAvaliable, 
            string mainPlaceName, Coordinates coordenates, string placeDescription, IDateTimeProvider dateTimeProvider)
        {
            this.name = name;
            this.dateTimeProvider = dateTimeProvider;
            BeginDate = new BeginDate(beginDate, dateTimeProvider);

            EndDate = endDate;
            RegistrationAvaliableSince = registrationAvaliable;
            
            places = new List<Place>() { Place.CreateMainPlace(mainPlaceName, coordenates, placeDescription) };
            audience = new Audience();
        }

        public bool IsHappeningNow() => BeginDate.HasBegun() && EndDate < dateTimeProvider.Now;
        
        public override string ToString() => $"{name} {Year}";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Event)obj;
            return ToString().ToUpper().Trim().Equals(other.ToString().Trim());
        }
        public override int GetHashCode() => ToString().GetHashCode();
    }
}
