namespace Atividade09.Tests;

public class ItemTests
{
    [Fact]
    public void AddItem_WithValidItem_AddsItem()
    {
        //Arrange
        var collection = new ItemCollection();
        var item = new Item("Item 1");

        //Act
        collection.AddItem(item);

        //Assert
        var items = collection.GetItems();
        Assert.Contains(item, items);
    }
    [Fact]
    public void AddItem_NullItem_AddsItem()
    {
        //Arrange
        var collection = new ItemCollection();

        //Act & Assert
        Assert.Throws<ArgumentException>(() => collection.AddItem(null!));

    }

    [Fact]
    public void RemoveItem_WithValidItem_RemovesItem()
    {
        //Arrange
        var collection = new ItemCollection();
        var item1 = new Item("Item 1");
        collection.AddItem(item1);

        //Act
        collection.RemoveItem(item1);

        //Assert
        var items = collection.GetItems();
        Assert.DoesNotContain(item1, items);
    }

    [Fact]
    public void RemoveItem_NullItem_ThrowsException()
    {
        //Arrange
        var collection = new ItemCollection();

        //Act & Assert
        Assert.Throws<ArgumentException>(() => collection.AddItem(null!));
    }

    [Fact]
    public void GetItems_NotEmpty_ReturnsItems()
    {
        //Arrange
        var collection = new ItemCollection();
        var item1 = new Item("Item 1");
        var item2 = new Item("Item 2");
        collection.AddItem(item1);
        collection.AddItem(item2);

        //Act
        var items = collection.GetItems();

        //Assert
        Assert.Contains(item1, items);
        Assert.Contains(item2, items);
    }
}