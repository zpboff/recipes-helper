namespace Recipes.API.App.Models;

public class OperationResult<TValue>
{
    public OperationStatus Status { get; set; }
    public TValue? Value { get; set; }
    public object? Errors { get; set; }

    public static OperationResult<TValue> Some(TValue value) => new()
    {
        Status = OperationStatus.Ok,
        Value = value
    };

    public static OperationResult<TValue> None(OperationStatus status, object? errors = null) => new()
    {
        Status = status,
        Errors = errors
    };
}