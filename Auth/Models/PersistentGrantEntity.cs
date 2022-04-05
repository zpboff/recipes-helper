using IdentityServer4.Models;

namespace Auth.Models;

public class PersistedGrantEntity: PersistedGrant
{
    public string Id { get; set; }
}