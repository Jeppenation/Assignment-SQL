using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public partial class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public virtual DbSet<UsersEntity> Users { get; set; }
        public virtual DbSet<UserAddressesEntity> UserAddresses { get; set; }
        public virtual DbSet<UserAuthenticationsEntity> UserAuthentications { get; set; }
        public virtual DbSet<AddressesEntity> Addresses { get; set; }
        public virtual DbSet<UserProfilesEntity> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Unique keys
            
            modelBuilder.Entity<UserProfilesEntity>().
                HasIndex(u => u.UserId).
                IsUnique();

            modelBuilder.Entity<UserAuthenticationsEntity>().
                HasIndex(u => u.Email).
                IsUnique();

            //Composite key
            modelBuilder.Entity<UserAddressesEntity>().
                HasKey(u => new { u.UserId, u.AddressId });

            modelBuilder.Entity<UserAddressesEntity>().
                HasOne(u => u.User).
                WithMany(u => u.UserAddresses).
                HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserAddressesEntity>().
                HasOne(u => u.Address).
                WithMany(u => u.UserAddresses).
                HasForeignKey(u => u.AddressId);
        }

    }
}

