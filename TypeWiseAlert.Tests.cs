using Xunit;

public class TypeWiseAlertTests
{
    [Theory]
    [InlineData(TypeWiseAlert.CoolingType.PASSIVE_COOLING, 20, TypeWiseAlert.BreachType.NORMAL)]
   
    public void ClassifyTemperatureBreach_ReturnsCorrectBreachType(TypeWiseAlert.CoolingType coolingType, double temperature, TypeWiseAlert.BreachType expectedBreach)
    {
        var result = TypeWiseAlert.ClassifyTemperatureBreach(coolingType, temperature);
        Assert.Equal(expectedBreach, result);
    }
}
