using Microsoft.AspNetCore.Identity;

namespace JobPortal.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add custom properties if needed (e.g., public string FullName { get; set; })
        public string Name { get; set; }
    }
}
