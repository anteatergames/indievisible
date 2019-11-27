using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum TeamWorkType
    {
        [Display(Name = "Game Design")]
        GameDesign,

        [Display(Name = "Code")]
        Code,

        [Display(Name = "Art")]
        Art,

        [Display(Name = "Sound")]
        Sound,

        [Display(Name = "Project Management")]
        ProjectManagement,

        [Display(Name = "Concept Art")]
        ArtConcept,

        [Display(Name = "2D Art")]
        Art2d,

        [Display(Name = "3D Art")]
        Art3d,

        [Display(Name = "Sound FX")]
        SoundFx,

        [Display(Name = "Writing")]
        Writing,

        [Display(Name = "3D Modelling")]
        Model3d,

        [Display(Name = "3D Animation")]
        Animation3d,

        [Display(Name = "Environment Art")]
        ArtEnvironment,

        [Display(Name = "Artificial Intellingence")]
        ArtificialIntellingence,

        [Display(Name = "Game Logic")]
        GameLogic,

        [Display(Name = "Level Design")]
        LevelDesign,

        [Display(Name = "Quality Assurance")]
        QualityAssurance,

        [Display(Name = "Testing")]
        Testing,

        [Display(Name = "Marketing")]
        Marketing,

        [Display(Name = "Animation")]
        Animation,

        [Display(Name = "Rigging")]
        Rigging,

        [Display(Name = "Visual FX")]
        VisualFx
    }
}