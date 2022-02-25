using Microsoft.AspNetCore.Identity;

namespace WebIdentity.Models
{
    public class AppliactionUser:IdentityUser
    {
        public string Name { get; set; }=string.Empty;
        public string? Age { get; set; }
    }
}
