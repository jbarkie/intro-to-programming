using Bank;
using NSubstitute;

namespace Banking.UnitTests.Accounts;
public class GoldCustomerDeposits
{

    [Fact]
    public void MakingAGoldAccountDepositEarnsBonus()
    {
        // Given
        var stubbedBonusCalculator = Substitute.For<ICalculateBonusesForDeposits>();
        var account = new BankAccount(stubbedBonusCalculator);
        var amountToDeposit = 142.23M;
        var expectedBonus = 13.23M;
        var openingBalance = account.GetBalance();
        stubbedBonusCalculator.CalculateDepositBonusFor(openingBalance, amountToDeposit).Returns(expectedBonus);

        // When
        // WTCYWTH
        account.Deposit(142.23M);

        // Then
        Assert.Equal(openingBalance + amountToDeposit + expectedBonus, account.GetBalance());
    }
}
