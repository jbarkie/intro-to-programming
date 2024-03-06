// https://osherove.com/tdd-kata-1
namespace StringCalculator.Tests;
public class Part1Tests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();
        var result = calculator.Add("");
        Assert.Equal(0, result);
    }
}
