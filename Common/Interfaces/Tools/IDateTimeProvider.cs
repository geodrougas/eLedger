using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Tools
{
    public interface IDateTimeProvider
    {
        public DateTimeOffset Now { get; }
    }
}
