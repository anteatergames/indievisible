using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IStudyCourseRepository : IRepository<StudyCourse>
    {
        List<StudyCourseListItemVo> GetCourses();

        List<StudyCourseListItemVo> GetCoursesByUserId(Guid userId);

        IQueryable<StudyPlan> GetPlans(Guid courseId);

        Task<bool> AddPlan(Guid courseId, StudyPlan plan);

        Task<bool> UpdatePlan(Guid courseId, StudyPlan plan);

        Task<bool> RemovePlan(Guid courseId, Guid planId);

        bool CheckStudentEnrolled(Guid courseId, Guid userId);

        Task<bool> AddStudent(Guid courseId, CourseMember student);

        Task<bool> UpdateStudent(Guid courseId, CourseMember student);

        Task<bool> RemoveStudent(Guid courseId, Guid userId);
    }
}
