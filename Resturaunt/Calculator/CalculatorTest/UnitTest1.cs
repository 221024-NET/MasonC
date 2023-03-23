namespace Calc.Test;
public class UnitTest1
{
    [Fact]
    //[InlineData("3+5-9+4")]
    public void Equals3()
    {
        string s = "3+5-9+4";
        var Calc = new Calculator();

        int result = Calc.doCalculation(s);

        Assert.Equal(3, result);
    }

    [Fact]
    public void Equals1()
    {
        string s = "3+4-6-2";
        var Calc = new Calculator();

        int result = Calc.doCalculation(s);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void Equals404()
    {
        string s = "+4-6-2";
        var Calc = new Calculator();

        int result = Calc.doCalculation(s);

        Assert.Equal(-404, result);
    }
}