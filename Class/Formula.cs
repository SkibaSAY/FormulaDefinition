using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FormulaDefinition.Class.Operators;

namespace FormulaDefinition
{
    public class Formula
    {
        private string baseItem;

        private List<OperatorBase> BaseOperators = new List<OperatorBase>()
        {
            new NegativeOperators(),
            new ImplicationOperators(),
            new AndOperators(),
            new OrOperators()
        };

        #region public

        public Formula First;

        public OperatorBase Operator;

        public Formula Second;

        #endregion

        public Formula(string inputStr)
        {
            if (Rule1.IsMatch(inputStr))
            {
                baseItem = inputStr;
            }
            else if (Rule2.IsMatch(inputStr))
            {
                var first = Rule2.Match(inputStr).Groups["First"].Value;
                First = new Formula(first);

                var operation = Rule2.Match(inputStr).Groups["Operator"].Value;
                Operator = BaseOperators.Find(x => x.Symbols.Contains(operation));

                var second  = Rule2.Match(inputStr).Groups["Second"].Value;
                Second = new Formula(second);
            }
            else//сработала аксиома 3
            {
                var first = Rule3.Match(inputStr).Groups["First"].Value;
                Operator = new NegativeOperators();
                First = new Formula(first);
            }
        }

        #region Аксиомы
        public static Regex Rule1 = new Regex(@"^\w+$", RegexOptions.Compiled);
        public static Regex Rule2 = new Regex($@"^\((?<First>({new NegativeOperators().ToString()})*(\w+))(?<Operator>({new ImplicationOperators().ToString()})|({new AndOperators().ToString()})|({new OrOperators().ToString()}))(?<Second>({new NegativeOperators().ToString()})*(\w+))\)$", RegexOptions.Compiled);
        public static Regex Rule3 = new Regex($@"^(({new NegativeOperators().ToString()})+)(?<First>\w+)$", RegexOptions.Compiled);
        #endregion

        public static bool ItIsFormula(string inputStr)
        {
            var stack = new Stack<string>();
            var iteratorForF = 1;

            foreach (var ch in inputStr)
            {
                switch (ch)
                {
                    case ')':

                        var flag = true;
                        var sb = new StringBuilder();
                        sb.Append(")");
                        do
                        {
                            if (stack.Count==0)
                            {
                                return false;
                            }
                            else if (stack.Peek().Equals("("))
                            {
                                flag = false;
                            }
                            sb.Append(stack.Pop());
                        } while (flag);

                        var formulChallenger = String.Join("",(sb.ToString().Reverse()));
                        var isFormula = IsFormulaRegex(formulChallenger);
                        if (!isFormula) return false;
                        else
                        {
                            stack.Push($"F{iteratorForF}");
                            iteratorForF++;
                        }
                        break;
                    default:
                        stack.Push(ch.ToString());
                        break;
                }
            }

            //там могла быть константа
            if (stack.Count != 0)
            {
                var sb = new StringBuilder();
                while (stack.Count!=0)
                {
                    sb.Append(stack.Pop());
                }
                var formulChallenger = String.Join("", (sb.ToString().Reverse()));
                if (!IsFormulaRegex(formulChallenger)) return false;
            }
            return true;
        }

        /// <summary>
        /// Проверка подготовленных строк по 3 правилам
        /// </summary>
        /// <param name="preparedFormula"></param>
        /// <returns>Формула или нет</returns>
        private static bool IsFormulaRegex(string preparedFormula)
        {
            if (Rule1.IsMatch(preparedFormula) || Rule2.IsMatch(preparedFormula) || Rule3.IsMatch(preparedFormula))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            var res = First.ToString();
            if (Operator == null)
            {
                res = baseItem;
            }
            else if (Operator is NegativeOperators)//унарный оператор
            {
                res = Operator.Symbols.First() + res;
            }
            else//бинарный оператор
            {
                //тут обязательны скобки, это для удовлетворения аксиомам формул
                res = $"({res}{Operator.Symbols.First()}{Second.ToString()})";
            }

            return res;
        }
    }
}
