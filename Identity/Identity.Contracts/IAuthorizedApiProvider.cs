namespace Identity.Contracts;

public interface IAuthorizedApiProvider
{
    Task<T?> GetRequestAsync<T>(string identityServerUrl, string url) where T : class;
    Task<TResponse?> PostRequestAsync<TResponse, TRequest>(string identityServerUrl, string url, TRequest? request = null) 
        where TResponse: class 
        where TRequest: class;
}