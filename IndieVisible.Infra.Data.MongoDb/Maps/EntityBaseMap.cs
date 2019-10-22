using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;
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
                map.MapIdMember(x => x.Id);
                map.AddKnownType(typeof(UserProfile));
            });
        }
    }
}
