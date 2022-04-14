using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Models;
using Auth.Settings;
using Core.MongoDb;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Mapster;
using MongoDB.Driver;

namespace Auth.Stores;

public class GrantsStore : IPersistedGrantStore
{
    private readonly IMongoCollection<PersistedGrantEntity> _grantsCollection;

    public GrantsStore(IMongoFactory mongoFactory, AuthMongoSettings settings)
    {
        _grantsCollection = mongoFactory.GetDataBase(settings)
            .GetCollection<PersistedGrantEntity>(settings.GrantsCollectionName);
    }

    public async Task StoreAsync(PersistedGrant grant)
    {
        var grantEntity = grant.Adapt<PersistedGrantEntity>();
        grantEntity.Id = Guid.NewGuid().ToString();
        
        await _grantsCollection.InsertOneAsync(grantEntity);
    }

    public async Task<PersistedGrant> GetAsync(string key)
    {
        var grantEntity = await _grantsCollection.Find(GetKeyFilter(key)).FirstAsync();

        return grantEntity.Adapt<PersistedGrant>();
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
    
    private FilterDefinition<PersistedGrantEntity> GetKeyFilter(string key)
    {
        return Builders<PersistedGrantEntity>.Filter.Eq(g => g.Key, key);
    }
    
    private FilterDefinition<PersistedGrantEntity> GetComplexFilter(PersistedGrantFilter filter)
    {
        return Builders<PersistedGrantEntity>.Filter.And(
            Builders<PersistedGrantEntity>.Filter.Eq(g => g.Type, filter.Type),
            Builders<PersistedGrantEntity>.Filter.Eq(g => g.ClientId, filter.ClientId),
            Builders<PersistedGrantEntity>.Filter.Eq(g => g.SessionId, filter.SessionId),
            Builders<PersistedGrantEntity>.Filter.Eq(g => g.SubjectId, filter.SubjectId)
        );
    }
}