using FormulaDefinition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MPRuleTest
{
    [TestClass]
    public class MPRuleTest
    {
        [TestMethod]
        public void Use_1()
        {
            var A = Formula.Load("A");
            var A_B = Formula.Load("(A→B)");
            var result = MPRule.Use(A, A_B);

            Assert.AreEqual("B", result.ToString());
        }
        [TestMethod]
        public void Use_2()
        {
            var A = Formula.Load("(A→B)");
            var A_B = Formula.Load("((A→B)→C)");
            var result = MPRule.Use(A, A_B);

            Assert.AreEqual("C", result.ToString());
        }

        [TestMethod]
        public void Use_3()
        {
            var A = Formula.Load("(A→C)");
            var A_B = Formula.Load("((A→B)→C)");
            var result = MPRule.Use(A, A_B);

            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void Use_4()
        {
            var A = Formula.Load("A");
            var A_B = Formula.Load("(A→(A→B))");
            var result = MPRule.Use(A, A_B);

            Assert.AreEqual("(A→B)", result.ToString());
        }
        [TestMethod]
        public void Use_5()
        {
            var A = Formula.Load("!A");
            var A_B = Formula.Load("(A→(A→B))");
            var result = MPRule.Use(A, A_B);

            Assert.AreEqual(null, result);
        }
    }
}
