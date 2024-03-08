namespace CSharpSyntax;
public class ValuesAndReferences
{
    [Fact]
    public void EntityAndValueDemo()
    {
        decimal myMoney = 5.00M;
        Decimal yourMoney = 5.00M;
        string myName = "Jeff";
        String yourName = "Joe";
        var myAccount = new BankAccount();
        {
            myAccount.Id = 52;
        }
        var yourAccount = new BankAccount();
        yourAccount.Deposit(1000);
    }

    [Fact]
    public void UsingAService()
    {
        var manager = new AccountManager();
        manager.DepositIntoAccount(52, 1000000);
        System.Int32 x = 10;
        Assert.True(x.IsEven());
        var sunday = 3.DaysFromToday();
        var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var evens = numbers.Where(n => n.IsEven());
        //Assert.True(Utils.IsEven(4));
        //Assert.False(Utils.IsEven(5));
    }
}
