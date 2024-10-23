namespace ToDoList.Test;

using ToDoList.WebApi.Controllers;

public class GetTests
{

    [Fact]
    public void Get_AllItems_ReturnAllItems()
    {
        //arrange
        var controller = new ToDoItemsController();

        //act
        var result = controller.Read();

        //assert

    }
}
