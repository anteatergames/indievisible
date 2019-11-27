using IndieVisible.Domain.Core.Attributes;

namespace IndieVisible.Domain.Core.Enums
{
    public enum ExternalLinkProvider
    {
        [ExternalLinkInfo(Display = "Website", Class = "fa fa-link", ColorClass = "bg-fuchsia", Type = ExternalLinkType.General, IsStore = false)]
        Website = 1,

        [ExternalLinkInfo(Display = "Facebook", Class = "fab fa-facebook-f", ColorClass = "btn-facebook", Type = ExternalLinkType.General, IsStore = false)]
        Facebook = 2,

        [ExternalLinkInfo(Display = "Twitter", Class = "fab fa-twitter", ColorClass = "btn-twitter", Type = ExternalLinkType.General, IsStore = false)]
        Twitter = 3,

        [ExternalLinkInfo(Display = "Instagram", Class = "fab fa-instagram", ColorClass = "btn-instagram", Type = ExternalLinkType.General, IsStore = false)]
        Instagram = 4,

        [ExternalLinkInfo(Display = "Youtube", Class = "fab fa-youtube", ColorClass = "bg-red", Type = ExternalLinkType.General, IsStore = false)]
        Youtube = 5,

        [ExternalLinkInfo(Display = "Xbox Live", Class = "fab fa-xbox", ColorClass = "bg-green-active", Type = ExternalLinkType.General, IsStore = true)]
        XboxLive = 6,

        [ExternalLinkInfo(Display = "PlayStation Store", Class = "fab fa-playstation", ColorClass = "bg-black-active", Type = ExternalLinkType.General, IsStore = true)]
        PlaystationStore = 7,

        [ExternalLinkInfo(Display = "Steam", Class = "fab fa-steam", ColorClass = "bg-black", Type = ExternalLinkType.General, IsStore = true)]
        Steam = 8,

        [ExternalLinkInfo(Display = "Game Jolt", Class = "gamejolt", ColorClass = "btn-gamejolt", Type = ExternalLinkType.GameDev, IsStore = true)]
        GameJolt = 9,

        [ExternalLinkInfo(Display = "Itch.io", Class = "itchio", ColorClass = "btn-itchio", Type = ExternalLinkType.GameDev, IsStore = true)]
        ItchIo = 10,

        [ExternalLinkInfo(Display = "Gamedev.net", Class = "gamedevnet", ColorClass = "btn-gamedevnet", Type = ExternalLinkType.GameDev, IsStore = false)]
        GamedevNet = 11,

        [ExternalLinkInfo(Display = "IndieDB", Class = "indiedb", ColorClass = "btn-indiedb", Type = ExternalLinkType.GameDev, IsStore = false)]
        IndieDb = 12,

        [ExternalLinkInfo(Display = "Unity Connect", Class = "unityconnect", ColorClass = "btn-unityconnect", Type = ExternalLinkType.GameDev, IsStore = false)]
        UnityConnect = 13,

        [ExternalLinkInfo(Display = "Google Play Store", Class = "fab fa-android", ColorClass = "btn-googleplaystore", Type = ExternalLinkType.General, IsStore = true)]
        GooglePlayStore = 14,

        [ExternalLinkInfo(Display = "Apple App Store", Class = "fab fa-apple", ColorClass = "btn-appleappstore", Type = ExternalLinkType.General, IsStore = true)]
        AppleAppStore = 15
    }
}