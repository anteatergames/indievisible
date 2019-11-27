using MongoDB.Driver;
using System;

namespace IndieVisible.Infra.Data.MongoDb
{
    public interface IMongoService
    {
        IMongoCollection<T> GetCollection<T>(Action<IMongoCollection<T>> action);
    }
}