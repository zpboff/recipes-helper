namespace EventService.Shared;

public class EventDto
{
    public EventDto(string appName, string key, DateTime eventDate)
    {
        AppName = appName;
        Key = key;
        EventDate = eventDate;
    }

    public string AppName { get; private set; }
    public string Key { get; private set; }
    public DateTime EventDate { get; private set; }
}