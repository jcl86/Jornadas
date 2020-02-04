using System;

namespace Jornadas.Domain
{
    public class BeginDate
    {
        private DateTime beginDate;
        private readonly IDateTimeProvider dateTimeProvider;

        public bool HasBegun() => beginDate > dateTimeProvider.Now;
        public bool IsFuture(DateTime potentialFutureDate) => beginDate < potentialFutureDate;
        public bool IsPast(DateTime potentialPastDate) => beginDate > potentialPastDate;

        public void Change(DateTime newDate)
        {
            if (HasBegun())
                throw new EventInCourseException(CoreStrings.EventInCourse);
            beginDate = newDate;
        }

        public BeginDate(DateTime beginDate, IDateTimeProvider dateTimeProvider)
        {
            Ensure.That<DomainException>(beginDate > dateTimeProvider.Now, CoreStrings.InvalidPastDate);

            this.beginDate = beginDate;
            this.dateTimeProvider = dateTimeProvider;
        }

        public int Year => beginDate.Year;
        public override string ToString() => beginDate.ToShortDateString();
        public string ToCompleteString() => $"{beginDate.ToShortDateString()} - {beginDate.ToShortTimeString()}";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Event)obj;
            return ToString().ToUpper().Trim().Equals(other.ToString().Trim());
        }
        public override int GetHashCode() => ToString().GetHashCode();
    }
}
