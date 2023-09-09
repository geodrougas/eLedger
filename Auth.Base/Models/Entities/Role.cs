using Microsoft.AspNetCore.Identity;

namespace Auth.Base.Models.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public bool IsBase { get; set; }
    }
}