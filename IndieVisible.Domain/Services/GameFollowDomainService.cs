using IndieVisible.Domain.Interfaces;
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
            int count = gameFollowRepository.Count(x => true);

            return count;
        }

        public int Count(Expression<Func<GameFollow, bool>> where)
        {
            int count = gameFollowRepository.Count(where);

            return count;
        }

        public IEnumerable<GameFollow> GetAll()
        {
            IQueryable<GameFollow> model = gameFollowRepository.GetAll();

            return model;
        }

        public GameFollow GetById(Guid id)
        {
            GameFollow model = gameFollowRepository.GetById(id);

            return model;
        }

        public IEnumerable<GameFollow> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            gameFollowRepository.Remove(id);
        }

        public Guid Add(GameFollow model)
        {
            gameFollowRepository.Add(model);

            return model.Id;
        }

        public Guid Update(GameFollow model)
        {
            gameFollowRepository.Update(model);

            return model.Id;
        }

        public IEnumerable<GameFollow> GetByGameId(Guid gameId)
        {
            IQueryable<GameFollow> followers = gameFollowRepository.Get(x => x.GameId == gameId);

            return followers.ToList();
        }

        IQueryable<GameFollow> IDomainService<GameFollow>.Search(Expression<Func<GameFollow, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
