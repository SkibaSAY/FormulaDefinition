using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FormulaDefinition;

namespace UnitTests.Tests
{
    [TestClass]
    public class TestCloseNegatives
    {
        [TestMethod]
        public void CloseNegatives_1()
        {
            var input = "¬(A∨B)";
            var formula = Formula.Load(input);
            formula.СloseNegatives();
            var res = formula.ToString();

            var curResult = "(¬A∧¬B)";
            Assert.AreEqual(curResult, res);
        }
        [TestMethod]
        public void CloseNegatives_2()
        {
            var input = "(A→B)";
            var formula = Formula.Load(input);
            formula.СloseNegatives();
            var res = formula.ToString();

            var curResult = "(¬A∨B)";
            Assert.AreEqual(curResult, res);
        }
        [TestMethod]
        public void CloseNegatives_3()
        {
            var input = "(((X→Y)→(Z→¬X))→(¬Y→¬Z))";
            var formula = Formula.Load(input);
            formula.СloseNegatives();
            var res = formula.ToString();

            var curResult = "(((¬X∨Y)∧(Z∧X))∨(Y∨¬Z))";
            Assert.AreEqual(curResult, res);
        }
    }
}
