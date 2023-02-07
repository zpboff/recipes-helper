namespace Core.Utilities;

public struct Maybe<TValue>
{
    public object? Errors { get; set; } 
    public TValue? Value { get; set; }
    public bool IsValid => Errors is null;

    public static Maybe<TValue> Some(TValue value) => new()
    {
        Value = value,
        Errors = null
    };

    public static Maybe<TValue> None(object errors) => new()
    {
        Errors = errors,
        Value = default
    };
}