namespace Core.Utilities;

public class PossibleError<TStatus, TErrors>
{
    public TStatus Status { get; set; }
    public IEnumerable<TErrors> Errors { get; set; }
}