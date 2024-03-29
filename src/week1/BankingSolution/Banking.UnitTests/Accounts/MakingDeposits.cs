﻿using Bank;
using NSubstitute;

namespace Banking.UnitTests.Accounts;
public class MakingDeposits
{
    [Theory]
    [InlineData(100)]
    [InlineData(42.23)]
    public void MakingADepositIncreasesBalance(decimal amountToDeposit)
    {
        // Given
        var account = new BankAccount(Substitute.For<ICalculateBonusesForDeposits>());
        var openingBalance = account.GetBalance();

        // When
        // WTCYWTH
        account.Deposit(amountToDeposit);

        // Then
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }
}
