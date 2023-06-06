using CodyleOffical.Models;
using CodyleOffical.Models.ViewModels;
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
        public DbSet<Sponsor> Sponsors { get; set; }

    }
}
