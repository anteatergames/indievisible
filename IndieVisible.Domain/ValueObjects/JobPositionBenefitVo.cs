using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.ValueObjects
{
    public class JobPositionBenefitVo
    {
        public JobPositionBenefit Benefit { get; set; }

        public bool Available { get; set; }
    }
}
