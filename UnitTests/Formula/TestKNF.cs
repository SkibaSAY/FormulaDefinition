using FormulaDefinition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.Tests
{
    [TestClass]
    public class TestKNF
    {
        [TestMethod]
        public void KNF_1() //формула уже в виде ДНФ
        {
            var input = "((A∧C)∧B)";
            var formula = Formula.Load(input);
            var knfFormula = formula.KNF();

            var result = "((A∧C)∧B)";
            var res = knfFormula.ToString();
            Assert.AreEqual(result, res);
        }

        [TestMethod]
        public void KNF_2()
        {
            var input = "((A∨B)∧C)";
            var formula = Formula.Load(input);
            var knfFormula = formula.KNF();

            var result = "((A∨B)∧C)";
            var res = knfFormula.ToString();
            Assert.AreEqual(result, res);
        }
        [TestMethod]
        public void KNF_3()
        {
            var input = "((A∧B)∨C)";
            var formula = Formula.Load(input);
            var knfFormula = formula.KNF();

            var result = "((A∨C)∧(B∨C))";
            var res = knfFormula.ToString();
            Assert.AreEqual(result, res);
        }
    }
}
