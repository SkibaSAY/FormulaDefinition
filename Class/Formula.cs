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
    public class Formula:ICloneable
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
        public Formula(Formula first, OperatorBase operatoR, Formula second = null,string baseItem = null)
        {
            if (first == null && second == null && baseItem == null) throw new ArgumentException();
            if (first != null && operatoR is NegativeOperators)
            {
                //топим импликацию, чтобы избежать случае ¬¬С вместо C
                if (first.Operator is NegativeOperators)
                {
                    First = first.First.First;
                    Operator = first.First.Operator;
                    Second = first.First.Second;
                    baseItem = first.First.baseItem;
                }
                else
                {
                    Operator = operatoR;
                    First = first;
                }
            }
            else if (first != null && second != null && !(operatoR is NegativeOperators))
            {
                Operator = operatoR;
                First = first;
                Second = second;
            }


            this.baseItem = baseItem;
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
                {
                    Operator = new NegativeOperators();
                    First = new Formula(first);
                }
                else
                {
                    baseItem = first;
                }
            }
        }
        #endregion

        /// <summary>
        /// Построить Дизьюнктивную нормальную форму(дизьюнкцию элементарных коньюнкций)
        /// </summary>
        /// <returns></returns>
        public Formula DNF()
        {
            var dnfFormul = (Formula)this.Clone();
            dnfFormul.WithoutInplication();
            dnfFormul.СloseNegatives();

            dnfFormul.BuildDNF(null);

            return dnfFormul;
        }

        /// <summary>
        /// Рекурсивный компонент преобразования в DNF
        /// </summary>
        private bool BuildDNF(Formula parentFormula)
        {
            var stopFlag = false;
            do
            {
                if (Operator is AndOperators)
                {
                    var weDoChange = true;
                    //((A∨B)∧(C∨D))
                    if (First.Operator is OrOperators && Second.Operator is OrOperators)
                    {
                        //внуки
                        var A = First.First;
                        var B = First.Second;
                        var C = Second.First;
                        var D = Second.Second;

                        //перегруппировка внуков
                        var grandSon1 = new Formula(A, new AndOperators(), C);
                        var grandSon2 = new Formula(A, new AndOperators(), D);
                        var grandSon3 = new Formula(B, new AndOperators(), C);
                        var grandSon4 = new Formula(B, new AndOperators(), D);

                        Operator = new OrOperators();
                        First = new Formula(grandSon1, new OrOperators(), grandSon2);
                        Second = new Formula(grandSon3, new OrOperators(), grandSon4);
                    }
                    //((A∨B)∧(C))
                    else if (First.Operator is OrOperators)
                    {
                        var A = First.First;
                        var B = First.Second;
                        var C = Second;

                        Operator = new OrOperators();
                        First = new Formula(A, new AndOperators(), C);
                        Second = new Formula(B, new AndOperators(), C);
                    }
                    //((A)∧(B∨C)) равносильно ((A∧B)∨(A∧C)) по дистрибутивности
                    else if (Second.Operator is OrOperators)
                    {

                        var A = First;
                        var B = Second.First;
                        var C = Second.Second;

                        Operator = new OrOperators();
                        First = new Formula(A, new AndOperators(), B);
                        Second = new Formula(A, new AndOperators(), C);
                    }
                    else
                    {
                        //(..)∧(..) тут уже отдельные переменные, ничего не меняем 
                        weDoChange = false;
                    }

                    //поднимаемся наверх, чтобы всё, что сверху уже было подготовлено
                    if (parentFormula != null && parentFormula.Operator is AndOperators && weDoChange)
                    {
                        //надо проворачивать тот же трюк на уровень выше
                        return false; //показывает, что нужен повтор на уровне выше
                    }
                }



                if (Operator is NegativeOperators || Operator == null)
                {
                    //тк заранее привели к виду тесных отрицаний, отрицания и пустой оператор указывают на то,
                    //что дальше уже переменная, значит подтверждение не нужно
                    stopFlag = true;
                }
                else
                {
                    //если нижние уровни подтвердили, что повтор им не нужен
                    stopFlag = First.BuildDNF(this) && Second.BuildDNF(this);
                }
                
            } while (!stopFlag);

            //подтверждаем на верх, что у нас всё в порядке
            return true;
        }

        /// <summary>
        /// Построить Коньюнктивную нормальную форму(Коньюнкция нормальных дизьюнкций)
        /// </summary>
        /// <returns></returns>
        public Formula KNF()
        {
            var knfFormul = (Formula)this.Clone();
            knfFormul.WithoutInplication();
            knfFormul.СloseNegatives();

            knfFormul.BuildKNF(null);

            return knfFormul;
        }
        private bool BuildKNF(Formula parentFormula)
        {
            var stopFlag = false;
            do
            {
                if (Operator is OrOperators)
                {
                    var weDoChange = true;
                    //((A∧B)∨(C∧D))
                    if (First.Operator is AndOperators && Second.Operator is AndOperators)
                    {
                        //внуки
                        var A = First.First;
                        var B = First.Second;
                        var C = Second.First;
                        var D = Second.Second;

                        //перегруппировка внуков
                        var grandSon1 = new Formula(A, new OrOperators(), C);
                        var grandSon2 = new Formula(A, new OrOperators(), D);
                        var grandSon3 = new Formula(B, new OrOperators(), C);
                        var grandSon4 = new Formula(B, new OrOperators(), D);

                        Operator = new AndOperators();
                        First = new Formula(grandSon1, new AndOperators(), grandSon2);
                        Second = new Formula(grandSon3, new AndOperators(), grandSon4);
                    }
                    //((A∧B)∨(C))
                    else if (First.Operator is AndOperators)
                    {
                        var A = First.First;
                        var B = First.Second;
                        var C = Second;

                        Operator = new AndOperators();
                        First = new Formula(A, new OrOperators(), C);
                        Second = new Formula(B, new OrOperators(), C);
                    }
                    //((A)∨(B∧C)) равносильно ((A∨B)∧(A∨C)) по дистрибутивности
                    else if (Second.Operator is AndOperators)
                    {

                        var A = First;
                        var B = Second.First;
                        var C = Second.Second;

                        Operator = new OrOperators();
                        First = new Formula(A, new OrOperators(), B);
                        Second = new Formula(A, new OrOperators(), C);
                    }
                    else
                    {
                        //(..)∨(..) тут уже отдельные переменные, ничего не меняем 
                        weDoChange = false;
                    }

                    //поднимаемся наверх, чтобы всё, что сверху уже было подготовлено
                    if (parentFormula != null && parentFormula.Operator is AndOperators && weDoChange)
                    {
                        //надо проворачивать тот же трюк на уровень выше
                        return false; //показывает, что нужен повтор на уровне выше
                    }
                }



                if (Operator is NegativeOperators || Operator == null)
                {
                    //тк заранее привели к виду тесных отрицаний, отрицания и пустой оператор указывают на то,
                    //что дальше уже переменная, значит подтверждение не нужно
                    stopFlag = true;
                }
                else
                {
                    //если нижние уровни подтвердили, что повтор им не нужен
                    stopFlag = First.BuildKNF(this) && Second.BuildKNF(this);
                }

            } while (!stopFlag);

            //подтверждаем на верх, что у нас всё в порядке
            return true;
        }

        /// <summary>
        /// Приведение к виду формулы с тесными отрицаниями
        /// </summary>
        public void СloseNegatives()
        {
            if (Operator is NegativeOperators)
            {
                if (First.Operator is null)//достигли листа дерева
                {
                    return;
                }
                else if(First.Operator is OrOperators)
                {
                    Operator = new AndOperators();
                    //сначала меняем second тк  иначе First перетирается
                    Second = new Formula(First.Second, new NegativeOperators());
                    First = new Formula(First.First, new NegativeOperators());
                }
                else if (First.Operator is AndOperators)
                {
                    Operator = new OrOperators();
                    First = new Formula(First.First, new NegativeOperators());
                    Second = new Formula(First.Second, new NegativeOperators());
                }
            }
            else if (Operator is ImplicationOperators)
            {
                WithoutInplication();
                СloseNegatives();
            }

            if (First != null) First.СloseNegatives();
            if (Second != null) Second.СloseNegatives();
        }

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
            }
            First.WithoutInplication();
            if(Second != null)
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

            resultFormula = resultFormula.RecurseSubstitution(dictFormuls,true);
            #endregion

            return resultFormula;
        }

        /// <summary>
        /// Метод обхода для замены обозначений на дочерние формулы 
        /// </summary>
        /// <param name="formulDict"></param>
        /// /// <param name="isUsingForSubstitution">использовать ли замену в подстановках</param>
        /// <returns></returns>
        public Formula RecurseSubstitution(Dictionary<string, Formula> formulDict, bool isUsingForSubstitution = false)
        {
            var result = (Formula)this.Clone();
            result = result.RecurseSubstitutionPrivate(formulDict, isUsingForSubstitution);
            return result;
        }
        /// <summary>
        /// Приватный Метод обхода для замены обозначений на дочерние формулы 
        /// !!!Он меняет исходную формулу, поэтому 
        /// в публичном RecurseSubstitution используется клонирование
        /// </summary>
        /// <param name="formulDict"></param>
        /// /// <param name="isUsingForSubstitution">использовать ли замену в подстановках</param>
        /// <returns></returns>
        private Formula RecurseSubstitutionPrivate(Dictionary<string,Formula> formulDict,bool isUsingForSubstitution=false)
        {
            if (First != null)
            {
                First = First.RecurseSubstitutionPrivate(formulDict, isUsingForSubstitution);
            }
            else if (formulDict.ContainsKey(baseItem))
            {
                if (isUsingForSubstitution)
                {
                    First = formulDict[baseItem].RecurseSubstitutionPrivate(formulDict, isUsingForSubstitution);
                }
                else
                {
                    First = formulDict[baseItem];
                }
                //formulDict.Remove(baseItem);
                baseItem = null;
            }

            if (Second != null)
            {
                Second = Second.RecurseSubstitutionPrivate(formulDict, isUsingForSubstitution);
            }

            //удаляем промежуточное звено
            if (First != null && Operator == null && Second == null) return First;
            return this;
        }

        /// <summary>
        /// Проверяет, что формула получена из родительской некоторой подстановкой
        /// </summary>
        /// <param name="parentFormul"></param>
        /// <returns>
        /// Список подстановок, если формула получена из родительской подстановкой.
        /// null ,если иначе
        /// </returns>
        public Dictionary<string,Formula> IsDerivedFrom(Formula parentFormul)
        {
            var substitution = new Dictionary<string, Formula>();
            IsDerivedFromRecurseParent(parentFormul, ref substitution);
            return substitution;
        }
        /// <summary>
        /// рекурсивный обход для проверки , что формула получена из родительской некоторой подстановкой
        /// </summary>
        /// <param name="parentFormul"></param>
        /// <param name="substitution"></param>
        private void IsDerivedFromRecurseParent(Formula parentFormul, ref Dictionary<string, Formula> substitution)
        {
            if (substitution == null) return;

            //parrent: !A  child: !B  => A = B
            if(parentFormul.Operator is NegativeOperators && this.Operator is NegativeOperators)
            {
                First.IsDerivedFromRecurseParent(parentFormul.First, ref substitution);
            }
            //parrent: !A  child: B => A = !B
            else if (parentFormul.Operator is NegativeOperators)
            {
                var newChild = new Formula(this, new NegativeOperators());
                newChild.IsDerivedFromRecurseParent(parentFormul.First, ref substitution);
            }

            //parrent: (A→B) child: (B→C)  →равны, поэтому продолжаем дальше раскручивать формулу
            else if (parentFormul.Operator != null && this.Operator!=null && parentFormul.Operator.GetType() == this.Operator.GetType())
            {
                First.IsDerivedFromRecurseParent(parentFormul.First, ref substitution);
                Second.IsDerivedFromRecurseParent(parentFormul.Second, ref substitution);
            }

            //дошли до пропозициональной переменной
            else if(parentFormul.Operator == null)
            {
                if (substitution.ContainsKey(parentFormul.baseItem) && substitution[parentFormul.baseItem].ToString().Equals(this.ToString()))
                {
                    //ничего не делаем, всё в порядке
                }
                //не содержится - добавляем
                else if (!substitution.ContainsKey(parentFormul.baseItem))
                {
                    substitution.Add(parentFormul.baseItem, this);
                }
                //подстановки в пропозициональную переменную не совпадают - значит всё не подстановка
                else
                {
                    substitution = null;
                }
            }
            //вышли за случаи, например: parrent: (A→B)
            //child: C
            //или child: !C
            //или child: (B∨C) 
            else
            {
                substitution = null;
            }
        }

        /// <summary>
        /// Проверка, что формула получена хотя бы из одной из переданных формул 
        /// </summary>
        /// <param name="axioms"></param>
        /// <returns></returns>
        public bool IsAxiom(List<Formula> axioms)
        {
            var equalAxiom = GetEqualAxiom(axioms);
            if (equalAxiom != null) return true;
            return false;
        }
        public Formula GetEqualAxiom(List<Formula> axioms)
        {
            Formula equalAxiom = null;

            foreach (var axiom in axioms)
            {
                var substitution = IsDerivedFrom(axiom);
                //из какой-то аксиомы удалось получить нашу формулу некоторой подстановкой
                if (substitution != null)
                {
                    equalAxiom = axiom;
                    break;
                }
            }

            return equalAxiom;
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

        public object Clone()
        {
            var clone = new Formula(First, Operator, Second,baseItem);

            clone.First = clone.First != null ? (Formula)clone.First.Clone() : null;
            clone.Second = clone.Second != null ? (Formula)clone.Second.Clone() : null;
            clone.Operator = Operator;
            clone.baseItem = clone.baseItem!=null?(string)baseItem.Clone():null;
            return clone;
        }

        /// <summary>
        /// Возвращает все пропозициональные переменные формулы
        /// </summary>
        /// <returns></returns>
        public HashSet<string> GetPropozVariables()
        {
            var propozParamsList = new HashSet<string>();
            GetPropozVariablesRecurse(propozParamsList);
            return propozParamsList;
        }

        /// <summary>
        /// Рекурсивный обход для определения всех пропозициональных переменных
        /// </summary>
        /// <param name="propozVariables"></param>
        private void GetPropozVariablesRecurse(HashSet<string> propozVariables)
        {
            if (baseItem == null)
            {
                this.First.GetPropozVariablesRecurse(propozVariables);
                if(this.Second!=null)
                    this.Second.GetPropozVariablesRecurse(propozVariables);
            }
            else propozVariables.Add(baseItem);
        }

        /// <summary>
        /// Возращает таблицу истинности
        /// </summary>
        /// <param name="propozVariables"></param>
        /// <returns></returns>
        public bool[,] GetTruthTable(IEnumerable<string> propozVariables)
        {
            var variables = propozVariables.ToList();
            var rowsCount = (int)Math.Pow(2, variables.Count);
            var columsCount = variables.Count;

            var table = new bool[rowsCount, columsCount+1];

            //инициализация Интерпретаций
            var propozValues = new Dictionary<string, bool>();
            foreach(var variable in variables)
            {
                propozValues.Add(variable, false);
            }

            for (int i = 0; i < rowsCount; i++)
            {             
                var curNum = i;
                var devidedCount = 1;
                while (curNum != 0)
                {
                    var residue = curNum % 2;

                    var columnNum = columsCount - devidedCount;

                    //заполняем словарь для последующего вычисления
                    var key = variables[columnNum];

                    var logicResidue = residue == 1 ? true : false;
                    propozValues[key] = logicResidue;

                    //заполняем таблицу
                    table[i, columnNum] = logicResidue;

                    curNum /= 2;
                    devidedCount++;
                }
                table[i, columsCount] = ComputeValueByVariables(propozValues);
            }
            return table;
        }

        /// <summary>
        /// Вычисление значения формулы по заданным значениям пропозициональных переменных
        /// </summary>
        /// <param name="propozeValues"></param>
        /// <returns></returns>
        public bool ComputeValueByVariables(Dictionary<string, bool> variables)
        {
            if (baseItem != null) return variables[baseItem];
            else if (Second != null)
            {
                return Operator.ComputeValue
                (
                    First.ComputeValueByVariables(variables),
                    Second.ComputeValueByVariables(variables)
                );
            }
            else
                return Operator.ComputeValue(
                    First.ComputeValueByVariables(variables)
                    );
        }

        /// <summary>
        /// Эквивалентность формул
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Formula)) return false;
            var secondFormula = obj as Formula;

            //получения всех пропозициональных переменных
            var propozVariablesHash = GetPropozVariables();
            propozVariablesHash.UnionWith(secondFormula.GetPropozVariables());

            var propozVariables = propozVariablesHash.ToList();

            //получили таблицы истинности
            var thisTable = GetTruthTable(propozVariables);
            var secondFormulaTable = secondFormula.GetTruthTable(propozVariables);

            //проверяем значения в таблице истинности
            var columsCount = (propozVariables.Count + 1);
            var rowsCount = thisTable.Length / columsCount;
            for (int i = 0; i < rowsCount; i++)
            {
                if (thisTable[i, columsCount - 1] != secondFormulaTable[i, columsCount - 1]) return false;
            }

            return true;
        }

    }
}
