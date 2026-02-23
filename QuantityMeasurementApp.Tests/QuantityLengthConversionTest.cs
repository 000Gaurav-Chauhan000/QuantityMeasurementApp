using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityLengthUC5ConversionTests
    {
        private const double Eps = 1e-6;

        [TestMethod]
        public void TestConvert_FeetToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.FEET, LengthUnit.INCHES);
            Assert.AreEqual(12.0, result, Eps);
        }

        [TestMethod]
        public void TestConvert_InchesToFeet()
        {
            double result = QuantityLength.Convert(24.0, LengthUnit.INCHES, LengthUnit.FEET);
            Assert.AreEqual(2.0, result, Eps);
        }

        [TestMethod]
        public void TestConvert_YardsToFeet()
        {
            double result = QuantityLength.Convert(2.0, LengthUnit.YARDS, LengthUnit.FEET);
            Assert.AreEqual(6.0, result, Eps);
        }

        [TestMethod]
        public void TestConvert_YardsToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.YARDS, LengthUnit.INCHES);
            Assert.AreEqual(36.0, result, Eps);
        }

        [TestMethod]
        public void TestConvert_CmToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.CENTIMETERS, LengthUnit.INCHES);
            Assert.AreEqual(0.393701, result, Eps);
        }

        [TestMethod]
        public void TestConvert_CmToFeet()
        {
            double result = QuantityLength.Convert(30.48, LengthUnit.CENTIMETERS, LengthUnit.FEET);
            Assert.AreEqual(1.0, result, 1e-4); 
        }

        [TestMethod]
        public void TestConvert_InstanceMethod_YardsToFeet()
        {
            var q = new QuantityLength(1.0, LengthUnit.YARDS);
            double result = q.ConvertTo(LengthUnit.FEET).Value;
            Assert.AreEqual(3.0, result, Eps);
        }
    }
}