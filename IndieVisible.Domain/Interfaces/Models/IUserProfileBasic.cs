using System;

namespace IndieVisible.Domain.Interfaces.Models
{
    public interface IUserProfileBasic
    {
        Guid UserId { get; set; }
        DateTime CreateDate { get; set; }
        string ProfileImageUrl { get; set; }
        string CoverImageUrl { get; set; }
        string Name { get; set; }
        string Location { get; set; }
    }
}