using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Concrete
{
    public class EFRestaurantDbContext : DbContext
    {
        public EFRestaurantDbContext()
            :base("name=RestaurantConnection")
        { }

        public virtual DbSet<Gallery> Gallery { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<MenuCategory> MenuCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasKey(k => k.Id);
            modelBuilder.Entity<Reservation>().Property(p => p.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Reservation>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Reservation>().Property(p => p.NumberOfGuests).IsRequired();
            modelBuilder.Entity<Reservation>().Property(p => p.PhoneNumber).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Reservation>().Property(p => p.Term).IsRequired();
            modelBuilder.Entity<Reservation>().Property(p => p.Arrived).IsOptional();

            modelBuilder.Entity<Gallery>().HasKey(k => k.Id);
            modelBuilder.Entity<Gallery>().Property(p => p.Position).IsRequired();
            modelBuilder.Entity<Gallery>().Property(p => p.Image).IsRequired();
            modelBuilder.Entity<Gallery>().Property(p => p.ImageMimeType).IsOptional().HasMaxLength(50);
            
            modelBuilder.Entity<MenuCategory>().HasKey(k => k.Id);
            modelBuilder.Entity<MenuCategory>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<MenuCategory>().Property(p => p.Position).IsRequired();

            modelBuilder.Entity<Dish>().HasKey(k => k.Id);
            modelBuilder.Entity<Dish>().Property(p => p.Name).IsRequired().HasMaxLength(70);
            modelBuilder.Entity<Dish>().Property(p => p.Photo).IsOptional();
            modelBuilder.Entity<Dish>().Property(p => p.Position).IsRequired();
            modelBuilder.Entity<Dish>().Property(p => p.Price).IsRequired().HasPrecision(16, 2);
            modelBuilder.Entity<Dish>().Property(p => p.Description).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Dish>().Property(p => p.PhotoMimeType).IsOptional().HasMaxLength(50);

            modelBuilder.Entity<MenuCategory>().HasMany(m => m.Dishes).WithRequired(r => r.MenuCategory).
                                                HasForeignKey(f => f.MenuCatId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
