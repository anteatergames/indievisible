﻿using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using System;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class BrainstormVoteRepository : Repository<BrainstormVote>, IBrainstormVoteRepository
    {
        public BrainstormVoteRepository(IndieVisibleContext context) : base(context)
        {

        }

        public BrainstormVote Get(Guid votingItemId, Guid userId)
        {
            BrainstormVote obj = Db.BrainstormVotes.FirstOrDefault(x => x.IdeaId == votingItemId && x.UserId == userId);

            return obj;
        }
    }
}
