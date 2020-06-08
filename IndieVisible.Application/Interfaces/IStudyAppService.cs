using IndieVisible.Application.ViewModels.Localization;
using IndieVisible.Application.ViewModels.Study;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndieVisible.Application.Interfaces
{
    public interface IStudyAppService
    {
        OperationResultVo GetMyMentors(Guid currentUserId);

        OperationResultVo GetMyStudents(Guid currentUserId);

        OperationResultVo GetMyCourses(Guid currentUserId);

        OperationResultVo GetCoursesByMe(Guid currentUserId);

        OperationResultVo GenerateNewCourse(Guid currentUserId);

        OperationResultVo<Guid> SaveCourse(Guid currentUserId, StudyCourseViewModel vm);

        OperationResultVo GetCourseById(Guid currentUserId, Guid id);

        OperationResultVo GetPlans(Guid currentUserId, Guid courseId);

        OperationResultVo SavePlans(Guid currentUserId, Guid courseId, IEnumerable<StudyPlanViewModel> plans);
    }
}