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
    }
}
