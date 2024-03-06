namespace StringCalculator.Tests;
public class Calculator
{
    public int Add(string numbers)
    {
        int result = 0;
        if (string.IsNullOrEmpty(numbers)) return result;
        string[] numbersStringArray = numbers.Split(',', '\n');
        foreach (string number in numbersStringArray)
        {
            result += int.Parse(number);
        }
        return result;
    }


}
