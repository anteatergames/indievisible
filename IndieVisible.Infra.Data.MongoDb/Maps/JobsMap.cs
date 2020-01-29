using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public static class JobsMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<JobPosition>(map =>
            {
                map.AutoMap();
            });

            BsonClassMap.RegisterClassMap<JobApplicant>(map =>
            {
                map.AutoMap();
            });
        }
    }
}