using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CBIB.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
