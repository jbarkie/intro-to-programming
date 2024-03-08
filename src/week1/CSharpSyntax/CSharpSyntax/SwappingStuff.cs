namespace CSharpSyntax;
public class SwappingStuff
{
    [Fact]
    public void CanSwapStuff()
    {
        var a = 10;
        var b = 15;

        // Magic!
        Swappers.Swap(ref a, ref b);
        Assert.Equal(15, a);
        Assert.Equal(10, b);

        var x = "Dumb";
        var y = "Dumber";
        Swappers.Swap(ref x, ref y);
        Assert.Equal("Dumber", x);
        Assert.Equal("Dumb", y);
    }
}

public class Swappers
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = b;
        b = a;
        a = temp;
    }
}
