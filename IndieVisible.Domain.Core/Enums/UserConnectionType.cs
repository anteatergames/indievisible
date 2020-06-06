using IndieVisible.Domain.Core.Attributes;

namespace IndieVisible.Domain.Core.Enums
{
    public enum UserConnectionType
    {
        [UiInfo(Display = "WorkedTogether")]
        WorkedTogether = 1,

        [UiInfo(Display = "Mentor")]
        Mentor = 2,

        [UiInfo(Display = "Pupil")]
        Pupil = 3
    }
}