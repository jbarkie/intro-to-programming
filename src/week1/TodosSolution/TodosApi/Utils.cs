namespace TodosApi;
public class Utils : IFormatDisplayInformation
{
    public string FormatName(string firstName, string lastName)
    {
        return $"{firstName} {lastName}";
    }
}