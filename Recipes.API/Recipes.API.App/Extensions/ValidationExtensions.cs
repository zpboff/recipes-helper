using FluentValidation.Results;

namespace Recipes.API.App.Extensions;

public static class ValidationExtensions
{
    public static Dictionary<string, List<string>> ToErrorsDictionary(this ValidationResult validationResult)
    {
        var errors = new Dictionary<string, List<string>>();
        
        if (validationResult.IsValid)
        {
            return errors;
        }

        return validationResult.Errors.Aggregate(errors, (acc, error) =>
        {
            if (!errors.ContainsKey(error.PropertyName))
            {
                errors[error.PropertyName] = new List<string>();
            }
            
            errors[error.PropertyName].Add(error.ErrorMessage);

            return errors;
        });
    }
}