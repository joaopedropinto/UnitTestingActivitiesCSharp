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
}