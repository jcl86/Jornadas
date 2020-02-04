using System;
using System.Drawing;

namespace Jornadas.Domain
{
    public class Institution
    {
        public string Name { get; }
        public string OfficialName { get; }
        public byte[] Logo { get; }
        public string Location { get; }

        public Institution(string name, string location, string officialName = null, byte[] logo = null)
        {
            Ensure.NotNullOrEmpty(name, $"{nameof(name)} can not be empty");
            Ensure.NotNullOrEmpty(location, $"{nameof(location)} can not be empty");

            Name = name;
            OfficialName = officialName;
            Logo = logo;
            Location = location;
        }
    }
}
