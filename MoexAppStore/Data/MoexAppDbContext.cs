using Microsoft.EntityFrameworkCore;
using MoexAppStore.Models;

namespace MoexAppStore.Data
{
    public class MoexAppDbContext : DbContext
    {
        public MoexAppDbContext(DbContextOptions<MoexAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>(entity => {
                entity.ToTable("profile");
                entity.Property(e => e.ProfileId)
                    .HasColumnType("bigint")
                    .UseSqlServerIdentityColumn();
                entity.Property(e => e.Username)
                    .HasColumnType("varchar(512)");
                entity.Property(e => e.Login)
                    .HasColumnType("varchar(512)");
                entity.Property(e => e.Password)
                    .HasColumnType("varchar(512)");
            });
        }

        public virtual DbSet<Profile> Profiles { get; set; }
    }
}