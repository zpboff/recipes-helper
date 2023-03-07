using System.ComponentModel.DataAnnotations.Schema;

namespace EventService.Worker;

[Table("Events")]
public class EventEntity
{
    public Guid Id { get; set; }
    public string AppName { get; set; }
    public string Key { get; set; }
    public DateTime EventDate { get; set; }
}