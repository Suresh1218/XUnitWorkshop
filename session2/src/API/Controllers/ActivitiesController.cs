
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly IActivityService _activityService;
        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _activityService.GetActivitiesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _activityService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await _activityService.CreateAsync(activity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            await _activityService.UpdateAsync(activity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            await _activityService.DeleteAsync(id);
            return Ok();
        }
    }
}