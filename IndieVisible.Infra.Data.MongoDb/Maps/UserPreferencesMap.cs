using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public static class UserPreferencesMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<UserPreferences>(map =>
            {
                map.AutoMap();
            });
        }
    }
}