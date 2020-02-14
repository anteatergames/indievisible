using IndieVisible.Domain.Core.Attributes;

namespace IndieVisible.Domain.Core.Enums
{
    public enum ExternalLinkProvider
    {
        [ExternalLinkInfo(Display = "Website", Class = "fa fa-link", ColorClass = "bg-fuchsia", Order = 11, Type = ExternalLinkType.General, IsStore = false)]
        Website = 1,

        [ExternalLinkInfo(Display = "Facebook", Class = "fab fa-facebook-f", ColorClass = "btn-facebook", Order = 12, Type = ExternalLinkType.ProfileAndGame, IsStore = false)]
        Facebook = 2,

        [ExternalLinkInfo(Display = "Twitter", Class = "fab fa-twitter", ColorClass = "btn-twitter", Order = 13, Type = ExternalLinkType.General, IsStore = false)]
        Twitter = 3,

        [ExternalLinkInfo(Display = "Instagram", Class = "fab fa-instagram", ColorClass = "btn-instagram", Order = 14, Type = ExternalLinkType.General, IsStore = false)]
        Instagram = 4,

        [ExternalLinkInfo(Display = "Youtube", Class = "fab fa-youtube", ColorClass = "bg-red", Order = 15, Type = ExternalLinkType.ProfileAndGame, IsStore = false)]
        Youtube = 5,

        [ExternalLinkInfo(Display = "Xbox Live", Class = "fab fa-xbox", ColorClass = "bg-green-active", Order = 21, Type = ExternalLinkType.ProfileAndGame, IsStore = true)]
        XboxLive = 6,

        [ExternalLinkInfo(Display = "PlayStation Store", Class = "fab fa-playstation", ColorClass = "bg-black-active", Order = 22, Type = ExternalLinkType.ProfileAndGame, IsStore = true)]
        PlaystationStore = 7,

        [ExternalLinkInfo(Display = "Steam", Class = "fab fa-steam", ColorClass = "bg-steam text-white", Order = 23, Type = ExternalLinkType.ProfileAndGame, IsStore = true)]
        Steam = 8,

        [ExternalLinkInfo(Display = "Game Jolt", Class = "gamejolt", ColorClass = "btn-gamejolt", Order = 1, Type = ExternalLinkType.GameDev, IsStore = true)]
        GameJolt = 9,

        [ExternalLinkInfo(Display = "Itch.io", Class = "itchio", ColorClass = "btn-itchio", Order = 2, Type = ExternalLinkType.GameDev, IsStore = true)]
        ItchIo = 10,

        [ExternalLinkInfo(Display = "Gamedev.net", Class = "gamedevnet", ColorClass = "btn-gamedevnet", Order = 3, Type = ExternalLinkType.GameDev, IsStore = false)]
        GamedevNet = 11,

        [ExternalLinkInfo(Display = "IndieDB", Class = "indiedb", ColorClass = "btn-indiedb", Order = 4, Type = ExternalLinkType.GameDev, IsStore = false)]
        IndieDb = 12,

        [ExternalLinkInfo(Display = "Unity Connect", Class = "unityconnect", ColorClass = "btn-unityconnect", Order = 5, Type = ExternalLinkType.GameDev, IsStore = false)]
        UnityConnect = 13,

        [ExternalLinkInfo(Display = "Google Play Store", Class = "fab fa-android", ColorClass = "btn-googleplaystore", Order = 31, Type = ExternalLinkType.ProfileAndGame, IsStore = true)]
        GooglePlayStore = 14,

        [ExternalLinkInfo(Display = "Apple App Store", Class = "fab fa-apple", ColorClass = "btn-appleappstore", Order = 32, Type = ExternalLinkType.ProfileAndGame, IsStore = true)]
        AppleAppStore = 15,

        [ExternalLinkInfo(Display = "Indiexpo", Class = "fas fa-gamepad", ColorClass = "bg-black-active", Order = 33, Type = ExternalLinkType.ProfileAndGame, IsStore = true)]
        IndiExpo = 16,

        [ExternalLinkInfo(Display = "Artstation", Class = "fab fa-artstation", ColorClass = "bg-artstation text-white", Order = 34, Type = ExternalLinkType.ProfileOnly, IsStore = false)]
        Artstation = 17,

        [ExternalLinkInfo(Display = "DeviantArt", Class = "fab fa-deviantart", ColorClass = "bg-deviantart text-white", Order = 35, Type = ExternalLinkType.ProfileOnly, IsStore = false)]
        DeviantArt = 18,

        [ExternalLinkInfo(Display = "Dev.to", Class = "fab fa-dev", ColorClass = "bg-black-active", Order = 36, Type = ExternalLinkType.ProfileOnly, IsStore = false)]
        DevTo = 19,

        [ExternalLinkInfo(Display = "GitHub", Class = "fab fa-github", ColorClass = "bg-black-active", Order = 37, Type = ExternalLinkType.ProfileOnly, IsStore = false)]
        GitHub = 20,

        [ExternalLinkInfo(Display = "HackerRank", Class = "fab fa-hackerrank", ColorClass = "bg-black-active", Order = 38, Type = ExternalLinkType.ProfileOnly, IsStore = false)]
        HackerRank = 21,

        [ExternalLinkInfo(Display = "LinkedIn", Class = "fab fa-linkedin-in", ColorClass = "btn-linkedin", Order = 39, Type = ExternalLinkType.ProfileOnly, IsStore = false)]
        LinkedIn = 22,

        [ExternalLinkInfo(Display = "Patreon", Class = "fab fa-patreon", ColorClass = "btn-patreon", Order = 40, Type = ExternalLinkType.ProfileOnly, IsStore = false)]
        Patreon = 23,

        [ExternalLinkInfo(Display = "Medium", Class = "fab fa-medium-m", ColorClass = "bg-black text-white", Order = 41, Type = ExternalLinkType.ProfileOnly, IsStore = false)]
        Medium = 24
    }
}