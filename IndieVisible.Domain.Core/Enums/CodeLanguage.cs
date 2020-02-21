using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum CodeLanguage
    {
        [Display(Name= "C#")]
        Csharp,
        [Display(Name = "Java")]
        Java,
        [Display(Name = "C++")]
        Cplusplus,
        [Display(Name = "Javascript")]
        Javascript,
        [Display(Name = "GML")]
        Gml
    }
}