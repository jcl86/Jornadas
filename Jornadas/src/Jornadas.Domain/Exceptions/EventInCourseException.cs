using System;

namespace Jornadas.Domain
{
    public class EventInCourseException : Exception
    {
        public EventInCourseException(string message) : base(message) { }
    }
}
