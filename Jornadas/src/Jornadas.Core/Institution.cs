using System;
using System.Drawing;

namespace Jornadas.Core
{
    public class Institution
    {
        public string Name { get; }
        public string OfficialName { get; }
        public Image Logo { get; }
        public string Location { get; }

        public Institution(string name, string location, string officialName = null, Image logo = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} can not be empty");

            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException($"{nameof(location)} can not be empty");

            Name = name;
            OfficialName = officialName;
            Logo = logo;
            Location = location;
        }
    }
}
