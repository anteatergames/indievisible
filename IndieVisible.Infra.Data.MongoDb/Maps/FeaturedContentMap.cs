using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public static class FeaturedContentMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<FeaturedContent>(map =>
            {
                map.AutoMap();
            });
        }
    }
}