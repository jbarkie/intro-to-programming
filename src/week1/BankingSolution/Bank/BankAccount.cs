﻿namespace Bank;

public class BankAccount
{
    private ICalculateBonusesForDeposits _bonusCalculator;
    private decimal _currentBalance = 5000M;

    public BankAccount(ICalculateBonusesForDeposits bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    public virtual void Deposit(decimal amountToDeposit)
    {
        GuardTransactionAmount(amountToDeposit);
        decimal bonus = _bonusCalculator.CalculateDepositBonusFor(_currentBalance, amountToDeposit);
        _currentBalance += amountToDeposit + bonus;
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