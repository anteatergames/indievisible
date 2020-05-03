using IndieVisible.Domain.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum GameCharacteristcs
    {
        [Display(Name = "Not Informed")]
        [UiInfo(Display = "Not Informed", Class = "times")]
        NotInformed = 0,

        [Display(Name = "Machine Learning")]
        [UiInfo(Display = "Machine Learning", Class = "check")]
        MachineLearning,

        [Display(Name = "Level Of Detail")]
        [UiInfo(Display = "Level Of Detail", Class = "check")]
        Lod,

        [Display(Name = "Procedural Geleration")]
        [UiInfo(Display = "Procedural Geleration", Class = "check")]
        ProceduralGeleration,

        [Display(Name = "Online Multiplayer")]
        [UiInfo(Display = "Online Multiplayer", Class = "check")]
        OnlineMultiplayer,

        [Display(Name = "Split Screen")]
        [UiInfo(Display = "Split Screen", Class = "check")]
        SplitScreen,

        [Display(Name = "Post Processing Effects")]
        [UiInfo(Display = "Post Processing Effects", Class = "check")]
        PostProcessingEffects
    }
}