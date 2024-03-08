namespace StringCalculator.Tests;
public class Calculator(ILogger logger, IWebService mockedWebService)
{
    public int Add(string numbers)
    {
        if (numbers == "") return 0;
        var result = numbers.Split(',').Select(int.Parse).Sum();
        try
        {
            logger.Write(result.ToString());
        }
        catch (LoggerException)
        {
            mockedWebService.FailureNotification($"caught LoggerException with argument {numbers}");
        }
        return result;
    }
}

public interface ILogger
{
    void Write(string message);
}

public class LoggerException : ApplicationException { }

public interface IWebService
{
    void FailureNotification(string message);
}