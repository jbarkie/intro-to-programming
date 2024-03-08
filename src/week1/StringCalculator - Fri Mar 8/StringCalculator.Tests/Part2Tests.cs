using NSubstitute;

namespace StringCalculator.Tests;

public class Part2Test
{

    [Fact]
    public void WriteSumToLogger()
    {
        // Given 
        var mockedLogger = Substitute.For<ILogger>();
        var calculator = new Calculator(mockedLogger, Substitute.For<IWebService>());
        // When 
        calculator.Add("1,2");
        // Then
        mockedLogger.Received().Write(Arg.Any<string>());
    }

    [Fact]
    public void NotifyWebServiceOfFailure()
    {
        // Given 
        var mockedLogger = Substitute.For<ILogger>();
        mockedLogger.When(log => log.Write(Arg.Any<string>())).Throw<LoggerException>();
        var mockedWebService = Substitute.For<IWebService>();
        var calculator = new Calculator(mockedLogger, mockedWebService);
        // When
        calculator.Add("1,2");
        // Then
        mockedWebService.Received().FailureNotification("caught LoggerException with argument 1,2");
    }
}