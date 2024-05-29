using NSubstitute;

namespace Atividade10.Tests;
public class UserManagerTests
{
    [Fact]
    public void FetchUserInfo_WithValidUserId_ReturnsUserInfo()
    {
        //Arrange
        var userService = Substitute.For<IUserService>();
        var user = new User("Joao Teste", "JoaoTeste@email.com");
        userService.GetUserInfo(1).Returns(user);

        var userManager = new UserManager(userService);

        //Act
        var trueUser = userManager.FetchUserInfo(1);

        //Assert
        Assert.Equal(user.Name, trueUser.Name);
        Assert.Equal(user.Email, trueUser.Email);
    }

    [Fact]
    public void FetchUserInfo_WithInvalidUserId_ThrowsArgumentException()
    {
        //Arrange
        var userService = Substitute.For<IUserService>();
        userService.GetUserInfo(Arg.Any<int>()).Returns((User)null);

        var userManager = new UserManager(userService);

        // Act
        var trueUser = userManager.FetchUserInfo(999);

        // Assert
        Assert.Null(trueUser);
    }
}
