using Jornadas.Domain;
using System;

namespace Jornadas.Test
{
    public static class ObjectFactory
    {
        public static Coordinates Huarte = new Coordinates((Latitude)42.8279805f, (Longitude)(-1.5951363f));
        public static User Francisco => new User("Franxisco de Rojas", "francisco@umbras.com");
        public static Institution AlterParadox => new Institution("Alter paradox", "Pamplona"); 

        public static Event UmbrasParadox => CreateEvent(
            new DateTime(2019, 08, 15, 10, 00, 00), 
            new DateTime(2019, 08, 18, 14, 00, 00),
            new DateTime(2019, 06, 15));

        public static Event CreateEvent(DateTime begin, DateTime end, DateTime registration, IDateTimeProvider provider = null)
        {
            var convention = new Event("Umbras Paradox", begin, end, registration, "Polideportivo Ugarrandia", Huarte,
                "Frontón principal del polideportivo Ugarrandia", provider ?? new DefaultDateTimeProvider());
            return convention;
        }
    }
}
