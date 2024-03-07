
namespace Bank;

public interface IClock
{
    DateTime GetCurrentLocalTime();
}

public class Clock : IClock
{
    public DateTime GetCurrentLocalTime()
    {
        return DateTime.Now;
    }
}