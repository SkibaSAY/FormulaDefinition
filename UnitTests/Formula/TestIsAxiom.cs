using FormulaDefinition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests.Tests
{
    [TestClass]
    public class TestIsAxiom
    {
        public static readonly List<Formula> axioms = new List<Formula>
        {
            Formula.Load("(A→(B→A))"),
            Formula.Load("((A→(B→C))→((A→B)→(A→C)))")
        };

        [TestMethod]
        public void Test_1()
        {
            var formula = Formula.Load("(C→(A→C))");
            var succes = formula.IsAxiom(axioms);
            Assert.AreEqual(succes, true);
        }
        [TestMethod]
        public void Test_2()
        {
            var formula = Formula.Load("(B→(A→C))");
            var succes = formula.IsAxiom(axioms);
            Assert.AreEqual(succes, false);
        }
        [TestMethod]
        public void Test_3()
        {
            var formula = Formula.Load("(!B→(!A→!B))");
            var succes = formula.IsAxiom(axioms);
            Assert.AreEqual(succes, true);
        }
        [TestMethod]
        public void Test_4()
        {
            var formula = axioms[1];
            var succes = formula.IsAxiom(axioms);
            Assert.AreEqual(succes, true);
        }
        [TestMethod]
        public void Test_5()
        {
            var formula = axioms[1];
            var substitution = new Dictionary<string, Formula>();
            substitution.Add("A", Formula.Load("(B∨С)"));
            substitution.Add("B", Formula.Load("((!A→С)∨(B∨!C))"));

            formula = formula.RecurseSubstitution(substitution);
            var succes = formula.IsAxiom(axioms);
            Assert.AreEqual(succes, true);
        }
        [TestMethod]
        public void Test_6()
        {
            var formula = axioms[0];
            var substitution = new Dictionary<string, Formula>();
            substitution.Add("A", Formula.Load("(A∨С)"));
            substitution.Add("B", Formula.Load("((!A→С)→(B∨!C))"));

            formula = formula.RecurseSubstitution(substitution);
            var succes = formula.IsAxiom(axioms);
            Assert.AreEqual(succes, true);
        }
    }
}
