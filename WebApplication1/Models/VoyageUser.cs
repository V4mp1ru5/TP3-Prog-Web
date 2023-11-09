using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class VoyageUser: IdentityUser
    {
        public virtual List<Voyage> voyages { get; set; }
    }
}
