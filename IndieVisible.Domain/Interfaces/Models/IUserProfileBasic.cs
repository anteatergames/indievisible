namespace IndieVisible.Domain.Interfaces.Models
{
    public interface IUserProfileBasic : IEntityBase
    {
        string ProfileImageUrl { get; set; }

        string CoverImageUrl { get; set; }

        string Name { get; set; }

        string Country { get; set; }

        string Location { get; set; }
    }
}