namespace IndieVisible.Application
{
    public static class Constants
    {
        public static string CacheKeyProfileFullName
        {
            get
            {
                return "{0}_fullName";
            }
        }

        public static string DefaultProfileDescription
        {
            get
            {
                return "is a game developer willing to rock the game development world with funny games.";
            }
        }
        public static string DefaultUsername
        {
            get
            {
                return "theuser";
            }
        }
        public static string DefaultAvatar
        {
            get
            {
                return "/images/profileimages/developer.png";
            }
        }

        public static string DefaultProfileCoverImage
        {
            get
            {
                return "/images/placeholders/profilecoverimage.jpg";
            }
        }

        public static string DefaultGameCoverImage
        {
            get
            {
                return "/images/placeholders/gamecoverimage.jpg";
            }
        }

        public static string DefaultGameThumbnail
        {
            get
            {
                return "/images/placeholders/gameplaceholder.jpg";
            }
        }

        public static string DefaultFeaturedImage
        {
            get
            {
                return "/images/placeholders/featuredimage.jpg";
            }
        }

        public static string DefaultImagePath
        {
            get
            {
                return "/storage/image";
            }
        }

        public static string DefaultUserImagePath
        {
            get
            {
                return "/storage/userimage";
            }
        }

        public static string DefaultCdnPath
        {
            get
            {
                return "https://indievisiblecdn.azureedge.net/";
            }
        }

        public static string DefaultAzureStoragePath
        {
            get
            {
                return "https://indievisible.blob.core.windows.net/";
            }
        }
    }
}
