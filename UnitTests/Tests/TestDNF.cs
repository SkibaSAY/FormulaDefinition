using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FormulaDefinition;

namespace UnitTests.Tests
{
    [TestClass]
    public class TestDNF
    {
        [TestMethod]
        public void DNF_1() //формула уже в виде ДНФ
        {
            var input = "((A∧C)∧B)";
            var formula = Formula.Load(input);
            var dnfFormula = formula.DNF();

            var result = "((A∧C)∧B)";
            var res = dnfFormula.ToString();
            Assert.AreEqual(result,res);
        }

        [TestMethod]
        public void DNF_2()
        {
            var input = "((A∨B)∧C)";
            var formula = Formula.Load(input);
            var dnfFormula = formula.DNF();

            var result = "((A∧C)∨(B∧C))";
            var res = dnfFormula.ToString();
            Assert.AreEqual(result, res);
        }
        [TestMethod]
        public void DNF_3()
        {
            var input = "((A→(B→C))→((A→¬C)→(A→¬B)))";
            var formula = Formula.Load(input);
            var dnfFormula = formula.DNF();

            var result = "((A∧(B∧¬C))∨((A∧C)∨(¬A∨¬B)))";
            var res = dnfFormula.ToString();
            Assert.AreEqual(result, res);
        }
        [TestMethod]
        public void DNF_4()
        {
            var input = "(((p→q)→r)→p)";
            var formula = Formula.Load(input);
            var dnfFormula = formula.DNF();

            var result = "(((¬p∧¬r)∨(q∧¬r))∨p)";
            var res = dnfFormula.ToString();
            Assert.AreEqual(result, res);
        }
    }
}
