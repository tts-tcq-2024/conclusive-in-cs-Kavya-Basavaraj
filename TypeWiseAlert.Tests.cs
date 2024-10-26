using Xunit;

public class TypeWiseAlertTests
{
    [Theory]
    [InlineData(TypeWiseAlert.CoolingType.PASSIVE_COOLING, 20, TypeWiseAlert.BreachType.NORMAL)]
    [InlineData(TypeWiseAlert.CoolingType.PASSIVE_COOLING, -1, TypeWiseAlert.BreachType.TOO_LOW)]
   
    public void ClassifyTemperatureBreach_ReturnsCorrectBreachType(TypeWiseAlert.CoolingType coolingType, double temperature, TypeWiseAlert.BreachType expectedBreach)
    {
        var result = TypeWiseAlert.ClassifyTemperatureBreach(coolingType, temperature);
        Assert.Equal(expectedBreach, result);
    }

    [Fact]
    public void CheckAndAlert_SendsToController()
    {
        var batteryChar = new TypeWiseAlert.BatteryCharacter { coolingType = TypeWiseAlert.CoolingType.PASSIVE_COOLING, brand = "BrandX" };
        TypeWiseAlert.CheckAndAlert(TypeWiseAlert.AlertTarget.TO_CONTROLLER, batteryChar, 36);
        // Validate console output, possibly using a custom TextWriter
    }

   
}
