using CalculatorLib;

namespace UnitTesting;

public class CalculatorTest
{
    // Arrange
    // The data to run the function
    // Act
    // Call the function to test
    // Assert
    // Compare the excpected vs the actual result
    // Edge cases
    // TDD -> Test Driven Development
    // dotnet new xunit
    [Fact]
    public void Add2and2()
    {
        // Arrange
        double a = 2;
        double b = 2;
        double expected = 4;
        Calculator calc = new();
        // Act
        double actual = calc.Add(a, b);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Add3And2()
    {
        // Arrange
        double a = 3;
        double b = 2;
        double expected = 5;
        Calculator calc = new();
        // Act
        double actual = calc.Add(a, b);
        // Assert
        Assert.Equal(expected, actual);
    }
}