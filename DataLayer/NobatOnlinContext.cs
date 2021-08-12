using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataLayer
{
    public class NobatOnlineContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NobatOnline;Integrated Security=true;");
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Beauty> Beauties { get; set; }
        public DbSet<BeautyImage> BeautyImages { get; set; }
        public DbSet<CustumerTicket> CustumerTickets { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Work> Works { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasOne(p => p.Province).WithMany(g => g.Cities).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Beauty>().HasOne(p => p.AppUser).WithMany(g => g.Beauties).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Beauty>().HasOne(p => p.City).WithMany(g => g.Beauties).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<BeautyImage>().HasOne(p => p.Beauty).WithMany(g => g.BeautyImages).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Ticket>().HasOne(p => p.Beauty).WithMany(g => g.Tickets).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CustumerTicket>().HasOne(p => p.AppUser).WithMany(g => g.CustumerTickets).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CustumerTicket>().HasOne(p => p.Ticket).WithMany(g => g.CustumerTickets).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CustumerTicket>().HasOne(p => p.Work).WithMany(g => g.CustumerTickets).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Work>().HasOne(p => p.Beauty).WithMany(g => g.Works).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<IdentityUserRole<int>>().HasKey(p => new { p.UserId, p.RoleId });
            modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(p => p.UserId);
            modelBuilder.Entity<IdentityUserToken<int>>().HasKey(p => new { p.UserId });
            
        }
    }
    public class AppUserConfiguring : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class BeautyConfiguring : IEntityTypeConfiguration<Beauty>
    {
        public void Configure(EntityTypeBuilder<Beauty> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class BeautyImageConfiguring : IEntityTypeConfiguration<BeautyImage>
    {
        public void Configure(EntityTypeBuilder<BeautyImage> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class CustumerTicketConfiguring : IEntityTypeConfiguration<CustumerTicket>
    {
        public void Configure(EntityTypeBuilder<CustumerTicket> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class TicketConfiguring : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            throw new NotImplementedException();
        }
    }
    public class WorkConfiguring : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            throw new NotImplementedException();
        }
    }
}
