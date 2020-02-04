using System;

namespace Jornadas.Domain
{
    public interface IDateTimeProvider
    {
        DateTime Today { get; }
        DateTime Now { get; }
    }
}
