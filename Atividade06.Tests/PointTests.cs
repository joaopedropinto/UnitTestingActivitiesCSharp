using Atividade06;
namespace Atividade06.Tests;
public class PointTests
{
    [Fact]
    public void DistanceTo_WithNull_ReturnsFalse()
    {
        // Arrange
        Point point1 = new Point(1, 2);

        // Act
        double distance = point1.DistanceTo(point1);

        // Assert
        Assert.Equal(0, distance);
    }
    [Fact]
    public void DistanceTo_DifferentPoints_ShouldReturnCorrectDistance()
    {
        // Arrange
        Point point1 = new Point(1, 2);
        Point point2 = new Point(4, 6);

        // Act
        double distance = point1.DistanceTo(point2);

        // Assert
        Assert.Equal(5, distance);
    }
    [Fact]
    public void DistanceTo_NullArgument_ShouldThrowArgumentNullException()
    {
        // Arrange
        Point point1 = new Point(1, 2);

        // Act & Assert
        Assert.Throws<System.ArgumentNullException>(() => point1.DistanceTo(null));
    }
}