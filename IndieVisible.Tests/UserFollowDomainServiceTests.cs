using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.Services;
using NSubstitute;
using System;
using Xunit;

namespace IndieVisible.Tests
{
    public class UserFollowDomainServiceTests
    {
        private Guid guidValid = new Guid("1E213EA8-3605-4B67-282D-08D6E573BA84");

        private readonly IUserFollowRepository mockRepository;

        public UserFollowDomainServiceTests()
        {
            mockRepository = Substitute.For<IUserFollowRepository>();

            UserFollow fakeUserFollow = new UserFollow
            {
                Id = guidValid,
                UserId = new Guid("0C7E18B2-3682-444D-A62B-30E311E76891"),
                CreateDate = DateTime.Today,
                FollowUserId = new Guid("4026CE87-9023-4D4E-9C64-AE88F1906F71")
            };

            mockRepository.GetById(guidValid).Returns(fakeUserFollow);
        }

        [Fact]
        public void GetByIdReturnsObject()
        {
            IUserFollowDomainService service = new UserFollowDomainService(mockRepository);

            Assert.NotNull(service.GetById(guidValid));
        }

        [Fact]
        public void GetByIdDoesNotReturnsObject()
        {

            IUserFollowDomainService service = new UserFollowDomainService(mockRepository);

            Assert.Null(service.GetById(Guid.Empty));
        }
    }
}
