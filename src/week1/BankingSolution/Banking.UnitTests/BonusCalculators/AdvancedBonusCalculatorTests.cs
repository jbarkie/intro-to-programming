using Bank;
using NSubstitute;

namespace Banking.UnitTests.BonusCalculators;
public class AdvancedBonusCalculatorTests
{
    [Fact]
    public void DuringBusinessHoursWithAdequateBalance()
    {
        var stubbedClock = Substitute.For<IProvideTheBusinessClock>();
        stubbedClock.IsOpen().Returns(true);
        var calculator = new AdvancedBonusCalculator(stubbedClock);
        var bonus = calculator.CalculateDepositBonusFor(5000M, 100);
        Assert.Equal(10, bonus);
    }

    [Fact]
    public void DuringBusinessHoursWithInadequateBalance()
    {
        var stubbedClock = Substitute.For<IProvideTheBusinessClock>();
        stubbedClock.IsOpen().Returns(true);
        var calculator = new AdvancedBonusCalculator(stubbedClock);
        var bonus = calculator.CalculateDepositBonusFor(4999.99M, 100);
        Assert.Equal(0, bonus);
    }

    [Fact]
    public void OutsideBusinessHours()
    {
        var stubbedClock = Substitute.For<IProvideTheBusinessClock>();
        stubbedClock.IsOpen().Returns(false);
        var calculator = new AdvancedBonusCalculator(stubbedClock);
        var bonus = calculator.CalculateDepositBonusFor(10000M, 100);
        Assert.Equal(0, bonus);
    }
}
