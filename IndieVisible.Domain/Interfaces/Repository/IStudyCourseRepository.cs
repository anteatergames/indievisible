using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IStudyCourseRepository : IRepository<StudyCourse>
    {
        List<StudyCourseListItemVo> GetCoursesByUserId(Guid userId);
    }
}
