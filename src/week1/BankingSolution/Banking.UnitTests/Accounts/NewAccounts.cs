using Bank;

namespace Banking.UnitTests.Accounts;
public class NewAccounts
{
    [Fact]
    public void NewAccountsHaveCorrectOpeningBalance()
    {
        // WTCYWHY - "Write the code you WISH YOU HAD"
        // Given - I have a new account
        var account = new BankAccount();
        // When - I get the balance
        decimal openingBalance = account.GetBalance();
        // Then - the account balance is 5000
        Assert.Equal(5000M, openingBalance);
    }
}
