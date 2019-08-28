using Jornadas.Core;
using System;
using Xunit;

namespace Jornadas.Test
{
    public static class ObjectFactory
    {
        public static Coordenates AnyCoordenates => new Coordenates(42, -2);
        public static Organizer Organizer => new Organizer();
        public static Convention UmbrasParadox => new Convention("Umbras paradox",
            new DateTime(2019, 08, 15, 10, 00, 00),
            new DateTime(2019, 08, 15, 14, 00, 00),
            new DateTime(2019, 06, 15),
            "Frontón principal", );
    }

    public class OrganizingAnEvent
    {
        [Fact]
        public void Organizer_can_create_an_event()
        {
            var organizer = ObjectFactory.Organizer;
            var convention = ObjectFactory.UmbrasParadox;

            convention.
        }
    }
}
