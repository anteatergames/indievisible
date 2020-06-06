using IndieVisible.Domain.Core.Attributes;

namespace IndieVisible.Domain.Core.Enums
{
    public enum StudyProfile
    {
        [UiInfo(Display = "Mentor")]
        Mentor = 1,

        [UiInfo(Display = "Student")]
        Student = 2
    }
}