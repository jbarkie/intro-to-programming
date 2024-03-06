


namespace Bank;

public class BankAccount
{
    private decimal _currentBalance = 5000M;

    public void Deposit(decimal amountToDeposit)
    {
        GuardTransactionAmount(amountToDeposit);
        _currentBalance += amountToDeposit;
    }

    private void GuardTransactionAmount(decimal transactionAmount)
    {
        if (transactionAmount <= 0) throw new InvalidTransactionAmountException();
    }

    public decimal GetBalance()
    {
        return _currentBalance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw > _currentBalance) throw new OverdraftException();
        GuardTransactionAmount(amountToWithdraw);
        _currentBalance -= amountToWithdraw;
    }
}