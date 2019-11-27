using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public static class GameMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Game>(map =>
            {
                map.AutoMap();
                map.MapMember(x => x.Title).SetIsRequired(true);
            });
        }
    }
}