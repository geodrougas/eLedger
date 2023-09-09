using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Base.Models.Entities.Criteria
{
    public record struct RoleCriteria(
        bool? IsBase = null
    );
}
