using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.ValueObjects
{
    public class StudyCourseListItemVo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool OpenForApplication { get; set; }

        public int StudentCount { get; set; }
    }
}
