using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Services;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.Services;
using IndieVisible.Tests.Attributes;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace IndieVisible.Tests.Domain
{
    [Trait("Category", "Domain")]
    public class GameDomainServiceTests
    {
        public IFixture Fixture { get; }

        public GameDomainServiceTests()
        {
            var customization = new AutoNSubstituteCustomization { ConfigureMembers = true };

            Fixture = new Fixture().Customize(customization);
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }


        [Theory]
        [Trait("Method", "GetAll")]
        [AutoSubstituteData]
        public async Task ShouldReturnGames(IGameRepository repository)
        {
            var sut = new GameDomainService(repository);

            var result = sut.GetAll();

            await repository.Received().GetAll();


            result.Should().NotBeNull();
            result.Should().HaveCountGreaterOrEqualTo(0);
        }

        [Theory]
        [Trait("Method", "GetAll")]
        [AutoSubstituteData]
        public async Task ShouldReturnSingleGame(IGameRepository repository)
        {
            var obj = Fixture.Create<Game>();

            repository.GetById(obj.Id).Returns(obj);

            var sut = new GameDomainService(repository);

            var result = sut.GetById(obj.Id);

            await repository.Received().GetById(obj.Id);


            result.Should().NotBeNull();

            result.Id.Should().Be(obj.Id);
        }
    }
}