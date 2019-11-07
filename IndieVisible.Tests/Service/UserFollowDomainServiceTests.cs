using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.Services;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using NSubstitute;
using System;
using System.Linq.Expressions;
using Xunit;

namespace IndieVisible.Tests.Service
{
    public class UserFollowDomainServiceTests
    {
    //    private Guid guidValid = new Guid("1E213EA8-3605-4B67-282D-08D6E573BA84");

    //    private readonly IUserConnectionRepository mockRepository;

    //    public UserFollowDomainServiceTests()
    //    {
    //        mockRepository = Substitute.For<IUserFollowRepositorySql>();

    //        UserConnection fakeEntity = new UserConnection
    //        {
    //            Id = guidValid,
    //            UserId = new Guid("0C7E18B2-3682-444D-A62B-30E311E76891"),
    //            CreateDate = DateTime.Today,
    //            TargetUserId = new Guid("4026CE87-9023-4D4E-9C64-AE88F1906F71")
    //        };

    //        mockRepository.GetById(guidValid).Returns(fakeEntity);

    //        mockRepository.Count(Arg.Any<Expression<Func<UserConnection, bool>>>()).Returns(10);
    //    }

    //    [Fact]
    //    public void GetByIdReturnsObject()
    //    {
    //        IUserFollowDomainService service = new UserConnectionDomainService(mockRepository);

    //        Assert.NotNull(service.GetById(guidValid));
    //    }

    //    [Fact]
    //    public void GetByIdDoesNotReturnsObject()
    //    {

    //        IUserFollowDomainService service = new UserFollowDomainService(mockRepository);

    //        Assert.Null(service.GetById(Guid.Empty));
    //    }

    //    [Fact]
    //    public void CountMustReturnValue()
    //    {
    //        IUserFollowDomainService service = new UserFollowDomainService(mockRepository);

    //        Assert.Equal(10, service.Count());
    //    }
    }
}
