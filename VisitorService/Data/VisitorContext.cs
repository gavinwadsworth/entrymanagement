using Microsoft.EntityFrameworkCore;
using VisitorService.Models;

namespace VisitorService.Data
{
    public class VisitorContext : DbContext
    {
        public VisitorContext(DbContextOptions<VisitorContext> options) : base (options)
        {

        }

        public DbSet<Visitor> Visitors { get; set; }
        //public DbSet<VisitorImage> VisitorImages { get; set; }
    }
}
