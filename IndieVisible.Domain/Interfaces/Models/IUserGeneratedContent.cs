using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Interfaces.Models
{
    public interface IUserGeneratedContent : IEntityBase
    {
        string AuthorPicture { get; set; }

        string AuthorName { get; set; }

        UserContentType UserContentType { get; set; }
    }
}
