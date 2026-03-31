using Microsoft.EntityFrameworkCore;
using QuantityMeasurement.Model.Entities;


namespace QuantityMeasurement.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<QuantityMeasurementEntity> QuantityLogs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users {get;set;}
    }
}