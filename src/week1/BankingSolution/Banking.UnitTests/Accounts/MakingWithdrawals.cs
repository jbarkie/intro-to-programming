using Bank;
using NSubstitute;

namespace Banking.UnitTests.Accounts;
public class MakingWithdrawals
{
    [Theory]
    [InlineData(100)]
    [InlineData(2.25)]
    public void MakingAWithdrawalDecreasesTheBalance(decimal amountToWithdraw)
    {
        var account = new BankAccount(Substitute.For<ICalculateBonusesForDeposits>());
        var openingBalance = account.GetBalance();

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact]
    public void OverdraftNotAllowed()
    {
        var account = new BankAccount(Substitute.For<ICalculateBonusesForDeposits>());
        var openingBalance = account.GetBalance();

        Assert.Throws<OverdraftException>(() =>
        {
            account.Withdraw(account.GetBalance() + .01M);
        });

        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void CanWithdrawAllMoney()
    {
        var account = new BankAccount(Substitute.For<ICalculateBonusesForDeposits>());
        var openingBalance = account.GetBalance();
        account.Withdraw(openingBalance);

    }

    [Theory]
    [InlineData(-1.0)]
    [InlineData(0)]
    public void ValidatesAmountForWithdrawal(decimal amountToWithdraw)
    {
        var account = new BankAccount(Substitute.For<ICalculateBonusesForDeposits>());
        var openingBalance = account.GetBalance();
        Assert.Throws<InvalidTransactionAmountException>(() => account.Withdraw(amountToWithdraw));
        Assert.Equal(openingBalance, account.GetBalance());
    }
}
