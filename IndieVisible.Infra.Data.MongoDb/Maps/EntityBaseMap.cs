using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public class EntityBaseMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Entity>(map =>
            {
                map.AutoMap();
                map.SetIsRootClass(true);
                map.MapIdMember(x => x.Id).SetIdGenerator(GuidGenerator.Instance);
                map.AddKnownType(typeof(UserProfile));
                map.AddKnownType(typeof(Game));
                map.AddKnownType(typeof(UserProfileExternalLink));
            });
        }
    }
}
