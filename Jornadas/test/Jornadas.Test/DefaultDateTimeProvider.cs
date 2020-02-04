using Jornadas.Domain;
using System;

namespace Jornadas.Test
{
    public class DefaultDateTimeProvider : IDateTimeProvider
    {
        public DateTime Today => DateTime.Today;
        public DateTime Now => DateTime.Now;
    }
}
