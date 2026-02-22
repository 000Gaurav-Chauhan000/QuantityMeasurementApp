using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp;

namespace QuantityMeasurementApp.Tests;

[TestClass]
public sealed class InchesTests
{
    [TestMethod]
    public void GivenTwoInchesValues_ShouldReturnTrue()
    {
        bool result = QuantityMeasurementAppService.AreInchesEqual(4, 4);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GivenDifferentInchesValues_ShouldReturnFalse()
    {
        bool result = QuantityMeasurementAppService.AreInchesEqual(4, 5);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void GivenOneNegativeInchesValue_ShouldThrowArgumentException()
    {
        try
        {
            QuantityMeasurementAppService.AreInchesEqual(-3, 3);
            Assert.Fail("Expected ArgumentException was not thrown.");
        }
        catch (ArgumentException)
        {
            Assert.IsTrue(true); 
        }
    }

    [TestMethod]

    public void GivenNegativeInchesValues_ShouldThrowArgumentException()
    {
        try
        {
            QuantityMeasurementAppService.AreInchesEqual(-3, -3);
            Assert.Fail("Expected ArgumentException was not thrown.");
        }
        catch (ArgumentException)
        {
            Assert.IsTrue(true); 
        }
    }

    [TestMethod]
    public void GivenDecimalInchesValues_ShouldReturnTrue()
    {
        bool result = QuantityMeasurementAppService.AreInchesEqual(2.5, 2.5);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GivenDecimalInchesValues_ShouldReturnFalse()
    {
        bool result = QuantityMeasurementAppService.AreInchesEqual(2.5, 2.6);
        Assert.IsFalse(result);
    }
}