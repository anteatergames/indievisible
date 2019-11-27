using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public static class GamificationMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Gamification>(map =>
            {
                map.AutoMap();
            });
        }
    }
}