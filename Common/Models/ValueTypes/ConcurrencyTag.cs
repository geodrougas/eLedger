using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.ValueTypes
{
    public class ConcurrencyTag
    {
        [ConcurrencyCheck]
        public Guid ConcurrencyToken { get; set; }

        public void Renew()
        {
            ConcurrencyToken = Guid.NewGuid();
        }
    }
}
