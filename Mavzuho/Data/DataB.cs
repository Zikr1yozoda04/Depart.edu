using Mavzuho.Models;
using Microsoft.EntityFrameworkCore;

namespace Mavzuho.Data
{
    public class DataB: DbContext
    {
        public DataB(DbContextOptions<DataB> options) : base(options) { }
        public DbSet<KatMavz> KatMavzs { get; set; }
        public DbSet<Mavod> Mavods { get; set; }
        public DbSet<Mavzu> Mavzus { get; set; }
        public DbSet<Tip> Tips { get; set; }
    }
}
