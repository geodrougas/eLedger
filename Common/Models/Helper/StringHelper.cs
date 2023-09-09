using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Helper
{
    public static class StringHelper
    {
        public static long? ToLong(this string? text)
        {
            if (long.TryParse(text, out var value)) 
                return value;

            return null;
        }
    }
}
