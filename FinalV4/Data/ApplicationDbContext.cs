using FinalV4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalV4.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext() : base()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<City>()
              .HasMany(c => c.DepartingFlights)
              .WithOne(f => f.DepartureCity)
              .HasForeignKey(f => f.DepartureCityId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<City>()
                .HasMany(c => c.ArrivingFlights)
                .WithOne(f => f.ArrivalCity)
                .HasForeignKey(f => f.ArrivalCityId)
                .OnDelete(DeleteBehavior.Restrict);

			//Converting Enums To String in DB
			builder
		   .Entity<Flight>()
		   .Property(d => d.flight_Class)
		   .HasConversion(new EnumToStringConverter<Flight_Class>());

			builder
			 .Entity<Flight>()
			 .Property(d => d.flight_Type)
			 .HasConversion(new EnumToStringConverter<Flight_Type>());

			builder
			.Entity<BookTicket>()
			.Property(d => d.reserve_Seats)
			.HasConversion(new EnumToStringConverter<Reserve_seats>());







			builder.Entity<ApplicationUser>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");

            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");

            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }



        public DbSet<City> Cities { get; set; }

        public DbSet<BookTicket> BookTickets { get; set; }
    }
}