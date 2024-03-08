namespace CSharpSyntax;
public class MoreTypes
{
    [Fact]
    public void PropertiesAndStuff()
    {
        var c = new Customer();
        c.Name = "Bob";
        Assert.Equal("Bob", c.Name);

        var myCustomers = new Dictionary<string, Customer>()
        {
            { "bob", new Customer() { Name="Bob Smith"} },
            { "sue", new Customer() { Name="Sue Jones" } }
        };
        Assert.Equal(0, myCustomers["sue"].CreditLimit);
    }
}
