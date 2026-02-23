using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace QuantityMeasurementApp.Tests;

[TestClass]
public sealed class FeetTests
{
    [TestMethod]
    public void GivenTwoFeetValues_ShouldReturnTrue()
    {
        bool result = QuantityMeasurementAppService.AreFeetEqual(4, 4);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GivenDifferentFeetValues_ShouldReturnFalse()
    {
        bool result = QuantityMeasurementAppService.AreFeetEqual(4, 5);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void GivenOneNegativeFeetValue_ShouldThrowArgumentException()
    {
        try
        {
            QuantityMeasurementAppService.AreFeetEqual(-3, 3);
            Assert.Fail("Expected ArgumentException was not thrown.");
        }
        catch (ArgumentException)
        {
            Assert.IsTrue(true); 
        }
    }

    [TestMethod]

    public void GivenNegativeFeetValues_ShouldThrowArgumentException()
    {
        try
        {
            QuantityMeasurementAppService.AreFeetEqual(-3, -3);
            Assert.Fail("Expected ArgumentException was not thrown.");
        }
        catch (ArgumentException)
        {
            Assert.IsTrue(true); 
        }
    }

    [TestMethod]
    public void GivenDecimalFeetValues_ShouldReturnTrue()
    {
        bool result = QuantityMeasurementAppService.AreFeetEqual(2.5, 2.5);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GivenDecimalFeetValues_ShouldReturnFalse()
    {
        bool result = QuantityMeasurementAppService.AreFeetEqual(2.5, 2.6);
        Assert.IsFalse(result);
    }
}