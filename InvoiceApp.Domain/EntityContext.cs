using InvoiceApp.Domain.Entity;
using InvoiceApp.Domain.Entity.EnumEntities;
using InvoiceApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;


namespace InvoiceApp.Domain
{
    public class UserContext: DbContext
    {
        public DbSet<UserEntity> Users => Set<UserEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasIndex(x => x.UserName)
                .IsUnique();

            modelBuilder.Entity<UserEntity>()
                 .Property(x => x.UserTypeFK)
                 .HasConversion<int>();

            modelBuilder.Entity<UserTypeEnum>()
                .Property(x=>x.Id)
                .HasConversion<int>();

            modelBuilder.Entity<UserTypeEnum>()
                .HasMany(x=>x.Users)
                .WithOne(x=>x.UserType)
                .HasPrincipalKey(x=>x.Id)
                .HasForeignKey(x=>x.UserTypeFK);

            modelBuilder.Entity<UserTypeEnum>()
                .HasData(
                Enum.GetValues(typeof(EUser))
                .Cast<EUser>()
                .Select(x=> new UserTypeEnum()
                {
                    Id=x,
                    Name=x.ToString()
                })
                );
        }

        public UserContext(DbContextOptions<UserContext> options)
            :base(options)
        {
            
        }

    }

}
