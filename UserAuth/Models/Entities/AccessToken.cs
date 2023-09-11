using Common.Interfaces.Tools;
using Common.Models.ValueTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Models.Entities
{
    public class AccessToken
    {
        public Guid Id { get; set; }
        public string DeviceDescription { get; set; }
        public Timestamp Creation { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }

        public AccessToken(
            Guid id,
            string deviceDescription,
            Timestamp creation,
            DateTimeOffset expirationDate)
        {
            Id = id;
            DeviceDescription = deviceDescription;
            Creation = creation;
            ExpirationDate = expirationDate;
        }

        public static AccessToken GenerateAccessToken(IDateTimeProvider dateTimeProvider, long expirationSeconds, User user, string device)
        {
            return new AccessToken(
                Guid.NewGuid(),
                device,
                Timestamp.NewTimestamp(dateTimeProvider, user.Id),
                dateTimeProvider.Now.AddSeconds(expirationSeconds)
            );
        }
    }
}
