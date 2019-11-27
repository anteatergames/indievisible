using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public static class BrainstormMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<BrainstormSession>(map =>
            {
                map.AutoMap();
                map.MapMember(x => x.Type).SetIsRequired(true);
            });

            BsonClassMap.RegisterClassMap<BrainstormIdea>(map =>
            {
                map.AutoMap();
            });
        }
    }
}