﻿using System.Threading.Tasks;
using Auth.Settings;
using Core.MongoDb;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using MongoDB.Driver;

namespace Auth.Stores
{
    public class ClientsStore: IClientStore
    {
        private readonly IMongoCollection<Client> _clientsCollection;

        public ClientsStore(IMongoFactory mongoFactory, AuthMongoSettings settings)
        {
            _clientsCollection = mongoFactory.GetDataBase(settings.ConnectionString, settings.Database)
                .GetCollection<Client>(settings.ClientsCollectionName);
        }
        
        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var filter = Builders<Client>.Filter.Eq(c => c.ClientId, clientId);

            return await _clientsCollection.Find(filter).FirstAsync();
        }
    }
}