using System.Collections.Generic;
using System.Linq;

namespace Jornadas.Domain
{
    public class Audience
    {
        private readonly List<IPartaker> partakers;

        public Audience()
        {
            partakers = new List<IPartaker>();
        }

        public bool HasRegistrations() => partakers.Any(x => !x.IsOrganizer);
        private int NextNumber => !partakers.Any() ? 1 : partakers.Max(x => x.Number);

        internal Assistant RegisterAssistant(User user)
        {
            var partaker = new Assistant(user.ToString(), user.Email, NextNumber);

            if (IsAlreadyRegistered(partaker))
                throw new DomainException($"{user.ToString()} is already registered");

            partakers.Add(partaker);
            return partaker;
        }

        internal Organizer RegisterOrganizer(User user, Institution institution)
        {
            var partaker = new Organizer(user.ToString(), user.Email, institution, NextNumber);

            if (IsAlreadyRegistered(partaker))
                throw new DomainException($"{user.ToString()} is already registered");

            partakers.Add(partaker);
            return partaker;
        }

        private bool IsAlreadyRegistered(IPartaker user) => partakers.Contains(user);
        
    }
}
