using Auth.Base.Models.Entities;
using Common.Interfaces.Tools;
using Common.Models.ValueTypes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.UserAuth.Models.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public Timestamp Creation { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }

        public RefreshToken(
            Guid id,
            string userName,
            Timestamp creation,
            DateTimeOffset expirationDate,
            bool isUsed,
            bool isRevoked)
        {
            Id = id;
            UserName = userName;
            Creation = creation;
            ExpirationDate = expirationDate;
            IsUsed = isUsed;
            IsRevoked = isRevoked;
        }

        public static RefreshToken GenerateToken(IDateTimeProvider dateTimeProvider, long expirationSeconds, User user)
        {
            return new RefreshToken(
                Guid.NewGuid(),
                user.UserName!,
                Timestamp.NewTimestamp(dateTimeProvider, user.Id),
                dateTimeProvider.Now.AddSeconds(expirationSeconds),
                false,
                false
            );
        }
    }
}
