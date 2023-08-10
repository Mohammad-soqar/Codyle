using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
using CodyleOfficial.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodyleOffical.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<UserInformation> UserInformations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CompType> CompTypes { get; set; }
        public DbSet<ApplicationCompany> ApplicationCompanies{ get; set; }
        public DbSet<ShoppingCart> ShoppingCarts{ get; set; }
    
        public DbSet<Services> Service { get; set; }
        public DbSet<BlogCart> Blogcarts { get; set; }
        public DbSet<Attendence> Attendences { get; set; }
        public DbSet<ClubMembers> ClubMember { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<EventLike> EventLike { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ...
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Event>()
                .HasMany(e => e.Sponsor)
                .WithMany(s => s.Events)
                .UsingEntity(join => join.ToTable("EventSponsors"));

        modelBuilder.Entity<Event>()
               .HasMany(e => e.Speakers)
               .WithMany(s => s.Events)// Assumes ApplicationCompany has a navigation property to Event as well
               .UsingEntity(join => join.ToTable("EventSpeakers")); // Replace "EventSponsors" with your join table name

            // ...
        }

    }
}
