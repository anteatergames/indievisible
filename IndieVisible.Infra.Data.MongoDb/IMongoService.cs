using System;
using MongoDB.Driver;

namespace IndieVisible.Infra.Data.MongoDb
{
    public interface IMongoService
    {
        IMongoCollection<T> GetCollection<T>(Action<IMongoCollection<T>> action);
    }
}