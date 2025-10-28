
using Microsoft.EntityFrameworkCore;
using OmuzgorServise.Model;
using System.Text.RegularExpressions;

namespace OmuzgorServise.Data
{
    public class OmuzgorDbContext:DbContext
    {
        public OmuzgorDbContext(DbContextOptions<OmuzgorDbContext> options) : base(options) { }

        public DbSet<Omuzgor> Omuzgoron { get; set; }
        public DbSet<Daraja> Daraja { get; set; }
        public DbSet<Unvon> Unvon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Omuzgor>()
                .HasOne(g => g.Daraja)
                .WithMany(f => f.Omuzgoron)
                .HasForeignKey(g => g.IdDaraja);

            modelBuilder.Entity<Omuzgor>()
                .HasOne(s => s.Unvon)
                .WithMany(g => g.Omuzgoron)
                .HasForeignKey(s => s.IdUnvon);
        }
    }
}
