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

        private static List<OperatorBase> BaseOperators = new List<OperatorBase>()
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

        #region Constructors
        public Formula(Formula first, OperatorBase operatoR, Formula second = null)
        {
            if (first == null && second == null) throw new ArgumentException();
            if (first != null && operatoR is NegativeOperators)
            {
                Operator = operatoR;
                First = first;
            }
            else if (first != null && second != null && !(operatoR is NegativeOperators))
            {
                Operator = operatoR;
                First = first;
                Second = second;
            }
        }

        /// <summary>
        /// Внутренний конструктор для создания базовых формул
        /// </summary>
        /// <param name="inputStr"></param>
        private Formula(string inputStr)
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

                var second = Rule2.Match(inputStr).Groups["Second"].Value;
                Second = new Formula(second);
            }
            else//сработала аксиома 3
            {
                var first = Rule3.Match(inputStr).Groups["First"].Value;
                var negCount = Rule3.Match(inputStr).Groups["Negative"].Value.Length;
                if (negCount % 2 == 1)
                    Operator = new NegativeOperators();
                First = new Formula(first);
            }
        }
        #endregion

        /// <summary>
        /// Получение эквивалетной формулы без импликаций
        /// </summary>
        public void WithoutInplication()
        {
            //показатель того, что дошли до низа
            if (baseItem != null) return;

            if (Operator is ImplicationOperators)
            {
                First = new Formula(First, new NegativeOperators());
                Operator = new OrOperators();
                Second = new Formula(Second, new NegativeOperators());
            }
            First.WithoutInplication();
            Second.WithoutInplication();
        }

        /// <summary>
        /// Получение формулы по строке
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static Formula Load(string inputStr)
        {
            var stack = new Stack<string>();
            var iteratorForF = 1;

            var dictFormuls = new Dictionary<string, Formula>();

            foreach (var ch in inputStr)
            {
                switch (ch)
                {
                    case ')':

                        var flag = true;
                        var formulElemets = new List<string>();
                        formulElemets.Add(")");
                        do
                        {
                            if (stack.Count == 0)
                            {
                                return null;
                            }
                            else if (stack.Peek().Equals("("))
                            {
                                flag = false;
                            }
                            formulElemets.Add(stack.Pop());
                        } while (flag);

                        formulElemets.Reverse();

                        var formulChallenger = String.Join("", formulElemets);
                        var isFormula = IsFormulaRegex(formulChallenger);
                        if (!isFormula) return null;
                        else
                        {
                            var formulKey = $"F{iteratorForF}";
                            stack.Push(formulKey);
                            iteratorForF++;

                            #region формирование промежуточной формулы
                            //тк тест пройден, то можно создавать
                            var formulValue = new Formula(formulChallenger);

                            dictFormuls.Add(formulKey, formulValue);
                            #endregion
                        }
                        break;
                    default:
                        stack.Push(ch.ToString());
                        break;
                }
            }

            if (stack.Count != 0)
            {
                var formulElements = new List<string>();
                while (stack.Count != 0)
                {
                    formulElements.Add(stack.Pop());
                }

                formulElements.Reverse();

                var formulChallenger = String.Join("", formulElements);

                if (!IsFormulaRegex(formulChallenger)) return null;
                else
                {
                    var formulValue = new Formula(formulChallenger);

                    dictFormuls.Add("F", formulValue);
                }
            }

            #region Подставновка в формулы других формул по обозначениям

            var resultFormula = dictFormuls["F"];
            dictFormuls.Remove("F");

            resultFormula = resultFormula.RecurseSubstitution(dictFormuls);
            #endregion

            return resultFormula;
        }

        /// <summary>
        /// Встроенный метод обхода для замены обозначений на дочерние формулы
        /// </summary>
        /// <param name="formulDict"></param>
        /// <returns></returns>
        private Formula RecurseSubstitution(Dictionary<string,Formula> formulDict)
        {

            if (First != null)
            {
                First = First.RecurseSubstitution(formulDict);
            }
            else if (formulDict.ContainsKey(baseItem))
            {
                First = formulDict[baseItem].RecurseSubstitution(formulDict);
                formulDict.Remove(baseItem);
                baseItem = null;
            }

            if (Second != null)
            {
                Second = Second.RecurseSubstitution(formulDict);
            }

            //удаляем промежуточное звено
            if (First != null && Operator == null && Second == null) return First;
            return this;
        }

        /// <summary>
        /// Проверка на то, формула или нет
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static bool ItIsFormula(string inputStr)
        {
            var formula = Load(inputStr);
            if (formula == null) return false;
            return true;
        }

        #region Аксиомы
        public static Regex Rule1 = new Regex(@"^\w+$", RegexOptions.Compiled);
        public static Regex Rule2 = new Regex($@"^\((?<First>({new NegativeOperators().ToString()})*(\w+))(?<Operator>({new ImplicationOperators().ToString()})|({new AndOperators().ToString()})|({new OrOperators().ToString()}))(?<Second>({new NegativeOperators().ToString()})*(\w+))\)$", RegexOptions.Compiled);
        public static Regex Rule3 = new Regex($@"^(?<Negative>(({new NegativeOperators().ToString()})+))(?<First>\w+)$", RegexOptions.Compiled);
        #endregion


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
            string res = "";
            if (Operator == null)
            {
                res = baseItem;
            }
            else if (Operator is NegativeOperators)//унарный оператор
            {
                res = Operator.Symbols.First() + First.ToString();
            }
            else//бинарный оператор
            {
                //тут обязательны скобки, это для удовлетворения аксиомам формул
                res = $"({First.ToString()}{Operator.Symbols.First()}{Second.ToString()})";
            }

            return res;
        }
    }
}
