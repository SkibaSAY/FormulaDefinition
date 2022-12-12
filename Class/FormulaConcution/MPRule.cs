using FormulaDefinition.Class.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaDefinition
{
    public static class MPRule
    {
        #region вспомогательные классы
        public class MPSource
        {
            public int Index { get; set; }
            public Formula Value { get; set; }
        }
        public class MPResult
        {
            public MPSource A { get; set; }
            public MPSource A_B { get; set; }
        }
        #endregion

        /// <summary>
        /// Получает результат по правилу MP, если оно выполнено
        /// </summary>
        /// <param name="first">A</param>
        /// <param name="second">(A->B)</param>
        /// <returns>B если правило MP выполняется:формула 2 разделяется "импликацией" и начало второй формулы соответсвует первой</returns>
        public static Formula Use(Formula A, Formula A_B)
        {
            if (A_B.Operator is ImplicationOperators)
            {
                if (A_B.First.ToString().Equals(A.ToString())) return A_B.Second; //т.е B
                return null;
            }
            return null;
        }
        public static MPResult DevideFrom(Formula necessaryFromula, List<Formula> famousFormuls)
        {
            var result = new MPResult();

            for (var i = 0; i < famousFormuls.Count; i++)
            {
                var A = famousFormuls[i];
                for (var j = 0; j < famousFormuls.Count; j++)
                {
                    if (i == j) continue;
                    var A_B = famousFormuls[j];
                    var formulaByMP = Use(A, A_B);
                    //если нам повезло и мы нашли пару, из которой что-то выводимо по МП, так ещё и это то, что нужно,
                    //то мы нашли ответ и возвращаем его
                    if (formulaByMP != null && formulaByMP.ToString().Equals(necessaryFromula.ToString()))
                    {
                        result.A = new MPSource { Index = i, Value = A };
                        result.A_B = new MPSource { Index = j, Value = A_B };
                        return result;
                    }
                }
            }
            if (result.A == null || result.A_B == null) return null;
            return result;
        }
    }
}
