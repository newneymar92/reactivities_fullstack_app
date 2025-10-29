using Application.Activities.Commands;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
  // GET: api/activities
  [HttpGet]
  public async Task<ActionResult<List<Activity>>> GetActivities()
  {
    // var activities = await context.Activities.ToListAsync();
    // return Ok(activities);
    return await Mediator.Send(new GetActivityList.Query());
  }

  // GET: api/activities/1
  [HttpGet("{id}")]
  public async Task<ActionResult<Activity>> GetActivityDetail(string id)
  {
    // var activity = await context.Activities.FindAsync(id);
    // if (activity == null) return NotFound();
    // return Ok(activity);
    return await Mediator.Send(new GetActivityDetails.Query { Id = id });
  }

  // POST: api/activities
  [HttpPost]
  public async Task<ActionResult<string>> CreateActivity(Activity activity)
  {
    // var activity = await context.Activities.AddAsync(activity);
    // await context.SaveChangesAsync();
    // return Ok(activity.Id);
    return await Mediator.Send(new CreateActivity.Command { Activity = activity });
  }

  // PUT: api/activities/1
  [HttpPut]
  public async Task<ActionResult> EditActivity(Activity activity)
  {
    await Mediator.Send(new EditActivity.Command { Activity = activity });
    return NoContent();
  }

  // DELETE: api/activities/1
  [HttpDelete("{id}")]
  public async Task<ActionResult> DeleteActivity(string id)
  {
    await Mediator.Send(new DeleteActivity.Command { Id = id });
    return Ok();
  }

}
