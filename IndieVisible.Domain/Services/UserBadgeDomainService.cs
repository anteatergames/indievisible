using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Services
{
    public class UserBadgeDomainService : IUserBadgeDomainService
    {
        private readonly IUserBadgeRepository userBadgeRepository;

        public UserBadgeDomainService(IUserBadgeRepository userBadgeRepository)
        {
            this.userBadgeRepository = userBadgeRepository;
        }

        public int Count()
        {
            int count = this.userBadgeRepository.Count(x => true);

            return count;
        }

        public IEnumerable<UserBadge> GetAll()
        {
            System.Linq.IQueryable<UserBadge> model = this.userBadgeRepository.GetAll();

            return model;
        }

        public UserBadge GetById(Guid id)
        {
            UserBadge model = this.userBadgeRepository.GetById(id);

            return model;
        }

        public IEnumerable<UserBadge> GetByUserId(Guid userId)
        {
            IEnumerable<UserBadge> model = this.userBadgeRepository.GetByUserId(userId);

            return model;
        }

        public void Remove(Guid id)
        {
            this.userBadgeRepository.Remove(id);
        }

        public Guid Add(UserBadge model)
        {
            this.userBadgeRepository.Add(model);

            return model.Id;
        }

        public Guid Update(UserBadge model)
        {
            this.userBadgeRepository.Update(model);

            return model.Id;
        }

        public int Count(Expression<Func<UserBadge, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserBadge> Get(Expression<Func<UserBadge, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
