using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public class TeamMap
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
                map.MapMember(x => x.Name).SetIsRequired(true);
            });
        }
    }
}
