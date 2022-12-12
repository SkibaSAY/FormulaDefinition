using FormulaDefinition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FormulaConlutionTest
{
    [TestClass]
    public class FormulaConlutionTest
    {
        public List<Formula> Axioms = new List<Formula>
        {
            Formula.Load("(A→(B→A))"),
            Formula.Load("((A→(B→C))→((A→B)→(A→C)))"),
            Formula.Load("((!B→!A)→((!B→A)→B))")
        };
        [TestMethod]
        public void FormulaConlution_1()
        {
            var hypotheses = new List<Formula>();
            var conclutions = new List<Formula>
            {
                Formula.Load("(A→((B→A)→A))"),//аксиома 1
                Formula.Load("((A→((B→A)→A))→((A→(B→A))→(A→A)))"),//аксиома 2
                Formula.Load("((A→(B→A))→(A→A))"),//МП 1 2
                Formula.Load("(A→(B→A))"),//аксиома 1
                Formula.Load("(A→A)"),//МП 3 4
            };
            var conclution = new FormulConlution(Axioms, hypotheses, conclutions);
            var success = conclution.IsCorrect(out List<string> protocol);

            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void FormulaConlution_1_Negative()
        {
            var hypotheses = new List<Formula>();
            var conclutions = new List<Formula>
            {
                Formula.Load("(A→((B→A)→A))"),//аксиома 1
                Formula.Load("((A→((B→A)→A))→((A→(B→A))→(A→A)))"),//аксиома 2
                Formula.Load("((A→(!B→A))→(A→A))"),//тут краш
                Formula.Load("(A→(B→A))"),//аксиома 1
                Formula.Load("(A→A)"),//МП 3 4
            };
            var conclution = new FormulConlution(Axioms, hypotheses, conclutions);
            var success = conclution.IsCorrect(out List<string> protocol);

            Assert.AreEqual(false, success);
        }

        [TestMethod]
        public void FormulaConlution_2()
        {
            var hypotheses = new List<Formula> {Formula.Load("(!A→!A)"), Formula.Load("!!A") };
            var conclutions = new List<Formula>
            {
                Formula.Load("((!A→!!A)→((!A→!A)→A))"),//аксиома 3
                Formula.Load("(!A→!A)"),//гипотеза
                Formula.Load("(!!A→(!A→!!A))"),//аксиома 1
                Formula.Load("!!A"),//гипотеза 
                Formula.Load("(!A→!!A)"),//МП 3 4
                Formula.Load("((!A→!A)→A)"), //МП 1 5
                Formula.Load("A") //МП 2 6
            };
            var conclution = new FormulConlution(Axioms, hypotheses, conclutions);
            var success = conclution.IsCorrect(out List<string> protocol);

            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void FormulaConlution_2_Without2Hyphotis()
        {
            var hypotheses = new List<Formula> { Formula.Load("(!A→!A)")};
            var conclutions = new List<Formula>
            {
                Formula.Load("((!A→!!A)→((!A→!A)→A))"),//аксиома 3
                Formula.Load("(!A→!A)"),//гипотеза
                Formula.Load("(!!A→(!A→!!A))"),//аксиома 1
                Formula.Load("!!A"),// ошибка сертификата, тк гипотезы нет 
                Formula.Load("(!A→!!A)"),//МП 3 4
                Formula.Load("((!A→!A)→A)"), //МП 1 5
                Formula.Load("A") //МП 2 6
            };
            var conclution = new FormulConlution(Axioms, hypotheses, conclutions);
            var success = conclution.IsCorrect(out List<string> protocol);

            Assert.AreEqual(false, success);
        }
    }
}
