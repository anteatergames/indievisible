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
    public class UserBadgeDomainService : IUserBadgeDomainService
    {
        private readonly IUserBadgeRepository userBadgeRepository;

        public UserBadgeDomainService(IUserBadgeRepository userBadgeRepository)
        {
            this.userBadgeRepository = userBadgeRepository;
        }

        public int Count()
        {
            int count = userBadgeRepository.Count(x => true);

            return count;
        }

        public int Count(Expression<Func<UserBadge, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserBadge> GetAll()
        {
            IQueryable<UserBadge> model = userBadgeRepository.GetAll();

            return model;
        }

        public UserBadge GetById(Guid id)
        {
            UserBadge model = userBadgeRepository.GetById(id);

            return model;
        }

        public IEnumerable<UserBadge> GetByUserId(Guid userId)
        {
            IQueryable<UserBadge> model = userBadgeRepository.GetByUserId(userId);

            return model.ToList();
        }

        public void Remove(Guid id)
        {
            userBadgeRepository.Remove(id);
        }

        public Guid Add(UserBadge model)
        {
            userBadgeRepository.Add(model);

            return model.Id;
        }

        public Guid Update(UserBadge model)
        {
            userBadgeRepository.Update(model);

            return model.Id;
        }

        public IEnumerable<UserBadge> Search(Expression<Func<UserBadge, bool>> where)
        {
            throw new NotImplementedException();
        }

        IQueryable<UserBadge> IDomainService<UserBadge>.Search(Expression<Func<UserBadge, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
