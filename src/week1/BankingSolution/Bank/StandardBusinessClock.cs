namespace Bank;
public class StandardBusinessClock(IClock _clock) : IProvideTheBusinessClock
{
    public bool IsOpen()
    {
        DateTime now = _clock.GetCurrentLocalTime();
        return (now.Hour >= 9 && now.Hour < 17) ? true : false;
    }
}
