using Domain;
using MediatR;
using AutoMapper;
using Persistence;

public class EditActivity
{
    public class Command : IRequest
    {
        public required Activity Activity { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync(request.Activity.Id);
            if (activity == null) throw new Exception("Activity not found");
            // activity.Title = request.Activity.Title;
            // activity.Description = request.Activity.Description;
            // activity.Date = request.Activity.Date;
            // activity.Category = request.Activity.Category;
            // activity.City = request.Activity.City;
            // activity.Venue = request.Activity.Venue;
            // activity.Latitude = request.Activity.Latitude;
            // activity.Longitude = request.Activity.Longitude;
            // activity.IsCancelled = request.Activity.IsCancelled;

            mapper.Map(request.Activity, activity);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}