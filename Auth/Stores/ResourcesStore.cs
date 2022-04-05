using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Settings;
using Core.MongoDb;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using MongoDB.Driver;

namespace Auth.Stores
{
    public class ResourcesStore: IResourceStore
    {
        private readonly IMongoCollection<ApiScope> _apiScopesCollection;
        private readonly IMongoCollection<IdentityResource> _identityResourcesCollection;
        private readonly IMongoCollection<ApiResource> _apiResourcesCollection;

        public ResourcesStore(IMongoFactory mongoFactory, AuthMongoSettings settings)
        {
            _apiScopesCollection = mongoFactory.GetDataBase(settings.ConnectionString, settings.Database)
                .GetCollection<ApiScope>(settings.ApiScopesCollectionName);
            _identityResourcesCollection = mongoFactory.GetDataBase(settings.ConnectionString, settings.Database)
                .GetCollection<IdentityResource>(settings.IdentityResourcesCollectionName);
            _apiResourcesCollection = mongoFactory.GetDataBase(settings.ConnectionString, settings.Database)
                .GetCollection<ApiResource>(settings.ApiResourcesCollectionName);
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            return Task.FromResult<IEnumerable<IdentityResource>>(Array.Empty<IdentityResource>());
        }

        public async Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            var filter = Builders<ApiScope>.Filter.Where(x => scopeNames.Contains(x.Name));
            
            return await _apiScopesCollection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var filter = Builders<ApiResource>.Filter.AnyIn(resource => resource.Scopes, scopeNames);
            
            return await _apiResourcesCollection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            var filter = Builders<ApiResource>.Filter.Where(x => apiResourceNames.Contains(x.Name));
            
            return await _apiResourcesCollection.Find(filter).ToListAsync();
        }

        public async Task<Resources> GetAllResourcesAsync()
        {
            var apiScopes = await _apiScopesCollection.Find(Builders<ApiScope>.Filter.Empty).ToListAsync();
            var apiResources = await _apiResourcesCollection.Find(Builders<ApiResource>.Filter.Empty).ToListAsync();
            var identityResources = await _identityResourcesCollection.Find(Builders<IdentityResource>.Filter.Empty).ToListAsync();

            return new Resources
            {
                ApiResources = apiResources,
                ApiScopes = apiScopes,
                IdentityResources = identityResources
            };
        }
    }
}