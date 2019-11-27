using IndieVisible.Infra.Data.MongoDb.Maps;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace IndieVisible.Infra.Data.MongoDb
{
    public class MongoDbPersistence
    {
        public static void Configure()
        {
            ConventionPack conventionPack = new ConventionPack
                {
                    new IgnoreIfDefaultConvention(true),
                    new IgnoreExtraElementsConvention(true),
                    new CamelCaseElementNameConvention(),
                    new EnumRepresentationConvention(BsonType.String)
                };
            ConventionRegistry.Register("IndieVisibleConventions", conventionPack, t => true);

            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            EntityBaseMap.Configure();
            UserProfileMap.Configure();
            GameMap.Configure();
            UserContentMap.Configure();
            UserPreferencesMap.Configure();
            FeaturedContentMap.Configure();
            GamificationActionMap.Configure();
            GamificationLevelMap.Configure();
            GamificationMap.Configure();
            PollMap.Configure();
            BrainstormMap.Configure();
            TeamMap.Configure();
        }
    }
}