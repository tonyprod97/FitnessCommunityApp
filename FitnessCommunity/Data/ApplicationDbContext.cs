using FitnessCommunity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCommunity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            
        }

        public DbSet<WeightLog> WeightLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users").HasMany(u => u.WeightLogs).WithOne(wl => wl.User);

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser()
                {
                    Id = "2204dae4-6cb2-4dbd-aac8-972d486ed767",
                    Email = "ana.anic@gmail.com",
                    NormalizedEmail = "ana.anic@gmail.com".ToUpper(),
                    UserName = "ana.anic@gmail.com",
                    NormalizedUserName = "ana.anic@gmail.com".ToUpper(),
                    PasswordHash = "AQAAAAEAACcQAAAAELDDBjldTca23egUkVYyY+T1RPphJETIEqcDq142PV6dR2hy4Zbu0d7VHlmzZDVrOg==",//Password is: Testing1!
                    FirstName = "Ana",
                    LastName = "Anic",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new ApplicationUser()
                {
                    Id = "a5ee4b19-904d-4834-9faf-3074b29c6551",
                    Email = "pero.peric@gmail.com",
                    NormalizedEmail = "pero.peric@gmail.com".ToUpper(),
                    UserName = "pero.peric@gmail.com",
                    NormalizedUserName = "pero.peric@gmail.com".ToUpper(),
                    PasswordHash = "AQAAAAEAACcQAAAAELDDBjldTca23egUkVYyY+T1RPphJETIEqcDq142PV6dR2hy4Zbu0d7VHlmzZDVrOg==",//Password is: Testing1!
                    FirstName = "Pero",
                    LastName = "Peric",
                    SecurityStamp = Guid.NewGuid().ToString()
                }
                );
            builder.Entity<WeightLog>().ToTable("Logs").HasOne(wl => wl.User).WithMany(u => u.WeightLogs).OnDelete(DeleteBehavior.Cascade);

            for (int i = 0; i < 10; i++)
            {
                builder.Entity<WeightLog>().HasData(
                new WeightLog()
                {
                    Id = Guid.NewGuid(),
                    UserId = "a5ee4b19-904d-4834-9faf-3074b29c6551",
                    WeightValue = 80 + i,
                    LogDate = DateTime.Now.AddDays(i)
                });
            }

            for (int i = 0; i < 10; i++)
            {
                builder.Entity<WeightLog>().HasData(
                new WeightLog()
                {
                    Id = Guid.NewGuid(),
                    UserId = "2204dae4-6cb2-4dbd-aac8-972d486ed767",
                    WeightValue = 80 + i,
                    LogDate = DateTime.Now.AddDays(i)
                });
            }
            
        }

    }
}
