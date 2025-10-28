using Mavzuho.Models;
using Microsoft.EntityFrameworkCore;

namespace Mavzuho.Data
{
    public class MavzuDbContext: DbContext
    {
        public MavzuDbContext(DbContextOptions<MavzuDbContext> options) : base(options) { }
        public DbSet<KatMavzu> KatMavzho { get; set; }
        public DbSet<Mavod> Mavodho { get; set; }
        public DbSet<Mavzu> Mavzuho { get; set; }
        public DbSet<Namud> Namudho { get; set; }
    }
}
