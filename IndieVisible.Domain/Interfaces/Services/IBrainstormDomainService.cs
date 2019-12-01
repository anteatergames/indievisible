using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IBrainstormDomainService : IDomainService<BrainstormSession>
    {
        BrainstormIdea GetIdea(Guid ideaId);

        void AddIdea(BrainstormIdea model);

        void UpdateIdea(BrainstormIdea idea);

        IEnumerable<BrainstormIdea> GetIdeasBySession(Guid sessionId);

        void AddVote(BrainstormVote model);

        void UpdateVote(BrainstormVote model);

        void AddComment(BrainstormComment model);

        BrainstormSession Get(BrainstormSessionType type);
    }
}