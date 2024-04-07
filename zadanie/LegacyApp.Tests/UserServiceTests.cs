namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            null, 
            "Malewski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            2
        );

        // Assert
        Assert.False(result);
    }
    
    
    [Fact]
    public void AddUser_ReturnsFalseWhenLastNameIsEmpty()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            null, 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            2
        );

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Malewski", 
            "kowalskikowalskipl",
            DateTime.Parse("2000-01-01"),
            2
        );

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Malewski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2010-01-01"),
            2
        );

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Malewski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            2
        );

        // Assert
        Assert.True(result);
    }
    
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            3
        );

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kwiatkowski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            5
        );

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithBelow500CreditLimit()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenUserCreditLimitDoesNotExist()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Andrzejewicz", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            6
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            100
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}