using IndieVisible.Domain.Core.Attributes;

namespace IndieVisible.Domain.Core.Enums
{
    public enum SupportedLanguage
    {
        [UiInfo(Culture = "en-US")]
        English = 1,
        [UiInfo(Culture = "pt-BR")]
        Portuguese = 2,
        [UiInfo(Culture = "ru-RU")]
        Russian = 3,
        [UiInfo(Culture = "es")]
        Spanish = 4,
        [UiInfo(Culture = "bs")]
        Bosnian = 5,
        [UiInfo(Culture = "sr")]
        Serbian = 6,
        [UiInfo(Culture = "hr")]
        Croatian = 7,
        [UiInfo(Culture = "de")]
        German = 8
    }
}
