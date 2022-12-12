using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FormulaDefinition;

namespace UnitTests.Tests
{
    [TestClass]
    public class TestWithoutImplication
    {
        [TestMethod]
        public void TestWithoutImplication_1()
        {
            var input = "(A→B)";
            var formula = Formula.Load(input);
            formula.WithoutInplication();
            var res = formula.ToString();
            var result = "(¬A∨B)";
            Assert.AreEqual(result, res);
        }
        [TestMethod]
        public void TestWithoutImplication_2()
        {
            var input = "((A→B)→¬C)";
            var formula = Formula.Load(input);
            formula.WithoutInplication();
            var res = formula.ToString();
            var result = "(¬(¬A∨B)∨¬C)";
            Assert.AreEqual(result, res);
        }

        [TestMethod]
        public void TestWithoutImplication_3()
        {
            var input = "(((A∨B)→C)→((D∨E)→F))";
            var formula = Formula.Load(input);
            formula.WithoutInplication();
            var res = formula.ToString();
            var result = "(¬(¬(A∨B)∨C)∨(¬(D∨E)∨F))";
            Assert.AreEqual(result, res);
        }

        [TestMethod]
        public void TestWithoutImplication_4()
        {
            var input = "¬(¬С→A)";
            var formula = Formula.Load(input);
            formula.WithoutInplication();
            var res = formula.ToString();
            var result = "¬(С∨A)";
            Assert.AreEqual(result, res);
        }
    }
}
