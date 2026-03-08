using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityWeightTests
    {
        private const double Eps = 1e-6;

        [TestMethod]
        public void TestEquality_KilogramToKilogram_SameValue()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(1.0, WeightUnit.KILOGRAM);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void TestEquality_GramToGram_SameValue()
        {
            var a = new QuantityWeight(1000.0, WeightUnit.GRAM);
            var b = new QuantityWeight(1000.0, WeightUnit.GRAM);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void TestEquality_PoundToPound_SameValue()
        {
            var a = new QuantityWeight(2.0, WeightUnit.POUND);
            var b = new QuantityWeight(2.0, WeightUnit.POUND);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void TestEquality_KilogramToGram_EquivalentValue()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(1000.0, WeightUnit.GRAM);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void TestEquality_KilogramToPound_EquivalentValue()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(2.2046244201837775, WeightUnit.POUND);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void TestEquality_GramToPound_EquivalentValue()
        {
            var a = new QuantityWeight(453.592, WeightUnit.GRAM);
            var b = new QuantityWeight(1.0, WeightUnit.POUND);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void TestConvert_KilogramToGram()
        {
            var result = new QuantityWeight(1.0, WeightUnit.KILOGRAM).ConvertTo(WeightUnit.GRAM);

            Assert.AreEqual(1000.0, result.Value, Eps);
            Assert.AreEqual(WeightUnit.GRAM, result.Unit);
        }

        [TestMethod]
        public void TestConvert_GramToKilogram()
        {
            var result = new QuantityWeight(1000.0, WeightUnit.GRAM).ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(1.0, result.Value, Eps);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void TestConvert_PoundToKilogram()
        {
            var result = new QuantityWeight(1.0, WeightUnit.POUND).ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(0.453592, result.Value, Eps);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void TestAdd_KilogramPlusGram_ResultInFirstOperandUnit()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(500.0, WeightUnit.GRAM);

            var result = a.Add(b);

            Assert.AreEqual(1.5, result.Value, Eps);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void TestAdd_PoundPlusGram_TargetKilogram()
        {
            var a = new QuantityWeight(1.0, WeightUnit.POUND);
            var b = new QuantityWeight(500.0, WeightUnit.GRAM);

            var result = a.Add(b, WeightUnit.KILOGRAM);

            Assert.AreEqual(0.953592, result.Value, Eps);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void TestAdd_KilogramPlusKilogram_TargetPound()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(1.0, WeightUnit.KILOGRAM);

            var result = a.Add(b, WeightUnit.POUND);

            Assert.AreEqual(2.0 / 0.453592, result.Value, 1e-5);
            Assert.AreEqual(WeightUnit.POUND, result.Unit);
        }

        [TestMethod]
        public void TestWeightAndLength_AreNotEqual()
        {
            var weight = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var length = new QuantityLength(1.0, LengthUnit.FEET);

            Assert.IsFalse(weight.Equals(length));
        }

        [TestMethod]
        public void TestEquality_NullComparison()
        {
            var weight = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            Assert.IsFalse(weight.Equals(null));
        }

        [TestMethod]
        public void TestEquality_SameReference()
        {
            var weight = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            Assert.IsTrue(weight.Equals(weight));
        }
    }
}