using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaDefinition
{
    public class FormulConlution
    {
        public List<Formula> Axioms = new List<Formula>();
        public List<Formula> Нypotheses = new List<Formula>();
        public List<Formula> Conclution = new List<Formula>();

        public FormulConlution(List<Formula> Axioms, List<Formula> Hypotheses, List<Formula> Conlutions)
        {
            this.Axioms = Axioms;
            this.Нypotheses = Hypotheses;
            this.Conclution = Conlutions;
        }
        public FormulConlution(string pathAxioms,string pathHypotheses,string pathConlution)
        {
            Axioms = ReadFormulList(pathAxioms);
            Нypotheses = ReadFormulList(pathHypotheses);
            Conclution = ReadFormulList(pathConlution);
        }
        public bool IsCorrect(out List<string> protocol)
        {
            protocol = new List<string>();
            var lastFormuls = new List<Formula>();
            foreach (var formula in Conclution)
            {
                var success = false;
                //аксиома
                if (!success)
                {
                    var equalAxiom = formula.GetEqualAxiom(Axioms);
                    if (equalAxiom != null)
                    {
                        protocol.Add($"{formula} : Аксиома({equalAxiom})");
                        success = true;
                    }
                }

                //гипотеза
                if (!success)
                {
                    //ищем первую подходящую аксиому
                    var equalHepotis = Нypotheses.Find(h=>h.Equals(formula));
                    if (equalHepotis!=null)
                    {
                        protocol.Add($"{formula} : Гипотеза({equalHepotis})");
                        success = true;
                    }
                }

                //по правилу MP
                if (!success)
                {
                    var mpResult = MPRule.DevideFrom(
                        necessaryFromula: formula,
                        famousFormuls: lastFormuls
                    );

                    if (mpResult != null)
                    {
                        protocol.Add($"{formula} : Получена по правилу MP из формул ({mpResult.A.Index+1}) {mpResult.A.Value}  и  " +
                            $"({mpResult.A_B.Index+1}) {mpResult.A_B.Value}");
                        success = true;
                    }
                }

                //если ничего не подошло, значит формула не имеет Сертификата(Таблички)
                if (!success)
                {
                    protocol.Add($"{formula} : не имеет Сертификата(Таблички)");
                    return false;
                }

                //если сюда попали, значит проверку прошли и могут использоваться для проверки правила MP
                lastFormuls.Add(formula);
            }

            return true;
        }
        private List<Formula> ReadFormulList(string path)
        {
            var list = new List<Formula>();
            if (File.Exists(path))
            {
                var arr = File.ReadAllLines(path);
                list = arr.Select(x => Formula.Load(x)).ToList();
            }
            return list;
        }
    }
}
