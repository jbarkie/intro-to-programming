using Bank;

namespace Banking.UnitTests.Accounts;
public class MakingWithdrawals
{
    [Theory]
    [InlineData(100)]
    [InlineData(2.25)]
    public void MakingAWithdrawalDecreasesTheBalance(decimal amountToWithdraw)
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact]
    public void OverdraftNotAllowed()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        account.Withdraw(account.GetBalance() + .01M);

        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void AreAnyDecimalsAllowed()
    {
        var account = new BankAccount();

        account.Withdraw(-5230);

        Assert.Equal(5000M, account.GetBalance());
    }
}
