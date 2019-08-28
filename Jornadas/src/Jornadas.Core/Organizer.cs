using System;
using System.Collections.Generic;
using System.Linq;

namespace Jornadas.Core
{
    public class User
    {
        public string Name { get; }
        public string Email { get; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return ((User)obj).Email.Trim().ToUpper().Equals(Email.Trim().ToUpper());
        }

        public override int GetHashCode() => Email.GetHashCode();
    }

    public class Organizer : User, IPartaker
    {
        public int EventId { get; }
        public Institution Institution { get; }

        public Organizer(string name, string email, Institution institution, int eventId) : base(name, email)
        {
            Institution = institution;
            EventId = eventId;
        }
    }

    public class Assistant
    {

    }

    public class Convention
    {
        public string Name { get; }
        public DateTime BeginDate { get; }
        public DateTime EndDate { get; }
        public DateTime RegistrationAvaliableSince { get; }

        public List<Place> Places { get; private set; }
        public Place MainPlace => Places.First();
        public void AddPlace(string name, Coordenates coordinates = null, string description = null) 
            => Places.Add(Place.CreatePlace(name, coordinates ?? MainPlace.Coordenates, description));

        public Convention(string name, DateTime beginDate, DateTime endDate, DateTime registrationAvaliable, 
            string mainPlaceName, Coordenates coordenates, string placeDescription = null)
        {
            Name = name;
            BeginDate = beginDate;
            EndDate = endDate;
            RegistrationAvaliableSince = registrationAvaliable;
            Places = new List<Place>() { new Place(mainPlaceName, coordenates, placeDescription) };
        }
    }
}
