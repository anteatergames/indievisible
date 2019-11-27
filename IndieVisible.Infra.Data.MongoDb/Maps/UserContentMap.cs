using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public class UserContentMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<UserContent>(map =>
            {
                map.AutoMap();
                map.MapMember(x => x.Content).SetIsRequired(true);
            });
        }
    }
}