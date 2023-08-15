using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Respawn;
using Services;

namespace Application.Tests
{
    public class TestBase : IClassFixture<SetupFixture>
    {
        protected IActivityService activityService { get; }
        protected DataContext applicationDbContext { get; }
        public TestBase(SetupFixture setupFixture)
        {
            this.applicationDbContext = setupFixture.ServiceProvider.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
            this.activityService = setupFixture.ServiceProvider.CreateScope().ServiceProvider.GetRequiredService<IActivityService>();
        }

        public void Dispose()
        {
        }
    }

    [CollectionDefinition("TestBase Collection")]
    public class TestBaseCollection : ICollectionFixture<SetupFixture>
    {
        protected IActivityService activityService { get; }
        protected DataContext applicationDbContext { get; }
        public TestBaseCollection(SetupFixture setupFixture)
        {
            this.applicationDbContext = setupFixture.ServiceProvider.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
            this.activityService = setupFixture.ServiceProvider.CreateScope().ServiceProvider.GetRequiredService<IActivityService>();
        }

        public void Dispose()
        {
        }
    }

    
}
