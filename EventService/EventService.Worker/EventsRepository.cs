namespace EventService.Worker;

public class EventsRepository
{
    private readonly EventsDbContext _context;

    public EventsRepository(EventsDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(EventEntity eventEntity)
    {
        _context.Events.Add(eventEntity);
        await _context.SaveChangesAsync();

        return eventEntity.Id;
    }
}