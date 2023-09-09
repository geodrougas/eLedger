using Common.Interfaces.Tools;

namespace Common.Models.ValueTypes
{
    public class Timestamp
    {
        public DateTimeOffset Date { get; set; }
        public Guid User { get; set; }

        public Timestamp(DateTimeOffset date, Guid user)
        {
            Date = date;
            User = user;
        }

        public void Update(
            IDateTimeProvider dateTimeProvider, Guid user)
        {
            Date = dateTimeProvider.Now;
            User = user;
        }

        public static Timestamp NewTimestamp(
            IDateTimeProvider dateTimeProvider, Guid user)
        {
            return new Timestamp(dateTimeProvider.Now, user);
        }
    }
}