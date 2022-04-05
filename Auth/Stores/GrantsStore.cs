using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Settings;
using Core.MongoDb;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using MongoDB.Driver;

namespace Auth.Stores;

public class GrantsStore : IPersistedGrantStore
{
    private readonly IMongoCollection<PersistedGrant> _grantsCollection;


    public GrantsStore(IMongoFactory mongoFactory, AuthMongoSettings settings)
    {
        _grantsCollection = mongoFactory.GetDataBase(settings.ConnectionString, settings.Database)
            .GetCollection<PersistedGrant>(settings.GrantsCollectionName);
    }

    public async Task StoreAsync(PersistedGrant grant)
    {
        await _grantsCollection.InsertOneAsync(grant);
    }

    public Task<PersistedGrant> GetAsync(string key)
    {
        return _grantsCollection.Find(GetKeyFilter(key)).FirstAsync();
    }

    public async Task<IEnumerable<PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
    {
        return await _grantsCollection.Find(GetComplexFilter(filter)).ToListAsync();
    }

    public Task RemoveAsync(string key)
    { 
        return _grantsCollection.DeleteOneAsync(GetKeyFilter(key));
    }

    public Task RemoveAllAsync(PersistedGrantFilter filter)
    {
        return _grantsCollection.DeleteManyAsync(GetComplexFilter(filter));
    }
    
    private FilterDefinition<PersistedGrant> GetKeyFilter(string key)
    {
        return Builders<PersistedGrant>.Filter.Eq(g => g.Key, key);
    }
    
    private FilterDefinition<PersistedGrant> GetComplexFilter(PersistedGrantFilter filter)
    {
        return Builders<PersistedGrant>.Filter.And(
            Builders<PersistedGrant>.Filter.Eq(g => g.Type, filter.Type),
            Builders<PersistedGrant>.Filter.Eq(g => g.ClientId, filter.ClientId),
            Builders<PersistedGrant>.Filter.Eq(g => g.SessionId, filter.SessionId),
            Builders<PersistedGrant>.Filter.Eq(g => g.SubjectId, filter.SubjectId)
        );
    }
}