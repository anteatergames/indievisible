using IndieVisible.Domain.Core.Attributes;

namespace IndieVisible.Domain.Core.Enums
{
    public enum GameGenre
    {
        [UiInfo(Display = "Strategy", Class = "red")]
        Strategy = 1,

        [UiInfo(Display = "Racing", Class = "blue")]
        Racing = 2,

        [UiInfo(Display = "Fighting", Class = "yellow")]
        Fighting = 3,

        [UiInfo(Display = "Adventure", Class = "green")]
        Adventure = 4,

        [UiInfo(Display = "RPG", Class = "navy")]
        Rpg = 5,

        [UiInfo(Display = "Action", Class = "orange")]
        Action = 6,

        [UiInfo(Display = "Simulation", Class = "gray")]
        Simulation = 7,

        [UiInfo(Display = "Sports", Class = "purple")]
        Sports = 8,

        [UiInfo(Display = "Horror", Class = "black")]
        Horror = 9,

        [UiInfo(Display = "Roguelike", Class = "aqua")]
        Roguelike = 10,

        [UiInfo(Display = "Casual", Class = "fuchsia")]
        Casual = 11,

        [UiInfo(Display = "Shoot'em Up", Class = "lime")]
        ShootEmUp = 12,

        [UiInfo(Display = "Beat'em Up", Class = "maroon")]
        BeatEmUp = 13,

        [UiInfo(Display = "Motion Comics", Class = "teal")]
        MotionComics = 14,

        [UiInfo(Display = "Platformer", Class = "olive")]
        Platformer = 15,

        [UiInfo(Display = "Metroidvania", Class = "red")]
        Metroidvania = 16
    }
}