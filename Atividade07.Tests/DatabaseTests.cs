using NSubstitute;
namespace Atividade07.Tests;

public class DatabaseTests
{
    [Fact]
    public void SaveUser_WithValidUser_SavesUser()
    {
        //Arrange
        var user = new User("Joao Teste", "JoaoTeste@email.com");
        var database = Substitute.For<IDatabase>();

        //Act
        database.SaveUser(user);

        //Assert
        database.Received(1).SaveUser(user);

    }
    [Fact]
    public void SaveUser_WithoutName_ThrowsArgumentException()
    {
        //Arrange
        var database = Substitute.For<IDatabase>();
        var userService = new UserService(database);
        var user = new User("", "JoaoTeste@email.com");

        //Act & Assert
        Assert.Throws<ArgumentException>(() => userService.SaveUser(user));
    }

    [Fact]
    public void SaveUser_WithoutEmail_ThrowsArgumentException()
    {
        //Arrange
        var database = Substitute.For<IDatabase>();
        var userService = new UserService(database);
        var user = new User("Joao Teste", "");
        //Act & Assert
        Assert.Throws<ArgumentException>(() => userService.SaveUser(user));
    }
}