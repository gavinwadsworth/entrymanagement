using Microsoft.AspNetCore.Identity;

namespace APIGateway.Models
{
    public class EMSUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
