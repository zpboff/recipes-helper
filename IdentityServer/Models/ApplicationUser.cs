using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace IdentityServer.Models;

[CollectionName("Users")]
public class ApplicationUser: MongoIdentityUser<string>
{
    
}