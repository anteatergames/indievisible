using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Models;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Infra.Data.MongoDb.Maps
{
    public class PollVoteMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<PollVote>(map =>
            {
                map.AutoMap();
            });
        }
    }
}
