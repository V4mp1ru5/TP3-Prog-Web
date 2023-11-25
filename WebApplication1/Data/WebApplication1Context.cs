using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1Context : IdentityDbContext<VoyageUser>
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var hasher = new PasswordHasher<VoyageUser>();
            VoyageUser u1 = new VoyageUser
            {
                // Primary key au format GUID
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "jim@test.com",
                Email = "jim@test.com",
                // La comparaison d'identity se fait avec les versions normalisés
                NormalizedEmail = "JIM@TEST.COM",
                NormalizedUserName = "JIM@TEST.COM"
            };
            // On encrypte le mot de passe
            u1.PasswordHash = hasher.HashPassword(u1, "Passw0rd!");
            builder.Entity<VoyageUser>().HasData(u1);
            builder.Entity<VoyageUser>().HasData(new
            {
                Id = 2,
                Name = "Timothé",
                DemoUserId = "11111111-1111-1111-1111-111111111111"
            });
            builder.Entity<Voyage>().HasData(new
            {
                Id = 1,
                Name = "cancune"
            });
            builder.Entity<Voyage>().HasData(new
            {
                Id = 2,
                Name = "Bahamas"
            });
            builder.Entity<VoyageUser>()
                .HasMany(c => c.Voyages)
                .WithMany(t => t.VoyageUsers)
                .UsingEntity(r => {
                    r.HasData(new { VoyagesId = 1, UsersId = 1 });
                    r.HasData(new { VoyagesId = 2, UsersId = 1 });
                });
        }   

        public DbSet<WebApplication1.Models.Voyage> Voyages { get; set; } = default!;
    }
}
