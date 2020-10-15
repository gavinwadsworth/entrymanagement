using APIGateway.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIGateway.Data
{
    public class EMSIdentityContext : IdentityDbContext<EMSUser, EMSRole, int>
    {
        public EMSIdentityContext(DbContextOptions<EMSIdentityContext> options): base (options)
        {

        }
    }
}
