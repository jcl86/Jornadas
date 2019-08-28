using System;

namespace Jornadas.Core
{
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
