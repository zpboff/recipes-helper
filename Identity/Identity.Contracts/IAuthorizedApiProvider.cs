namespace Identity.Contracts;

public interface IAuthorizedApiProvider<TSettings> where TSettings: IdentitySettings
{
    Task<T?> GetRequestAsync<T>(string url) where T : class;
    Task<TResponse?> PostRequestAsync<TResponse, TRequest>(string url, TRequest? request = null) 
        where TResponse: class 
        where TRequest: class;
}