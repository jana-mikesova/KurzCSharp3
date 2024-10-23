namespace ToDoList.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.DivideInt(10, 5);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var divideAction = () => calculator.DivideInt(10, 0);

        // Assert
        Assert.Throws<DivideByZeroException>(() => calculator.DivideInt(10, 0));
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.DivideFloat(10, 0);

        // Assert
        Assert.Equal(float.PositiveInfinity, result);
    }

    [Theory]
    [InlineData(10, 5)]
    [InlineData(30, 15)]

    public void DivideInt_ValuesAreMultipliedBv2_Equal2(int value1, int value2)
    {
        // arrange
        var calculator = new Calculator();
        // act
        var result = calculator.DivideInt(value1, value2);
        // assert
    }

}

public class Calculator
{
    public int DivideInt(int dividend, int divisor)
    {
        return dividend / divisor;
    }

    public float DivideFloat(float dividend, float divisor)
    {
        return dividend / divisor;
    }
}
