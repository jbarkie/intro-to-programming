using Bank;
using NSubstitute;

namespace Banking.UnitTests.BusinessClock;
public class StandardBusinessClockTests
{
    [Fact]
    public void WeAreClosed()
    {
        var stubbedClock = Substitute.For<IClock>();
        stubbedClock.GetCurrentLocalTime().Returns(new DateTime(2024, 3, 7, 17, 00, 00));
        var clock = new StandardBusinessClock(stubbedClock);
        Assert.False(clock.IsOpen());
    }
    [Fact]
    public void WeAreOpen()
    {
        var stubbedClock = Substitute.For<IClock>();
        stubbedClock.GetCurrentLocalTime().Returns(new DateTime(2024, 3, 7, 16, 59, 59));
        var clock = new StandardBusinessClock(stubbedClock);
        Assert.True(clock.IsOpen());
    }
}
