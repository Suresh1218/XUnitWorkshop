using Application.Activities;
using Application.Core;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Services;

namespace Application.Tests
{
    public class SetupFixture
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public SetupFixture()
        {
            _configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json").Build();

            var services = new ServiceCollection();

            services.AddDbContext<IDataContext ,DataContext>(options =>
                   options.UseSqlServer(
                       _configuration.GetConnectionString("DefaultConnection")));

            services.AddHttpClient<IActivityService, ActivityService>();

            services.AddScoped<IConfiguration>((x) => { return _configuration; });
            _serviceProvider = services.BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider { get { return _serviceProvider; } }
        public IConfiguration Configuration { get { return _configuration; } }

        public void Dispose()
        {
            // Do any common cleanup.
        }
    }
}
