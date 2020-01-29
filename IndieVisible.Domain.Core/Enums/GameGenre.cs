using IndieVisible.Domain.Core.Attributes;

namespace IndieVisible.Domain.Core.Enums
{
    public enum GameGenre
    {
        [UiInfo(Class = "red")]
        Strategy = 1,

        [UiInfo(Class = "blue")]
        Racing = 2,

        [UiInfo(Class = "yellow")]
        Fighting = 3,

        [UiInfo(Class = "green")]
        Adventure = 4,

        [UiInfo(Class = "navy")]
        Rpg = 5,

        [UiInfo(Class = "orange")]
        Action = 6,

        [UiInfo(Class = "gray")]
        Simulation = 7,

        [UiInfo(Class = "purple")]
        Sports = 8,

        [UiInfo(Class = "black")]
        Horror = 9,

        [UiInfo(Class = "aqua")]
        Roguelike = 10,

        [UiInfo(Class = "fuchsia")]
        Casual = 11,

        [UiInfo(Class = "lime")]
        ShootEmUp = 12,

        [UiInfo(Class = "maroon")]
        BeatEmUp = 13,

        [UiInfo(Class = "teal")]
        MotionComics = 14,

        [UiInfo(Class = "olive")]
        Platformer = 15,

        [UiInfo(Class = "red")]
        Metroidvania = 16
    }
}