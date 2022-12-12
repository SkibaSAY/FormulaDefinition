using FormulaDefinition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class Test_RecurseSubstitution
    {
        [TestMethod]
        public void Test_1()
        {
            var formula = Formula.Load("Abc");
            var substitution = new Dictionary<string, Formula>();

            substitution.Add("Abc", Formula.Load("(B∨С)"));
            substitution.Add("B", Formula.Load("((!A→С)∨(B∨!C))"));

            var result = formula.RecurseSubstitution(substitution);
            Assert.AreEqual(result.ToString(), "(B∨С)");
        }
        [TestMethod]
        public void Test_2()
        {
            var formula = Formula.Load("!B");
            var substitution = new Dictionary<string, Formula>();

            substitution.Add("Abc", Formula.Load("(B∨С)"));
            substitution.Add("B", Formula.Load("((!A→С)∨(B∨!C))"));

            var result = formula.RecurseSubstitution(substitution);
            Assert.AreEqual(result.ToString(), "¬((¬A→С)∨(B∨¬C))");
        }
        [TestMethod]
        public void Test_3()
        {
            var formula = Formula.Load("((!B∨A)→!A)");
            var substitution = new Dictionary<string, Formula>();

            substitution.Add("A", Formula.Load("(B∨С)"));
            substitution.Add("B", Formula.Load("((!A→С)∨(B∨!C))"));

            var result = formula.RecurseSubstitution(substitution);
            Assert.AreEqual(result.ToString(), "((¬((¬A→С)∨(B∨¬C))∨(B∨С))→¬(B∨С))");
        }
    }
}
