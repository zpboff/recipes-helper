using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Models;
using Auth.Settings;
using Core.MongoDb;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Mapster;
using MongoDB.Driver;

namespace Auth.Stores
{
    public class ResourcesStore: IResourceStore
    {
        private readonly IMongoCollection<ApiScopeEntity> _apiScopesCollection;
        private readonly IMongoCollection<IdentityResourceEntity> _identityResourcesCollection;
        private readonly IMongoCollection<ApiResourceEntity> _apiResourcesCollection;

        public ResourcesStore(IMongoFactory mongoFactory, AuthMongoSettings settings)
        {
            _apiScopesCollection = mongoFactory.GetDataBase(settings.ConnectionString, settings.Database)
                .GetCollection<ApiScopeEntity>(settings.ApiScopesCollectionName);
            _identityResourcesCollection = mongoFactory.GetDataBase(settings.ConnectionString, settings.Database)
                .GetCollection<IdentityResourceEntity>(settings.IdentityResourcesCollectionName);
            _apiResourcesCollection = mongoFactory.GetDataBase(settings.ConnectionString, settings.Database)
                .GetCollection<ApiResourceEntity>(settings.ApiResourcesCollectionName);
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            return Task.FromResult<IEnumerable<IdentityResource>>(Array.Empty<IdentityResource>());
        }

        public async Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            var filter = Builders<ApiScopeEntity>.Filter.Where(x => scopeNames.Contains(x.Name));
            
            return await _apiScopesCollection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var filter = Builders<ApiResourceEntity>.Filter.AnyIn(resource => resource.Scopes, scopeNames);
            
            return await _apiResourcesCollection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            var filter = Builders<ApiResourceEntity>.Filter.Where(x => apiResourceNames.Contains(x.Name));
            
            return await _apiResourcesCollection.Find(filter).ToListAsync();
        }

        public async Task<Resources> GetAllResourcesAsync()
        {
            var apiScopes = await _apiScopesCollection.Find(Builders<ApiScopeEntity>.Filter.Empty).ToListAsync();
            var apiResources = await _apiResourcesCollection.Find(Builders<ApiResourceEntity>.Filter.Empty).ToListAsync();
            var identityResources = await _identityResourcesCollection.Find(Builders<IdentityResourceEntity>.Filter.Empty).ToListAsync();

            return new Resources
            {
                ApiResources = apiResources.Select(r => r.Adapt<ApiResource>()).ToList(),
                ApiScopes = apiScopes.Select(s => s.Adapt<ApiScope>()).ToList(),
                IdentityResources = identityResources.Select(i => i.Adapt<IdentityResource>()).ToList()
            };
        }
    }
}