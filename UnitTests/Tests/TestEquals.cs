using FormulaDefinition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.Tests
{
    [TestClass]
    public class TestEquals
    {
        [TestMethod]
        public void TestEquals_1()
        {
            var formula1 = Formula.Load("(A→B)");
            var formula2 = Formula.Load("(¬A∨B)");
            var result = formula1.Equals(formula2);

            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public void TestEquals_2_DNF()
        {
            var formula1 = Formula.Load("((A∨B)∧C)");
            var formula2 = Formula.Load("((A∧C)∨(B∧C))");
            var result = formula1.Equals(formula2);

            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public void TestEquals_3_DNF()
        {
            var formula1 = Formula.Load("((A→(B→C))→((A→¬C)→(A→¬B)))");
            var formula2 = Formula.Load("((A∧(B∧¬C))∨((A∧C)∨(¬A∨¬B)))");
            var result = formula1.Equals(formula2);

            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public void TestEquals_3_KNF()
        {
            var formula1 = Formula.Load("((A∧B)∨C)");
            var formula2 = Formula.Load("((A∨C)∧(B∨C))");
            var result = formula1.Equals(formula2);

            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public void TestEquals_3()
        {
            var formula1 = Formula.Load("((A∨B)∧C)");
            var formula2 = Formula.Load("((A∧C)∨(B∨C))");
            var result = formula1.Equals(formula2);

            Assert.AreEqual(result, false);
        }
        [TestMethod]
        public void TestEquals_4()
        {
            var formula1 = Formula.Load("A");
            var formula2 = Formula.Load("B");
            var result = formula1.Equals(formula2);

            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestEquals_5()
        {
            var formula1 = Formula.Load("(A∨B)");
            var formula2 = Formula.Load("(B∨C)");
            var result = formula1.Equals(formula2);

            //тк пропозицональные переменные разные, а мы смотрим на таблицу истинности из [A B C]
            Assert.AreEqual(result, false);
        }
    }
}
