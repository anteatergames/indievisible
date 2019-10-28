using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public class UserProfileMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<UserProfile>(map =>
            {
                map.AutoMap();
                map.MapMember(x => x.Name).SetIsRequired(true);
            });
        }
    }
}
