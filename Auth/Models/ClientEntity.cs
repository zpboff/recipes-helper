using IdentityServer4.Models;

namespace Auth.Models;

public class ClientEntity: Client
{
    public string Id { get; set; }
}