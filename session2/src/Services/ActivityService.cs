using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Services
{
    public class ActivityService : IActivityService
    {
        private readonly IDataContext _dataContext;
        public ActivityService(IDataContext dbContext) 
        {
            _dataContext = dbContext;
        }
        public async Task<Activity> CreateAsync(Activity activity)
        {
            activity.Date = DateTime.UtcNow;
            _dataContext.Activities.Add(activity);
            await _dataContext.SaveChangesAsync(CancellationToken.None);

            return activity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var activity = await _dataContext.Activities.FindAsync(id);
            _dataContext.Activities.Remove(activity);

            await _dataContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<Activity> GetAsync(Guid id)
        {
            return await _dataContext.Activities.Include(a => a.SubActivities).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Activity>> GetActivitiesAsync()
        {
            return await _dataContext.Activities.Include(a => a.SubActivities).ToListAsync();
        }

        public async Task UpdateAsync(Activity request)
        {
            var activity = await _dataContext.Activities.FindAsync(request.Id);
            activity.Venue = request.Venue;
            activity.City = request.City;
            activity.SubActivities = request.SubActivities;
            activity.Title = request.Title;
            activity.Description = request.Description;
            activity.Category = request.Category;
            activity.Date = request.Date;
          
            await _dataContext.SaveChangesAsync(CancellationToken.None);
        }
    }

    public interface IActivityService
    {
        public Task<Activity> CreateAsync(Activity activity);
        public Task UpdateAsync(Activity activity);
        public Task DeleteAsync(Guid id);
        public Task<Activity> GetAsync(Guid id);
        public Task<List<Activity>> GetActivitiesAsync();
    }
}
