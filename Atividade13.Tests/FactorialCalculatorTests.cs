namespace Atividade13.Tests;
public class FactorialCalculatorTests
{
    [Fact]
    public void Calculate_WithNegativeNumber_ThrowsArgumentException()
    {
        //Arrange
        var calculator = new FactorialCalculator();

        //Act & Assert Assert.Throws<ArgumentException>(() => collection.AddItem(null!));
        Assert.Throws<ArgumentException>(() => calculator.Calculate(-1));
    }

    [Fact]
    public void Calculate_WithZero_ReturnsOne()
    {
        //Arrange
        var calculator = new FactorialCalculator();

        //Act
        var result = calculator.Calculate(0);

        //Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Calculate_WithOne_ReturnsOne()
    {
        //Arrange
        var calculator = new FactorialCalculator();

        //Act
        var result = calculator.Calculate(1);

        //Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Calculate_WithPositiveNumber_ReturnsFactorial()
    {
        //Arrange
        var calculator = new FactorialCalculator();

        // Act & Assert
        Assert.Equal(1, calculator.Calculate(1));
        Assert.Equal(2, calculator.Calculate(2));
        Assert.Equal(6, calculator.Calculate(3));
        Assert.Equal(24, calculator.Calculate(4));
        Assert.Equal(120, calculator.Calculate(5));
    }
}
