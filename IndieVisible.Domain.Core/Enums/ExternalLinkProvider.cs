using IndieVisible.Domain.Core.Attributes;

namespace IndieVisible.Domain.Core.Enums
{
    public enum ExternalLinkProvider
    {
        [UiInfo(Display = "Website", Class = "fa fa-link", Type = ExternalLinkType.General)]
        Website = 1,
        [UiInfo(Display = "Facebook", Class = "fab fa-facebook-f", Type = ExternalLinkType.General)]
        Facebook = 2,
        [UiInfo(Display = "Twitter", Class = "fab fa-twitter", Type = ExternalLinkType.General)]
        Twitter = 3,
        [UiInfo(Display = "Instagram", Class = "fab fa-instagram", Type = ExternalLinkType.General)]
        Instagram = 4,
        [UiInfo(Display = "Youtube", Class = "fab fa-youtube", Type = ExternalLinkType.General)]
        Youtube = 5,
        [UiInfo(Display = "XboxLive", Class = "fab fa-xbox", Type = ExternalLinkType.General)]
        XboxLive = 6,
        [UiInfo(Display = "Psn", Class = "fab fa-playstation", Type = ExternalLinkType.General)]
        Psn = 7,
        [UiInfo(Display = "Steam", Class = "fab fa-steam", Type = ExternalLinkType.General)]
        Steam = 8,
        [UiInfo(Display = "Game Jolt", Class = "gamejolt", Type = ExternalLinkType.GameDev)]
        GameJolt = 9,
        [UiInfo(Display = "Itch.io", Class = "itchio", Type = ExternalLinkType.GameDev)]
        ItchIo = 10,
        [UiInfo(Display = "Gamedev.net", Class = "gamedevnet", Type = ExternalLinkType.GameDev)]
        GamedevNet = 11,
        [UiInfo(Display = "IndieDB", Class = "indiedb", Type = ExternalLinkType.GameDev)]
        IndieDb = 12,
        [UiInfo(Display = "Unity Connect", Class = "unityconnect", Type = ExternalLinkType.GameDev)]
        UnityConnect = 13
    }
}