


namespace Bank;

public class BankAccount
{
    private decimal _currentBalance = 5000M;

    public void Deposit(decimal amountToDeposit)
    {
        _currentBalance += amountToDeposit;
    }

    public decimal GetBalance()
    {
        return _currentBalance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        _currentBalance -= amountToWithdraw;
    }
}