using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FormulaDefinition;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestRule1_1()
        {
            var input = "A";
            var result = Formula.ItIsFormula(input);

            Assert.AreEqual(true,result);
        }
        [TestMethod]
        public void TestRule1_2()
        {
            var input = "Asd212";
            var result = Formula.ItIsFormula(input);

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestRule2_1()
        {
            var input = "Asd→sdsa";
            var result = Formula.ItIsFormula(input);

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void TestRule2_2()
        {
            var input = "((Asd→sdsa)&(Ads→sa122))";
            var result = Formula.ItIsFormula(input);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestRule3_1()
        {
            var input = "¬sdsa";
            var result = Formula.ItIsFormula(input);

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestRule3_2()
        {
            var input = "¬((Asd→sdsa)&(Ads→sa122))";
            var result = Formula.ItIsFormula(input);

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestRule3_3()
        {
            var input = "¬(¬F→B)";
            var result = Formula.ItIsFormula(input);

            Assert.AreEqual(true, result);
        }
    }
}
