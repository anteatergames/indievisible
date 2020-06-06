using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.ValueObjects.Study
{
    public class StudyCoursesOfUserVo
    {
        public Guid UserId { get; set; }

        public List<UserCourseVo> Courses { get; set; }
    }

    public class UserCourseVo
    {
        public Guid CourseId { get; set; }

        public string CourseName { get; set; }
    }
}
