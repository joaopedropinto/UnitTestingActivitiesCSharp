namespace Atividade08.Tests;

public class StatisticsTests
{
    [Fact]
    public void CalculateAverage_WithValidList_ReturnsAverage()
    {
        //Arrange
        var statistics = new Statistics();
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        //Act
        var result = statistics.CalculateAverage(numbers);

        //Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void CalculateAverage_WithEmptyList_ThrowsException()
    {
        //Arrange
        var statistics = new Statistics();
        var numbers = new List<int>();

        //Act & Assert
        Assert.Throws<ArgumentException>(() => statistics.CalculateAverage(numbers));
        
    }
}