namespace EventService.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly EventsRepository _repository;

    public Worker(ILogger<Worker> logger, EventsRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            
            await _repository.Create(new EventEntity
            {
                Key = "Test",
                AppName = "EventService.Worker",
                EventDate = DateTimeOffset.Now.UtcDateTime
            });
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}