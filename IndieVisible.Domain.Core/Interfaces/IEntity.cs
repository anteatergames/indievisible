using System;

namespace IndieVisible.Domain.Core.Interfaces
{
    public interface IEntity
    {
        Guid UserId { get; set; }

        DateTime CreateDate { get; set; }
    }
}