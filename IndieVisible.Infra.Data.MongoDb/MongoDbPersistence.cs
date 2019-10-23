using IndieVisible.Infra.Data.MongoDb.Maps;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Infra.Data.MongoDb
{
    public class MongoDbPersistence
    {
        public static void Configure()
        {
            EntityBaseMap.Configure();
            UserProfileMap.Configure();
            GameMap.Configure();
            UserProfileExternalLinkMap.Configure();

            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            var conventionPack = new ConventionPack
                {
                    new IgnoreIfDefaultConvention(true),
                    new IgnoreExtraElementsConvention(true),
                    new CamelCaseElementNameConvention(),
                    new EnumRepresentationConvention(BsonType.String)
                };
            ConventionRegistry.Register("IndieVisibleConventions", conventionPack, t => true);
        }
    }
}
