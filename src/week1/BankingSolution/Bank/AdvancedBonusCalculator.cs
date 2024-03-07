namespace Bank;
public class AdvancedBonusCalculator(IProvideTheBusinessClock clock) : ICalculateBonusesForDeposits
{
    private readonly IProvideTheBusinessClock _clock = clock;

    public decimal CalculateDepositBonusFor(decimal currentBalance, decimal amountToDeposit)
    {
        // if between 9am-5pm M-F not on a holiday
        // then, if currentBalance >= 5000, return bonus of 10%
        // otherwise, return no bonus
        // WTCYWYH
        if (_clock.IsOpen() && currentBalance >= 5000M)
        {
            return amountToDeposit * .10M;
        }
        return 0;
    }
}
