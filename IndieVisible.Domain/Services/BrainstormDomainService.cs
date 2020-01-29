using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Services
{
    public class BrainstormDomainService : BaseDomainMongoService<BrainstormSession, IBrainstormRepository>, IBrainstormDomainService
    {
        public BrainstormDomainService(IBrainstormRepository repository) : base(repository)
        {
        }

        public override Guid Add(BrainstormSession model)
        {
            if (model.Type == 0)
            {
                model.Type = BrainstormSessionType.Generic;
            }

            return base.Add(model);
        }

        public BrainstormSession Get(BrainstormSessionType type)
        {
            return repository.Get(x => x.Type == type).FirstOrDefault();
        }

        public void AddComment(BrainstormComment model)
        {
            repository.AddComment(model);
        }

        public void AddIdea(BrainstormIdea model)
        {
            repository.AddIdea(model);
        }

        public void AddVote(BrainstormVote model)
        {
            repository.AddVote(model);
        }

        public BrainstormIdea GetIdea(Guid ideaId)
        {
            Task<BrainstormIdea> task = Task.Run(async () => await repository.GetIdea(ideaId));

            return task.Result;
        }

        public IEnumerable<BrainstormIdea> GetIdeasBySession(Guid sessionId)
        {
            Task<IEnumerable<BrainstormIdea>> task = Task.Run(async () => await repository.GetIdeasBySession(sessionId));

            return task.Result;
        }

        public void UpdateIdea(BrainstormIdea idea)
        {
            repository.UpdateIdea(idea);
        }

        public void UpdateVote(BrainstormVote model)
        {
            repository.UpdateVote(model);
        }
    }
}
