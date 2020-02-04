using Jornadas.Domain;
using System;

namespace Jornadas.Test
{
    public class CustomDateTimeProvider : IDateTimeProvider
    {
        public DateTime Today { get; set; }
        public DateTime Now { get; set; }

        public CustomDateTimeProvider(DateTime value)
        {
            Today = value;
            Now = value;
        }       
    }
}
