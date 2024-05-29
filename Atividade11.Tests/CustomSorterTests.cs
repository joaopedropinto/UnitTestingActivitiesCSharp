namespace Atividade11.Tests;
public class CustomSorterTests
{
    [Fact]
    public void SortDescending_WithUnsortedList_ReturnsSortedList(){
        //Arrange
        var list = new List<int> { 1, 3, 2 };
        var sorter = new CustomSorter();

        //Act
        var result = sorter.SortDescending(list);

        //Assert
        var expected = new List<int> { 3, 2, 1 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SortDescending_WithSortedList_ResturnsSortedList(){
        //Arrange
        var list = new List<int> { 3, 2, 1 };
        var sorter = new CustomSorter();

        //Act
        var result = sorter.SortDescending(list);

        //Assert
        var expected = new List<int> { 3, 2, 1 };
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SortDescending_WithEmptyList_ReturnsEmptyList(){
        //Arrange
        var list = new List<int>();
        var sorter = new CustomSorter();

        //Act
        var result = sorter.SortDescending(list);

        //Assert
        Assert.Empty(result);
    }
}
