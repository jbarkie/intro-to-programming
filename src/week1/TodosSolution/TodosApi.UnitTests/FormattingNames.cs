namespace TodosApi.UnitTests;
public class FormattingNames
{
    [Theory]
    [InlineData("Bob", "Smith", "Bob Smith")]
    [InlineData("Jill", "Jones", "Jill Jones")]
    public void NamesAreFormattedProperly(string firstName, string lastName, string expected)
    {
        var utils = new Utils();

        var fullName = utils.FormatName(firstName, lastName);

        Assert.Equal(expected, fullName);
    }
}
