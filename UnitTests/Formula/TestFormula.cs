using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FormulaDefinition;
using FormulaDefinition.Class.Operators;

namespace UnitTests.Tests
{
    [TestClass]
    public class TestFormula
    {
        [TestMethod]
        public void FormulaConstructor()
        {
            var inputStr = "((Asd→sdsa)&(Ads→sa122))";
            var formula = Formula.Load(inputStr);
            var flag = formula.Operator is AndOperators;
            Assert.AreEqual(flag,true);
        }

        [TestMethod]
        public void FormulaConstructor_negative()
        {
            var inputStr = "!((Asd→sdsa)&(Ads→sa122))";
            var formula = Formula.Load(inputStr);
            var flag = formula.Operator is NegativeOperators;
            Assert.AreEqual(flag, true);
        }

        [TestMethod]
        public void FormulaConstructor_MultiNegative()
        {
            var inputStr = "!!!!!!(!(!Asd→sdsa)&(Ads→!sa122))";
            var formula = Formula.Load(inputStr);

            var res = formula.ToString();
            var curRes = "(¬(¬Asd→sdsa)∧(Ads→¬sa122))";
            
            Assert.AreEqual(curRes, res);
        }

        [TestMethod]
        public void FormulaConstructor_MultiNegative_2()
        {
            var inputStr = "!!!!!(!!(!!Asd→sdsa)&(!!!Ads→!!sa122))";
            var formula = Formula.Load(inputStr);

            var res = formula.ToString();
            var curRes = "¬((Asd→sdsa)∧(¬Ads→sa122))";

            Assert.AreEqual(curRes, res);
        }
    }
}
