namespace Bank;
public class StandardBonusCalculator : ICalculateBonusesForDeposits
{
    public decimal CalculateBonus(decimal balance, decimal amountToDeposit)
    {
        return balance >= 5000M ? amountToDeposit * .10M : 0;
    }

    public decimal CalculateDepositBonusFor(decimal currentBalance, decimal amountToDeposit)
    {
        return CalculateBonus(currentBalance, amountToDeposit);
    }
}
