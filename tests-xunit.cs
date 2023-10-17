dotnet new xunit -o MyWebApp.Tests

public class PrimeService
{
    [Fact]
    public void IsPrime_InputIs1_ReturnFalse()
    {
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
    {
    }
}