using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public static class TranslationMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<TranslationProject>(map =>
            {
                map.AutoMap();
            });

            BsonClassMap.RegisterClassMap<TranslationTerm>(map =>
            {
                map.AutoMap();
            });

            BsonClassMap.RegisterClassMap<TranslationEntry>(map =>
            {
                map.AutoMap();
            });
        }
    }
}