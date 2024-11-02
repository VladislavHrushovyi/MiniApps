using MiniShop.Application.Repository;
using MiniShop.Domain.Models;
using Moq;
using Xunit;

namespace MiniShop.Tests.RepositoryTests;

public class BaseRepositoryTests
{
    [Fact]
    public void AddItem_Test()
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Checks = new List<Check>(),
            Date = DateTime.Now,
            Nickname = "test",
            RoleUser = new UserRole(),
            RoleUserId = Guid.NewGuid()
        };
        var baseRepositoryMock = new Mock<IBaseRepository<User>>();
        baseRepositoryMock.Setup(x => x.Add(user)).ReturnsAsync(user);
        
        var result  = baseRepositoryMock.Object.Add(user).GetAwaiter().GetResult();
        
        Assert.Equal(user.Id, result.Id);
    }
}