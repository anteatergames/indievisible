using IndieVisible.Domain.Core.Attributes;

namespace IndieVisible.Domain.Core.Enums
{
    public enum BadgeType
    {
        [UiInfo(Order = 0, Display = "Beta Tester", Description = "Helped to test the platform before the launch day")]
        BetaTester = 1,

        [UiInfo(Order = 1, Display = "Loved One", Description = "Loved by everyone")]
        LovedOne = 2,

        [UiInfo(Order = 2, Display = "Conversation Starter", Description = "Usually start good conversations")]
        ConversationStarter = 3,

        [UiInfo(Order = 3, Display = "Talkative", Description = "Comment a lot on posts")]
        Talkative = 4,

        [UiInfo(Order = 4, Display = "Helper", Description = "Helps everyone")]
        Helper = 5,

        [UiInfo(Order = 5, Display = "Jam Fan", Description = "Participates on several game jams")]
        JamFan = 6,

        [UiInfo(Order = 6, Display = "Admin", Description = "Is a System Admin")]
        Admin = 7,

        [UiInfo(Order = 7, Display = "Curator", Description = "Is a Curator for content")]
        Curator = 8,

        [UiInfo(Order = 8, Display = "Babel", Description = "Helped to translate a game")]
        Babel = 9
    }
}