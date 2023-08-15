using Application.Activities;
using AutoMapper;
using Domain;
using MediatR;
using MockQueryable.Moq;
using Moq;
using Persistence;

namespace Application.Tests.Tests
{
    public class CreateTests : TestBase
    {
        public CreateTests(SetupFixture fixture) : base(fixture) 
        {
        }

        [Fact]
        public async void Create()
        {
            // Arrange
            Activity act = new Activity() { Id = new Guid(), Title = "Test new activity", Category = "CS", City = "Pune", Venue = "Pune", Description = "description", Date = DateTime.Now };
            
            // Act
            var result = await activityService.CreateAsync(act);

            // Assert
            Assert.True(applicationDbContext.Activities.Any(a => a.Id == act.Id));
        }

        /// <summary>
        /// mock DB
        /// </summary>
        [Fact]
        public async void GetActivityById()
        {
            // Arrange 
            List<Activity> activities = new List<Activity>()
            {
                new Activity()
                {
                    Id = Guid.NewGuid(),
                    Title = "Moc Test1",
                    Category = "Moc test1 category",
                    City = "Pune",
                    Venue = "Pune",
                    Description = "Test moc description",
                    Date = DateTime.Now,
                    SubActivities = new List<SubActivity>()
                    {
                        new SubActivity()
                        {
                            Id = Guid.NewGuid(),
                            SubTitle = "SubActivity Title 1"
                        }
                    }
                },
                new Activity()
                {
                    Id = Guid.NewGuid(),
                    Title = "Moc Test2",
                    Category = "Moc test2 category",
                    City = "Pune",
                    Venue = "Pune",
                    Description = "Test moc description",
                    Date = DateTime.Now
                },
                new Activity()
                {
                    Id = Guid.NewGuid(),
                    Title = "Moc Test3",
                    Category = "Moc test3 category",
                    City = "Pune",
                    Venue = "Pune",
                    Description = "Test moc description",
                    Date = DateTime.Now
                }
            };

            var activity = activities.Last();

            var mockContext = new Mock<IDataContext>();
            var mockset = activities.AsQueryable().BuildMockDbSet();
            mockContext.Setup(c => c.Activities).Returns(mockset.Object);

            Details.Handler handler = new Details.Handler(mockContext.Object);

            //Act 
            var result = await handler.Handle(new Details.Query() { Id = activity.Id }, CancellationToken.None);

            //Assert 
            Assert.Equal(result.Title, activity.Title);
        }

    }
}
