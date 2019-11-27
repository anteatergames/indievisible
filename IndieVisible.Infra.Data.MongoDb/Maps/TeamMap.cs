using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public static class TeamMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Team>(map =>
            {
                map.AutoMap();
                map.MapMember(x => x.Name).SetIsRequired(true);
            });

            BsonClassMap.RegisterClassMap<TeamMember>(map =>
            {
                map.AutoMap();
            });
        }
    }
}