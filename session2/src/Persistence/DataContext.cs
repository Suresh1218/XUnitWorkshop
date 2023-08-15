using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Persistence
{
    public class DataContext : DbContext, IDataContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DataContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<SubActivity> SubActivities { get; set; }
    }

    public interface IDataContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<SubActivity> SubActivities { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}