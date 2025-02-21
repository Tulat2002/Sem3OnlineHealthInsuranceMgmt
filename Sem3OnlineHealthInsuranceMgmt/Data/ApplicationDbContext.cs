using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sem3OnlineHealthInsuranceMgmt.Models;

namespace Sem3OnlineHealthInsuranceMgmt.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Insurance> Insurances { get; set; }
    public DbSet<Company> Companies { get; set; }
    
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<OrderHeader> OrderHeaders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Health insurance", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Life insurance", DisplayOrder = 2 },
            new Category { Id = 3, Name = "Agricultural insurance", DisplayOrder = 3 }
        );
        
        modelBuilder.Entity<Company>().HasData(
            new Company { Id = 1, Name = "Tech Solusion", StreetAddress = "12 Hang Chieu", City = "Ha Noi", State = "IL", PostalCode = "121212", PhoneNumber = "0911604868"},
            new Company { Id = 2, Name = "Open AI", StreetAddress = "43 Vong Ha", City = "Vinh", State = "IL", PostalCode = "328717", PhoneNumber = "0904334323"},
            new Company { Id = 3, Name = "Meta", StreetAddress = "98 Bach Dang", City = "Da Nag", State = "DN", PostalCode = "973525", PhoneNumber = "0911323355"}
        );

        modelBuilder.Entity<Insurance>().HasData(
    new Insurance
    {
        Id = 1,
        Title = "Health insurance",
        ResponsibleUnit = "UnitedHealth Group",
        Description = "Reference site about Lorem Ipsum, giving information on its origins, as well as a random Lipsum generator.",
        ISBN = "SWD9999101",
        ListPrice = 99,
        Price = 90,
        Price50 = 85,
        Price100 = 80,
        CategoryId = 1,
        ImageUrl = "",
    },
    new Insurance
    {
        Id = 2,
        Title = "Life insurance",
        ResponsibleUnit = "AXA",
        Description = "Protect your loved ones with our life insurance plans, ensuring financial stability in case of unforeseen events.",
        ISBN = "LIF9988776",
        ListPrice = 150,
        Price = 140,
        Price50 = 130,
        Price100 = 120,
        CategoryId = 1,
        ImageUrl = "",
    },
    new Insurance
    {
        Id = 3,
        Title = "Car insurance",
        ResponsibleUnit = "Ping An Insurance",
        Description = "Comprehensive car insurance coverage for all types of vehicles, including accident protection and theft coverage.",
        ISBN = "CAR1122334",
        ListPrice = 200,
        Price = 180,
        Price50 = 170,
        Price100 = 160,
        CategoryId = 1,
        ImageUrl = "",
    },
    new Insurance
    {
        Id = 4,
        Title = "Home insurance",
        ResponsibleUnit = "Berkshire Hathaway",
        Description = "Secure your home and belongings against fire, theft, and natural disasters with our trusted insurance policies.",
        ISBN = "HOM4455667",
        ListPrice = 180,
        Price = 170,
        Price50 = 160,
        Price100 = 150,
        CategoryId = 2,
        ImageUrl = "",
    },
    new Insurance
    {
        Id = 5,
        Title = "Travel insurance",
        ResponsibleUnit = "China Life Insurance",
        Description = "Enjoy your travels worry-free with our travel insurance, covering medical emergencies, lost luggage, and trip cancellations.",
        ISBN = "TRV7788990",
        ListPrice = 75,
        Price = 70,
        Price50 = 65,
        Price100 = 60,
        CategoryId = 2,
        ImageUrl = "",
    },
    new Insurance
    {
        Id = 6,
        Title = "Agricultural insurance",
        ResponsibleUnit = "Allianz",
        Description = "Designed for farmers and agribusinesses, providing protection against crop loss due to extreme weather or pests.",
        ISBN = "AGR5566778",
        ListPrice = 130,
        Price = 120,
        Price50 = 110,
        Price100 = 100,
        CategoryId = 3,
        ImageUrl = "",
    }
);

        // modelBuilder.Entity<Insurance>().HasData(
        //     new Insurance { Id = 1, Name = "HealthHappy", Description = "Bảo hiểm cho sức khỏe", DurationInMonths = 1, StartDate = new DateTime(2024, 12, 28), EndDate = new DateTime(2025, 12, 28), IsActive = true },
        //     new Insurance { Id = 2, Name = "LifeHappy", Description = "Bảo hiểm nhân thọ", DurationInMonths = 1, StartDate = new DateTime(2024, 12, 28), EndDate = new DateTime(2025, 12, 28), IsActive = true },
        //     new Insurance { Id = 3, Name = "AgriculturalHappy", Description = "Bảo hiểm nông nghiệp", DurationInMonths = 1, StartDate = new DateTime(2024, 12, 28), EndDate = new DateTime(2025, 12, 28), IsActive = true }
        // );

    }
}