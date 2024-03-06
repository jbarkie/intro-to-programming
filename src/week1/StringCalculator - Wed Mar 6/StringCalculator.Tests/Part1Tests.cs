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

    [Fact]
    public void OneNumberDoesNotChange()
    {
        var calculator = new Calculator();
        var result = calculator.Add("1");
        Assert.Equal(1, result);
    }

    [Fact]
    public void TwoNumbersAddedCorrectly()
    {
        var calculator = new Calculator();
        var result = calculator.Add("2,2");
        Assert.Equal(4, result);
    }

    [Fact]
    public void MoreThanTwoNumbersAddedCorrectly()
    {
        var calculator = new Calculator();
        var result = calculator.Add("1,2,3,4,5");
        Assert.Equal(15, result);
    }

    [Fact]
    public void NewlineDelimiterSupported()
    {
        var calculator = new Calculator();
        var result = calculator.Add("1\n2,3");
        Assert.Equal(6, result);
    }

    [Fact]
    public void IncorrectFormatThrowsException()
    {
        var calculator = new Calculator();
        Assert.Throws<FormatException>(() => calculator.Add("1\n,"));
    }
}
