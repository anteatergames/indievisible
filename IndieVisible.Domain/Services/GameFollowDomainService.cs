using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Services
{
    public class GameFollowDomainService : IGameFollowDomainService
    {
        private readonly IGameFollowRepository gameFollowRepository;

        public GameFollowDomainService(IGameFollowRepository gameFollowRepository)
        {
            this.gameFollowRepository = gameFollowRepository;
        }

        public int Count()
        {
            int count = this.gameFollowRepository.Count(x => true);

            return count;
        }

        public IEnumerable<GameFollow> GetAll()
        {
            System.Linq.IQueryable<GameFollow> model = this.gameFollowRepository.GetAll();

            return model;
        }

        public GameFollow GetById(Guid id)
        {
            GameFollow model = this.gameFollowRepository.GetById(id);

            return model;
        }

        public IEnumerable<GameFollow> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            this.gameFollowRepository.Remove(id);
        }

        public Guid Add(GameFollow model)
        {
            this.gameFollowRepository.Add(model);

            return model.Id;
        }

        public Guid Update(GameFollow model)
        {
            this.gameFollowRepository.Update(model);

            return model.Id;
        }

        public int Count(Expression<Func<GameFollow, bool>> where)
        {
            var count = this.gameFollowRepository.Count(where);

            return count;
        }

        public IEnumerable<GameFollow> GetByGameId(Guid gameId)
        {
            var followers = this.gameFollowRepository.Get(x => x.GameId == gameId);

            return followers.ToList();
        }

        public IEnumerable<GameFollow> Get(Expression<Func<GameFollow, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
