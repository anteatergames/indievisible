using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public class BrainstormMap
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
