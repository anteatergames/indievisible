using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Domain.ValueObjects.Study;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Interfaces.Services
{
    public interface IStudyDomainService
    {
        #region General

        IEnumerable<Guid> GetMentorsByUserId(Guid userId);

        IEnumerable<Guid> GetStudentsByUserId(Guid userId);
        #endregion

        #region Course
        List<StudyCourseListItemVo> GetCoursesByUserId(Guid userId);

        StudyCoursesOfUserVo GetCoursesForUserId(Guid userId);

        StudyCourse GenerateNewCourse(Guid userId);

        StudyCourse GetCourseById(Guid id);

        void AddCourse(StudyCourse model);

        void UpdateCourse(StudyCourse model);
        #endregion
    }
}
