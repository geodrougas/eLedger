using Common.Interfaces.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Helper
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}
